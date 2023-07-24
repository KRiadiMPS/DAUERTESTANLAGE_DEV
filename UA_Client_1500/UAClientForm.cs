//=============================================================================
// Siemens AG
// (c)Copyright (2018) All Rights Reserved
//----------------------------------------------------------------------------- 
// Tested with: Windows 10 Enterprise x64
// Engineering: Visual Studio 2013
// Functionality: Wrapps up important classes/methods of the OPC UA .NET Stack to help
// with simple client implementations
//-----------------------------------------------------------------------------
// Change log table:
// Version Date Expert in charge Changes applied
// 01.00.00 31.08.2016 (Siemens) First released version
// 01.01.00 22.02.2017 (Siemens) Implements user authentication, SHA256 Cert, Basic256Rsa256 connection,
// Basic256Rsa256 connections, read/write structs/UDTs
// 01.02.00 14.12.2017 (Siemens) Implements method calling
// 01.03.00 27.11.2018 (Siemens) Updated UAClientHelperAPI V1.4, Improved endpoint handling
//=============================================================================


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;

namespace UA_Client_1500
{
    public partial class UAClientForm : Form
    {
 
        #region Fields
        private Session mySession;
        private Subscription mySubscription;
        private UAClientHelperAPI myClientHelperAPI;
        private EndpointDescription mySelectedEndpoint;
        private MonitoredItem myMonitoredItem;
        private List<String> myRegisteredNodeIdStrings;
        private ReferenceDescriptionCollection myReferenceDescriptionCollection;
        private List<string[]> myStructList;
        private UAClientCertForm myCertForm;
        private Int16 itemCount;
        #endregion


        #region Construction
        // Form Construction
        public UAClientForm()
        {
            InitializeComponent();
            myClientHelperAPI = new UAClientHelperAPI();
            myRegisteredNodeIdStrings = new List<String>();
            browsePage.Enabled = false;
            rwPage.Enabled = false;
            subscribePage.Enabled = false;
            structPage.Enabled = false;
            methodPage.Enabled = false;
            itemCount = 0;
        }
        #endregion


