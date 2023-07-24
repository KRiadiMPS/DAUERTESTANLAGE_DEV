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
 * - Dauertest Document  
 * - Dauertest logo
 * - Dauertest chart
 * - Dauertest infos
 * - Formatierung der PDF-Datei
 **********************************************************************************************************************/

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
//namespace MPS_DT_2020_V00
namespace UA_Client_1500
{    
    public static class PDFCreator
    {
        public static object[][] guiValuesPdf;

        public static string _datum;
        public static string _bearbeiter;
        public static void CreateReport_PDF()
        {
            //--> style
            Styling stl = new Styling();
            /////////////////////////////////////////////
            // Dauertest Document
            //------------------------------------------------------------------------
            /////////////////////////////////////////////
            // --> create pdf-doc
            PdfDocument docPdf = new PdfDocument();
            XSize size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4); // 842, 595
            //--> Add page to pdf-doc
            PdfPage pagePdf = docPdf.AddPage(); //--> //595  842
            //--> Add grafic to pdf-page in pdf-doc
            XGraphics xgr = XGraphics.FromPdfPage(pagePdf);
            //------------------------------------------------------------------------
            //--> Create and place image of logo
            /////////////////////////////////////////////
            // Dauertest logo
            //------------------------------------------------------------------------
            ///////////////////////////////////////////// 
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            //XImage logo = XImage.FromFile("C:\\Users\\Khalid Riadi\\Desktop\\Aktuelles\\MPS-DT-2020_V01\\bilder\\MPS_Logo_CMYK_Claim.jpg");
            XImage logo = XImage.FromFile(path+ "\\MPS_Logo_HKS47K.png");

            double pwl = logo.PixelWidth;//2373
            double phl = logo.PixelHeight;//483
            double hrl = logo.HorizontalResolution;//300
            double vrl = logo.VerticalResolution;//300

            xgr.DrawImage(logo, 62, 24, pwl*0.02, phl*0.02);

            DateTime _dt = DateTime.Now;
            string datePdfOben = _dt.ToString("g");
            

            //--> Create and place image of chart
            /////////////////////////////////////////////
            // Dauertest chart
            //------------------------------------------------------------------------
            ///////////////////////////////////////////// 
            //XImage chart = XImage.FromFile("C:\\Users\\Khalid Riadi\\Desktop\\Aktuelles\\MPS-DT-2020_V02\\bilder\\ChartTest.png");

            XImage chart = XImage.FromFile(Containerklasse.imgChartPfad);


            /******************************************** Raus kommentiert zum Testen einer EMF Einbindung in die PDF **********************************/
            /************************ 12.03.2021 ********************/
            //XImage chart = XImage.FromFile(Containerklasse.pdfPfad + "\\Testgraph.pdf");
            /*******************************************************************************************************************************************/

            



            double pw = chart.PixelWidth;//543 von 595
            double ph = chart.PixelHeight;//345 von 842
            double hr = chart.HorizontalResolution;//95.986602783203125
            double vr = chart.VerticalResolution;//95.986602783203125

            double BreiteNeu = pw * 0.45;
            double LaengeNeu = ph * 0.45;

            double RandLinks = 0.05 * size.Width ;
            double PosUnten = size.Height - 0.05 * size.Height;

