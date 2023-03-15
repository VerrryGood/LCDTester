using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class CommonValues
    {
        public static CommFunction.ElevData sendData = new CommFunction.ElevData();
        public static CommFunction.LCDData elevData = new CommFunction.LCDData();
        public static byte[] sendByteData;

        public static readonly Color floorSelectColor = Color.FromArgb(102, 128, 225);
    }
}
