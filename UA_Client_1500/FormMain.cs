/**********************************************************************************************************************
 * Namespace: UA_Client_1500                                                                                         *
 * Class    :                                                                                       *
 *                                                                                                                    *
 * written by Khalid Riadi                                                                                            *
 * copyright                                                                                                          *
 * Magnet  Physik                                                                                                     *  
 * History:                                                                                                           *
 * xx (2020-12-02,KR):  version                                                                                       *
 *                                                                                                                    *  
 * Kurzbeschreibung:                                                                                                  *  
 * -   Dauertest Bedienung  
 * -   Messwerte auslesen                                                                                             *                          
 * -   Messwerte visualisieren                                                                    
 * -   Messdaten in csv speichern   
 * -   IM mit einem vorgegebenen Takt starten
 **********************************************************************************************************************/





using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//using SimaticNET.OPC.OpcDaClient;
//using ZedGraph;
using System.Security.Permissions;
using System.Timers;
using System.IO;
using Siemens.UAClientHelper;
using Opc.Ua;
using Opc.Ua.Client;
using System.Security.Cryptography.X509Certificates;


namespace UA_Client_1500
{
    public partial class FormMain : Form
    {
        #region opc ua fields
        private UAClientHelperAPI myClientHelperAPI;
        private EndpointDescription mySelectedEndpoint;
        private Session mySession;
        private ReferenceDescriptionCollection myReferenceDescriptionCollection;
        private UAClientCertForm myCertForm;
        private Subscription mySubscription;
        private MonitoredItem myMonitoredItem;
        private Int16 itemCount;
        #endregion

        #region old fields
        //public DaServerMgt _OPC_Server;
        public bool OPCServerIsConnected;
        private Thread Aufzeichnen;
        private Thread TempUeberwachen;
        public bool Pause;
        public bool Continue;
        public bool Running;
        private int anzImp = 0;

        private int count = 0;
        //private ReturnCode _READFEHLERMELDUNG;
        //private bool ConnIsOK = true;
        //private bool Pause;

        //OPC_Read reader_dta = new OPC_Read();
        //OPC_Write writer_dta = new OPC_Write();
        //writer_dta.Dispose();
        //PP: Instanzierung der Objekte
        Data_Visualization Visualisierung = new Data_Visualization();
        Data_Import_Export ImportExport = new Data_Import_Export();
        Temp_Analyse temp = new Temp_Analyse();
        //PP: Instanzierung der Objekte

        private System.Timers.Timer TaktTimer;

        // Temp Überwachung
        private bool TempUeberschritten;
        // Aufnahmeinterval
        private int AufnahmeRate;
        // Taktzeit berechnet
        private DateTime DT_TaktBerechnet;
        private double taktErr; 
        #endregion

        public FormMain()
        {            
            InitializeComponent();

            #region connect to opc ua server

            myClientHelperAPI = new UAClientHelperAPI();
            //.....................................................
            // 1. Endpoint
            //.....................................................
            mySelectedEndpoint = new EndpointDescription();

            //string discoveryUrl = "opc.tcp://mps-nb025-win10:62640/IntegrationObjects/ServerSimulator";
            string discoveryUrl = "opc.tcp://mps-nb025-win10:62640";
            //string discoveryUrl = "opc.tcp://172.16.1.17:4840";
            ApplicationDescriptionCollection servers = myClientHelperAPI.FindServers(discoveryUrl);
            EndpointDescriptionCollection endpoints = myClientHelperAPI.GetEndpoints(discoveryUrl);
            mySelectedEndpoint = endpoints[0];
            //.....................................................
            //2. connect
            //.....................................................
            //Register mandatory events (cert and keep alive)
            myClientHelperAPI.KeepAliveNotification += new KeepAliveEventHandler(Notification_KeepAlive);
            myClientHelperAPI.CertificateValidationNotification += new CertificateValidationEventHandler(Notification_ServerCertificate);
            myClientHelperAPI.Connect(endpoints[0], false, "User name", "Password").Wait();
            //.....................................................
            //2.1 Knoten voneinander lösen
            //.....................................................
            myReferenceDescriptionCollection = myClientHelperAPI.BrowseRoot();
            TreeView treeview = new TreeView();
            foreach (ReferenceDescription refDesc in myReferenceDescriptionCollection)
            {
                treeview.Nodes.Add(refDesc.DisplayName.ToString()).Tag = refDesc;
                ReferenceDescription a = refDesc;
                string refDescName = refDesc.DisplayName.ToString();
                foreach (TreeNode node in treeview.Nodes)
                {
                    node.Nodes.Add("");
                }
            }
            //.....................................................
            //2.2  Read Node
            //.....................................................

            double temp = ReadTempNode(Containerklasse.NODE_Id_RaumTemp);

            string IMStat = ReadIMStatBitNode(Containerklasse.NODE_Id_STATUS);


            //.....................................................
            //3. session
            //.....................................................
            //Extract the session object for further direct session interactions
            mySession = myClientHelperAPI.Session;
            //.....................................................
            //4. Browse mySession
            //.....................................................
            
            #endregion

            #region Init GUI/IM

            AufnahmeRate = 10;


            // initialisieren
            ResetImpulsCounter();
            //          
            Containerklasse.Czahl = 0;
            // 
            Containerklasse.TESTGESTARTET = false;
            //
            btn_StopTest.Enabled = false;
            btn_Fortsetzen.Enabled = false;
            btn_Pause.Enabled = false;
            btn_TempQuit.Enabled = false;
            dateiToolStripMenuItem.Enabled = true; //DG, 24.02.21
            // IM Status ständig visualisieren
            timer2.Start();

            Testobjekt.SelectedItem = "IM";
            //Datum auf Gui anzeigen
            DateTime datum = DateTime.Now;
            Datumslabel.Text = datum.ToString("d"); ;
            Containerklasse.DurchnittTaktzeit = "00,00"; 
            #endregion
        }

        #region connect-functions opc ua
        // OpcEventHandlers
        private void Notification_ServerCertificate(CertificateValidator cert, CertificateValidationEventArgs e)
        {
            //Handle certificate here
            //To accept a certificate manually move it to the root folder (Start > mmc.exe > add snap-in > certificates)
            //Or handle via UAClientCertForm

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CertificateValidationEventHandler(Notification_ServerCertificate), cert, e);
                return;
            }

