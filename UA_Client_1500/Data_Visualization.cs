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
 * -  Aufbereitung der Messwerte zur Visualisierung innerhalb des Windows.Charts  
 * -  Skalierung der Achsen, Zeitbasis (X-Achse), Abfrage der Eingabefelder für den Datenexport  
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

//namespace MPS_DT_2020_V00
namespace UA_Client_1500
{
    class Data_Visualization
    {

        private int _dauer_stunden;
        private int _dauer_minuten;
        private int _gesamtdauer_sekunden;
        private string _gesamtdauer_stunden_minuten;
        private string[] _gesamtdauer_hh_mm = new string[10000];  //init = 0;
        private int _anzahl_messungen;
        private int _abtastintervall_Temperatur;

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
        public Boolean _T1_Schaltzustand;
        public Boolean _T2_Schaltzustand;
        public Boolean _T3_Schaltzustand;
        private Boolean _T4_Schaltzustand;
        private Boolean _T5_Schaltzustand;
        private Boolean _T6_Schaltzustand;
        private Boolean _T7_Schaltzustand;
        private Boolean _T8_Schaltzustand;


        public string[] _Zeit /*= new string[1000]*/;
        public double[] _T1_Wert /*= new double[1000]*/;
        public double[] _T2_Wert /*= new double[1000]*/;
        public double[] _T3_Wert /*= new double[1000]*/;
        public double[] _T4_Wert /*= new double[1000]*/;
        public double[] _T5_Wert /*= new double[1000]*/;
        public double[] _T6_Wert /*= new double[1000]*/;
        public double[] _T7_Wert /*= new double[1000]*/;
        public double[] _T8_Wert /*= new double[1000]*/;

        private Series _Datenreihe1;
        private System.Windows.Forms.DataVisualization.Charting.Chart _Chart1;

        private int _count;

        private int _YaxisMAX;
        private double[] Temparray = new double[8];

        /*HIER DEKLARIEREUNG ZWEIER NEUER VARIABLEN FÜR DIE Y-ACHSEN SKALIERUNG, DG, 03.03.2021*/
        /***************************************************************************************/
        /***************************************************************************************/
        private int Letztes_YaxisMAX = 30;
        private int Neues_YaxisMAX = 30;
        /***************************************************************************************/
        /***************************************************************************************/
        /***************************************************************************************/
        private string _IM_AN;
        private string _IM_SN;
        private string _MF_AN;
        private string _MF_SN;



        public Data_Visualization()
        {
            //Variablen für Zeitbasis
            _dauer_stunden = 0;
            _dauer_minuten = 0;
            _gesamtdauer_sekunden = 0;
            _gesamtdauer_stunden_minuten = string.Empty;
            //_gesamtdauer_hh_mm = null;  //was überlegen
            _anzahl_messungen = 0;
            _abtastintervall_Temperatur = 0;
            //Weitere Variablen

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
            _T4_Schaltzustand = false;
            _T5_Schaltzustand = false;
            _T6_Schaltzustand = false;
            _T7_Schaltzustand = false;
            _T8_Schaltzustand = false;

            _IM_AN = string.Empty;
            _IM_SN = string.Empty;
            _MF_AN = string.Empty;
            _MF_SN = string.Empty;

            /*
            _T1_Wert = 0.0;
            _T2_Wert = 0.0;
            _T3_Wert = 0.0;
            _T4_Wert = 0.0;
            _T5_Wert = 0.0;
            _T6_Wert = 0.0;
            _T7_Wert = 0.0;
            _T8_Wert = 0.0;
            */

            _Datenreihe1 = null;
            _Chart1 = null;

            _count = 0;
            _YaxisMAX = 0;
            


        }

