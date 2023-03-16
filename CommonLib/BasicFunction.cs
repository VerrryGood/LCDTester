using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class BasicFunction
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static int StringtoFloorNum(string floorText)
        {
            if (floorText.Contains("B"))
            {
                return int.Parse(floorText.Trim('B')) * -1;
            }
            else
            {
                return int.Parse(floorText.Trim('F'));
            }
        }

        public static byte ConvertBitToByte(BitArray bitArray)
        {
            byte[] returnByte = new byte[1];
            bitArray.CopyTo(returnByte, 0);
            return returnByte[0];
        }

        
    }
}