            try
            {
                //Search for the server's certificate in store; if found -> accept
                X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509CertificateCollection certCol = store.Certificates.Find(X509FindType.FindByThumbprint, e.Certificate.Thumbprint, true);
                store.Close();
                if (certCol.Capacity > 0)
                {
                    e.Accept = true;
                }

                //Show cert dialog if cert hasn't been accepted yet
                else
                {
                    if (!e.Accept & myCertForm == null)
                    {
                        myCertForm = new UAClientCertForm(e);
                        myCertForm.ShowDialog();
                    }
                }
            }
            catch
            {
                ;
            }
        }
        private void Notification_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new KeepAliveEventHandler(Notification_KeepAlive), sender, e);
                return;
            }

            try
            {
                // check for events from discarded sessions.
                if (!Object.ReferenceEquals(sender, mySession))
                {
                    return;
                }

                // check for disconnected session.
                if (!ServiceResult.IsGood(e.Status))
                {
                    // try reconnecting using the existing session state
                    mySession.Reconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                //ResetUI();
            }
        }    
        
        public void Verbinden()
        {          
            if (true)
            {
                lbl_ConnectInfo.Text = "Profinet verbunden";
                lbl_ConnectInfo.BackColor = System.Drawing.Color.Green;
                lbl_ConnectInfo.ForeColor = System.Drawing.Color.White;
                //Statusbox.Text = Visualisierung.StatusGUI(1);
            }
            else
            {
                lbl_ConnectInfo.Text = "Profinet nicht verbunden!";
                lbl_ConnectInfo.BackColor = System.Drawing.Color.Red;
                lbl_ConnectInfo.ForeColor = System.Drawing.Color.White;
                Statusbox.Text = Visualisierung.StatusGUI(0);
            }

        }

        private void SubscribeBtn(object sender, EventArgs e)
        {
            //this example only supports one item per subscription; remove the following IF loop to add more items
            if (myMonitoredItem != null && mySubscription != null)
            {
                try
                {
                    myMonitoredItem = myClientHelperAPI.RemoveMonitoredItem(mySubscription, myMonitoredItem);
                }
                catch
                {
                    //ignore
                    ;
                }
            }

            try
            {
                //use different item names for correct assignment at the notificatino event
                itemCount++;
                string monitoredItemName = "myItem" + itemCount.ToString();
                if (mySubscription == null)
                {
                    mySubscription = myClientHelperAPI.Subscribe(1000);
                }
                //myMonitoredItem = myClientHelperAPI.AddMonitoredItem(mySubscription, subscriptionIdTextBox.Text, monitoredItemName, 1);
                //myClientHelperAPI.ItemChangedNotification += new MonitoredItemNotificationEventHandler(Notification_MonitoredItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        #endregion

        #region UserInteraktion
        #region GUI Butons
        private void btn_Close_Click(object sender, EventArgs e)
        {
            #region IM ausschalten
            // IM AUS
            WriteByteNode(Containerklasse.NODE_Id_IM_ON, "false"); Thread.Sleep(500);
            // COUNTER IMPULSE RESETEN
            ResetImpulsCounter();
            #endregion

            #region session disconnect
            if (mySession != null && !mySession.Disposed)
            {
                try
                {
                    mySubscription.Delete(true);
                }
                catch
                {
                    ;
                }

                myClientHelperAPI.Disconnect();
                mySession = myClientHelperAPI.Session;

                //ResetUI();
            } 
            #endregion

            #region watezeit ohne GUI blickieren;)
            Containerklasse.AufnahmeTaktzeitBeendet = false;
            SetTimer(5000);//starten
            do
            {
                Datumslabel.Text = "Programm wird geschlossen";
            } while (!Containerklasse.AufnahmeTaktzeitBeendet);

            if (TaktTimer.Enabled)
            {
                TaktTimer.Stop();
            }
            #endregion

            if (Containerklasse.TESTGESTARTET)
            {
                Console.WriteLine("zeile 152: test läuft noch");
            }
            ImportExport.CloseCSV();

            #region Treads
            if (Aufzeichnen.IsAlive)
            {
                this.Aufzeichnen.Abort();
                Console.WriteLine("Zeichnen.Abort()");
            }
            if (TempUeberwachen.IsAlive)
            {
                this.TempUeberwachen.Abort();
                Console.WriteLine("TempUeberwachen.Abort()");
            } 
            #endregion

            #region Timer
            if (timer1.Enabled)
            {
                timer1.Stop();
                timer1.Dispose();
                Console.WriteLine("timer1.Stop()");
            }

            if (timer2.Enabled)
            {
                timer2.Stop();
                timer2.Dispose();
                Console.WriteLine("timer2.Stop()");
            }

            if (timer3.Enabled)
            {
                timer3.Stop();
                timer3.Dispose();
                Console.WriteLine("timer3.Stop()");
            }

            if (timer4.Enabled)
            {
                timer4.Stop();
                timer4.Dispose();
                Console.WriteLine("timer4.Stop()");
            } 
            #endregion

            #region GUI schließen
            lbl_ConnectInfo.Text = "Profinet wird getrennt";
            lbl_ConnectInfo.BackColor = System.Drawing.Color.Red;
            lbl_ConnectInfo.ForeColor = System.Drawing.Color.White;


            // 
            Thread.Sleep(3000);
            Close(); 
            #endregion
        }
        private void btn_StartTest_Click(object sender, EventArgs e)
        {
            DT_TaktBerechnet = DateTime.Now;
            taktErr = 0;
            // Prozessstartwerte werden in der Containerklasse zwischengespeichert 
            #region ProzessStartwerte
            Containerklasse.BisherigeTestDauer = 0;
            Containerklasse.DatumDesTests = DateTime.Now; ; //_dt = DateTime.Now;
            Containerklasse.TESTGESTARTET = true;
            if (Taktzeitvorgabe.Text.Contains("."))
            {
                Taktzeitvorgabe.Text = Taktzeitvorgabe.Text.Replace(".", ",");
                MessageBox.Show("Taktzeiteingabe fehlerhaft - Zeit mit Punkt statt Komma eingegeben. Automatische Umwandlung der Zeiteingabe in Kommazahl und anschließender Start des Dauertests.");
                Containerklasse.TAKT = 1000 * Convert.ToDouble(Taktzeitvorgabe.Text);
            }
            else
            {
                Containerklasse.TAKT = 1000 * Convert.ToDouble(Taktzeitvorgabe.Text);
            };

            //Containerklasse.TAKT = 1000 * Convert.ToDouble(Taktzeitvorgabe.Text); //23.03.2021, Version 02j, Oben in die IF-Abfrage eingesetzt (DG)
            #endregion
            // Prozessstatus beim starten
            #region ProzessStatus
            ResetImpulsCounter();
            AnzahlImpulseSchreiben();
            Running = true;
            btn_IM_ON.Enabled = false;
            btn_IM_OFF.Enabled = false;
            btn_StartTest.Enabled = false;
            btn_Fortsetzen.Enabled = false;
            btn_StopTest.Enabled = true;
            btn_Pause.Enabled = true;
            btn_Close.Enabled = false;
            panel_testinfos.Enabled = false; //Hinzugefügt 15.12.2020, DG - Sperren der Eingabefelder nach Teststart
            panel_vorgabepar.Enabled = false; //Hinzugefügt 15.12.2020, DG - Freigeben der Eingabefelder nach Teststart
            dateiToolStripMenuItem.Enabled = false;
            #endregion
            //"Prozessabbild" - Fixieren der GUI-Werte
            #region Prozessabbild
            //PP: "Prozessabbild" - Fixieren der GUI-Werte
            object[][] GUIvalues = {
                            new object []
                            {
                                Projektnummer.Text,
                                PVpv.Text, BA.Text,
                                bearbeiter.Text,
                                IM_AName.Text,
                                MF_AN.Text,
                                MF_SN.Text,
                                MF_AName.Text,
                                IM_AN.Text,
                                IM_SN.Text,
                                U_IM.Text,
                                I_MAG.Text,
                                energie.Text,
                                P_Dauer.Text,
                                kuhlungsart.Text,
                                sonstBemerkungen.Text,
                                Taktzeitvorgabe.Text,
                                Testzeitvorgabe.Text,
                                RG_Kühlung.Checked.ToString(),
                                Druckluft_Kuhlung.Checked.ToString(),
                                T1_Name.Text,
                                T1_MAX.Text,
                                T2_Name.Text,
                                T2_MAX.Text,
                                T3_Name.Text,
                                T3_MAX.Text,
                                T4_checkBox.Checked.ToString(),
                                T4_Name.Text,
                                T4_MAX.Text,
                                T5_checkBox.Checked.ToString(),
                                T5_Name.Text,
                                T5_MAX.Text,
                                T6_checkBox.Checked.ToString(),
                                T6_Name.Text,
                                T6_MAX.Text,
                                T7_checkBox.Checked.ToString(),
                                T7_Name.Text,
                                T7_MAX.Text,
                                T8_checkBox.Checked.ToString(),
                                T8_Name.Text,
                                T8_MAX.Text,
                                IMon_Override.Checked.ToString(),
                                Testobjekt.Text
                            }
            };

            ImportExport.FixGUIvalues(GUIvalues);

            //ImportExport.CheckGUIInput(); 
            #endregion
            // Daten für PDF-datei werden in der Containerklasse zwischengespeichert 
            #region PDF-datei
            Containerklasse.pdfDatum = DateTime.Now.ToString("d");

            Containerklasse.pdfTestobjekt = Testobjekt.Text;
            Containerklasse.pdfProjektNr = Projektnummer.Text;
            Containerklasse.pdfPVpv = PVpv.Text;
            Containerklasse.pdfBetriebsauftrag = BA.Text;
            Containerklasse.pdfBearbeiter = bearbeiter.Text;
            Containerklasse.pdfIMArtikelNr = IM_AN.Text;
            Containerklasse.pdfIMSerienNr = IM_SN.Text;
            Containerklasse.pdfMFArtikelNr = MF_AN.Text;
            Containerklasse.pdfMFSerienNr = MF_SN.Text;
            Containerklasse.pdfSpannung = U_IM.Text;
            Containerklasse.pdfMagnetiStrom = I_MAG.Text;
            Containerklasse.pdfEnergie = energie.Text;
            Containerklasse.pdfDauerleistung = P_Dauer.Text;
            Containerklasse.pdfKuehlung = kuhlungsart.Text;
            Containerklasse.pdfBemerkung = sonstBemerkungen.Text;
            Containerklasse.pdfTaktzeit = Taktzeitvorgabe.Text;
            Containerklasse.pdfTestdauer = Testdauerlabel.Text;
            Containerklasse.pdfT1Name = T1_Name.Text;
            Containerklasse.pdfT2Name = T2_Name.Text;
            Containerklasse.pdfT3Name = T3_Name.Text;
            Containerklasse.pdfT4Name = T4_Name.Text;
            Containerklasse.pdfT5Name = T5_Name.Text;
            Containerklasse.pdfT6Name = T6_Name.Text;
            Containerklasse.pdfT7Name = T7_Name.Text;
            Containerklasse.pdfT8Name = T8_Name.Text;


            //Containerklasse.pdfTaktzeitErr = Testobjekt.Text;// muss noch!
            #endregion
            // Max Temp-Werte werden in der Containerklasse zwischengespeichert
            #region Temp
            Containerklasse.T4_max = Convert.ToDouble(T4_MAX.Text);
            Containerklasse.T5_max = Convert.ToDouble(T5_MAX.Text);
            Containerklasse.T6_max = Convert.ToDouble(T6_MAX.Text);

            Containerklasse.T4_oben_max = Convert.ToDouble(T7_MAX.Text);
            Containerklasse.T5_oben_max = Convert.ToDouble(T8_MAX.Text);

            Containerklasse.RaumTemp_max = Convert.ToDouble(T1_MAX.Text);
            Containerklasse.AbluftTemp_max = Convert.ToDouble(T3_MAX.Text);
            Containerklasse.MFTemp_max = Convert.ToDouble(T2_MAX.Text);

            //PDFCreator.CreateReport_PDF();

            #endregion
            // Thresds zum Aufzeichnen, Impulse zu starten und Tempüberwachen
            #region Threads und Timer
            // --> Thread zum Aufzeichnen 
            this.Aufzeichnen = new Thread(Test);
            Aufzeichnen.SetApartmentState(ApartmentState.STA);
            this.Aufzeichnen.Start();
            // --> Timer um Impulse zu starten
            timer1.Interval = Convert.ToInt32(1000 * Convert.ToDouble(Taktzeitvorgabe.Text)); // 1000 * Convert.ToInt32(Taktzeitvorgabe.Text);
            timer1.Start();

            // --> Tempüberwachen
            //System.Threading.ThreadPool.QueueUserWorkItem(TemperaturUeberwachung);
            this.TempUeberwachen = new Thread(TemperaturUeberwachung);
            TempUeberwachen.SetApartmentState(ApartmentState.STA);
            this.TempUeberwachen.Start();

            timer3.Interval = Convert.ToInt32(Testzeitvorgabe.Text) * 60 * 1000;
            timer3.Start();

            timer4.Start();
            #endregion
        }
        private void btn_StopTest_Click(object sender, EventArgs e)
        {
            if (TempUeberwachen.IsAlive)
            {
                //TempUeberschritten = false;
                this.TempUeberwachen.Abort();
            }
            HupeEinshalten(); HupeAusschalten();
            //Containerklasse.IMSTEUERN = 0; IM soll anbleiben wegen Kühlung, DG, 24.02.2021
            //WriteByteNode(null, null);
            AnzahlImpulseSchreiben();
            ResetImpulsCounter();
            //--------------------------------

            //Testdauer am Ende
            Containerklasse.pdfTestdauer = Testdauerlabel.Text;

            try
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                }
                if (timer2.Enabled)
                {
                    Console.WriteLine("timer2 lebt noch!!!!!!!!!!!!!!! ");
                }
                if (timer3.Enabled)
                {
                    timer3.Stop();
                }
                if (timer4.Enabled)
                {
                    timer4.Stop();
                }
                //if (TaktTimer.Enabled)
                //{
                //    TaktTimer.Stop();
                //}
                if (Aufzeichnen.IsAlive)
                {
                    this.Aufzeichnen.Abort();
                }
            }
            catch (Exception s)
            {
                var ss = s;
                Console.WriteLine("catschNr.1 Zeichnen.Abort(): " + ss);
            }
            try
            {
                if (TempUeberwachen.IsAlive)
                {
                    this.TempUeberwachen.Abort();
                }
            }
            catch (Exception r)
            {
                var rr = r;
                Console.WriteLine("catschNr.2 TempUeberwachen.Abort() : " + rr);
            }
            Containerklasse.Czahl = 0;
            Containerklasse.CanzImp = 0;
            //if (Running)
            //{
            //    TaktTimer.Stop();
            //    TaktTimer.Dispose();
            //}
            Running = false;

            btn_StartTest.Enabled = true;
            btn_StopTest.Enabled = false;
            btn_Fortsetzen.Enabled = false;
            btn_IM_ON.Enabled = true;
            btn_IM_OFF.Enabled = true;
            btn_Pause.Enabled = false;
            btn_Close.Enabled = true;
            panel_testinfos.Enabled = true; //Hinzugefügt 15.12.2020, DG - Freigeben der Eingabefelder nach Teststart
            panel_vorgabepar.Enabled = true; //Hinzugefügt 15.12.2020, DG - Freigeben der Eingabefelder nach Teststart
            dateiToolStripMenuItem.Enabled = true; //DG, 24.02.21

            ImportExport.CloseCSV();

            #region Eingabefelder aktualisieren
            /******************* ES SOLLEN DIE FELDER NICHT MEHR GELÖSCHT WERDEN!!! BEI NEUSTART EINES TESTS SOLL ALLES EINGEGEBEN BLEIBEN!!!! ******************
             * ********************* DG, 24.02.2021 **********************************
            Projektnummer.Text = string.Empty;
            PVpv.Text = string.Empty;
            BA.Text = string.Empty;
            bearbeiter.Text = string.Empty;
            IM_AName.Text = string.Empty;
            MF_AN.Text = string.Empty;
            MF_SN.Text = string.Empty;
            MF_AName.Text = string.Empty;
            IM_AN.Text = string.Empty;
            IM_SN.Text = string.Empty;
            U_IM.Text = string.Empty;
            I_MAG.Text = string.Empty;
            energie.Text = string.Empty;
            P_Dauer.Text = string.Empty;
            kuhlungsart.Text = string.Empty;
            sonstBemerkungen.Text = string.Empty;
            //Taktzeitvorgabe.Text = "30";
            Testzeitvorgabe.Text = "8";
            RG_Kühlung.Checked = false;
            Druckluft_Kuhlung.Checked = false;
            */
            //T1_Name.Text = string.Empty;
            //T1_MAX.Text = string.Empty;
            //T2_Name.Text = string.Empty;
            //T2_MAX.Text = string.Empty;
            //T3_Name.Text = string.Empty;
            //T3_MAX.Text = string.Empty;
            //T4_checkBox.Checked = false;
            //T4_Name.Text = string.Empty;
            //T4_MAX.Text = string.Empty;
            //T5_checkBox.Checked = false;
            //T5_Name.Text = string.Empty;
            //T5_MAX.Text = string.Empty;
            //T6_checkBox.Checked = false;
            //T6_Name.Text = string.Empty;
            //T6_MAX.Text = string.Empty;
            //T7_checkBox.Checked = false;
            //T7_Name.Text = string.Empty;
            //T7_MAX.Text = string.Empty;
            //T8_checkBox.Checked = false;
            //T8_Name.Text = string.Empty;
            //T8_MAX.Text = string.Empty;

            /*Bearbeitet von DG am 24.02.2021*/
            //IMon_Override.Checked = false;   //nicht notwendig
            //Testobjekt.SelectedItem = "IM";
            #endregion


            PDFReportErstellen();
            /* Status Box soll immer abh. vom IM sein bzw. von Fehlern. Dieser Status hier ist unnötig und verhindert, dass anschließend
            ein Test neugestartet werden kann bzw. dann der Status richtig angezeigt wird.
            //Statusbox.Text = Visualisierung.StatusGUI(0);
            //Statusbox.BackColor = Color.Gray;
            */
        }
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            //btn_Pause.Text = "Test Pause"; Text soll sich beim klicken nicht ändern
            timer1.Stop();
            timer4.Stop();
            Pause = true;
            btn_Fortsetzen.Enabled = true;
            btn_Pause.Enabled = false;
        }
        private void btn_Fortsetzen_Click(object sender, EventArgs e)
        {
            //btn_Fortsetzen.Text = "Test Fortsetzen"; Text soll sich beim klicken nicht ändern
            timer1.Start();
            timer4.Start();
            Pause = false;
            btn_Pause.Enabled = true;
            btn_Fortsetzen.Enabled = false;
        }
        private void btn_IM_ON_Click(object sender, EventArgs e)
        {
            WriteByteNode(Containerklasse.NODE_Id_IM_ON, "true");
        }
        private void btn_IM_OFF_Click(object sender, EventArgs e)
        {
            WriteByteNode(Containerklasse.NODE_Id_IM_ON, "false");
        }
        private void btn_TempQuit_Click(object sender, EventArgs e)
        {
            TempUeberschritten = false;
            // ampel rot
            Containerklasse.AMPELHUPE = Berechnungen.ResetBit(Containerklasse.AMPELHUPE, 4);
            // hupen
            Containerklasse.AMPELHUPE = Berechnungen.ResetBit(Containerklasse.AMPELHUPE, 6);
            // convert bytes of ampel and hupe to string
            byte vIn = Containerklasse.AMPELHUPE;
            string ampelhupe = System.Text.Encoding.ASCII.GetString(new[] { vIn });
            // write 
            WriteByteNode(Containerklasse.NODE_Id_AMPELHUPE, ampelhupe);
            // button deaktivieren
            if (pnl_StatusFarbe.BackColor == Color.Red)
            {
                btn_TempQuit.Enabled = false;
            }
        }
        #endregion
        private void savedataMenu_Click(object sender, EventArgs e)
        {
            //Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] buffer = new string[18];
                buffer[0] = Projektnummer.Text;
                buffer[1] = PVpv.Text;
                buffer[2] = BA.Text;
                buffer[3] = bearbeiter.Text;
                buffer[4] = IM_AName.Text;
                buffer[5] = MF_AN.Text;
                buffer[6] = MF_SN.Text;
                buffer[7] = MF_AName.Text;
                buffer[8] = IM_AN.Text;
                buffer[9] = IM_SN.Text;
                buffer[10] = U_IM.Text;
                buffer[11] = I_MAG.Text;
                buffer[12] = energie.Text;
                buffer[13] = P_Dauer.Text;
                buffer[14] = kuhlungsart.Text;
                buffer[15] = sonstBemerkungen.Text;
                buffer[16] = Taktzeitvorgabe.Text;
                buffer[17] = Testzeitvorgabe.Text;
                //buffer[18] = RG_Kühlung.Checked;
                //buffer[19] = Druckluft_Kuhlung.Checked;
                //EVENTUELL NOCH TEMPERATURFELDER HINZUFÜGEN//
                File.WriteAllLines(saveFileDialog1.FileName, buffer, Encoding.UTF8);
            }

        }        
        private void IM_AName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visualisierung.AutoCompletionIM(IM_AName.SelectedIndex);
            IM_AN.Text = Visualisierung.IM_Artikelnummer;
            IM_SN.Text = Visualisierung.IM_Seriennummer;
        }
        private void MF_AName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visualisierung.AutoCompletionMF(MF_AName.SelectedIndex);
            MF_AN.Text = Visualisierung.MF_Artikelnummer;
            MF_SN.Text = Visualisierung.MF_Seriennummer;
        }
        private void opendataMenu_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //Get the path of specified file
                    filePath = openFileDialog.FileName;


                    //StreamReader sr = new StreamReader(filePath);


                    var buffer = File.ReadAllLines(filePath);
                    Projektnummer.Text = buffer[0];
                    PVpv.Text = buffer[1];
                    BA.Text = buffer[2];
                    bearbeiter.Text = buffer[3];
                    IM_AName.Text = buffer[4];
                    MF_AN.Text = buffer[5];
                    MF_SN.Text = buffer[6];
                    MF_AName.Text = buffer[7];
                    IM_AN.Text = buffer[8];
                    IM_SN.Text = buffer[9];
                    U_IM.Text = buffer[10];
                    I_MAG.Text = buffer[11];
                    energie.Text = buffer[12];
                    P_Dauer.Text = buffer[13];
                    kuhlungsart.Text = buffer[14];
                    sonstBemerkungen.Text = buffer[15];
                    Taktzeitvorgabe.Text = buffer[16];
                    Testzeitvorgabe.Text = buffer[17];
                    //buffer[18] = RG_Kühlung.Checked;
                    //buffer[19] = Druckluft_Kuhlung.Checked;
                    //EVENTUELL NOCH TEMPERATURFELDER HINZUFÜGEN//
                }
            }

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }
        private void GraphPic_Click(object sender, EventArgs e)
        {
            // save to a bitmap                   chart1

            Bitmap bmp = new Bitmap(2100, 1500);
            chart1.DrawToBitmap(bmp, new Rectangle(0, 0, 2100, 1500));
            bmp.Save(@"C:\Users\Khalid Riadi\Desktop\Aktuelles\ChartTest.png");




            //Bitmap bmp = new Bitmap(2100, 1500);
            //chart1.DrawToBitmap(bmp, new Rectangle(0, 0, 2100, 1500));
            //bmp.Save(@"C:\Users\Khalid Riadi\Desktop\Aktuelles\HiddenChart2.png"); //C:\Users\Khalid Riadi\Desktop\Aktuelles
        }
        private void Test(object dummy)
        {
            #region Felder
            string[] xval = new string[10000];//Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            string[] dauer_hh_mm = new string[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG

            double[] yval = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] yval1 = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] sinAngle = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG

            double[] yT5 = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] yT6 = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] yT4_oben = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] yT5_oben = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] yRaumTemp = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] yT4 = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] yAbluftTemp = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            double[] yMFTemp = new double[10000]; //Auf 10000 geändert für mehr Puffer - weil Aufnahmerate auf 10 sec. gestellt ist, reichen 1000 nicht aus!!! 15.12.2020, DG
            #endregion


            //PP: Erstellung der .CSV-Datei
            ImportExport.SpeicherortCSV_fest();
            ImportExport.CreateCSVname();
            ImportExport.CreateCSV();
            ImportExport.WriteHeaderCSV();
        //PP: Erstellung der .CSV-Datei

        MeasuringRun:
            if (Pause)
            {
                goto ende;

            }
            do
            {
                // --> abfragen ob die verbindung noch da ist
                if (true)
                {
                    MethodInvoker VerbindungIstGutMeldung = delegate
                    {
                        lbl_ConnectInfo.Text = "Profinet ist Verbunden";
                        lbl_ConnectInfo.BackColor = System.Drawing.Color.Green;
                    };
                    Invoke(VerbindungIstGutMeldung);
                }
                else // --> überspringe alles
                {
                    MethodInvoker VerbindungGetrenntMeldung = delegate
                    {
                        lbl_ConnectInfo.Text = "Profinet nicht Verbunden!";
                        lbl_ConnectInfo.BackColor = System.Drawing.Color.Red;
                    };
                    Invoke(VerbindungGetrenntMeldung);
                    goto ende;
                }
                // auslesen des OPC Servers:


                // Statusbox aktualisieren

                #region array size aktualisieren
                // Felder werden bei jedem durchlauf um 1 element inkrementirt
                string[] xVal = new string[Containerklasse.Czahl];
                double[] yVal = new double[Containerklasse.Czahl];

                double[] yVal_T5 = new double[Containerklasse.Czahl];
                double[] yVal_T6 = new double[Containerklasse.Czahl];
                double[] yVal_T4_oben = new double[Containerklasse.Czahl];
                double[] yVal_T5_oben = new double[Containerklasse.Czahl];
                double[] yVal_Raumtemp = new double[Containerklasse.Czahl];
                double[] yVal_T4 = new double[Containerklasse.Czahl];
                double[] yVal_Abluft = new double[Containerklasse.Czahl];
                double[] yVal_MFTemp = new double[Containerklasse.Czahl];
                #endregion
                /////////////////////////////
                // --> Dies ist sogenannter generischer Delegate,
                // --> innerhalb des Blocks vollen Zugriff auf die
                // --> UI zuläßt
                /////////////////////////////
                MethodInvoker LabelUpdate = delegate
                {
                    // pausieren durch button-Click
                    if (btn_Pause.Text == "Test Pause")
                    {
                        Running = false;
                        // btn_Pause.Text = "Pause";
                    }
                    count = Containerklasse.Czahl;
                    label1.Text = count.ToString() + " Messungen";
                    this.chart1.Invalidate();
                    this.chart1.Series.Clear();

                    //this.chart1.Titles.Add("TEMPERATUREN");

                    #region Visualisierung
                    //Übertragung der GUI-Werte von "Data_Import_Export" zu "Data-Visualization"
                    Visualisierung.T1Name = ImportExport.T1Name;
                    Visualisierung.T2Name = ImportExport.T2Name;
                    Visualisierung.T3Name = ImportExport.T3Name;
                    Visualisierung.T4Name = ImportExport.T4Name;
                    //Console.WriteLine(ImportExport.T4Name);
                    //Console.WriteLine(ImportExport.T4Schaltzustand);
                    //Console.WriteLine(ImportExport.T5Schaltzustand);
                    //Console.WriteLine(ImportExport.T6Schaltzustand);
                    //Console.WriteLine(ImportExport.T7Schaltzustand);
                    //Console.WriteLine(ImportExport.T8Schaltzustand);
                    Visualisierung.T4Schaltzustand = ImportExport.T4Schaltzustand;
                    Visualisierung.T5Name = ImportExport.T5Name;
                    Visualisierung.T5Schaltzustand = ImportExport.T5Schaltzustand;
                    Visualisierung.T6Name = ImportExport.T6Name;
                    Visualisierung.T6Schaltzustand = ImportExport.T6Schaltzustand;
                    Visualisierung.T7Name = ImportExport.T7Name;
                    Visualisierung.T7Schaltzustand = ImportExport.T7Schaltzustand;
                    Visualisierung.T8Name = ImportExport.T8Name;
                    Visualisierung.T8Schaltzustand = ImportExport.T8Schaltzustand;


                    Visualisierung.Diagrammname = chart1;
                    Visualisierung.CreateDatenreihe();

                    // datapoints einbinden
                    //xval[count] = Visualisierung.TestDauerhhmm(count * Containerklasse.TAKT / 1000, 1);
                    xval[count] = Visualisierung.TestDauerhhmm(count * AufnahmeRate, 1);
                    //xval[count] = Convert.ToString(count);
                    yval1[count] = count * 1.0;
                    //Console.WriteLine(count);

                    // --> Temperaturen aufzeichnen                    
                    #region read temps opc ua
                    
                    yT5[count] = ReadTempNode(Containerklasse.NODE_Id_T5);
                    yT6[count] = ReadTempNode(Containerklasse.NODE_Id_T6);
                    yT4_oben[count] = ReadTempNode(Containerklasse.NODE_Id_T4_oben);
                    yT5_oben[count] = ReadTempNode(Containerklasse.NODE_Id_T5_oben);
                    yRaumTemp[count] = ReadTempNode(Containerklasse.NODE_Id_RaumTemp);
                    yT4[count] = ReadTempNode(Containerklasse.NODE_Id_T4);
                    yAbluftTemp[count] = ReadTempNode(Containerklasse.NODE_Id_AbluftTemp);
                    yMFTemp[count] = ReadTempNode(Containerklasse.NODE_Id_MFTemp);  
                    
                    #endregion
                    #region zu visualisierende temp ?

                    if (T1_checkBox.Checked)
                    {
                        lb_T1.Text = Convert.ToString(yRaumTemp[count]);
                        Visualisierung._T1_Schaltzustand = true;
                    }
                    else { Visualisierung._T1_Schaltzustand = false; }
                    if (T2_checkBox.Checked)
                    {
                        lb_T2.Text = Convert.ToString(yMFTemp[count]);
                        Visualisierung._T2_Schaltzustand = true;
                    }
                    else { Visualisierung._T2_Schaltzustand = false; }
                    if (T3_checkBox.Checked)
                    {
                        lb_T3.Text = Convert.ToString(yAbluftTemp[count]);
                        Visualisierung._T3_Schaltzustand = true;
                    }
                    else { Visualisierung._T3_Schaltzustand = false; }
                    if (T4_checkBox.Checked)
                    {
                        lb_T4.Text = Convert.ToString(yT4[count]);
                    }
                    if (T5_checkBox.Checked)
                    {
                        lb_T5.Text = Convert.ToString(yT5[count]);
                    }
                    if (T6_checkBox.Checked)
                    {
                        lb_T6.Text = Convert.ToString(yT6[count]);
                    }
                    if (T7_checkBox.Checked)
                    {
                        lb_T7.Text = Convert.ToString(yT4_oben[count]);
                    }
                    if (T8_checkBox.Checked)
                    {
                        lb_T8.Text = Convert.ToString(yT5_oben[count]);
                    }

                    #endregion
                    object[][] values = {
                        new object [] {
                            Visualisierung.TestDauerBerechnen(count*AufnahmeRate, 1),
                            yRaumTemp[count].ToString(),
                            yMFTemp[count].ToString(),
                            yAbluftTemp[count].ToString(),
                            yT4[count].ToString(),
                            yT5[count] .ToString(),
                            yT6[count] .ToString(),
                            yT4_oben[count].ToString(),
                            yT5_oben[count].ToString()
                            }
                    };
                    ImportExport.Messwerte2CSV = values;
                    

                    //PP: Berechnung der Zeitbasis für die Datenvisualisierung
                    Visualisierung.Abtastintervall_Temperatur = AufnahmeRate; //Als Variable in GUI einpflegen
                    Visualisierung.Anzahl_Messungen_Temperatur = count;
                    //dauer_hh_mm[count] = Visualisierung.gesamtdauer_hh_mm(count);

                    // --> arrays zum plotten aktualisieren
                    for (int i = 0; i < count; i++)
                    {
                        xVal[i] = xval[i];

                        yVal[i] = sinAngle[i];

                        yVal_T5[i] = yT5[i];
                        yVal_T6[i] = yT6[i];
                        yVal_T4_oben[i] = yT4_oben[i];
                        yVal_T5_oben[i] = yT5_oben[i];
                        yVal_Raumtemp[i] = yRaumTemp[i];
                        yVal_T4[i] = yT4[i];
                        yVal_Abluft[i] = yAbluftTemp[i];
                        yVal_MFTemp[i] = yMFTemp[i];
                    }

                    //Visualisierung Temperaturwerte im Container zwischenspeichern
                    Containerklasse._Zeit = xVal;
                    Containerklasse._T1_Wert = yVal_Raumtemp;
                    Containerklasse._T2_Wert = yVal_MFTemp;
                    Containerklasse._T3_Wert = yVal_Abluft;
                    Containerklasse._T4_Wert = yVal_T4;
                    Containerklasse._T5_Wert = yVal_T5;
                    Containerklasse._T6_Wert = yVal_T6;
                    Containerklasse._T7_Wert = yVal_T4_oben;
                    Containerklasse._T8_Wert = yVal_T5_oben;
                    // X-Achse aktualisieren/anpassen
                    Visualisierung.xAchseAktualisieren(count);
                    //Visualisierung.Datenpunkte
                    Visualisierung.BefüllungDatenreihen();
                    //Visualisierung.Achsenskalierung
                    Visualisierung.count = count;
                    //Visualisierung.Update()
                    Visualisierung.AktualisierungDatenreihen();

                    Datumslabel.Text = Visualisierung.DatumGUI();
                    //Testdauerlabel.Text = Visualisierung.TestDauerBerechnen(count * AufnahmeRate, 1);
                    #endregion

                    //PP: Dieses Objekt wird genutzt, um die Messwerte an die ImportExport-Klasse zu übergeben
                    //{Zeitbasis, T1, T2, T3, T4, T5, T6, T7, T8}                    


                    ImportExport.WriteDataCSV();

                    //Statusbox.Text = Visualisierung.StatusGUI(2);

                };
                Invoke(LabelUpdate);

                #region watezeit ohne GUI blockieren;)
                Containerklasse.AufnahmeTaktzeitBeendet = false;
                SetTimer(AufnahmeRate * 1000);//starten
                do
                {
                } while (!Containerklasse.AufnahmeTaktzeitBeendet);
                //Console.WriteLine(a);
                if (TaktTimer.Enabled)
                {
                    TaktTimer.Stop();
                    //TaktTimer.Dispose();
                }
                #endregion

                // Anzahl Messwerte inkrementieren und im Container zwischenspeichern
                count = count + 1;
                Containerklasse.Czahl = count;

            } while (Running && !TempUeberschritten && !Pause);

        // --> Sprungmarke wenn keine pn-verbindung vorhanden
        ende:
            // --> zurück zur Messung
            goto MeasuringRun;
        }
        /// leer /////////////////////////////////////////////////
        #region leer
        private void Druckluft_Kuhlung_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Statusbox_Click(object sender, EventArgs e)
        {

        }
        private void RG_Kühlung_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void dateiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion
        
        #region Timer/IMStaus
        private void timer1_Tick(object sender, EventArgs e)
        {

            // Impuls nur wenn Temp nicht überschritten!! muss bearbeitet
            if (Running && !TempUeberschritten && Containerklasse.CanzImp >= 1)// bedingung(fehlt): wenn die Dauer noch nicht abgelaufen ist
            {
                // zwischengespeicherte Anzahl der Impulse aus dem Container zurückholen
                anzImp = Containerklasse.CanzImp;
                // Steuerbeyt auf 3 setzen damit ein Impuls gestartet werden kann
                WriteByteNode(Containerklasse.NODE_Id_IM_START, "true");
            }
            
            Thread.Sleep(100);
            if (true)// bedingung(fehlt): wenn die Dauer noch nicht abgelaufen ist
            {
                // inkrementiere Anzahl der Impulse um 1
                anzImp = anzImp + 1;
                // erreichte Anzahl der Impulse im Container zwischenspeichern
                Containerklasse.CanzImp = anzImp;
                //IMStart-Bit auf 0 zurücksetzen
                WriteByteNode(Containerklasse.NODE_Id_IM_START, "false");
            }
            // anzahl der Impulse auf der gui aktualisieren
            AnzahlImpulseSchreiben();          

            int anz_IMPULSE = Convert.ToInt32(ReadTempNode(Containerklasse.NODE_Id_ANZ_IMPULSE));
            if (anz_IMPULSE > 1)
            {
                double taktErr;
                taktErr = Convert.ToDouble(Containerklasse.BisherigeTestDauer) / ReadTempNode(Containerklasse.NODE_Id_ANZ_IMPULSE);
                label28.Text = "Berechnete Taktzeit [s]: " + taktErr.ToString("00.00"); //Angepasst wieder auf "00.00", DG 23.03.2021
                Containerklasse.DurchnittTaktzeit = taktErr.ToString("00.00");
            }


        }//IM starten
        private void timer2_Tick(object sender, EventArgs e)
        {
            string IMStat = ReadIMStatBitNode(Containerklasse.NODE_Id_STATUS);
            //string ready = ReadIMStatBitNode(Containerklasse.NODE_Id_READY);
            if (IMStat == "0" && !TempUeberschritten)
            {
                Statusbox.Text = Visualisierung.StatusGUI(4);
                pnl_StatusFarbe.BackColor = Color.LightCyan;
            }
            if (IMStat == "1")//1-->IM on
            {
                Statusbox.Text = Visualisierung.StatusGUI(4);
                pnl_StatusFarbe.BackColor = Color.LightCyan;
            }
            if (IMStat == "3" && !TempUeberschritten)//3-->ready
            {
                Statusbox.Text = Visualisierung.StatusGUI(1);
                pnl_StatusFarbe.BackColor = Color.LimeGreen;
            }
            if (IMStat == "5" && !TempUeberschritten)//5-->busy
            {
                Statusbox.Text = Visualisierung.StatusGUI(2);
                pnl_StatusFarbe.BackColor = Color.Yellow;
            }
            if (IMStat == "9" || TempUeberschritten)// 9-->fault
            {
                HupeEinshalten(); HupeAusschalten();
                Statusbox.Text = Visualisierung.StatusGUI(3);
                pnl_StatusFarbe.BackColor = Color.Red;
            }
        }//IM Status check
        private void timer3_Tick(object sender, EventArgs e)
        {
            btn_StopTest.PerformClick();
            //PDFReportErstellen();
        }// stopen wenn testdauer abgelaufen
        private void timer4_Tick(object sender, EventArgs e)//gesamtdauer des tests
        {
            Containerklasse.BisherigeTestDauer++;


            //string hh ;
            //string mm;
            //string ss ;
            TimeSpan dtDiff = DateTime.Now - DT_TaktBerechnet;
            Containerklasse.tsTestDauer = dtDiff;
            Testdauerlabel.Text = Berechnungen.TestDauerBerechnen(Containerklasse.BisherigeTestDauer, 1);
        }//bisherige Dauer  
        private void SetTimer(int takt)
        {
            // Create a timer with a two second interval.
            TaktTimer = new System.Timers.Timer(takt);
            // Hook up the Elapsed event for the timer. 
            TaktTimer.Elapsed += OnTimedEvent;
            TaktTimer.AutoReset = true;
            TaktTimer.Enabled = true;
        }
        #endregion

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              //e.SignalTime);
            Containerklasse.AufnahmeTaktzeitBeendet = true;
            //Console.WriteLine(Containerklasse.TaktzeitBeendet);
        }
       
        #region TemperaturUeberwachung thread
        private void TemperaturUeberwachung(object dummy)
        {
            //TempUeberwachen:
            //bool DoIt = false;
            bool T1Exeeded = false;
            bool T2Exeeded = false;
            bool T3Exeeded = false;
            bool T4Exeeded = false;
            bool T5Exeeded = false;
            bool T6Exeeded = false;
            bool T7Exeeded = false;
            bool T8Exeeded = false;

            do
            {
                // Call with Nodes id's 
                temp.TempAnalyse(ReadTempNode(Containerklasse.NODE_Id_T5), ReadTempNode(Containerklasse.NODE_Id_T6),
                    ReadTempNode(Containerklasse.NODE_Id_T4_oben), ReadTempNode(Containerklasse.NODE_Id_T5_oben), ReadTempNode(Containerklasse.NODE_Id_RaumTemp)
                    , ReadTempNode(Containerklasse.NODE_Id_T4), ReadTempNode(Containerklasse.NODE_Id_AbluftTemp), ReadTempNode(Containerklasse.NODE_Id_MFTemp));

                if (temp.MFTemp_exceeded & T2_checkBox.Checked) //& T2_checkBox.Checked hinzugefügt (DG, 18.12.2020)
                {
                    T1Exeeded = true;
                }
                if (!temp.MFTemp_exceeded)
                {
                    T1Exeeded = false;
                }
                if (temp.AbluftTemp_exceeded & T3_checkBox.Checked) //& T3_checkBox.Checked hinzugefügt (DG, 18.12.2020)
                {
                    T2Exeeded = true;
                }
                if (!temp.AbluftTemp_exceeded)
                {
                    T2Exeeded = false;
                }
                if (temp.RaumTemp_exceeded & T1_checkBox.Checked)   //& T1_checkBox.Checked hinzugefügt (DG, 18.12.2020)
                {
                    T3Exeeded = true;
                }
                if (!temp.RaumTemp_exceeded)
                {
                    T3Exeeded = false;
                }

                if (T4_checkBox.Checked)
                {
                    if (temp.T4_exceeded)
                    {
                        T4Exeeded = true;
                    }
                    else
                    {
                        T4Exeeded = false;
                    }
                }
                if (T5_checkBox.Checked)
                {
                    if (temp.T5_exceeded)
                    {   
                        T5Exeeded = true;
                    }
                    else
                    {
                        T5Exeeded = false;
                    }
                }
                if (T6_checkBox.Checked)
                {
                    if (temp.T6_exceeded)
                    {   
                        T6Exeeded = true;
                    }
                    else
                    {
                        T6Exeeded = false;
                    }
                }
                if (T7_checkBox.Checked)
                {
                    if (temp.T4_oben_exceeded)
                    {   
                        T7Exeeded = true;
                    }
                    else
                    {
                        T7Exeeded = false;
                    }
                }
                if (T8_checkBox.Checked)
                {
                    if (temp.T5_oben_exceeded)
                    {   
                        T8Exeeded = true;
                    }
                    else
                    {
                        T8Exeeded = false;
                    }
                }

                if (T1Exeeded || T2Exeeded || T3Exeeded || T4Exeeded || T5Exeeded || T6Exeeded || T7Exeeded || T8Exeeded)
                {
                    MethodInvoker TempQuit1 = delegate
                    {
                        btn_TempQuit.Enabled = false;
                    };
                    Invoke(TempQuit1);

                    TempUeberschritten = true;
                    // ampel rot
                    Containerklasse.AMPELHUPE = Berechnungen.SetBit(Containerklasse.AMPELHUPE, 4);
                    // hupen
                    Containerklasse.AMPELHUPE = Berechnungen.SetBit(Containerklasse.AMPELHUPE, 6);
                    // write hier: 

                }

                if (!T1Exeeded && !T2Exeeded && !T3Exeeded && !T4Exeeded && !T5Exeeded && !T6Exeeded && !T7Exeeded && !T8Exeeded)
                {
                    MethodInvoker TempQuit2 = delegate
                    {
                        if (pnl_StatusFarbe.BackColor == Color.Red)
                        {
                            btn_TempQuit.Enabled = true;
                        }
                    };
                    Invoke(TempQuit2);
                }


            } while (true);
        }

        #endregion

        #region Read/Write
        private void WriteByteNode(string _Node, string byteValue)
        {
            List<String> nodeIdStrings = new List<String>();
            List<String> values = new List<String>();
            nodeIdStrings.Add(_Node);

            //string Eingabe = Console.ReadLine();

            values.Add(byteValue);
            myClientHelperAPI.WriteValues(values, nodeIdStrings);
        }
        private double ReadTempNode(string _Node)
        {
            List<String> nodeIdStrings = new List<String>();
            List<String> values = new List<String>();
            nodeIdStrings.Add(_Node);

            values = myClientHelperAPI.ReadValues(nodeIdStrings);

            string val = values[0];
            double temperatur = double.Parse(val);
            // convert string to byte after reading
            byte[] byteArray = new byte[1];
            byteArray = BitConverter.GetBytes(temperatur);
            byte IM_Steuern = byteArray[0];

            // convert byte[] to string
            int intValue = BitConverter.ToInt16(byteArray, 0);

            return temperatur;
        }
        private byte ReadIMStatusNode(string _Node)
        {
            List<String> nodeIdStrings = new List<String>();
            List<String> values = new List<String>();
            nodeIdStrings.Add(_Node);

            values = myClientHelperAPI.ReadValues(nodeIdStrings);


            string val = values[0];
            double numVal = double.Parse(val);
            // convert string to byte after reading
            byte[] byteArray = new byte[1];
            byteArray = BitConverter.GetBytes(numVal);
            byte IM_State = byteArray[0];

            // convert byte[] to string
            int intValue = BitConverter.ToInt16(byteArray, 0);

            return IM_State;
        }
        private string ReadIMStatBitNode(string _Node)
        {
            List<String> nodeIdStrings = new List<String>();
            List<String> values = new List<String>();
            nodeIdStrings.Add(_Node);

            values = myClientHelperAPI.ReadValues(nodeIdStrings);


            string result = values[0];
            

            return result;
        }



        #endregion

        #region Impuls
        private void ResetImpulsCounter()
        {
            WriteByteNode(Containerklasse.NODE_Id_ResetImpCounter, "true");
            Thread.Sleep(200);
            WriteByteNode(Containerklasse.NODE_Id_ResetImpCounter, "false");
        }
        private void AnzahlImpulseSchreiben()
        {
            int anz_IMPULSE = Convert.ToInt32(ReadTempNode(Containerklasse.NODE_Id_ANZ_IMPULSE));

                
            label2.Text = Convert.ToString(anz_IMPULSE) + " Impulse";
            Containerklasse.pdfAnzahlImpulse = label2.Text;
            
        } 
        #endregion

        #region Hupe Ein/Aus
        private void HupeEinshalten()
        {
            Containerklasse.AMPELHUPE = Berechnungen.SetBit(Containerklasse.AMPELHUPE, 6);//Auf Bit 6 umgeändert, DG, 15.12.2020
            //WriteByteNode(null, null);
        }
        private void HupeAusschalten()
        {
            Containerklasse.AMPELHUPE = Berechnungen.ResetBit(Containerklasse.AMPELHUPE, 6);//Auf Bit 6 umgeändert, DG, 15.12.2020
            Thread.Sleep(50);
            //WriteByteNode(null, null);
        }

        #endregion       

        #region InfoForm
        private void informationenZuMPSDT2020ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("MPS-DT-2020-V02f, 03.03.2021, Magnet-Physik Dr. Steingroever GmbH. D. Gromoll, K. Riadi", "Software Informationen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //var neueForm = new Infoform();
            //neueForm.Show();
        }
        #endregion

        #region Temperatur anzeigen
        //private void AktuelleTempAnzeigen()
        //{
        //    OPC_Read dtaTempAktuell = new OPC_Read();
        //    lb_T1.Text = Convert.ToString(dtaTempAktuell.RaumTemp);
        //    lb_T2.Text = Convert.ToString(dtaTempAktuell.MFTemp);
        //    lb_T3.Text = Convert.ToString(dtaTempAktuell.AbluftTemp);
        //    lb_T4.Text = Convert.ToString(dtaTempAktuell.T4);
        //    lb_T5.Text = Convert.ToString(dtaTempAktuell.T5);
        //    lb_T6.Text = Convert.ToString(dtaTempAktuell.T6);
        //    lb_T7.Text = Convert.ToString(dtaTempAktuell.T4_oben);
        //    lb_T8.Text = Convert.ToString(dtaTempAktuell.T5_oben);
        //}
        private void T4_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region PDFReportErstellen
        private void PDFReportErstellen()
        {


            // testschleife stoppen
            if (Running)
            {
                //TaktTimer.Stop();
                //TaktTimer.Dispose();
            }

            Containerklasse.TESTGESTARTET = false;
            Running = false;
            // bitmap aus xhert erzeugen
            Bitmap bmp = new Bitmap(2100, 1500);
            chart1.DrawToBitmap(bmp, new Rectangle(0, 0, 2100, 1500));

            Containerklasse.imgChartPfad = Containerklasse.pdfPfad + "\\ChartTest.png";
            bmp.Save(Containerklasse.imgChartPfad);

            string pdfName = "\\" + Containerklasse.pdfDocPfadName + ".pdf";
            //Containerklasse.pdfDocPfad = Containerklasse.pdfPfad + "\\DauerTest.pdf";
            Containerklasse.pdfDocPfad = Containerklasse.pdfPfad + pdfName;
            //chart1.SaveImage(Containerklasse.pdfPfad + "\\Test.emf", ChartImageFormat.Emf);
            //chart1.Printing.Print(true);

            // PDF report erzeugen
            PDFCreator.CreateReport_PDF();
        }

        #endregion

        private void btn_Entw_Click(object sender, EventArgs e)
        {
            UAClientForm FormOPCUAScout = new UAClientForm();
            // Show the settings form
            FormOPCUAScout.Show();
        }
    }
    public static class Containerklasse
    { 
        // test gestertet
        public static bool TESTGESTARTET;
        // IM Steuern
        public static byte IMSTEUERN;
        // Hupe/Ampel steuern
        public static byte AMPELHUPE;
        // DTA Reset counter
        public static byte RESETCOUNTER;
        //
        #region OPC UA Nodes ID's
        // (\) muss vor dem (")
        public static string NODE_Id_RMLDONOFF = "ns = 3;s=\"RMLD IM ON\"";
        public static string NODE_Id_FAULT = "ns=3;s=\"IM FAULT\""; 
        public static string NODE_Id_READY = "ns=3;s=\"IM READY\""; 
        public static string NODE_Id_BUSY = "ns=3;s=\"IM BUSY\"";
        public static string NODE_Id_STATUS = "ns=3;s=\"[101]IM STATUS\".\"IM STATUS\"";

        public static string NODE_Id_ANZ_IMPULSE = "ns=3;s=\"[101]IM STATUS\".\"IM ANZ IMPULSE\"";

        public static string NODE_Id_IM_ON = "ns=3;s=\"IM ON/OFF\"";
        public static string NODE_Id_IM_START = "ns=3;s=\"IM START\"";
        //public static string NODE_Id_STEUERN = "ns=3;s=\"[103]IM STEUERN\".\"IM STEUERN\"";
        //public static string NODE_Id_IM_ON = "ns=3;s=\"[103]IM STEUERN\".\"IM ON OFF\"";
        //public static string NODE_Id_IM_START = "ns=3;s=\"[103]IM STEUERN\".\"IM START\"";


        public static string NODE_Id_AMPELHUPE = "ns=3;s=\"[103]IM STEUERN\".\"IM STEUERN\"";

        public static string NODE_Id_T5 = "ns=3;s=\"[100]TEMPERATUREN\".\"T5\"";
        public static string NODE_Id_T6 = "ns=3;s=\"[100]TEMPERATUREN\".\"T6\"";
        public static string NODE_Id_T4_oben = "ns=3;s=\"[100]TEMPERATUREN\".\"T4_oben\"";
        public static string NODE_Id_T5_oben = "ns=3;s=\"[100]TEMPERATUREN\".\"T5_oben\"";
        public static string NODE_Id_RaumTemp = "ns=3;s=\"[100]TEMPERATUREN\".\"RaumTemp\"";
        public static string NODE_Id_T4 = "ns=3;s=\"[100]TEMPERATUREN\".\"T4\"";
        public static string NODE_Id_AbluftTemp = "ns=3;s=\"[100]TEMPERATUREN\".\"AbluftTemp\"";
        public static string NODE_Id_MFTemp = "ns=3;s=\"[100]TEMPERATUREN\".\"MFTemp\"";
        public static string NODE_Id_test = "ns=3;s=\"[100]TEMPERATUREN\".\"test\"";

        public static string NODE_Id_ResetImpCounter = "ns=3;s=\"PN_ResetCounter\"";
        #endregion
        // 
        #region Dauer/Takt
        public static TimeSpan tsTestDauer;
        public static DateTime DatumDesTests;
        public static string DurchnittTaktzeit;
        public static int BisherigeTestDauer;
        // Takt der Aufzeichnung
        public static double TAKT;
        // TaktzeitBeendet
        public static bool AufnahmeTaktzeitBeendet;
        #endregion
        // 
        #region IM status
        public static byte IMStatus;
        public static bool STANDBY;
        public static bool READY;
        public static bool BUSY;
        public static bool FAULT;
        #endregion
        // 
        #region DTA Temperaturen
        public static byte DTAStatus;
        public static double T5;
        public static double T6;
        public static double T4_oben;
        public static double T5_oben;
        public static double RaumTemp;
        public static double T4;
        public static double AbluftTemp;
        public static double MFTemp;         

        public static string[] _Zeit /*= new string[1000]*/;
        public static double[] _T1_Wert /*= new double[1000]*/;
        public static double[] _T2_Wert /*= new double[1000]*/;
        public static double[] _T3_Wert /*= new double[1000]*/;
        public static double[] _T4_Wert /*= new double[1000]*/;
        public static double[] _T5_Wert /*= new double[1000]*/;
        public static double[] _T6_Wert /*= new double[1000]*/;
        public static double[] _T7_Wert /*= new double[1000]*/;
        public static double[] _T8_Wert /*= new double[1000]*/;       
        
        // DTA Temperaturen Grenzwerte
        public static double T5_max;
        public static double T6_max;
        public static double T4_oben_max;
        public static double T5_oben_max;
        public static double RaumTemp_max;
        public static double T4_max;
        public static double AbluftTemp_max;
        public static double MFTemp_max;
        #endregion        
        // 
        #region Dauertest Dokumentation
        public static string Projektnummer;
        public static string PV;
        public static string Betriebsauftrag;
        public static string MF_ArtikelName;
        public static string MF_ArtikelNummer;
        public static string MF_Seriennummer;
        public static string IM_Artikelname;
        public static string IM_Artikelnummer;
        public static string IM_Seriennummer;
        public static string Ladespannung_U;
        public static string Magnetisierstrom_I;
        public static string Energie_E;
        public static string Dauerleistung_P;
        public static string Kühlungsart;
        public static string Bemerkung;
        #endregion
        // 
        #region Dauertest-Vorgabeparameter
        public static string Taktzeit;
        public static string Testzeit;
        public static string MF_MaxTemp;
        #endregion
        // Graph (werden nicht mehr gebraucht!)
        #region Graph
        public static string[] Cxval;
        public static double[] Cyval;
        public static double[] Cyval1;
        public static double[] CsinAngle;
        public static int Czahl;
        public static int CanzImp; 
        #endregion
        // 
        #region PDF
        public static string pdfDatum;

        public static string pdfTestobjekt;
        public static string pdfProjektNr;
        public static string pdfPVpv;
        public static string pdfBetriebsauftrag;
        public static string pdfBearbeiter;
        public static string pdfIMArtikelNr;
        public static string pdfIMSerienNr;
        public static string pdfMFArtikelNr;
        public static string pdfMFSerienNr;
        public static string pdfSpannung;
        public static string pdfMagnetiStrom;
        public static string pdfEnergie;
        public static string pdfDauerleistung;
        public static string pdfKuehlung;
        public static string pdfBemerkung;

        public static string pdfTaktzeitErr;
        public static string pdfTaktzeit;
        public static string pdfTestdauer;
        public static string pdfAnzahlImpulse;
        public static string pdfT1Name;
        public static string pdfT2Name;
        public static string pdfT3Name;
        public static string pdfT4Name;
        public static string pdfT5Name;
        public static string pdfT6Name;
        public static string pdfT7Name;
        public static string pdfT8Name; 
        

        // PDF pfad
        public static string pdfPfad;
        public static string pdfDocPfad; 
        public static string imgChartPfad;
        public static string pdfDocPfadName;
        #endregion
    }
}
