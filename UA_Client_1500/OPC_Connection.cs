/**********************************************************************************************************************
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
 **********************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SimaticNET.OPC.OpcDaClient;
using System.Windows.Forms;


//namespace MPS_DT_2020_V00
namespace UA_Client_1500
{
    public static class OPC_Connection
    {
        //public static DaServerMgt OPC_Server;
        public static bool connectFailed;
        public static bool OPC_connected;
        public static bool OPC_disconnected;
        public static string url;
        public static string itemInput;
        public static string itemOutput;
        //public static ItemIdentifier[] itemIdentifiersInput;
        //public static ItemIdentifier[] itemIdentifiersOutput;
        //public static ConnectInfo connectInfo;
        public static int clientHandle;
        //private static ReturnCode READFEHLERMELDUNG;

        public static bool ConnIsOK { get; private set; }

        public static void OPC_Conn()
        {
            //clientHandle = 0;
            //url = "opcda://localhost/OPC.SimaticNET/{B6EACB30-42D5-11D0-9517-0020AFAA4B3C}";
            //itemInput = "PNIO:[ctrl1]EB4120,64,BYTE"; 
            //itemOutput = "PNIO:[ctrl1]AB4116,64,BYTE"; 
            //connectInfo = new ConnectInfo();
            //connectInfo.KeepAliveTime = 5000;  // Zeit setzen
            //connectInfo.LocalId = "de";



            //ItemIdentifier[] itemIdentifierIn = new ItemIdentifier[64];
            //for (int i = 0; i < 64; i++)
            //{
            //    itemIdentifierIn[i] = new ItemIdentifier();
            //    itemIdentifierIn[i].ItemName = itemInput + i;
            //}
            //itemIdentifiersInput = itemIdentifierIn;


            //ItemIdentifier[] itemIdentifierOut = new ItemIdentifier[64];
            //for (int i = 0; i < 64; i++)
            //{
            //    itemIdentifierOut[i] = new ItemIdentifier();
            //    //itemIdentifier12[i].ItemName = "PNIO:[ctrl1]AB256,12,BYTE" + i;
            //    itemIdentifierOut[i].ItemName = itemOutput + i;
            //}
            //itemIdentifiersOutput = itemIdentifierOut;

            //OPC_connected = OPCConnect();

        }

        private static bool OPCConnect()
        {
            //OPC_Server = new DaServerMgt();

            //// --> OPC-Server verbinden
            //try
            //{
            //    OPC_Server.Connect(url, clientHandle, ref connectInfo, out connectFailed);
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Keine Verbindung");
            //}
            //OPC_disconnected = false;
            //if (!OPC_Server.IsConnected)
            //{
            //    MessageBox.Show("Keine Verbindung");
            //    OPC_disconnected = true;
            //    OPC_connected = false;
            //}
            //return OPC_Server.IsConnected;
            return false;
        }

        public static bool OPCDisConnect()
        {
            //// --> OPC-Server trennen
            //try
            //{
            //    OPC_Server.Disconnect();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Verbindung kann nicht getrennt werden!");
            //}

            //OPC_connected = false;
            //return !OPC_Server.IsConnected;
            return false;
        }

        public static bool VerbindungUeberwachen()
        {
            //using (OPC_Read reader_dta1 = new OPC_Read())
            //{
            //using (OPC_Read opcread = new OPC_Read())
            //{

            //    READFEHLERMELDUNG = opcread.READFEHLERMELDUNG;

            //    if (READFEHLERMELDUNG == ReturnCode.ITEMERROR)
            //    {
            //        ConnIsOK = false;
            //    }
            //    else
            //    {
            //        ConnIsOK = true;
            //    }
            //}
            //return ConnIsOK;
            return false;
        }


        public static string MeldungProfinet()
        {
            string result = " ";
            if (VerbindungUeberwachen())
            {
                result = "Profinet ist Verbunden";                    
            }
            else
            {
                result = "Profinet ist nicht Verbunden!";
            }

            return result;
        }




    }







}

