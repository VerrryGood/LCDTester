using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class CommFunction
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ElevData
        {
            public byte opCode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] sourceIP;
            public byte equipKind;
            public byte protocolKind;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
            public byte[] data;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LCDData
        {
            public byte crtDisplayCounter;
            public byte crtMode;
            public byte crtArrow;
            public byte crtStatus0;
            public byte crtStatus1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] elseData1;
            public byte crtActionNum;
            public byte thousandChar;
            public byte hundredChar;
            public byte tenthChar;
            public byte firstChar;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
            public byte[] elseData2;
        }

        public enum OPCODE : byte
        {
            TIMESYNC = 2,
            ALIVEMSG = 3,
            FIRECONTROL = 4,
            EQCONTROL = 5,
            ELEVFLOOR = 21,
            WEATHERINFO = 31,
            ELECINFO = 32,
            CARTALRMINFO = 33,
            VOLUMECTRL = 41,
            BRIGHTNESS = 42,
            FILESEND = 71,
            COMMAND = 72,
            COMMCLOSE = 99
        }

        public enum EQUIPKIND : byte
        {
            ELEVATOR = 1,
            ESCALATOR = 2,
            MOVINGWALK = 3,
            EAISERVER = 4,
            LCDSCREEN = 5,
            MULTIPOST = 6
        }

        public enum PROTOCOLKIND : byte
        {
            OTIS = 1,
            SCHINDLER = 2,
            SAMIL = 3,
            HANSON = 4
        }

        public enum MODENUMBER : byte
        {
            MAINTENANCE = 1,
            PARKING = 4,
            NORMAL = 5,
            FIRE = 12,
            EARTHQUAKE = 13,
            MOVING = 21
        }

        public enum ACTIONNUMBER : byte
        {
            OPENED = 6,
            CLOSED = 7,
            OPENING = 14,
            CLOSING = 15
        }

        public static byte[] MakeFrame(byte[] data)
        {
            int makeLength = data.Length + 8;
            byte[] makePacket = new byte[makeLength];

            makePacket[0] = 0xaa;
            makePacket[1] = 0xaa;

            if (makeLength > 255)
            {
                makePacket[3] = (byte)(makeLength / 256);
                makePacket[2] = (byte)(makeLength - (makePacket[3] * 256));
            }
            else
            {
                makePacket[3] = 0;
                makePacket[2] = (byte)makeLength;
            }

            for (int i = 4; i < makeLength - 4; i++)
            {
                makePacket[i] = data[i - 4];
            }

            int checkSum = CalculateCheckSum(makePacket, makeLength);
            if (checkSum > 255)
            {
                makePacket[makeLength - 3] = (byte)(checkSum / 256);
                makePacket[makeLength - 4] = (byte)(checkSum - (makePacket[makeLength - 3] * 256));
            }
            else
            {
                makePacket[makeLength - 3] = 0;
                makePacket[makeLength - 4] = (byte)checkSum;
            }

            makePacket[makeLength - 2] = 0x55;
            makePacket[makeLength - 1] = 0x55;

            return makePacket;
        }

        public static int CalculateCheckSum(byte[] packet, int actualLength)
        {
            int checkSum = 0;

            for (int i = 2; i < actualLength - 4; i++)
            {
                checkSum += packet[i];
            }

            return checkSum;
        }

        public static object ConvertByteToStr(byte[] data, Type type)
        {
            IntPtr ptr = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, ptr, data.Length);
            object obj = Marshal.PtrToStructure(ptr, type);
            Marshal.FreeHGlobal(ptr);
            return obj;
        }

        public static byte[] ConvertStrToByte(object obj)
        {
            int dataSize = Marshal.SizeOf(obj);
            IntPtr buff = Marshal.AllocHGlobal(dataSize);
            Marshal.StructureToPtr(obj, buff, false);
            byte[] data = new byte[dataSize];
            Marshal.Copy(buff, data, 0, dataSize);
            Marshal.FreeHGlobal(buff);
            return data;
        }
    }
}
