﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesDades;
using FormBase;
using VariablesGlobals;
using TCP;
using System.Net.NetworkInformation;
using System.Threading;

namespace PACS_NONAME_NAU
{
    public partial class frmConnectionShip : frmBaseMain
    {
        PacsTcpClient tcp = new PacsTcpClient();
        DadesDB db = new DadesDB("SecureCoreG2");
        Thread EstablishConnection, ShowEstablishedConnectionShip;

        public frmConnectionShip()
        {
            InitializeComponent();
        }

        private void frmConnectionShip_Load(object sender, EventArgs e)
        {
            db.Connectar();
            LoadPlanetData();
            LoadShipData();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void LoadShipData()
        {
            lblShipName.Text = RefVariables.ShipName;
            lblShipIP.Text = RefVariables.ShipIp;
            lblFilePortShip.Text = RefVariables.ShipFilePort.ToString();
            lblMsgPortShip.Text = RefVariables.ShipMessagePort.ToString();
            picBoxShip.Image = Image.FromFile(RefVariables.ShipImage);
        }

        private void LoadPlanetData()
        {
            lblPlanetName.Text = RefVariables.PlanetName;
            lblPlanetIP.Text = RefVariables.PlanetIp;
            lblFilePortPlanet.Text = RefVariables.PlanetFilePort.ToString();
            lblMsgPortPlanet.Text = RefVariables.PlanetMessagePort.ToString();
            picBoxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            rtxData.Font = new Font("Arial", 11, FontStyle.Bold);
            rtxData.ForeColor = Color.White;


            EstablishConnection = new Thread(SendErMessage);
            EstablishConnection.Start();

            ShowEstablishedConnectionShip = new Thread(ShowEstablishedConnection);
            ShowEstablishedConnectionShip.Start();

        }

        private void ShowEstablishedConnection()
        {
            EntryRequirementShip();
        }

        private void SendErMessage()
        {
           tcp.SendMessage(RefVariables.PlanetIp, RefVariables.PlanetMessagePort, EntryRequirementPlanet());
        }

        private string EntryRequirementPlanet()
        {
            string message = "";
            bool networkStatus;
            Ping myPing = new Ping();
            string ip_ping = RefVariables.PlanetIp;

            networkStatus = NetworkInterface.GetIsNetworkAvailable();

            message += "*********** ER - Entry Requirement ***********" + "\n";


            message += "\n" + "Check for network availability..." + "\n";
            if (networkStatus)
            {
                message += "System is connected to the network!" + "\n" + "\n";

                PingReply reply = myPing.Send(ip_ping, 1000);
                if (reply.Address != null)
                {
                    message += "-------------- Delivery Data --------------" + "\n" + "\n";
                    message += ("ER" + "." + RefVariables.ShipName + "." + RefVariables.ShipName + "-" + RefVariables.PlanetCode + "\n" + "\n");
                    panStatus.BackColor = Color.Green;

                   
                }
                else
                {
                    message += "Response from " + ip_ping + ": Destination host inaccessible." + "\n";
                    panStatus.BackColor = Color.Red;
                }
            }
            else
            {
                message += "Inaccessible network." + "\n";
            }
            
            return message;
        }

        private string EntryRequirementShip()
        {
            string message = "";
            bool networkStatus;
            Ping myPing = new Ping();
            string ip_ping = RefVariables.PlanetIp;

            networkStatus = NetworkInterface.GetIsNetworkAvailable();

            rtxData.Clear();
            rtxData.AppendText("*********** ER - Entry Requirement ***********" + "\n");

            rtxData.AppendText("\n" + "Check for network availability..." + "\n");
            if (networkStatus)
            {
                rtxData.AppendText("System is connected to the network!" + "\n" + "\n");

                rtxData.AppendText("-------------- Remote device identificaton --------------" + "\n" + "\n");

                rtxData.AppendText("Sending ping to remote Host with ip: " + ip_ping + "\n");
                rtxData.AppendText("Ping " + ip_ping + "\n");

                PingReply reply = myPing.Send(ip_ping, 1000);
                if (reply.Address != null)

                {
                    rtxData.AppendText("Response from " + ip_ping + "\n" + "\n");
                    rtxData.AppendText("-------------- Delivery Data --------------" + "\n" + "\n");

                    rtxData.AppendText("ER" + "." + RefVariables.ShipName + "." + RefVariables.ShipName + "-" + RefVariables.PlanetCode + "\n" + "\n");
                    panStatus.BackColor = Color.Green;

                    rtxData.AppendText("Waiting for the VR-Validation Result message of the TCP port........." + "\n");
                }
                else
                {
                    rtxData.AppendText("Response from " + ip_ping + ": Destination host inaccessible." + "\n");
                    panStatus.BackColor = Color.Red;
                }
            }
            else
            {
                rtxData.AppendText("Inaccessible network." + "\n");
            }
            message += rtxData.Text;
            return message;
        }

        //private void TancarFil()
        //{
        //    if (MakingPing != null)
        //    {
        //        MakingPing.Abort();
        //    }

        //    if (StartingServer != null)
        //    {
        //        StartingServer.Abort();
        //    }


        //}

    }
}
