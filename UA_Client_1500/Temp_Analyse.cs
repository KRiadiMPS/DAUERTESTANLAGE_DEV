using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA_Client_1500
{
    class Temp_Analyse: IDisposable
    {
        //private double _T5;
        //private double _T6;
        //private double _T4_oben;
        //private double _T5_oben;
        //private double _RaumTemp;
        //private double _T4;
        //private double _AbluftTemp;
        //private double _MFTemp;

        private double _MaxTemp;
        private double _T5_max;
        private double _T6_max;
        private double _T4_oben_max;
        private double _T5_oben_max;
        private double _RaumTemp_max;
        private double _T4_max;
        private double _AbluftTemp_max;
        private double _MFTemp_max;

        public bool T5_exceeded;
        public bool T6_exceeded;
        public bool T4_oben_exceeded;
        public bool T5_oben_exceeded;
        public bool RaumTemp_exceeded;
        public bool T4_exceeded;
        public bool AbluftTemp_exceeded;
        public bool MFTemp_exceeded;

        public Temp_Analyse()
        {
            // max temperatur
            _T5_max = Convert.ToDouble(Containerklasse.T5_max);
            _T6_max = Convert.ToDouble(Containerklasse.T6_max);
            _T4_oben_max = Convert.ToDouble(Containerklasse.T4_oben_max);
            _T5_oben_max = Convert.ToDouble(Containerklasse.T5_oben_max);
            _RaumTemp_max = Convert.ToDouble(Containerklasse.RaumTemp_max);
            _T4_max = Convert.ToDouble(Containerklasse.T4_max);
            _AbluftTemp_max = Convert.ToDouble(Containerklasse.AbluftTemp_max);
            _MFTemp_max = Convert.ToDouble(Containerklasse.MFTemp_max);
        }

        public void TempAnalyse(double t5, double t6, double t4oben, double t5oben, double tRaum, double t4, double tAbluft, double tMF)
        {
            _T5_max = Convert.ToDouble(Containerklasse.T5_max);
            _T6_max = Convert.ToDouble(Containerklasse.T6_max);
            _T4_oben_max = Convert.ToDouble(Containerklasse.T4_oben_max);
            _T5_oben_max = Convert.ToDouble(Containerklasse.T5_oben_max);
            _RaumTemp_max = Convert.ToDouble(Containerklasse.RaumTemp_max);
            _T4_max = Convert.ToDouble(Containerklasse.T4_max);
            _AbluftTemp_max = Convert.ToDouble(Containerklasse.AbluftTemp_max);
            _MFTemp_max = Convert.ToDouble(Containerklasse.MFTemp_max);

            if (t5 > _T5_max)
            {
                T5_exceeded = true;
            }
            if (t6 > _T6_max)
            {
                T6_exceeded = true;
            }
            if (t4oben > _T4_oben_max)
            {
                T4_oben_exceeded = true;
            }
            if (t5oben > _T5_oben_max)
            {
                T5_oben_exceeded = true;
            }
            if (tRaum > _RaumTemp_max)
            {
                RaumTemp_exceeded = true;
            }
            if (t4 > _T4_max)
            {
                T4_exceeded = true;
            }
            if (tAbluft > _AbluftTemp_max)
            {
                AbluftTemp_exceeded = true;
            }
            if (tMF > _MFTemp_max)
            {
                MFTemp_exceeded = true;
            }
            // 
            if (t5 <= _MaxTemp)
            {
                T5_exceeded = false;
            }
            if (t6 <= _MaxTemp)
            {
                T6_exceeded = false;
            }
            if (t4oben <= _MaxTemp)
            {
                T4_oben_exceeded = false;
            }
            if (t5oben <= _MaxTemp)
            {
                T5_oben_exceeded = false;
            }
            if (tRaum <= _MaxTemp)
            {
                RaumTemp_exceeded = false;
            }
            if (t4 <= _MaxTemp)
            {
                T4_exceeded = false;
            }
            if (tAbluft <= _MaxTemp)
            {
                AbluftTemp_exceeded = false;
            }
            if (tMF <= _MaxTemp)
            {
                MFTemp_exceeded = false;
            }
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