        public string gesamtdauer_hh_mm(int count)
        {
            try
            {
                _gesamtdauer_sekunden = _anzahl_messungen * _abtastintervall_Temperatur;
                TimeSpan span = new TimeSpan(0, 0, _gesamtdauer_sekunden);
                _dauer_stunden = span.Hours;
                _dauer_minuten = span.Minutes;
                _gesamtdauer_stunden_minuten = _dauer_stunden.ToString() + ":" + _dauer_minuten.ToString();
                Console.WriteLine(_gesamtdauer_stunden_minuten);
                _gesamtdauer_hh_mm[count] = _gesamtdauer_stunden_minuten;
                Console.WriteLine(_gesamtdauer_hh_mm[count]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Kovertierung der Zeitbasis [hh:mm] ist fehlerhaft", ex.ToString());
            }

            return _gesamtdauer_stunden_minuten;

        }

        public string TestDauerBerechnen(int AnzMessungen, int Takt)
        {
            // Takt in Sekunden
            int dauerInSekunden = Takt * AnzMessungen;
            int dauerInMinuten = dauerInSekunden / 60;
            int RestSekunden = dauerInSekunden % 60;// sekunden
            int DauerInStunden = dauerInMinuten / 60;// Stunden
            int RestMinuten = dauerInMinuten % 60; // minuten
            string Stunden; string Minuten; string Sekunden;

            if (DauerInStunden>=10)
            {
                 Stunden = Convert.ToString(DauerInStunden);
            }
            else
            {
                Stunden = "0" + Convert.ToString(DauerInStunden);
            }
            if (RestMinuten>=10)
            {
                Minuten = Convert.ToString(RestMinuten);
            }
            else
            {
                Minuten = "0" + Convert.ToString(RestMinuten);
            }
            if (RestSekunden>=10)
            {
                Sekunden = Convert.ToString(RestSekunden);
            }
            else
            {
                Sekunden = "0" + Convert.ToString(RestSekunden);
            }
            string dauer = Stunden + ":" + Minuten + ":" + Sekunden;
            return dauer;
        }
        public string TestDauerhhmm(int AnzMessungen, int Takt)
        {
            // Takt in Sekunden
            int dauerInSekunden = Takt * AnzMessungen;
            int dauerInMinuten = dauerInSekunden / 60;
            int RestSekunden = dauerInSekunden % 60;// sekunden
            int DauerInStunden = dauerInMinuten / 60;// Stunden
            int RestMinuten = dauerInMinuten % 60; // minuten
            string Stunden; string Minuten; string Sekunden;

            if (DauerInStunden >= 10)
            {
                Stunden = Convert.ToString(DauerInStunden);
            }
            else
            {
                Stunden = "0" + Convert.ToString(DauerInStunden);
            }
            if (RestMinuten >= 10)
            {
                Minuten = Convert.ToString(RestMinuten);
            }
            else
            {
                Minuten = "0" + Convert.ToString(RestMinuten);
            }
            if (RestSekunden >= 10)
            {
                Sekunden = Convert.ToString(RestSekunden);
            }
            else
            {
                Sekunden = "0" + Convert.ToString(RestSekunden);
            }
            string dauer = Stunden + ":" + Minuten;
            return dauer;
        }
        public void AutoCompletionMF(int SelectedIndex)
        {
            try
            {
                if (Convert.ToInt16(SelectedIndex) > -1)
                {

                    switch (SelectedIndex.ToString())
                    {
                        case "0":
                            _MF_AN = "-";
                            _MF_SN = "-";
                            break;
                        case "1":
                            _MF_AN = "-";
                            _MF_SN = "100098";
                            break;
                        case "2":
                            _MF_AN = "8917010";
                            _MF_SN = "129966";
                            break;
                        case "3":
                            _MF_AN = "91020075";
                            _MF_SN = "-";
                            break;
                        case "4":
                            _MF_AN = "1003225";
                            _MF_SN = "114647";
                            break;
                        case "5":
                            _MF_AN = "8917055";
                            _MF_SN = "121921";
                            break;
                        case "6":
                            _MF_AN = "100332";
                            _MF_SN = "100097";
                            break;
                        case "7":
                            _MF_AN = "100331";
                            _MF_SN = "103530";
                            break;
                        case "8":
                            _MF_AN = "251982";
                            _MF_SN = "110839";
                            break;
                        case "9":
                            _MF_AN = "220227";
                            _MF_SN = "106719";
                            break;
                        case "10":
                            _MF_AN = "91100015";
                            _MF_SN = "-";
                            break;
                        case "11":
                            _MF_AN = "91030009";
                            _MF_SN = "-";
                            break;
                        case "12":
                            _MF_AN = "240434";
                            _MF_SN = "110690";
                            break;
                        case "13":
                            _MF_AN = "1000330";
                            _MF_SN = "112204";
                            break;
                        case "14":
                            _MF_AN = "201316";
                            _MF_SN = "-";
                            break;
                        case "15":
                            _MF_AN = "93071045";
                            _MF_SN = "-";
                            break;
                        case "16":
                            _MF_AN = "100331";
                            _MF_SN = "103527";
                            break;
                        case "17":
                            _MF_AN = "93071041";
                            _MF_SN = "-";
                            break;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Auto-Ergänzung für den MF-Artikel ist fehlerhaft", ex.ToString());
            }


        }



        public void AutoCompletionIM(int SelectedIndex)
        {

            try
            {
                if (Convert.ToInt16(SelectedIndex) > -1)
                {
                    switch (SelectedIndex.ToString())
                    {
                        case "0":
                            _IM_AN = "8331001";
                            _IM_SN = "131828";
                            break;
                        case "1":
                            _IM_AN = "8331004";
                            _IM_SN = "131829";
                            break;
                        case "2":
                            _IM_AN = "8200002";
                            _IM_SN = "107822";
                            break;
                        case "3":
                            _IM_AN = "8231006";
                            _IM_SN = "130043";
                            break;
                        case "4":
                            _IM_AN = "8200153";
                            _IM_SN = "112206";
                            break;
                        case "5":
                            _IM_AN = "8400040";
                            _IM_SN = "121192";
                            break;
                        case "6":
                            _IM_AN = "8630999";
                            _IM_SN = "130215";
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Auto-Ergänzung für den IM-Artikel ist fehlerhaft", ex.ToString());
            }


        }


        public void CreateDatenreihe()
        {
            int linienbreite = 3;

            try
            {

                Series Datenreihe1 = new Series();
                {
                    Datenreihe1.Name = _T1_Name;
                    Datenreihe1.ChartType = SeriesChartType.FastLine;
                    Datenreihe1.XValueType = ChartValueType.String;
                    Datenreihe1.YValueType = ChartValueType.Double;
                    Datenreihe1.Color = Color.Red;
                    Datenreihe1.BorderWidth = linienbreite;
                    _Chart1.Series.Add(Datenreihe1);

                }

                Series Datenreihe2 = new Series();
                {
                    Datenreihe2.Name = _T2_Name;
                    Datenreihe2.ChartType = SeriesChartType.FastLine;
                    Datenreihe2.XValueType = ChartValueType.String;
                    Datenreihe2.YValueType = ChartValueType.Double;
                    Datenreihe2.Color = Color.Green;
                    Datenreihe2.BorderWidth = linienbreite;
                    _Chart1.Series.Add(Datenreihe2);

                }

                Series Datenreihe3 = new Series();
                {
                    Datenreihe3.Name = _T3_Name;
                    Datenreihe3.ChartType = SeriesChartType.FastLine;
                    Datenreihe3.XValueType = ChartValueType.String;
                    Datenreihe3.YValueType = ChartValueType.Double;
                    Datenreihe3.Color = Color.Blue;
                    Datenreihe3.BorderWidth = linienbreite;
                    _Chart1.Series.Add(Datenreihe3);
                }

                if (_T4_Schaltzustand == true)
                {
                    Series Datenreihe4 = new Series();
                    {
                        Datenreihe4.Name = _T4_Name;
                        Datenreihe4.ChartType = SeriesChartType.FastLine;
                        Datenreihe4.XValueType = ChartValueType.String;
                        Datenreihe4.YValueType = ChartValueType.Double;
                        Datenreihe4.Color = Color.Magenta;
                        Datenreihe4.BorderWidth = linienbreite;
                        _Chart1.Series.Add(Datenreihe4);
                    }
                }

                if (_T5_Schaltzustand == true)
                {
                    Series Datenreihe5 = new Series();
                    {
                        Datenreihe5.Name = _T5_Name;
                        Datenreihe5.ChartType = SeriesChartType.FastLine;
                        Datenreihe5.XValueType = ChartValueType.String;
                        Datenreihe5.YValueType = ChartValueType.Double;
                        Datenreihe5.Color = Color.Turquoise;
                        Datenreihe5.BorderWidth = linienbreite;
                        _Chart1.Series.Add(Datenreihe5);
                    }
                }

                if (_T6_Schaltzustand == true)
                {
                    Series Datenreihe6 = new Series();
                    {
                        Datenreihe6.Name = _T6_Name;
                        Datenreihe6.ChartType = SeriesChartType.FastLine;
                        Datenreihe6.XValueType = ChartValueType.String;
                        Datenreihe6.YValueType = ChartValueType.Double;
                        Datenreihe6.Color = Color.Black;
                        Datenreihe6.BorderWidth = linienbreite;
                        _Chart1.Series.Add(Datenreihe6);
                    }
                }

                if (_T7_Schaltzustand == true)
                {
                    Series Datenreihe7 = new Series();
                    {
                        Datenreihe7.Name = _T7_Name;
                        Datenreihe7.ChartType = SeriesChartType.FastLine;
                        Datenreihe7.XValueType = ChartValueType.String;
                        Datenreihe7.YValueType = ChartValueType.Double;
                        Datenreihe7.Color = Color.Black;
                        Datenreihe7.BorderWidth = linienbreite;
                        _Chart1.Series.Add(Datenreihe7);
                    }
                }

                if (_T8_Schaltzustand == true)
                {
                    Series Datenreihe8 = new Series();
                    {
                        Datenreihe8.Name = _T8_Name;
                        Datenreihe8.ChartType = SeriesChartType.FastLine;
                        Datenreihe8.XValueType = ChartValueType.String;
                        Datenreihe8.YValueType = ChartValueType.Double;
                        Datenreihe8.Color = Color.Orange;
                        Datenreihe8.BorderWidth = linienbreite;
                        _Chart1.Series.Add(Datenreihe8);
                    }
                }

            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die Datenreihen konnten nicht erstellt werden.", ex.ToString());
            }

            //return _gesamtdauer_stunden_minuten;

        }

        public void BefüllungDatenreihen()
        {
            try
            {
                _Chart1.ChartAreas[0].AxisX.Minimum = 0;
                _Chart1.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(_count + 1.0);
                _Chart1.ChartAreas[0].AxisX.Title = "Zeit [hh:mm]";
                _Chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

                //**************************************************************************************************************//
                //Ab hier Y-Achsenskalierung mit u.a. Lösung von PP angepasst zum testen!!! , DG am 10.02.2021//
                //wieder auf Maximum 110 festgelegt, DG 24.02.2021. Automatische Lösung hat nicht funktioniert //
                //**************************************************************************************************************//
                //**************************************************************************************************************//
                //**************************************************************************************************************//
                _Chart1.ChartAreas[0].AxisY.Minimum = 10;
                // _Chart1.ChartAreas[0].AxisY.Maximum = 110;                                       
                if (_count < 1)
                {
                    Temparray[0] = 0;
                    Temparray[1] = 0;
                    Temparray[2] = 0;
                    Temparray[3] = 0;
                    Temparray[4] = 0;
                    Temparray[5] = 0;
                    Temparray[6] = 0;
                    Temparray[7] = 0;
                }
                else
                {
                    if (_T1_Schaltzustand == false){Temparray[0] = 1;}
                    else{Temparray[0] = Containerklasse._T1_Wert[_count];}
                    if (_T2_Schaltzustand == false)
                    {
                        Temparray[1] = 1;
                    }
                    else { Temparray[1] = Containerklasse._T2_Wert[_count]; }
                    if (_T3_Schaltzustand == false)
                    {
                        Temparray[2] = 1;
                    }
                    else { Temparray[2] = Containerklasse._T3_Wert[_count]; }

                    if (_T4_Schaltzustand == false)
                    {
                        Temparray[3] = 1;
                    }
                    else
                    {
                        Temparray[3] = Containerklasse._T4_Wert[_count];
                    }

                    if (_T5_Schaltzustand == false)
                    {
                        Temparray[4] = 1;
                    }
                    else
                    {
                        Temparray[4] = Containerklasse._T5_Wert[_count];
                    }

                    if (_T6_Schaltzustand == false)
                    {
                        Temparray[5] = 1;
                    }
                    else
                    {
                        Temparray[5] = Containerklasse._T6_Wert[_count];
                    }

                    if (_T7_Schaltzustand == false)
                    {
                        Temparray[6] = 1;
                    }
                    else
                    {
                        Temparray[6] = Containerklasse._T7_Wert[_count];
                    }

                    if (_T8_Schaltzustand == false)
                    {
                        Temparray[7] = 1;
                    }
                    else
                    {
                        Temparray[7] = Containerklasse._T8_Wert[_count];
                    }

                    _YaxisMAX = Convert.ToInt32(Temparray.DefaultIfEmpty(0).Max()); //SCHLIESST 0 WERTE AUS - SONST EXCEPTION!!!

                    if (_YaxisMAX > Letztes_YaxisMAX)
                    {
                        Neues_YaxisMAX = _YaxisMAX;
                        Letztes_YaxisMAX = _YaxisMAX;
                    }
                    else
                    {
                        Neues_YaxisMAX = Letztes_YaxisMAX;
                    }
                }             
                _Chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Neues_YaxisMAX) + 10; //Convert.ToInt32(_count + 5); //Anpassen an maximal gemessene Temperatur
                _Chart1.ChartAreas[0].AxisY.Title = "Temperatur [°C]";
                _Chart1.ChartAreas[0].AxisY.Interval = 5;
                //**************************************************************************************************************//
                //**************************************************************************************************************//
                //**************************************************************************************************************//
                //**************************************************************************************************************//


                //Vorlage   _Zeit
                //chart1.Series["RaumTemp"].Points.DataBindXY(Visualisierung.Dauer_hh_mm, yval1);
                if (_T1_Schaltzustand == true)
                {
                    _Chart1.Series[_T1_Name].Points.DataBindXY(Containerklasse._Zeit, Containerklasse._T1_Wert); 
                }

                if (_T2_Schaltzustand == true)
                {
                    _Chart1.Series[_T2_Name].Points.DataBindXY(Containerklasse._Zeit, Containerklasse._T2_Wert); 
                }

                if (_T3_Schaltzustand == true)
                {
                    _Chart1.Series[_T3_Name].Points.DataBindXY(Containerklasse._Zeit, Containerklasse._T3_Wert);  
                }               

                //_Chart1.Series[_T1_Name].Points.DataBindXY(_gesamtdauer_hh_mm, _T1_Wert);
                //_Chart1.Series[_T2_Name].Points.DataBindXY(_gesamtdauer_hh_mm, _T2_Wert);
                //_Chart1.Series[_T3_Name].Points.DataBindXY(_gesamtdauer_hh_mm, _T3_Wert);
                if (_T4_Schaltzustand == true)
                {
                    _Chart1.Series[_T4_Name].Points.DataBindXY(Containerklasse._Zeit, Containerklasse._T4_Wert);
                }
                if (_T5_Schaltzustand == true)
                {
                    _Chart1.Series[_T5_Name].Points.DataBindXY(Containerklasse._Zeit, Containerklasse._T5_Wert);
                }
                if (_T6_Schaltzustand == true)
                {
                    _Chart1.Series[_T6_Name].Points.DataBindXY(Containerklasse._Zeit, Containerklasse._T6_Wert);
                }
                if (_T7_Schaltzustand == true)
                {
                    _Chart1.Series[_T7_Name].Points.DataBindXY(Containerklasse._Zeit, Containerklasse._T7_Wert);
                }
                if (_T8_Schaltzustand == true)
                {
                    _Chart1.Series[_T8_Name].Points.DataBindXY(Containerklasse._Zeit, Containerklasse._T8_Wert);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Fehler beim Schreiben der Temperaturdaten. Temperaturbezeichnung fehlt?", ex.ToString());
            }
        }

        //ALTE ACHSENSKALIERUNGSFUNKTION - WIRD NICHT VERWENDET
      /*  public void AchsenskalierungDatenreihen()
        {
            try
            {
                /*
                _Chart1.ChartAreas[0].AxisX.Minimum = 0;
                //_Chart1.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(_count + 1.0);
                _Chart1.ChartAreas[0].AxisX.Title = "Zeit [hh:mm]";
                _Chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

                //Logik hinterlegen für dynamische Skalierung der Y-Achse.
                //_YaxisMAX
                Temparray[0] = _T1_Wert[_count];
                Temparray[1] = _T2_Wert[_count];
                Temparray[2] = _T3_Wert[_count];
                Temparray[3] = _T4_Wert[_count];
                Temparray[4] = _T5_Wert[_count];
                Temparray[5] = _T6_Wert[_count];
                Temparray[6] = _T7_Wert[_count];
                Temparray[7] = _T8_Wert[_count];
                _YaxisMAX = Convert.ToInt32(Temparray.Max());

                if (_YaxisMAX < 30)
                {
                    _YaxisMAX = 25;
                }

                //PP: Y-Achse Temperatur
                _Chart1.ChartAreas[0].AxisY.Minimum = 20;
                _Chart1.ChartAreas[0].AxisY.Maximum = _YaxisMAX + 5; //(Convert.ToInt32(yval1[count]) + 5); //Anpassen an maximal gemessene Temperatur
                _Chart1.ChartAreas[0].AxisY.Title = "Temperatur [°C]";

            
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die Achsenskalierung konnte nicht vorgenommen werden", ex.ToString());
            }

        } */

        public void xAchseAktualisieren(int count)
        {
            _Zeit = new string[count];
            _T1_Wert = new double[count];
            _T2_Wert = new double[count];
            _T3_Wert = new double[count];
            _T4_Wert = new double[count];
            _T5_Wert = new double[count];
            _T6_Wert = new double[count];
            _T7_Wert = new double[count];
            _T8_Wert = new double[count];

        }
        public void AktualisierungDatenreihen()
        {
            try
            {
                _Chart1.Update();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die Datenreihen konnte nicht aktualisiert werden", ex.ToString());
            }
        }


        public string DatumGUI()
        {
            try
            {
                DateTime _dt = DateTime.Now;
                string date = _dt.ToString("g");
                return date;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Das aktuelle Datum kann nicht visualisiert werden", ex.ToString());
                return "Space is only noise";
            }
        }


        public string StatusGUI(int state)
        {
            try
            {
                switch (state)
                {
                    case 1:
                        return "READY";
                        break;
                    case 2:
                        return "BUSY";
                        break;
                    case 3:
                        return "ERROR";
                        break;
                    case 4:
                        return "IM OFF";
                        break;
                    default:
                        return "STATUS";
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Die Zustansausgabe ist fehlerhaft", ex.ToString());
                return "FF";
            }
        }



        public System.Windows.Forms.DataVisualization.Charting.Chart Diagrammname
        {
            set { _Chart1 = value; }
        }


        public int Abtastintervall_Temperatur
        {
            get { return _abtastintervall_Temperatur; }
            set { _abtastintervall_Temperatur = value; }
        }

        public int Anzahl_Messungen_Temperatur
        {
            get { return _anzahl_messungen; }
            set { _anzahl_messungen = value; }
        }

        public string[] Dauer_hh_mm
        {
            get { return _gesamtdauer_hh_mm; }
        }

        /*
        public object[][] GUIwerte2Visualization
        {
            get { return _GUIwerte; }
            set { _GUIwerte = value; }
        }
        */
        
        public string T1Name
        {
            set { _T1_Name = value; }
        }

        public string T1Max
        {
            set { _T1_MAX = value; }
        }

        public string T2Name
        {
            set { _T2_Name = value; }
        }

        public string T2Max
        {
            set { _T2_MAX = value; }
        }

        public string T3Name
        {
            set { _T3_Name = value; }
        }

        public string T3Max
        {
            set { _T3_MAX = value; }
        }

        public string T4Name
        {
            set { _T4_Name = value; }
        }

        public string T4Max
        {
            set { _T4_MAX = value; }
        }

        public Boolean T4Schaltzustand
        {
            set { _T4_Schaltzustand = value; }
        }

        public string T5Name
        {
            set { _T5_Name = value; }
        }

        public string T5Max
        {
            set { _T5_MAX = value; }
        }

        public Boolean T5Schaltzustand
        {
            set { _T5_Schaltzustand = value; }
        }

        public string T6Name
        {
            set { _T6_Name = value; }
        }

        public string T6Max
        {
            set { _T6_MAX = value; }
        }

        public Boolean T6Schaltzustand
        {
            set { _T6_Schaltzustand = value; }
        }
        public string T7Name
        {
            set { _T7_Name = value; }
        }

        public string T7Max
        {
            set { _T7_MAX = value; }
        }

        public Boolean T7Schaltzustand
        {
            set { _T7_Schaltzustand = value; }
        }

        public string T8Name
        {
            set { _T8_Name = value; }
        }

        public string T8Max
        {
            set { _T8_MAX = value; }
        }

        public Boolean T8Schaltzustand
        {
            set { _T8_Schaltzustand = value; }
        }
        // Messdaten
        //public string[] Zeit
        //{
        //    set { _Zeit = value; }
        //}
        //public double[] T1yWert
        //{
        //    set { _T1_Wert = value; }
        //}

        //public double[] T2yWert
        //{
        //    set { _T2_Wert = value; }
        //}

        //public double[] T3yWert
        //{
        //    set { _T3_Wert = value; }
        //}

        //public double[] T4yWert
        //{
        //    set { _T4_Wert = value; }
        //}

        //public double[] T5yWert
        //{
        //    set { _T5_Wert = value; }
        //}

        //public double[] T6yWert
        //{
        //    set { _T6_Wert = value; }
        //}

        //public double[] T7yWert
        //{
        //    set { _T7_Wert = value; }
        //}

        //public double[] T8yWert
        //{
        //    set { _T8_Wert = value; }
        //}


        public int count
        {
            set { _count = value; }
        }

        public string IM_Artikelnummer
        {
            get { return _IM_AN; }
        }

        public string IM_Seriennummer
        {
            get { return _IM_SN; }
        }

        public string MF_Artikelnummer
        {
            get { return _MF_AN; }
        }

        public string MF_Seriennummer
        {
            get { return _MF_SN; }
        }


    }
}