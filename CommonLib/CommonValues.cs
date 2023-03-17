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
        public const string weatherIPText = "WeatherIP";
        public const string floorPortText = "FloorPort";
        public const string weatherPortText = "WeatherPort";

        public static CommFunction.ElevData elevData = new CommFunction.ElevData();
        public static CommFunction.LCDData lcdData = new CommFunction.LCDData();
        public static byte[] sendByteData;

        public static CommFunction.BasicData protocolData = new CommFunction.BasicData();
        public static CommFunction.WeatherData weatherData = new CommFunction.WeatherData();
        public static byte[] weatherByteData;

        public static CommFunction.BasicData closeData = new CommFunction.BasicData();
        public static byte[] closeByteData;

        public static readonly Color floorSelectColor = Color.FromArgb(102, 128, 225);

        public static int picIndex = 1;
    }
}
