using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class BasicFunction
    {
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
    }
}
