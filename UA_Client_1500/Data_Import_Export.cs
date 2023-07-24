/**********************************************************************************************************************
 * Namespace: UA_Client_1500                                                                                          *
 * Class    :                                                                                                         *
 * (sub)class: Styling                                                                                                *
 * written by Khalid Riadi                                                                                            *
 * copyright                                                                                                          *
 * Magnet  Physik                                                                                                     *  
 * History:                                                                                                           *
 * (2020-12-08,KR):  version                                                                                          *
 *                                                                                                                    *  
 * Kurzbeschreibung:                                                                                                  *  
 * -   
 * -  
 * -  
 * -  
 * -  
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
using SimaticNET.OPC.OpcDaClient;
//using ZedGraph;
using Accord.IO;
using System.IO;


namespace UA_Client_1500
//namespace MPS_DT_2020_V00
{
    class Data_Import_Export
    {
        //Variablen für File-Dialog; fällt ggf. weg
        private FolderBrowserDialog _automatisiertSpeichern;
        private DialogResult _objResult;
        private string _automatisiertSpeichernPfad;
        private string _dateiname;

        //Variablen für CSV-Erstellung
        private string _filenameCSV;
        private CsvWriter _writer;
        private DataTable _table;

        //Variablen für CSV-Beschreibung: Header
        private DateTime _dt;
        private string _T1_Name;
        private string _T2_Name;
        private string _T3_Name;
        private string _T4_Name;
        private string _T5_Name;
        private string _T6_Name;
        private string _T7_Name;
        private string _T8_Name;
        private string _T1_MAX;
        private string _T2_MAX;
        private string _T3_MAX;
        private string _T4_MAX;
        private string _T5_MAX;
        private string _T6_MAX;
        private string _T7_MAX;
        private string _T8_MAX;
        private Boolean _T4_Schaltzustand;
        private Boolean _T5_Schaltzustand;
        private Boolean _T6_Schaltzustand;
        private Boolean _T7_Schaltzustand;
        private Boolean _T8_Schaltzustand;
        private string _projektnr;
        private string _PVpv;
        private string _BAnr;
        private string _bearbeiter;
        private string _MF_Artikelname;
        private string _MF_AN;
        private string _MF_SN;
        private string _IM_Artikelname;
        private string _IM_AN;
        private string _IM_SN;
        private string _U_IM;
        private string _I_MAG;
        private string _E_MAG;
        private string _P_Dauer;
        private string _Kuehlungsart;
        private string _Bemerkungen;
        private string _sonstiges;
        private string _Taktzeit_Vorgabe;
        private string _Testzeit_Vorgabe;
        private string _RG_Schaltzustand;
        private string _Druckluft_Schaltzustand;
        private string _IMon_Override;
        private string _Testobjekt;


        //Variablen für CSV-Beschreibung: Messwerte
        private object[][] _messwerte;
        private object[][] _GUIwerte;

        private string _zeitbasis;
        private double _T1_Wert;
        private double _T2_Wert;
        private double _T3_Wert;
        private double _T4_Wert;
        private double _T5_Wert;
        private double _T6_Wert;
        private double _T7_Wert;
        private double _T8_Wert;

        //Variablen für CSV-Auslesen
        private CsvReader _reader;
        private object[][] _readMatrix;



        public Data_Import_Export()
        {
            //Variablen für File-Dialog; fällt ggf. weg
            _automatisiertSpeichern = null;
            _objResult = 0;
            _automatisiertSpeichernPfad = string.Empty;
            _dateiname = string.Empty;

            //Variablen für CSV-Erstellung
            _filenameCSV = string.Empty;
            _writer = null;
            _table = null;

            //Variablen für CSV-Beschreibung: Header

            _GUIwerte = null;

            _T1_Name = string.Empty;
            _T2_Name = string.Empty;
            _T3_Name = string.Empty;
            _T4_Name = string.Empty;
            _T5_Name = string.Empty;
            _T6_Name = string.Empty;
            _T7_Name = string.Empty;
            _T8_Name = string.Empty;
            _T1_MAX = string.Empty;
            _T2_MAX = string.Empty;
            _T3_MAX = string.Empty;
            _T4_MAX = string.Empty;
            _T5_MAX = string.Empty;
            _T6_MAX = string.Empty;
            _T7_MAX = string.Empty;
            _T8_MAX = string.Empty;
            _projektnr = string.Empty;
            _PVpv = string.Empty;
            _BAnr = string.Empty;
            _bearbeiter = string.Empty;
            _MF_Artikelname = string.Empty;
            _MF_AN = string.Empty;
            _MF_SN = string.Empty;
            _IM_Artikelname = string.Empty;
            _IM_AN = string.Empty;
            _IM_SN = string.Empty;
            _U_IM = string.Empty;
            _I_MAG = string.Empty;
            _E_MAG = string.Empty;
            _P_Dauer = string.Empty;
            _Kuehlungsart = string.Empty;
            _Bemerkungen = string.Empty;
            _sonstiges = string.Empty;
            _Taktzeit_Vorgabe = string.Empty;
            _Testzeit_Vorgabe = string.Empty;
            _RG_Schaltzustand = string.Empty;
            _Druckluft_Schaltzustand = string.Empty;
            _IMon_Override = string.Empty;
            _Testobjekt = string.Empty;

            _T4_Schaltzustand = false;
            _T5_Schaltzustand = false;
            _T6_Schaltzustand = false;
            _T7_Schaltzustand = false;
            _T8_Schaltzustand = false;

            //Variablen für CSV-Beschreibung: Messwerte
            _messwerte = null;

            //Variablen für CSV-Einlesen
            _reader = null;
            _readMatrix = null;

        }

        public void SpeicherortCSV()
        {
            try
            {
                _automatisiertSpeichern = new FolderBrowserDialog();
                _automatisiertSpeichern.Description = "Ort an dem die Dauertest-Dokumentation gespeichert werden soll";
                _automatisiertSpeichern.SelectedPath = @"C:\";       // Vorgabe Pfad (und danach der gewählte Pfad)
                _objResult = _automatisiertSpeichern.ShowDialog();   //Fehler tritt auf.
                //MessageBox.Show("Neuer Pfad: " + _automatisiertSpeichern.SelectedPath);
                _automatisiertSpeichernPfad = _automatisiertSpeichern.SelectedPath;
                Console.WriteLine(_automatisiertSpeichernPfad);
                //_automatisiertSpeichernPfad = "C:\\MPS_Dauertest\\ArtikelNr\\SerienNr";

                //_dateiname = date + "_Dauertest_" + "GUITestobjekt_" + "GUITestzeit_" + "GUIImag";

                //Durch dieses hier zu ersetzen.
                _automatisiertSpeichernPfad = @"C:\MPS_Dauertest\ArtikelNr\SerienNr2";
                DirectoryInfo di = Directory.CreateDirectory(_automatisiertSpeichernPfad);

                Containerklasse.pdfPfad = _automatisiertSpeichernPfad; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Der Speicherort für die Dauertest-Dokumentation konnte nicht gewählt werden.", ex.ToString());

            }
        }


        public void CreateCSVname()
        {
            try
            {

                _dt = DateTime.Now;
                string date = _dt.ToString("d");
                string time = _dt.TimeOfDay.ToString();
                char[] datechar = date.ToCharArray();
                char[] timechar = time.ToCharArray();

                time = Convert.ToString(timechar[0]) + Convert.ToString(timechar[1]) + Convert.ToString(timechar[3]) +
                    Convert.ToString(timechar[4]) + Convert.ToString(timechar[6]) + Convert.ToString(timechar[7]);

                date = Convert.ToString(datechar[6]) + Convert.ToString(datechar[7]) + Convert.ToString(datechar[8])
                    + Convert.ToString(datechar[9]) + Convert.ToString(datechar[3]) + Convert.ToString(datechar[4])
                    + Convert.ToString(datechar[0]) + Convert.ToString(datechar[1]);


                date = date + time;


                if (_Testobjekt == "IM")
                {
                    _dateiname = date + "_Dauertest_" + _Testobjekt + "_" + _IM_AN + "_" + _IM_SN + "_" + _Testzeit_Vorgabe + "h";
                    _filenameCSV = string.Concat(_automatisiertSpeichernPfad, "\\", _dateiname, ".csv");

                }


                if (_Testobjekt == "MF")
                {
                    _dateiname = date + "_Dauertest_" + _Testobjekt + "_" + _MF_AN + "_" + _MF_SN + "_" + _Testzeit_Vorgabe + "h";
                    _filenameCSV = string.Concat(_automatisiertSpeichernPfad, "\\", _dateiname, ".csv");

                }

                if (_Testobjekt == "Entwicklung")
                {
                    _dateiname = date + "_Dauertest_" + _Testobjekt + "_" + "MF_" + _MF_AN + "_" + _MF_SN + "_" + "IM_" + _IM_AN + "_" + _IM_SN + "_" + _Testzeit_Vorgabe + "h";
                    _filenameCSV = string.Concat(_automatisiertSpeichernPfad, "\\", _dateiname, ".csv");

                }

                Containerklasse.pdfDocPfadName = _dateiname;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Der .CSV-Dateiname konnte nicht erstellt werden.", ex.ToString());

            }
        }


        //_Dateiname muss vorher definiert werden über getter oder CreateCSVname
        public void CreateCSV()
        {
            try
            {
                _writer = new CsvWriter(_filenameCSV);
                _table = new DataTable("Dauertestdoku");             
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die .CSV-Datei konnte nicht erstellt werden.", ex.ToString());
            }


        }

        /*
        public void DropdownLaborIM()
        {
            try
            {
                if (_IM_Artikelname IM - U - 0310 - A----KP--081A1F3G2A1 - Labor)


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die .CSV-Datei konnte nicht erstellt werden.", ex.ToString());

            }


        }
        */


        public void FixGUIvalues(object[][] GUIvalues)
        {
            try
            {
                _GUIwerte = GUIvalues;
                _projektnr = _GUIwerte[0][0].ToString();
                _PVpv = _GUIwerte[0][1].ToString();
                _BAnr = _GUIwerte[0][2].ToString();
                _bearbeiter = _GUIwerte[0][3].ToString();
                _MF_Artikelname = _GUIwerte[0][4].ToString();
                _MF_AN = _GUIwerte[0][5].ToString();
                _MF_SN = _GUIwerte[0][6].ToString();
                _IM_Artikelname = _GUIwerte[0][7].ToString();
                _IM_AN = _GUIwerte[0][8].ToString();
                _IM_SN = _GUIwerte[0][9].ToString();
                _U_IM = _GUIwerte[0][10].ToString();
                _I_MAG = _GUIwerte[0][11].ToString();
                _E_MAG = _GUIwerte[0][12].ToString();
                _P_Dauer = _GUIwerte[0][13].ToString();
                _Kuehlungsart = _GUIwerte[0][14].ToString();
                _Bemerkungen = _GUIwerte[0][15].ToString();
                _Taktzeit_Vorgabe = _GUIwerte[0][16].ToString();
                _Testzeit_Vorgabe = _GUIwerte[0][17].ToString();
                _RG_Schaltzustand = _GUIwerte[0][18].ToString();
                _Druckluft_Schaltzustand = _GUIwerte[0][19].ToString();
                _T1_Name = _GUIwerte[0][20].ToString();
                _T1_MAX = _GUIwerte[0][21].ToString();
                _T2_Name = _GUIwerte[0][22].ToString();
                _T2_MAX = _GUIwerte[0][23].ToString();
                _T3_Name = _GUIwerte[0][24].ToString();
                _T3_MAX = _GUIwerte[0][25].ToString();
                _T4_Schaltzustand = Convert.ToBoolean(_GUIwerte[0][26].ToString());

                _T4_Name = _GUIwerte[0][27].ToString();
                _T4_MAX = _GUIwerte[0][28].ToString();

                _T5_Schaltzustand = Convert.ToBoolean(_GUIwerte[0][29].ToString());

                _T5_Name = _GUIwerte[0][30].ToString();
                _T5_MAX = _GUIwerte[0][31].ToString();

                _T6_Schaltzustand = Convert.ToBoolean(_GUIwerte[0][32].ToString());

                _T6_Name = _GUIwerte[0][33].ToString();
                _T6_MAX = _GUIwerte[0][34].ToString();

                _T7_Schaltzustand = Convert.ToBoolean(_GUIwerte[0][35].ToString());

                _T7_Name = _GUIwerte[0][36].ToString();
                _T7_MAX = _GUIwerte[0][37].ToString();

                _T8_Schaltzustand = Convert.ToBoolean(_GUIwerte[0][38].ToString());

                _T8_Name = _GUIwerte[0][39].ToString();
                _T8_MAX = _GUIwerte[0][40].ToString();
                _IMon_Override = _GUIwerte[0][41].ToString();
                _Testobjekt = _GUIwerte[0][42].ToString();
                //Console.WriteLine(_Testobjekt);

                /*
                //Überprüfung der Eingaben aller Felder
                if (_Testobjekt == "IM" || _Testobjekt == "MF" || _Testobjekt == "")
                {
                    if (_projektnr == "" || _PVpv == "" || _BAnr == "" || _bearbeiter == "" || _MF_Artikelname == "" || _MF_AN == "" || _MF_SN == "" || _IM_Artikelname == "" || _IM_AN == "" || _IM_SN == "" || _U_IM == "" || _I_MAG == "" || _E_MAG == "" || _P_Dauer == "" || _Kuehlungsart == "" || _Taktzeit_Vorgabe == "" || _Testzeit_Vorgabe == "" || _T1_Name == "" || _T1_MAX == "" || _T2_Name == "" || _T2_MAX == "" || _T3_Name == "" || _T3_MAX == "")
                    {
                        MessageBox.Show("Bitte die Felder der Dauertest-Dokumentation vollständig ausfüllen");

                        //Hier muss noch eine Aktion folgen!!!!
                        Application.Restart();
                        Environment.Exit(0);
                        return;
                    }
                }
                */


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die GUI-Infos konnten nicht fixiert werden.", ex.ToString());

            }
        }

        public void CheckGUIInput()
        {
            //Hier wird über eine ODER-Verknüpfung gecheckt, ob die Input-Felder offen geblieben sind
            try
            {
                if (_Testobjekt == "IM" || _Testobjekt == "MF" || _Testobjekt == "")
                {
                    if (_projektnr == "" || _PVpv == "" || _BAnr == "" || _bearbeiter == "" || _MF_Artikelname == "" || _MF_AN == "" || _MF_SN == "" || _IM_Artikelname == "" || _IM_AN == "" || _IM_SN == "" || _U_IM == "" || _I_MAG == "" || _E_MAG == "" || _P_Dauer == "" || _Kuehlungsart == "" || _Taktzeit_Vorgabe == "" || _Testzeit_Vorgabe == "" || _T1_Name == "" || _T1_MAX == "" || _T2_Name == "" || _T2_MAX == "" || _T3_Name == "" || _T3_MAX == "")
                    {
                        MessageBox.Show("Bitte die Felder der Dauertest-Dokumentation vollständig ausfüllen. \nDas Programm wird zu diesem Zwecke neu gestartet.");
                        Application.Restart();
                        Environment.Exit(0);
                        //return;
                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die GUI-Infos konnten nicht fixiert werden.", ex.ToString());

            }

        }



        public void SpeicherortCSV_fest()
        {
            try
            {
                /*
                Console.WriteLine("Hallo Speicherort CSV_fest nach try");
                Console.WriteLine(_Testobjekt);
                Console.WriteLine("Hallo Speicherort CSV_fest nach try");
                */

                if (_Testobjekt == "IM")
                {
                    _automatisiertSpeichernPfad = string.Concat(@"C:\MPS_Dauertest\", _IM_AN, "\\", _IM_SN);

                    /*
                    string PfadIM1 = @"C:\MPS_Dauertest\%IM_AN%\".Replace("%IM_AN%", _IM_AN);
                    string PfadIM2 = "%IM_SN%".Replace("%IM_SN%", _IM_SN);
                    Console.WriteLine(PfadIM2);
                    _automatisiertSpeichernPfad = PfadIM1 + PfadIM2;
                    //_automatisiertSpeichernPfad = Path.Combine(PfadIM1, PfardIM2);
                    */
                    Containerklasse.pdfPfad = _automatisiertSpeichernPfad;
                }

                if (_Testobjekt == "MF")
                {
                    _automatisiertSpeichernPfad = string.Concat(@"C:\MPS_Dauertest\", _MF_AN, "\\", _MF_SN);
                    Containerklasse.pdfPfad = _automatisiertSpeichernPfad;
                }

                if (_Testobjekt == "Entwicklung")
                {
                    _automatisiertSpeichernPfad = string.Concat(@"C:\MPS_Dauertest\", "Entwicklung", "\\", _bearbeiter);
                    Containerklasse.pdfPfad = _automatisiertSpeichernPfad;
                }

                //IST NICHT MEHR NOTWENDIG; ES WIRD JEDE DATEI MIT DATUM UND UHRZEIT IM NAMEN VERSEHEN.  DADURCH KANN KEINE ÜBERSCHREIBUNG STATTFINDEN
                //DG, 04.03.2021
                //if (Directory.Exists(_automatisiertSpeichernPfad))
                //{
                //    MessageBox.Show("Achtung, das Verzeichnis existiert bereits. Ist die Seriennummer richtig?");
                //    return;
                //}

                DirectoryInfo di = Directory.CreateDirectory(_automatisiertSpeichernPfad);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Das Verzeichnis für die Dauertest-Dokumentation konnte nicht erstellt werden.", ex.ToString());

            }

            finally
            {

            }
        }


        public void WriteHeaderCSV()
        {
            try
            {
                //_writer in CreateCSV() initialisiert
                _writer.WriteHeaders("Datum:", _dt.ToString("G"));
                _writer.WriteHeaders("Projekt-Nr.:", _projektnr);
                _writer.WriteHeaders("PV/pv:", _PVpv);
                _writer.WriteHeaders("Betriebsauftrag:", _BAnr);
                _writer.WriteHeaders("Bearbeiter:", _bearbeiter);
                _writer.WriteHeaders("Testobjekt:", _Testobjekt);
                _writer.WriteHeaders("MF-Artikelname:", _MF_Artikelname);
                _writer.WriteHeaders("MF Artikel-Nr.:", _MF_AN);
                _writer.WriteHeaders("MF Serien-Nr.:", _MF_SN);
                _writer.WriteHeaders("IM Artikelname:", _IM_Artikelname);
                _writer.WriteHeaders("IM Artikel-Nr.:", _IM_AN);
                _writer.WriteHeaders("IM Serien-Nr.:", _IM_SN);
                _writer.WriteHeaders("Ladespannung U [VDC]:", _U_IM);
                _writer.WriteHeaders("Magnetisierstrom I [kA]:", _I_MAG);
                _writer.WriteHeaders("Energie E [Ws]:", _E_MAG);
                _writer.WriteHeaders("Dauerleistung P [W]:", _P_Dauer);
                _writer.WriteHeaders("Kuehlungsart:", _Kuehlungsart);
                _writer.WriteHeaders("Sonstige Bemerkungen:", _Bemerkungen);
                _writer.WriteHeaders("Taktzeitvorgabe:", _Taktzeit_Vorgabe);
                _writer.WriteHeaders("Testzeitvorgabe:", _Testzeit_Vorgabe);
                _writer.WriteHeaders("T1 " + _T1_Name + " MAX [°C]:", _T1_MAX);
                _writer.WriteHeaders("T2 " + _T2_Name + " MAX [°C]:", _T2_MAX);
                _writer.WriteHeaders("T3 " + _T3_Name + " MAX [°C]:", _T3_MAX);
                _writer.WriteHeaders("T4 " + _T4_Name + " MAX [°C]:", _T4_MAX);
                _writer.WriteHeaders("T5 " + _T5_Name + " MAX [°C]:", _T5_MAX);
                _writer.WriteHeaders("T6 " + _T6_Name + " MAX [°C]:", _T6_MAX);
                _writer.WriteHeaders("T7 " + _T7_Name + " MAX [°C]:", _T7_MAX);
                _writer.WriteHeaders("T8 " + _T8_Name + " MAX [°C]:", _T8_MAX);
                _writer.WriteHeaders("RG140 eingeschaltet:", _RG_Schaltzustand);
                _writer.WriteHeaders("Druckluft eingeschaltet:", _Druckluft_Schaltzustand);
                _writer.WriteHeaders("Samplezeit T-Messung [s]:", 10.ToString());//angepasst von 30. auf 10. , 15.12.2020, DG
                _writer.WriteHeaders("Schaltsignal IM gebrückt:", _IMon_Override);
                _writer.WriteHeaders("****************************", "***********************************");

                //Noch anzupassen an GUI; Name des Temperatursensors als Variable aus GUI implementieren
                _table.Columns.Add("Testdauer [hh:mm]");
                _table.Columns.Add(_T1_Name);
                _table.Columns.Add(_T2_Name);
                _table.Columns.Add(_T3_Name);

                //Aussortieren der Schaltzustände
                if (_T4_Schaltzustand)
                {
                    _table.Columns.Add(_T4_Name);
                }

                if (_T5_Schaltzustand)
                {
                    _table.Columns.Add(_T5_Name);
                }

                if (_T6_Schaltzustand)
                {
                    _table.Columns.Add(_T6_Name);
                }

                if (_T7_Schaltzustand)
                {
                    _table.Columns.Add(_T7_Name);
                }

                if (_T8_Schaltzustand)
                {
                    _table.Columns.Add(_T8_Name);
                }

                _writer.Write(_table);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Der Header der .CSV-Datei konnte nicht erstellt werden.", ex.ToString()); 

            }

        }


        //Hier müssen vorher die _messwerte (=MesswerteCSV) gesettet werden
        public void WriteDataCSV()
        {
            try
            {
                //_writer in CreateCSV() initialisiert
                _writer.Write(_messwerte);


                /* Mit dieser Lösung müssten 32 Zustände programmiert werden
                //Alle T-Werte in .CSV-Datei schreiben
                if (_T4_Schaltzustand && _T5_Schaltzustand && _T6_Schaltzustand && _T7_Schaltzustand && _T8_Schaltzustand)
                {
                    object[][] aktiveWerte = {
                            new object [] { _messwerte[0][0], _messwerte[0][1], _messwerte[0][2], _messwerte[0][3] }
                        };
                    _writer.Write(aktiveWerte);
                }

                //T1-
                if (_T4_Schaltzustand && _T5_Schaltzustand && _T6_Schaltzustand && _T7_Schaltzustand && _T8_Schaltzustand)
                {
                    object[][] aktiveWerte = {
                            new object [] { _messwerte[0][0], _messwerte[0][1], _messwerte[0][2], _messwerte[0][3] }
                        };
                    _writer.Write(aktiveWerte);
                }
                */


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die Messwerte konnten nicht in die .CSV-Datei gescherieben werden.", ex.ToString());

            }


        }

        public void CloseCSV() //=Export?
        {
            try
            {
                //_writer in CreateCSV() initialisiert
                _writer.Dispose();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die .CSV-Datei konnte nicht geschlossen werden.", ex.ToString());

            }
        }


        public void ReadCSV() //Einlesen einer .csv-Datei über Objekt-Methode
        {

            try
            {
                //_reader in CreateCSV() initialisiert
                _reader = new CsvReader(_filenameCSV, hasHeaders: true);
                _readMatrix = _reader.ToJagged<object>();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die .CSV-Datei konnte nicht eingelesen werden.", ex.ToString());

            }

        }



        public string DateinameCSV
        {
            get { return _dateiname; }
            set { _dateiname = value; }
        }

        public object[][] Messwerte2CSV
        {
            get { return _messwerte; }
            set { _messwerte = value; }
        }

        public object[][] MesswerteFROMCSV
        {
            get { return _readMatrix; }
            set { _readMatrix = value; }
        }

        public object[][] GUIwerte2CSV
        {
            get { return _GUIwerte; }
            set { _GUIwerte = value; }
        }

        public string Testobjekt
        {
            get { return _Testobjekt; }
            set { _Testobjekt = value; }
        }

        public string T1Name
        {
            get { return _T1_Name; }
        }

        public string T1Max
        {
            get { return _T1_MAX; }
        }

        public string T2Name
        {
            get { return _T2_Name; }
        }

        public string T2Max
        {
            get { return _T2_MAX; }
        }

        public string T3Name
        {
            get { return _T3_Name; }
        }

        public string T3Max
        {
            get { return _T3_MAX; }
        }

        public string T4Name
        {
            get { return _T4_Name; }
        }

        public string T4Max
        {
            get { return _T4_MAX; }
        }

        public Boolean T4Schaltzustand
        {
            get { return _T4_Schaltzustand; }
        }

        public string T5Name
        {
            get { return _T5_Name; }
        }

        public string T5Max
        {
            get { return _T5_MAX; }
        }

        public Boolean T5Schaltzustand
        {
            get { return _T5_Schaltzustand; }
        }

        public string T6Name
        {
            get { return _T6_Name; }
        }

        public string T6Max
        {
            get { return _T6_MAX; }
        }

        public Boolean T6Schaltzustand
        {
            get { return _T6_Schaltzustand; }
        }
        public string T7Name
        {
            get { return _T7_Name; }
        }

        public string T7Max
        {
            get { return _T7_MAX; }
        }

        public Boolean T7Schaltzustand
        {
            get { return _T7_Schaltzustand; }
        }

        public string T8Name
        {
            get { return _T8_Name; }
        }

        public string T8Max
        {
            get { return _T8_MAX; }
        }

        public Boolean T8Schaltzustand
        {
            get { return _T8_Schaltzustand; }
        }


    }
}
