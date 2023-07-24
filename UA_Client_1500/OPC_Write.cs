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
    class OPC_Write:IDisposable
    {
        //DaServerMgt OPC_Server = new DaServerMgt();

        public OPC_Write()
        {
            //--> OPC-Server-object aus dem Containerklasse hollen
            //OPC_Server = Containerklasse.opcServer;

            //--> im bus schreiben
            //OPCWrite();
        }
        public void OPCWrite()
        {
            //ItemValue[] itemValues = new ItemValue[64];

            //// --> items erzeugen und mit 0 füllen
            //for (int i = 0; i < 64; i++)
            //{
            //    itemValues[i] = new ItemValue
            //    {
            //        Value = 0
            //    };
            //}

            //// --> items mit den zu übertragenen Werten füllen
            //itemValues[0].Value = Containerklasse.IMSTEUERN;
            //itemValues[2].Value = Containerklasse.AMPELHUPE;
            //itemValues[4].Value = Containerklasse.RESETCOUNTER;

            //// --> auf Bus schreiben
            //try
            //{
            //    //Containerklasse.opcServer.Write(ref OPC_Connection.itemIdentifiersOutput, itemValues);
            //}
            //catch (Exception)
            //{
            //    //throw;
            //}
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
    }
}