            xgr.DrawImage(chart, RandLinks, 525, BreiteNeu, LaengeNeu); //407; 258
            /////////////////////////////////////////////
            // Dauertest infos
            //------------------------------------------------------------------------
            ///////////////////////////////////////////// 
            int rand = 60;
            int startEintrag = 200;
            int Hoehe = 100;
            int AbstandNextZeile = 15;
            //Aktuelles Datum und Uhrzeit
            xgr.DrawString(datePdfOben, stl.fontStd, XBrushes.Black, rand+400, 45);
            //Titel:
            xgr.DrawString("Dauertest " + Containerklasse.pdfTestobjekt + " - " + stl.BA + Containerklasse.pdfBetriebsauftrag, stl.fontTitel, XBrushes.Black, rand, 80);
            //xgr.DrawString(Containerklasse.pdfBetriebsauftrag, stl.fontTitel, XBrushes.Black, 160, 80);
            xgr.DrawString("Allgemeine Informationen", stl.fontAbschnitt, XBrushes.Black, rand, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            // Datum:
            xgr.DrawString(stl.ErzeugtAm, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfDatum, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Testobjekt:
            xgr.DrawString(stl.Testobjekt, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfTestobjekt, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Projekt Nr.:
            xgr.DrawString(stl.ProjektNr, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfProjektNr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Proj. Verantwortlicher:
            xgr.DrawString(stl.PVpv, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfPVpv, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Bearbeiter:
            xgr.DrawString(stl.Bearbeiter, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfBearbeiter, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //IM Art. Nr.:
            xgr.DrawString(stl.ArtikelNrIM, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfIMArtikelNr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //IM Ser. Nr.:
            xgr.DrawString(stl.SerienNrIM, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfIMSerienNr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //MF Art. Nr.:
            xgr.DrawString(stl.ArtikelNrMF, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfMFArtikelNr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //MF Ser. Nr.:
            xgr.DrawString(stl.SerienNrMF, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfMFSerienNr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile+2;
            //Ab hier technische TestParameter
            xgr.DrawString("Testparameter und gemessene Werte", stl.fontAbschnitt, XBrushes.Black, rand, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Ladespannung:
            xgr.DrawString(stl.Spannung, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfSpannung, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Magnetisierstrom:
            xgr.DrawString(stl.MagStrom, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfMagnetiStrom, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Energie:
            xgr.DrawString(stl.Energie, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfEnergie, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Dauerleistung
            xgr.DrawString(stl.Dauerleistung, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfDauerleistung, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Kuehlung
            xgr.DrawString(stl.Kuehlung, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfKuehlung, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Bemerkung
            xgr.DrawString(stl.Bemerkung, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfBemerkung, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Taktzeit
            xgr.DrawString(stl.Taktzeit, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfTaktzeit, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Testdauer
            xgr.DrawString(stl.Testdauer, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfTestdauer, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Anzahl Impulse
            xgr.DrawString(stl.ImpulseAnz, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.pdfAnzahlImpulse, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            //Taktzeit Errechnet
            xgr.DrawString(stl.TaktzeitErr, stl.fontStd, XBrushes.Black, rand, Hoehe);
            xgr.DrawString(Containerklasse.DurchnittTaktzeit, stl.fontStd, XBrushes.Black, startEintrag, Hoehe); Hoehe = Hoehe + AbstandNextZeile+5;
            xgr.DrawString(stl.Linie, stl.fontStd, XBrushes.Black,
              new XRect(0, Hoehe-20, pagePdf.Width, pagePdf.Height),
              XStringFormats.TopCenter);
            //Maximalwerte Temperaturen            
            double T1_reportMaximum = 0;
            double T2_reportMaximum = 0;
            double T3_reportMaximum = 0;
            double T4_reportMaximum = 0;
            double T5_reportMaximum = 0;
            double T6_reportMaximum = 0;
            double T7_reportMaximum = 0;
            double T8_reportMaximum = 0;
            if (Containerklasse._T1_Wert != null)
            {
               T1_reportMaximum = Containerklasse._T1_Wert.Max();
                if (T1_reportMaximum > 1000) { T1_reportMaximum = 0; }
            }
            else
            {
                T1_reportMaximum = 0;
            }
            if (Containerklasse._T2_Wert != null)
            {
                T2_reportMaximum = Containerklasse._T2_Wert.Max();
                if (T2_reportMaximum > 1000) { T2_reportMaximum = 0; }
            }
            else
            {
                T2_reportMaximum = 0;
            }
            if (Containerklasse._T3_Wert != null)
            {
                T3_reportMaximum = Containerklasse._T3_Wert.Max();
                if (T3_reportMaximum > 1000) { T3_reportMaximum = 0; }
            }
            else
            {
                T3_reportMaximum = 0;
            }
            if (Containerklasse._T4_Wert != null)
            {
                T4_reportMaximum = Containerklasse._T4_Wert.Max();
                if (T4_reportMaximum > 1000) { T4_reportMaximum = 0; }
            }
            else
            {
                T4_reportMaximum = 0;
            }
            if (Containerklasse._T5_Wert != null)
            {
                T5_reportMaximum = Containerklasse._T5_Wert.Max();
                if (T5_reportMaximum > 1000) { T5_reportMaximum = 0; }
            }
            else
            {
                T5_reportMaximum = 0;
            }
            if (Containerklasse._T6_Wert != null)
            {
                T6_reportMaximum = Containerklasse._T6_Wert.Max();
                if (T6_reportMaximum > 1000) { T6_reportMaximum = 0; }
            }
            else
            {
                T6_reportMaximum = 0;
            }
            if (Containerklasse._T7_Wert != null)
            {
                T7_reportMaximum = Containerklasse._T7_Wert.Max();
                if (T7_reportMaximum > 1000) { T7_reportMaximum = 0; }
            }
            else
            {
                T7_reportMaximum = 0;
            }
            if (Containerklasse._T8_Wert != null)
            {
                T8_reportMaximum = Containerklasse._T8_Wert.Max();
                if (T8_reportMaximum > 1000) { T8_reportMaximum = 0; }
            }
            else
            {
                T8_reportMaximum = 0;
            }

            string MaxT1ReportStr = Containerklasse.pdfT1Name + ": " + T1_reportMaximum;
            string MaxT2ReportStr = Containerklasse.pdfT2Name + ": " + T2_reportMaximum;
            string MaxT3ReportStr = Containerklasse.pdfT3Name + ": " + T3_reportMaximum;
            string MaxT4ReportStr = Containerklasse.pdfT4Name + ": " + T4_reportMaximum;
            string MaxT5ReportStr = Containerklasse.pdfT5Name + ": " + T5_reportMaximum;
            string MaxT6ReportStr = Containerklasse.pdfT6Name + ": " + T6_reportMaximum;
            string MaxT7ReportStr = Containerklasse.pdfT7Name + ": " + T7_reportMaximum;
            string MaxT8ReportStr = Containerklasse.pdfT8Name + ": " + T8_reportMaximum;
            
            
            xgr.DrawString(stl.Maximalwerte, stl.fontStd, XBrushes.Black, rand, Hoehe+5);Hoehe = Hoehe + 5;
            xgr.DrawString(MaxT1ReportStr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe);
            xgr.DrawString(MaxT2ReportStr, stl.fontStd, XBrushes.Black, startEintrag+150, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            xgr.DrawString(MaxT3ReportStr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe);
            xgr.DrawString(MaxT4ReportStr, stl.fontStd, XBrushes.Black, startEintrag + 150, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            xgr.DrawString(MaxT5ReportStr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe);
            xgr.DrawString(MaxT6ReportStr, stl.fontStd, XBrushes.Black, startEintrag + 150, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            xgr.DrawString(MaxT7ReportStr, stl.fontStd, XBrushes.Black, startEintrag, Hoehe);
            xgr.DrawString(MaxT8ReportStr, stl.fontStd, XBrushes.Black, startEintrag + 150, Hoehe); Hoehe = Hoehe + AbstandNextZeile;
            

            /////////////////////////////////////////////
            // Linien (zwischenlinien)
            //------------------------------------------------------------------------
            ///////////////////////////////////////////// 
            // 
            xgr.DrawString(stl.Linie, stl.fontStd, XBrushes.Black,
              new XRect(0, 40, pagePdf.Width, pagePdf.Height),
              XStringFormats.TopCenter);

            xgr.DrawString(stl.Linie, stl.fontStd, XBrushes.Black,
              new XRect(0, Hoehe, pagePdf.Width, pagePdf.Height),
              XStringFormats.TopCenter);

            //docPdf.Save("C:\\Users\\Khalid Riadi\\Desktop\\Aktuelles\\MPS-DT-2020_V01\\bilder\\test1.pdf");
            //docPdf.Close();
            //Process.Start("C:\\Users\\Khalid Riadi\\Desktop\\Aktuelles\\MPS-DT-2020_V01\\bilder\\test1.pdf");

            docPdf.Save(Containerklasse.pdfDocPfad);
            docPdf.Close();
            try
            {
                Process.Start(Containerklasse.pdfDocPfad);
            }
            catch (Exception)
            {
                MessageBox.Show("Der Report wurde NICHT erstellt werden.");
            }

            //MessageBox.Show("Der Report wurde erfolgreich erstellt werden.");
        }
        public static void EintraegeFuellen()
        {



            //Projektnummer.Text,
            //PVpv.Text, 
            //BA.Text,

            //IM_AName.Text,
            //MF_AN.Text,
            //MF_SN.Text,
            //MF_AName.Text,
            //IM_AN.Text,
            //IM_SN.Text,
            //U_IM.Text,
            //I_MAG.Text,
            //energie.Text,
            //P_Dauer.Text,
            //kuhlungsart.Text,
            //sonstBemerkungen.Text,
            //Taktzeitvorgabe.Text,
            //Testzeitvorgabe.Text,
            //RG_Kühlung.Checked.ToString(),
            //Druckluft_Kuhlung.Checked.ToString(),
            //T1_Name.Text,
            //T1_MAX.Text,
            //T2_Name.Text,
            //T2_MAX.Text,
            //T3_Name.Text,
            //T3_MAX.Text,
            //T4_checkBox.Checked.ToString(),
            //T4_Name.Text,
            //T4_MAX.Text,
            //T5_checkBox.Checked.ToString(),
            //T5_Name.Text,
            //T5_MAX.Text,
            //T6_checkBox.Checked.ToString(),
            //T6_Name.Text,
            //T6_MAX.Text,
            //T7_checkBox.Checked.ToString(),
            //T7_Name.Text,
            //T7_MAX.Text,
            //T8_checkBox.Checked.ToString(),
            //T8_Name.Text,
            //T8_MAX.Text,
            //IMon_Override.Checked.ToString(),
            //Testobjekt.Text
        }
        public static void DrawBezier(XGraphics gfx, int number)
        {

            //BeginBox(gfx, number, "DrawBezier");
            gfx.DrawBezier(new XPen(XColors.DarkRed, 5), 20, 110, 40, 10, 170, 90, 230, 20);
            //EndBox(gfx);

        }
    }
}

public class Styling
{
    public XFont fontStd;    
    public XFont fontTitel;
    public XFont fontAbschnitt;

    public string Linie;

    public string Dauertest;

    public string ErzeugtAm;
    public string ProjektNr;
    public string PVpv;
    public string BA;
    public string Bearbeiter;
    public string Testobjekt;
    public string ArtikelNrIM;
    public string SerienNrIM;
    public string ArtikelNrMF;
    public string SerienNrMF;
    public string Spannung;
    public string MagStrom;
    public string Energie;
    public string Dauerleistung;
    public string Kuehlung;
    public string Bemerkung;
    public string Taktzeit;
    public string TaktzeitErr;
    public string Testdauer;
    public string ImpulseAnz;
    public string Maximalwerte;
    
    public Styling()
    {
        fontStd = new XFont("Times New Roman", 9, XFontStyle.Regular);
        fontTitel = new XFont("Arial", 16, XFontStyle.Bold);
        fontAbschnitt = new XFont("Times New Roman", 10, XFontStyle.Bold);
        
        Dauertest       = "Dauertest";
        ErzeugtAm       = "Erzeugt am:";
        ProjektNr = "Projektnummer:"; //Formatierung angepasst von DG, 15.12.2020
        BA = "BA ";
        Bearbeiter      = "Bearbeiter:";
        Testobjekt      = "Testobjekt:";
        ArtikelNrIM       = "IM Artikel Nr.:";
        SerienNrIM        = "IM Serien Nr.:";
        ArtikelNrMF = "MF Artikel Nr.:";
        SerienNrMF = "MF Serien Nr.:";
        Spannung        = "Spannung [V]:";//Formatierung angepasst von DG, 15.12.2020
        MagStrom = "Magnetisierstrom [kA]:";//Formatierung angepasst von DG, 15.12.2020
        Energie         = "Energie [Ws]:";//Formatierung angepasst von DG, 15.12.2020
        Dauerleistung = "Dauerleistung [W]:";//Formatierung angepasst von DG, 15.12.2020
        Kuehlung         = "Kühlung:";
        PVpv = "Projektverantwortlicher:";
        TaktzeitErr     = "Taktzeit Errechnet [s]:";//Formatierung angepasst von DG, 15.12.2020
        Testdauer       = "Testdauer [min]:";//Formatierung angepasst von DG, 15.12.2020
        ImpulseAnz      = "Anzahl Impulse:";
        Taktzeit = "Taktzeit vorgegeben [s]:";//Formatierung angepasst von DG, 15.12.2020
        Bemerkung       = "Bemerkung:";
        Maximalwerte = "Temperaturmaximalwerte[°C]: ";

        Linie = "________________________________________________________________________________________________________";

    }

    //Draw an image in original size
    public void DrawImage(XGraphics gfx, string filename)
    {
        XImage image = XImage.FromFile(filename);

        // Left position in point
        double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
        gfx.DrawImage(image, x, 0);
    }
    // Draw an image scaled
    public void DrawImageScaled(XGraphics gfx, string filename)
    {
        //BeginBox(gfx, number, "DrawImage (scaled)");
        XImage image = XImage.FromFile(filename);
        gfx.DrawImage(image, 0, 0, 250, 140);
        //EndBox(gfx);
    }

    public void SpeicherortCSV_fest()
    {
        //try
        //{
        //    /*
        //    Console.WriteLine("Hallo Speicherort CSV_fest nach try");
        //    Console.WriteLine(_Testobjekt);
        //    Console.WriteLine("Hallo Speicherort CSV_fest nach try");
        //    */

        //    if (_Testobjekt == "IM")
        //    {
        //        _automatisiertSpeichernPfad = string.Concat(@"C:\MPS_Dauertest\", _IM_AN, "\\", _IM_SN);

        //        /*
        //        string PfadIM1 = @"C:\MPS_Dauertest\%IM_AN%\".Replace("%IM_AN%", _IM_AN);
        //        string PfadIM2 = "%IM_SN%".Replace("%IM_SN%", _IM_SN);
        //        Console.WriteLine(PfadIM2);
        //        _automatisiertSpeichernPfad = PfadIM1 + PfadIM2;
        //        //_automatisiertSpeichernPfad = Path.Combine(PfadIM1, PfardIM2);
        //        */

        //    }

        //    if (_Testobjekt == "MF")
        //    {
        //        _automatisiertSpeichernPfad = string.Concat(@"C:\MPS_Dauertest\", _MF_AN, "\\", _MF_SN);

        //    }

        //    if (_Testobjekt == "Entwicklung")
        //    {
        //        _automatisiertSpeichernPfad = string.Concat(@"C:\MPS_Dauertest\", "Entwicklung", "\\", _bearbeiter);

        //    }


        //    if (Directory.Exists(_automatisiertSpeichernPfad))
        //    {
        //        MessageBox.Show("Achtung, das Verzeichnis existiert bereits. Ist die Seriennummer richtig?");
        //        return;
        //    }

        //    DirectoryInfo di = Directory.CreateDirectory(_automatisiertSpeichernPfad);

        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
        //    MessageBox.Show("Das Verzeichnis für die Dauertest-Dokumentation konnte nicht erstellt werden.", ex.ToString());

        //}

        //finally
        //{

        //}
    }
}