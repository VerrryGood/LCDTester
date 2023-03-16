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
        public const string baseTitle = "Base";
        public const string ipText = "FloorIP";
        public const string portText = "FloorPort";

        public static CommFunction.ElevData elevData = new CommFunction.ElevData();
        public static CommFunction.LCDData lcdData = new CommFunction.LCDData();
        public static byte[] sendByteData;

        public static readonly Color floorSelectColor = Color.FromArgb(102, 128, 225);
    }
}
