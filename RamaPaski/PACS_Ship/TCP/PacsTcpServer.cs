﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;


namespace TCP
{
    public class PacsTcpServer
    {
        NetworkStream stream;
        TcpClient client;
        TcpListener listener;
        List<string> clientMessages = new List<string>();        
        bool isConnected;
        public string IPClient;

        /*
         * PROJECT METHOD SCHEMA
         * 
         * - StopListening()
         * - GetClientMessages()
         * - StartServer(string ipAddress, int port)
         * - ListenClient(string ipAddress, int port)
         * 
         */

        // Parar d'escoltar
        public void StopListening()
        {
            this.isConnected = false;
            stream.Close();
            client.Close();
            listener.Stop();
        }

        // Obtenir missatges
        public string GetClientMessages()
        {
            string final = "";
            foreach (string item in clientMessages)
            {
                final += item + "\n";
            }
            return final;
        }

        // Iniciar Servidor
        public void StartServer(string ipAddress, int port)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(ipAddress), port);
                listener.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Turning of subprocess");
            }

        }

        // Obtenir la direccio des d'on se'ns fa ping
        public string ReceivePing()
        {
            string data;
            byte[] buffer = new byte[1024];

            isConnected = true;

            clientMessages.Clear();
            while (isConnected)
            {
                if (listener.Pending())
                {
                    client = listener.AcceptTcpClient();
                    stream = client.GetStream();

                    int num = stream.Read(buffer, 0, buffer.Length);
                    data = Encoding.ASCII.GetString(buffer, 0, num);

                    IPEndPoint remoteIpEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    clientMessages.Add("\nThe response from planet " + remoteIpEndPoint.Address + " was: " + data);

                    Console.WriteLine(remoteIpEndPoint);

                    return remoteIpEndPoint.ToString();
                }
            }

            return null;
        }

        // Escoltar
        public void ListenClient(string ipAddress, int port)
        {
            string data;
            byte[] buffer = new byte[1024];

            listener = new TcpListener(IPAddress.Parse(ipAddress), port);
            listener.Start();

            isConnected = true;

            clientMessages.Clear();
            while (isConnected)
            {
                if (listener.Pending())
                {
                    client = listener.AcceptTcpClient();
                    stream = client.GetStream();

                    int num = stream.Read(buffer, 0, buffer.Length);
                    data = Encoding.ASCII.GetString(buffer, 0, num);

                    IPEndPoint remoteIpEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    clientMessages.Add(remoteIpEndPoint.Address + ";" + data);
                }
            }
        }
    }
}
