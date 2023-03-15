using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Timers = System.Timers;
using System.Threading.Tasks;

namespace LCDTester
{
    public class SendClient
    {
        private UdpClient sendClient;
        private IPEndPoint serverEndPoint;
        private int floorPort;

        public SendClient(int port)
        {
            floorPort = port;
            serverEndPoint = new IPEndPoint(IPAddress.Any, floorPort);
        }
    }
}
