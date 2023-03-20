using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Timers = System.Timers;
using System.Threading.Tasks;
using CommonLib;

namespace LCDTester
{
    public class FloorSendClient
    {
        private UdpClient sendClient;
        private IPEndPoint serverEndPoint;
        private int floorPort;

        private Timers.Timer sendTimer = new Timers.Timer(500);

        public FloorSendClient(int port)
        {
            floorPort = port;
            serverEndPoint = new IPEndPoint(IPAddress.Broadcast, floorPort);
        }

        public void Start()
        {
            sendClient = new UdpClient();
            sendClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            sendTimer.Elapsed += SendInfo;
            sendTimer.Start();
        }

        private void SendInfo(object sender, Timers.ElapsedEventArgs e)
        {
            sendClient.Send(CommonValues.sendByteData, CommonValues.sendByteData.Length, serverEndPoint);
        }

        public void Stop()
        {
            sendTimer.Stop();
            sendTimer.Elapsed -= SendInfo;
            if (sendClient != null)
                sendClient.Close();
        }
    }
}
