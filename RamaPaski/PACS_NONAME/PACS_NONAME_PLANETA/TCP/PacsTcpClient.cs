using System;
using System.Collections.Generic;
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

                sendData = Encoding.ASCII.GetBytes(message);
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

        public int MakePingTimes(string ipAddress, int times)
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
    }
}
