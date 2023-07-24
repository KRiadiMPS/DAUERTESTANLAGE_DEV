/**********************************************************************************************************************
 * Namespace: UA_Client_1500                                                                                         *
 * Class    :                                                                                                *
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace MPS_DT_2020_V00
namespace UA_Client_1500
{
    public static class Berechnungen
    {
        /// <summary>
        /// Setzt ein bestimmtes Bit in einem Byte.
        /// </summary>
        /// <param name="b">Byte, welches bearbeitet werden soll.</param>
        /// <param name="BitNumber">Das zu setzende Bit (0 bis 7).</param>
        /// <returns>Ergebnis - Byte</returns>
        public static byte SetBit(byte b, int BitNumber)
        {
            //Kleine Fehlerbehandlung
            if (BitNumber < 8 && BitNumber > -1)
            {
                return (byte)(b | (byte)(0x01 << BitNumber));
            }
            else
            {
                throw new InvalidOperationException(
                "Der Wert für BitNumber " + BitNumber.ToString() + " war nicht im zulässigen Bereich! (BitNumber = (min)0 - (max)7)");
            }
        }
        public static byte ResetBit(byte byteValue, int BitNumber)
        {
            //intValue = intValue | (1 << bitPosition);  
            // intValue |= 1 << bitPosition;
            // intValue &= ~(1 << bitPosition);
            //int intValue = Convert.ToInt32(byteValue);
            int intValue = byteValue;
            intValue &= ~(1 << BitNumber);
            byte[] bValue = BitConverter.GetBytes(intValue);
            //intValue = intValue | (1 << 3);
            byte result = bValue[0];
            return result;
        }
        /// <summary>
        /// Prüft, ob ein angegebenes Bit im Byte gesetzt ist.
        /// </summary>
        /// <param name="b">Byte, welches getestet werden soll.</param>
        /// <param name="BitNumber">Das zu prüfende Bit (0 bis 7).</param>
        /// <returns>gesetzt=true, nicht gesetzt=false</returns>
        public static bool CheckBitSet(byte b, int BitNumber)
        {
            //Kleine Fehlerbehandlung
            if (BitNumber < 8 && BitNumber > -1)
            {
                return (b & (1 << BitNumber)) > 0;
            }
            else
            {
                throw new InvalidOperationException(
                "Der Wert für BitNumber " + BitNumber.ToString() + " war nicht im zulässigen Bereich! (BitNumber = (min)0 - (max)7)");
            }

        }
        public static byte SetBits(byte b, int BitNumber)
        {
            string StatusString = Convert.ToString(b, 2).PadLeft(8, '0');
            char SignalReady1 = StatusString[0];
            char SignalReady2 = StatusString[1];
            char SignalBusy1 = StatusString[2];
            char SignalBusy2 = StatusString[3];
            char SignallampeFault1 = StatusString[4];
            char SignallampeFault2 = StatusString[5];
            char Fehlerhupe1 = StatusString[6];
            char Fehlerhupe2 = StatusString[7];

            byte bb = 0;
            //bb[0] = true;




            return 0;
        }
        public static string TestDauerBerechnen(int AnzMessungen, int Takt)
        {
            string hh;
            string mm;
            string ss;
            // Takt in Sekunden
            int dauerInSekunden = Takt * AnzMessungen;
            int RestSekunden = dauerInSekunden % 60;// sekunden

            int dauerInMinuten = dauerInSekunden / 60;
            int RestMinuten = dauerInMinuten % 60; // minuten

            int DauerInStunden = dauerInMinuten / 60;// Stunden
            int RestStunden = DauerInStunden % 60;

            string Stunden = Convert.ToString(RestStunden);
            string Minuten = Convert.ToString(RestMinuten);
            string Sekunden = Convert.ToString(RestSekunden);



            if (RestSekunden < 10)
            {
                ss = "0" + Sekunden;
            }
            else
            {
                ss = Sekunden;
            }
            if (RestMinuten < 10)
            {
                mm = "0" + Minuten;
            }
            else
            {
                mm = Minuten;
            }
            if (RestStunden < 10)
            {
                hh = "0" + Stunden;
            }
            else
            {
                hh = Stunden;
            }



            string dauer = hh + ":" + mm + ":" + ss;
            return dauer;
        }

        public static double DurchnittlicheTakt(TimeSpan ts, int AnzImpulse)
        {
            int hh = ts.Hours;
            int mm = ts.Minutes;
            int ss = ts.Seconds;
            double result = 0;

            double anzSekunden = hh * 60 * 60 + mm * 60 + ss;

            if (AnzImpulse>0)
            {
                result = anzSekunden / AnzImpulse; 
            }

            return result;
        }
        public static double TemperaturUmrechnen(byte b1, byte b2)// bereit
        {
            // jeder Temeraturwert besteht aus 2 bytes
            // es wird durch 10 dividiert
            double result = (0.1) * (b1 * 256 + b2 * 1);
            // Temperatur als double-wert zurückgeben
            return result;
        }

        public static int AnzahlImpulse(byte b3, byte b4)
        {
            int result = b3 * 256 + b4 * 1;
            // Temperatur als double-wert zurückgeben
            return result;
        }
    }
}
