﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using FormBase;
using TCP;
using AccesDades;
using GlobalVariables;

namespace PACS_NONAME_PLANETA
{
    public partial class frmPlanetConnection : frmBaseMain
    {
        #region Variables

        PacsTcpServer serverTCP = new  PacsTcpServer();
        PacsTcpClient clientTCP = new PacsTcpClient();
        
        Thread server;

        Dades _Dades = new Dades();
        DataSet dts;

        string validationMessage;
        string planet, remoteIP;

        bool status = false;

        #endregion

        public frmPlanetConnection()
        {
            InitializeComponent();
            planet = RefVariables.PlanetName;
        }

        #region Start Server + Load Form + Close Form
        private void frmPlanetCrypto_Load(object sender, EventArgs e)
        {
            btnRunServer.Enabled = false;
            
            Control.CheckForIllegalCrossThreadCalls = false;
            _Dades.ConnectDB();

            DataSet dts = new DataSet();

            lblPlanetName.Text = planet;
            lblPlanetIP.Text = RefVariables.PlanetIp;
            lblPlanetPort.Text = RefVariables.PlanetMessagePort.ToString();

            lblShipName.Text = "???";
            lblShipIp.Text = "???";
            lblShipPort.Text = "???";

            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
            pboxNau.Image = Image.FromFile(Application.StartupPath + "\\..\\resources\\images\\Ships\\shipUnknown.png");

            Timer_Arrow.Start();

            server = new Thread(ServerListen);
            server.Start();
            CheckThreadStatus();
        }

        private void ServerListen()
        {
            serverTCP.StartServer(RefVariables.PlanetIp, RefVariables.PlanetMessagePort);
            remoteIP = serverTCP.ReceivePing();
            //rtxtInfo.Text = "\n";
            rtxtInfo.Text += serverTCP.GetClientMessages();
            LoadShipInfo(remoteIP);
            status = true;
        }

        private void CheckThreadStatus()
        {
            if (status)
            {
                server.Abort();
            }
        }

        private void frmPlanetConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Abort();
        }

        #endregion

        #region Animations
        private void Timer_Arrow_Tick(object sender, EventArgs e)
        {
            pnlConnect1.BackColor = Color.Yellow;
            pnlConnect1.BackColor = Color.White;
        }
        #endregion

        #region Load Ship Info + Defragment Code
        private void LoadShipInfo(string ip)
        {
            int pos;
            string cShip, delivery;
            dts = new DataSet();

            (cShip, delivery) = DefragmentCode();

            RefVariables.ShipName = cShip;

            pos = ip.IndexOf(":");
            lblShipIp.Text = ip.Substring(0, pos);
            lblShipName.Text = cShip;

            // Coger puerto de la nave de la base de datos
            dts = _Dades.PortarPerConsulta("select * from SpaceShips where SpaceshipImage is not null and CodeSpaceShip = '" + cShip + "'", "SpaceShips");
            RefVariables.ShipMessagePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip1"].ToString());
            RefVariables.ShipImage = dts.Tables[0].Rows[0]["SpaceshipImage"].ToString();
            RefVariables.ShipId = int.Parse(dts.Tables[0].Rows[0]["idSpaceShip"].ToString());
            RefVariables.ShipFilePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip"].ToString());
            RefVariables.ShipIp = lblShipIp.Text;

            RefVariables.DeliveryCode = delivery;

            lblShipPort.Text = RefVariables.ShipMessagePort.ToString();
            pboxNau.Image = Image.FromFile(Application.StartupPath + "\\..\\resources\\images\\Ships\\" + RefVariables.ShipImage);
        }

        private (string, string) DefragmentCode()
        {
            string[] finalSplitted;
            string codeShip, codeDelivery, text;

            text = rtxtInfo.Text;

            int notIndex = text.IndexOf("ER");
            int firstindex = text.IndexOf("ER", notIndex + 15);
            int secondindex = text.IndexOf("\n", firstindex);
            string finalMessage = text.Substring(firstindex, secondindex - firstindex);

            finalSplitted = finalMessage.Split('.');

            codeShip = finalSplitted[1];
            codeDelivery = finalSplitted[2];

            return (codeShip, codeDelivery);
        }
        #endregion

        #region CheckData + Send validation
        private void btnCheckChat_Click(object sender, EventArgs e)
        {
            int stage = 1;
            string result;

            if (CheckDeliveryData())
            {
                result = "VP";
            }
            else
            {
                result = "AD";
            }

            validationMessage = "VR" + stage.ToString() + RefVariables.ShipName + result;

            StartClient();
        }

        private void StartClient()
        {
            clientTCP.SendMessage(RefVariables.ShipIp, RefVariables.ShipMessagePort, validationMessage);
        }

        private void btnRunServer_Click(object sender, EventArgs e)
        {
            server = new Thread(ServerListen);
            server.Start();
            CheckThreadStatus();
        }

        private bool CheckDeliveryData()
        {
            dts = new DataSet();

            dts = _Dades.PortarPerConsulta("select * from DeliveryData where idPlanet =" + RefVariables.PlanetId +
                " and idSpaceShip =" + RefVariables.ShipId +
                " and CodeDelivery ='" + RefVariables.DeliveryCode +
                "' and DeliveryDate = '2022-05-04'"
                );

            if( dts.Tables[0].Rows.Count == 1)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
