using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    class PacsTcpServer
    {
        NetworkStream stream;
        TcpClient client;
        TcpListener listener;
        List<string> clientMessages = new List<string>();
        bool isConnected;

        public void StopListening()
        {
            this.isConnected = false;
            stream.Close();
            client.Close();
            listener.Stop();
        }

        public List<string> GetClientMessages()
        {
            return this.clientMessages;
        }


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