        #region UserInteractionHandlers
        // Event handlers called by the UI
        private void EndpointButton_Click(object sender, EventArgs e)
        {
            bool foundEndpoints = false;
            endpointListView.Items.Clear();
            //The local discovery URL for the discovery server
            //string discoveryUrl = "opc.tcp://mps-nb025-win10:62640/IntegrationObjects/ServerSimulator"; // discoveryTextBox.Text;  
            string discoveryUrl = discoveryTextBox.Text;
            try
            {
                ApplicationDescriptionCollection servers = myClientHelperAPI.FindServers(discoveryUrl);
                foreach (ApplicationDescription ad in servers)
                {
                    foreach (string url in ad.DiscoveryUrls)
                    {

                        try
                        {
                            EndpointDescriptionCollection endpoints = myClientHelperAPI.GetEndpoints(url);
                            foundEndpoints = foundEndpoints || endpoints.Count > 0;

                            EndpointDescription epo = endpoints[0];



                            foreach (EndpointDescription ep in endpoints)
                            {
                                string securityPolicy = ep.SecurityPolicyUri.Remove(0, 42);
                                string key = "[" + ad.ApplicationName + "] " + " [" + ep.SecurityMode + "] " + " [" + securityPolicy + "] " + " [" + ep.EndpointUrl + "]";
                                if (!endpointListView.Items.ContainsKey(key))
                                {
                                    endpointListView.Items.Add(key, key, 0).Tag = ep;
                                }

                            }
                        }
                        catch (ServiceResultException sre)
                        {
                            //If an url in ad.DiscoveryUrls can not be reached, myClientHelperAPI will throw an Exception
                            MessageBox.Show(sre.Message, "Error");
                        }

                    }
                    if (!foundEndpoints)
                    {
                        MessageBox.Show("Could not get any Endpoints", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void SubscribeButton_Click(object sender, EventArgs e)
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
                myMonitoredItem = myClientHelperAPI.AddMonitoredItem(mySubscription, subscriptionIdTextBox.Text, monitoredItemName, 1);
                myClientHelperAPI.ItemChangedNotification += new MonitoredItemNotificationEventHandler(Notification_MonitoredItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void EpConnectButton_Click(object sender, EventArgs e)
        {
            //Check if sessions exists; If yes > delete subscriptions and disconnect
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
                
                ResetUI();
            }
            else
            {
                try
                {
                    //Register mandatory events (cert and keep alive)
                    myClientHelperAPI.KeepAliveNotification += new KeepAliveEventHandler(Notification_KeepAlive);
                    myClientHelperAPI.CertificateValidationNotification += new CertificateValidationEventHandler(Notification_ServerCertificate);

                    //Check for a selected endpoint
                    if (mySelectedEndpoint != null)
                    {
                        //Call connect
                        myClientHelperAPI.Connect(mySelectedEndpoint, userPwButton.Checked, userTextBox.Text, pwTextBox.Text).Wait();
                        //Extract the session object for further direct session interactions
                        mySession = myClientHelperAPI.Session;

                        //UI settings
                        epConnectServerButton.Text = "vom opc ua Server trennen";
                        browsePage.Enabled = true;
                        rwPage.Enabled = true;
                        subscribePage.Enabled = true;
                        structPage.Enabled = true;
                        methodPage.Enabled = true;
                        myCertForm = null;
                    }
                    else
                    {
                        MessageBox.Show("bitte ein endpoint aussuchen!", "Error");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    myCertForm = null;
                    ResetUI();
                    MessageBox.Show(ex.InnerException.Message, "Error");
                }
            }

        }
        private void WriteValButton_Click(object sender, EventArgs e)
        {
            List<String> values = new List<string>();
            List<String> nodeIdStrings = new List<string>();
            values.Add(writeTextBox.Text);
            nodeIdStrings.Add(writeIdTextBox.Text);
            try
            {
                myClientHelperAPI.WriteValues(values, nodeIdStrings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void UnsubscribeButton_Click(object sender, EventArgs e)
        {
            myClientHelperAPI.RemoveSubscription(mySubscription);
            mySubscription = null;
            itemCount = 0;
            subscriptionTextBox.Text = "";
        }
        private void NodeTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            descriptionGridView.Rows.Clear();

            try
            {
                ReferenceDescription refDesc = (ReferenceDescription)e.Node.Tag;
                Node node = myClientHelperAPI.ReadNode(refDesc.NodeId.ToString());
                VariableNode variableNode = new VariableNode();

                string[] row1 = new string[] { "Node Id", refDesc.NodeId.ToString() };
                string[] row2 = new string[] { "Namespace Index", refDesc.NodeId.NamespaceIndex.ToString() };
                string[] row3 = new string[] { "Identifier Type", refDesc.NodeId.IdType.ToString() };
                string[] row4 = new string[] { "Identifier", refDesc.NodeId.Identifier.ToString() };
                string[] row5 = new string[] { "Browse Name", refDesc.BrowseName.ToString() };
                string[] row6 = new string[] { "Display Name", refDesc.DisplayName.ToString() };
                string[] row7 = new string[] { "Node Class", refDesc.NodeClass.ToString() };
                string[] row8 = new string[] { "Description", "null" };
                try { row8 = new string[] { "Description", node.Description.ToString() }; }
                catch { row8 = new string[] { "Description", "null" }; }
                string[] row9 = new string[] { "Type Definition", refDesc.TypeDefinition.ToString() };
                string[] row10 = new string[] { "Write Mask", node.WriteMask.ToString() };
                string[] row11 = new string[] { "User Write Mask", node.UserWriteMask.ToString() };
                if (node.NodeClass == NodeClass.Variable)
                {
                    variableNode = (VariableNode)node.DataLock;
                    List<NodeId> nodeIds = new List<NodeId>();
                    List<string> displayNames = new List<string>();
                    List<ServiceResult> errors = new List<ServiceResult>();
                    NodeId nodeId = new NodeId(variableNode.DataType);
                    nodeIds.Add(nodeId);
                    mySession.ReadDisplayName(nodeIds, out displayNames, out errors);

                    string[] row12 = new string[] { "Data Type", displayNames[0] };
                    string[] row13 = new string[] { "Value Rank", variableNode.ValueRank.ToString() };
                    string[] row14 = new string[] { "Array Dimensions", variableNode.ArrayDimensions.Capacity.ToString() };
                    string[] row15 = new string[] { "Access Level", variableNode.AccessLevel.ToString() };
                    string[] row16 = new string[] { "Minimum Sampling Interval", variableNode.MinimumSamplingInterval.ToString() };
                    string[] row17 = new string[] { "Historizing", variableNode.Historizing.ToString() };

                    object[] rows = new object[] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, row16, row17 };
                    foreach (string[] rowArray in rows)
                    {
                        descriptionGridView.Rows.Add(rowArray);
                    }
                }
                else
                {
                    object[] rows = new object[] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11 };
                    foreach (string[] rowArray in rows)
                    {
                        descriptionGridView.Rows.Add(rowArray);
                    }
                }

                descriptionGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                myClientHelperAPI.Disconnect();
            }
            catch
            {
                ;
            }
        }
        private void NodeTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();

            ReferenceDescriptionCollection referenceDescriptionCollection;
            ReferenceDescription refDesc = (ReferenceDescription)e.Node.Tag;

            try
            {
                referenceDescriptionCollection = myClientHelperAPI.BrowseNode(refDesc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            foreach (ReferenceDescription tempRefDesc in referenceDescriptionCollection)
            {
                if (tempRefDesc.ReferenceTypeId != ReferenceTypeIds.HasNotifier)
                {
                    e.Node.Nodes.Add(tempRefDesc.DisplayName.ToString()).Tag = tempRefDesc;
                }
            }
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Nodes.Add("");
            }
        }
        private void BrowsePage_Enter(object sender, EventArgs e)
        {
            if (myReferenceDescriptionCollection == null)
            {
                try
                {
                    myReferenceDescriptionCollection = myClientHelperAPI.BrowseRoot();
                    foreach (ReferenceDescription refDesc in myReferenceDescriptionCollection)
                    {
                        nodeTreeView.Nodes.Add(refDesc.DisplayName.ToString()).Tag = refDesc;
                        foreach (TreeNode node in nodeTreeView.Nodes)
                        {
                            node.Nodes.Add("");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
        private void ReadValButton_Click(object sender, EventArgs e)
        {
            List<String> nodeIdStrings = new List<String>();
            List<String> values = new List<String>();
            nodeIdStrings.Add(readIdTextBox.Text);
            try
            {
                values = myClientHelperAPI.ReadValues(nodeIdStrings);
                readTextBox.Text = values.ElementAt<String>(0);
            }
            catch (Exception ex)
            {                                             
                MessageBox.Show(ex.Message, "Error");                
            }
            
        }
        private void EndpointListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            mySelectedEndpoint = (EndpointDescription)e.Item.Tag;
        }
        private void OpcTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !e.TabPage.Enabled;
            if (!e.TabPage.Enabled)
            {
                MessageBox.Show("Establish a connection to a server first.", "Error");
            }
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            List<String> nodeIdStrings = new List<String>();
            nodeIdStrings.Add(rgNodeIdTextBox.Text);
            try
            {                
                myRegisteredNodeIdStrings = myClientHelperAPI.RegisterNodeIds(nodeIdStrings);
                regNodeIdTextBox.Text = myRegisteredNodeIdStrings.ElementAt<String>(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error"); 
            }
            
        }
        private void UnregisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                myClientHelperAPI.UnregisterNodeIds(myRegisteredNodeIdStrings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            myRegisteredNodeIdStrings.Clear();
            regNodeIdTextBox.Text = "";
            rgReadTextBox.Text = "";
            rgWriteTextBox.Text = "";
        }
        private void RgReadButton_Click(object sender, EventArgs e)
        {
            List<String> values = new List<String>();
            try
            {
                values = myClientHelperAPI.ReadValues(myRegisteredNodeIdStrings);
                rgReadTextBox.Text = values.ElementAt<String>(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void RgWriteButton_Click(object sender, EventArgs e)
        {
            List<String> values = new List<string>();
            values.Add(rgWriteTextBox.Text);
            try
            {
                myClientHelperAPI.WriteValues(values, myRegisteredNodeIdStrings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }            
        }
        private void UserPwButton_CheckedChanged(object sender, EventArgs e)
        {
            if (userPwButton.Checked)
            {
                userTextBox.Enabled = true;
                pwTextBox.Enabled = true;
            }
        }
        private void UserAnonButton_CheckedChanged(object sender, EventArgs e)
        {
            if (userAnonButton.Checked)
            {
                userTextBox.Enabled = false;
                pwTextBox.Enabled = false;
            }
        }
        private void StructReadButton_Click(object sender, EventArgs e)
        {
            structGridView.Rows.Clear();
            myStructList = new List<string[]>();

            try
            {
                myStructList = myClientHelperAPI.ReadStructUdt(structNodeIdTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            foreach (string[] val in myStructList)
            {
                string[] row = new string[] { val[0], val[1], val[2] };
                structGridView.Rows.Add(row);
                if (structGridView.Rows[structGridView.Rows.Count - 1].Cells[1].Value.ToString() == ".." ||
                    structGridView.Rows[structGridView.Rows.Count - 1].Cells[0].Value.ToString().Contains("_Size"))
                {
                    structGridView.Rows[structGridView.Rows.Count - 1].Cells[1].Style.BackColor = Color.Gainsboro;
                    structGridView.Rows[structGridView.Rows.Count - 1].Cells[1].ReadOnly = true;
                }
            }

            structGridView.ClearSelection();
        }
        private void StructWriteButton_Click(object sender, EventArgs e)
        {
            if (structGridView.Rows.Count == 0)
            {
                MessageBox.Show("Read a struct/UDT first.","Error");
                return;
            }

            //Clear the list and refill with values from GridView to get value changes
            myStructList.Clear();
            foreach (DataGridViewRow row in structGridView.Rows )
            {
                string[] tempString = new String[3];
                try
                {
                    tempString[0] = structGridView.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch
                {
                    tempString[0] = "";
                }

                try
                {
                    tempString[1] = structGridView.Rows[row.Index].Cells[1].Value.ToString();
                }
                catch
                {
                    tempString[1] = "";
                }

                try
                {
                    tempString[2] = structGridView.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch
                {
                    tempString[2] = "";
                }

                myStructList.Add(tempString);
            }

            try
            {
                myClientHelperAPI.WriteStructUdt(structNodeIdTextBox.Text, myStructList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void MethodInfoButton_Click(object sender, EventArgs e)
        {
            //Clear grid view first
            inputArgumentsGridView.Rows.Clear();
            outputArgumentsGridView.Rows.Clear();

            //Creata list of strings for the method's arguments
            List<string> methodArguments = new List<string>();

            //Get the arguments
            try
            {
                methodArguments = myClientHelperAPI.GetMethodArguments(methodNodeIdTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            } 

            //If arguemnt is null there's no method
            if (methodArguments == null)
            {
                MessageBox.Show("The Node Id doesn't refer to a method", "Error");
                return;
            }

            //Check for display name to determine if there are intput and/or output arguments for the method
            foreach (String argument in methodArguments)
            {
                String[] strArray = argument.Split(';');

                if (strArray[0] == "InputArguments")
                {
                    string[] row = new string[] { strArray[1], strArray[2], strArray[3] };
                    inputArgumentsGridView.Rows.Add(row);
                }

                if (strArray[0] == "OutputArguments")
                {
                    string[] row = new string[] { strArray[1], strArray[2], strArray[3] };
                    outputArgumentsGridView.Rows.Add(row);
                }
            }

            //If there's no argument stored in the gridview there's no argument to care about
            if (inputArgumentsGridView.Rows.Count == 0)
            {
                string[] row = new string[] { "-", "-", "none" };
                inputArgumentsGridView.Rows.Add(row);
            }

            if (outputArgumentsGridView.Rows.Count == 0)
            {
                string[] row = new string[] { "-", "-", "none" };
                outputArgumentsGridView.Rows.Add(row);
            }

            inputArgumentsGridView.ClearSelection();
            outputArgumentsGridView.ClearSelection();

            //Enable the call button after retrieving argument info
            callButton.Enabled = true;
        }
        private void CallButton_Click(object sender, EventArgs e)
        {
            //Call the method

            //Create a list of string arrays for the input arguments
            List<string[]> inputData = new List<string[]>();

            //Copy data from the gridview to the argument list (value at [0]; data type at [1]) 
            //First check for data type "none" > no input argument available
            if (inputArgumentsGridView.Rows[0].Cells[2].Value.ToString() != "none")
            {
                foreach (DataGridViewRow row in inputArgumentsGridView.Rows)
                {
                    inputData.Add(new String[2] { row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString() });
                }
            }

            //Create an object list for retrieving the output arguments
            IList<object> outputValues;
            try
            {
                //Call the method
                outputValues = myClientHelperAPI.CallMethod(methodNodeIdTextBox.Text, objectNodeIdTextBox.Text, inputData);

                if (outputValues != null)
                {
                    if (outputValues.Count > 0) //if the method does not return a value
                    {
                        //Copy output arguments to the gridview
                        for (int i = 0; i < outputArgumentsGridView.Rows.Count; i++)
                        {
                            string outstring = "";
                            if (outputArgumentsGridView.Rows[i].Cells[2].Value.Equals("ByteString"))
                            {
                                outstring = BitConverter.ToString((byte[])outputValues[i]).Replace("-", string.Empty);
                            }
                            else
                            {
                                outstring = outputValues[i].ToString();
                            }

                            outputArgumentsGridView.Rows[i].Cells[1].Value = outstring;

                        }
                    }
                }
                //Success; Status = Good
                MessageBox.Show("Method called successfully.", "Success");
            }
            catch (Exception ex)
            {
                //Message contains status 
                MessageBox.Show(ex.Message, "Error");
            } 
        }
        private void DiscoveryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EndpointButton_Click(this, new EventArgs());
            }
        }
        #endregion


        #region OpcEventHandlers
        // Global OPC UA event handlers
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
        private void Notification_MonitoredItem(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MonitoredItemNotificationEventHandler(Notification_MonitoredItem), monitoredItem, e);
                return;
            }
            MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;
            if (notification == null)
            {
                return;
            }

            subscriptionTextBox.Text = "Item name: " + monitoredItem.DisplayName;
            subscriptionTextBox.Text += System.Environment.NewLine + "Value: " + Utils.Format("{0}", notification.Value.WrappedValue.ToString());
            subscriptionTextBox.Text += System.Environment.NewLine + "Source timestamp: " + notification.Value.SourceTimestamp.ToString();
            subscriptionTextBox.Text += System.Environment.NewLine + "Server timestamp: " + notification.Value.ServerTimestamp.ToString();
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
                ResetUI();
            }
        }
        #endregion


        #region PrivateMethods
        // Private methods for UI handling
        private void ResetUI()
        {
            descriptionGridView.Rows.Clear();
            nodeTreeView.Nodes.Clear();
            myReferenceDescriptionCollection = null;
            structGridView.Rows.Clear();
            inputArgumentsGridView.Rows.Clear();
            outputArgumentsGridView.Rows.Clear();
            myStructList = null;

            subscriptionTextBox.Text = "";
            subscriptionIdTextBox.Text = "";
            readIdTextBox.Text = "";
            writeIdTextBox.Text = "";
            readTextBox.Text = "";
            writeTextBox.Text = "";
            rgReadTextBox.Text = "";
            rgWriteTextBox.Text = "";
            rgNodeIdTextBox.Text = "";
            regNodeIdTextBox.Text = "";
            epConnectServerButton.Text = "Verbinden mit opc ua server";

            browsePage.Enabled = false;
            rwPage.Enabled = false;
            subscribePage.Enabled = false;
            structPage.Enabled = false;
            methodPage.Enabled = false;

            opcTabControl.SelectedIndex = 0;
        }
        #endregion
    }
}