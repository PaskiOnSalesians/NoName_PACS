using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    public class PacsTcpClient
    {
        NetworkStream stream;
        TcpClient client;

        /*
         * PROJECT METHOD SCHEMA
         * 
         * - CheckNetwork()
         * - SendMessage(string server, int port, string message)
         * - MakePing(string ipAddress)
         * - MakePing(string ipAddress, int times)
         * 
         */

        public PacsTcpClient()
        {

        }

        public bool CheckNetwork()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public string SendMessage(string server, int port, string message)
        {
            byte[] sendData;

            try
            {
                this.client = new TcpClient(server, port);

                sendData = UTF8Encoding.UTF8.GetBytes(message);
                this.stream = this.client.GetStream();
                this.stream.Write(sendData, 0, sendData.Length);

                this.stream.Close();
                this.client.Close();

                return "Message sent";
            }
            catch (Exception)
            {
                return "Message failed";
            }
        }

        public bool MakePing(string ipAddress)
        {
            Ping myPing = new Ping();
            PingReply reply = myPing.Send(ipAddress, 1000);

            if (reply.Address != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int MakePing(string ipAddress, int times)
        {
            int correctPings = 0;
            bool pingStatus;

            for (int i = 0; i < times; i++)
            {
                pingStatus = MakePing(ipAddress);

                if (pingStatus)
                {
                    correctPings++;
                }
            }

            return correctPings;
        }


        public void SendMessage(string server, int port, byte[] data)
        {
            try
            {
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            //Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
        }

    }
}
