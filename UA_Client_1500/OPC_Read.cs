/**********************************************************************************************************************
/**********************************************************************************************************************
 * Namespace: UA_Client_1500                                                                                         *
 * Class    : PDFCreator                                                                                              *
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
 **********************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SimaticNET.OPC.OpcDaClient;

//namespace MPS_DT_2020_V00
namespace UA_Client_1500
{
    class OPC_Read :IDisposable
    {
        //DaServerMgt OPC_Server = new DaServerMgt();
        public byte[] DTA_Output_64bytes = new byte[64];
        #region IM STATUS
        public bool STANDBY;
        public bool READY;
        public bool BUSY;
        public bool FAULT;
        public int ANZAHLIMPULSE;
        //public ReturnCode READFEHLERMELDUNG;
        #endregion
        #region DT STATUS
        public bool DRUCKLUFT_UEBERW;
        public bool MV_THERMOSCHALTER; 
        #endregion
        #region TEMPERATUREN
        public double T5;
        public double T6;
        public double T4_oben;
        public double T5_oben;
        public double RaumTemp;
        public double T4;
        public double AbluftTemp;
        public double MFTemp;
        #endregion
        #region TEMPERATUREN BYTES
        private byte IMStatus;
        private byte DTAStatus;
        private byte T5_1;
        private byte T5_2;
        private byte T6_1;
        private byte T6_2;
        private byte T4_oben_1;
        private byte T4_oben_2;
        private byte T5_oben_1;
        private byte T5_oben_2;
        private byte RaumTemp_1;
        private byte RaumTemp_2;
        private byte T4_1;
        private byte T4_2;
        private byte AbluftTemp_1;
        private byte AbluftTemp_2;
        private byte MFTemp_1;
        private byte MFTemp_2;
        #endregion
        public OPC_Read()
        {
            //OPC_Server = Containerklasse.opcServer;

            DTA_Output_64bytes = OPCRead();

            //BytesZerlegen();

            //StatusIM();

            //// --> Umrechnungen von byte zum passenden datentypen
            //T5              = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[0], DTA_Output_64bytes[1]);
            //T6              = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[2], DTA_Output_64bytes[3]);
            //T4_oben         = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[4], DTA_Output_64bytes[5]);
            //T5_oben         = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[6], DTA_Output_64bytes[7]);
            //RaumTemp        = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[8], DTA_Output_64bytes[9]);
            //T4              = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[10], DTA_Output_64bytes[11]);
            //AbluftTemp      = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[12], DTA_Output_64bytes[13]);
            //MFTemp          = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[14], DTA_Output_64bytes[15]);
            //ANZAHLIMPULSE   = Berechnungen.AnzahlImpulse(DTA_Output_64bytes[34], DTA_Output_64bytes[35]);
        }
        public byte[] OPCRead()
        {


            //ReturnCode result;
            //ItemValue[] itemValues = null;
            //try
            //{
            //    //result = Containerklasse.opcServer.Read(0, ref OPC_Connection.itemIdentifiersInput, out itemValues);
            //}
            //catch (Exception)
            //{
            //    result = ReturnCode.ITEMERROR;

            //}

            //byte[] dta_Output = new byte[64];
            ////if (result == ReturnCode.SUCCEEDED)
            ////{
            ////    for (int i = 0; i < 64; i++)
            ////    {
            ////        dta_Output[i] = (byte)itemValues[i].Value;
            ////    }
            ////}
            ////READFEHLERMELDUNG = result;

            //DTA_Output_64bytes = dta_Output;


            //BytesZerlegen();

            //StatusIM();

            // --> Umrechnungen von byte zum passenden datentypen
            //T5 = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[0], DTA_Output_64bytes[1]);
            //T6 = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[2], DTA_Output_64bytes[3]);
            //T4_oben = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[4], DTA_Output_64bytes[5]);
            //T5_oben = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[6], DTA_Output_64bytes[7]);
            //RaumTemp = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[8], DTA_Output_64bytes[9]);
            //T4 = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[10], DTA_Output_64bytes[11]);
            //AbluftTemp = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[12], DTA_Output_64bytes[13]);
            //MFTemp = Berechnungen.TemperaturUmrechnen(DTA_Output_64bytes[14], DTA_Output_64bytes[15]);
            //ANZAHLIMPULSE = Berechnungen.AnzahlImpulse(DTA_Output_64bytes[34], DTA_Output_64bytes[35]);

            //return dta_Output;
            return null;
        }
        private void BytesZerlegen()
        {
            /////////////////////////////
            // IM Status
            /////////////////////////////
            IMStatus = DTA_Output_64bytes[30];
            /////////////////////////////
            // DTA Status
            /////////////////////////////
            DTAStatus = DTA_Output_64bytes[32];
            /////////////////////////////
            // T5
            /////////////////////////////
            T5_1 = DTA_Output_64bytes[0];
            T5_2 = DTA_Output_64bytes[1];
            /////////////////////////////
            // T6
            /////////////////////////////
            T6_1 = DTA_Output_64bytes[2];
            T6_2 = DTA_Output_64bytes[3];
            /////////////////////////////
            // T4_oben
            /////////////////////////////
            T4_oben_1 = DTA_Output_64bytes[4];
            T4_oben_2 = DTA_Output_64bytes[5];
            /////////////////////////////
            // T5_oben
            /////////////////////////////
            T5_oben_1 = DTA_Output_64bytes[6];
            T5_oben_2 = DTA_Output_64bytes[7];
            /////////////////////////////
            // RaumTemp
            /////////////////////////////
            RaumTemp_1 = DTA_Output_64bytes[8];
            RaumTemp_2 = DTA_Output_64bytes[9];
            /////////////////////////////
            // T4
            /////////////////////////////
            T4_1 = DTA_Output_64bytes[10];
            T4_2 = DTA_Output_64bytes[11];
            /////////////////////////////
            // AbluftTemp
            /////////////////////////////
            AbluftTemp_1 = DTA_Output_64bytes[12];
            AbluftTemp_2 = DTA_Output_64bytes[13];
            /////////////////////////////
            // MFTemp
            /////////////////////////////
            MFTemp_1 = DTA_Output_64bytes[14];
            MFTemp_2 = DTA_Output_64bytes[15];
        }
        private void StatusIM() // bereit
        {
            string StatusString = Convert.ToString(IMStatus, 2).PadLeft(8, '0');
            // jeder char aus dem String kann mit einem Signal verknüpft werden
            char _STANDBY = StatusString[7];
            char _READY = StatusString[6];
            char _BUSY = StatusString[5];
            char _FAULT = StatusString[4];
            //STANDBY=
            if (_STANDBY == '0')
            {
                STANDBY = false;
            }
            if (_STANDBY == '1')
            {
                STANDBY = true;
            }
            //READY=
            if (_READY == '0')
            {
                READY = false;
            }
            if (_READY == '1')
            {
                READY = true;
            }
            //BUSY=
            if (_BUSY == '0')
            {
                BUSY = false;
            }
            if (_BUSY == '1')
            {
                BUSY = true;
            }
            //FAULT=
            if (_FAULT == '0')
            {
                FAULT = false;
            }
            if (_FAULT == '1')
            {
                FAULT = true;
            }
        }
        private void StatusDTA()// bereit
        {
            string StatusString = Convert.ToString(DTAStatus, 2).PadLeft(8, '0');
            // jeder char aus dem String kann mit einem Signal verknüpft werden
            // muss noch geklärt werden!!!!!!!!!!
            //DRUCKLUFT_UEBERW=
            //MV_THERMOSCHALTER=
        }

        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: verwalteten Zustand (verwaltete Objekte) entsorgen.
                }

                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.

                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        // ~OPC_Read() {
        //   // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
        //   Dispose(false);
        // }

        // Dieser Code wird hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(true);
            // TODO: Auskommentierung der folgenden Zeile aufheben, wenn der Finalizer weiter oben überschrieben wird.
            // GC.SuppressFinalize(this);
        }
        #endregion


        //public void Dispose()
        //{
        //    ((IDisposable)OPC_Server).Dispose();
        //}
        //private double TemperaturUmrechnen(byte b1, byte b2)// bereit
        //{
        //    // jeder Temeraturwert besteht aus 2 bytes
        //    // es wird durch 10 dividiert
        //    double result = (0.1)*(b1 * 256 + b2 * 1);
        //    // Temperatur als double-wert zurückgeben
        //    return result;
        //}
        //private int AnzahlImpulse(byte b3, byte b4)
        //{
        //    int result = b3 * 256 + b4 * 1;
        //    // Temperatur als double-wert zurückgeben
        //    return result;
        //}
    }    
}
