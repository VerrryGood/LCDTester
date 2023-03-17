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
        public struct BasicData
        {
            public byte opCode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] sourceIP;
            public byte equipKind;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
            public byte[] data;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AckData
        {
            [MarshalAs(UnmanagedType.I1)]
            public byte opCode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ipAddress;
            [MarshalAs(UnmanagedType.I1)]
            public byte equipKind;
            [MarshalAs(UnmanagedType.I1)]
            public byte ackKind;
        }

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

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct WeatherData
        {
            [MarshalAs(UnmanagedType.I1)]
            public byte weatherPic;
            [MarshalAs(UnmanagedType.I1)]
            public byte tempMinus;
            [MarshalAs(UnmanagedType.I1)]
            public byte temperature;
            [MarshalAs(UnmanagedType.I1)]
            public byte decTemp;
            [MarshalAs(UnmanagedType.I1)]
            public byte humidity;
            [MarshalAs(UnmanagedType.I1)]
            public byte dust;
            [MarshalAs(UnmanagedType.I1)]
            public byte percent;
            [MarshalAs(UnmanagedType.I1)]
            public byte standard;
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

        public enum COMMACK : byte
        {
            SUCCESS = 0,
            FAILED = 1,
            DUPLICATE = 2,
            ALREADYDONE = 3
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

        public static byte[] ReleaseFrame(byte[] packet, int actualLength)
        {
            if (!(packet[0] == 0xaa && packet[1] == 0xaa))
                return null;

            if (!(packet[actualLength - 1] == 0x55 && packet[actualLength - 2] == 0x55))
                return null;

            if (actualLength != (packet[3] * 256) + packet[2])
                return null;

            int checkSum = CalculateCheckSum(packet, actualLength);
            byte lowByte = (byte)(checkSum / 256);
            byte highByte = (byte)(checkSum - (lowByte * 256));
            if (lowByte != packet[actualLength - 3] || highByte != packet[actualLength - 4])
                return null;

            byte[] data = new byte[actualLength - 8];
            Array.Clear(data, 0, data.Length);
            Array.Copy(packet, 4, data, 0, data.Length);

            return data;
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

        public static byte[] AdjustByteLength(byte[] data, int length)
        {
            byte[] tempByte = new byte[length];
            if (data.Length < length)
            {
                Array.Copy(data, tempByte, data.Length);
            }

            return tempByte;
        }
    }
}
