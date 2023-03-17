using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib;

namespace LCDTester
{
    public class WeatherSendClient
    {
        private TcpClient weatherClient;
        private NetworkStream weatherStream;
        private int weatherPort;

        public WeatherSendClient(int port)
        {
            weatherPort = port;
        }

        private Thread sendThread;
        private Thread receiveThread;
        private bool connecting;
        private byte[] rcvPacket = new byte[256];
        private int actualLength;
        private byte[] cutData;
        private CommFunction.AckData ackData;
        private bool sendFinished;


        public void SendWeather()
        {
            sendThread = new Thread(SendWeatherFunction)
            {
                IsBackground = true
            };
            sendThread.Start();
        }

        private void SendWeatherFunction()
        {
            try
            {
                weatherClient = new TcpClient();
                weatherClient.Connect(IPAddress.Loopback, weatherPort);
                weatherStream = weatherClient.GetStream();
                connecting = true;

                receiveThread = new Thread(Receiving)
                {
                    IsBackground = true
                };
                receiveThread.Start();

                sendFinished = false;
                weatherStream.Write(CommonValues.weatherByteData, 0, CommonValues.weatherByteData.Length);
                weatherStream.Flush();

                while (!sendFinished) { Thread.Sleep(100); }

                weatherStream.Write(CommonValues.closeByteData, 0, CommonValues.closeByteData.Length);
                weatherStream.Flush();

                connecting = false;
                weatherStream.Close();
                weatherClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생!\n{ex}");
            }
        }

        private void Receiving()
        {
            while (connecting)
            {
                try
                {
                    actualLength = weatherStream.Read(rcvPacket, 0, rcvPacket.Length);
                    cutData = CommFunction.ReleaseFrame(rcvPacket, actualLength);

                    if (cutData == null)
                    {
                        LCDTester.testerManager.WriteStatus("프레임 체크 에러");
                        continue;
                    }

                    ackData = (CommFunction.AckData)CommFunction.ConvertByteToStr(cutData, typeof(CommFunction.AckData));
                    switch (ackData.ackKind)
                    {
                        case (byte)CommFunction.COMMACK.SUCCESS:
                            LCDTester.testerManager.WriteStatus("성공");
                            break;
                        case (byte)CommFunction.COMMACK.FAILED:
                            LCDTester.testerManager.WriteStatus("실패");
                            break;
                    }

                    sendFinished = true;
                }
                catch { }
            }
        }
    }
}
