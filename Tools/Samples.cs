using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGps.Tools
{
    public class Samples
    {
        public static string loginhex = "78 78 0D 01  03 53 41 35 32 15 03 62  00 02  2D 06 0D 0A";
        public static string loginresponsehex = "78 78 05 01 00 02 EB 47 0D 0A";

        public static string gpspositionhex = "78 78 1F 12 0B 08 1D 11 2E 10 CF 02 7A C7 EB 0C 46 58 49 00 14 8F 01 CC 00 28 7D 00 1F B8 00 03 80 81 0D 0A";
        
        public static string hearbeathex = "78 78 0A 13 44 01 04 00 01 00 05 08 45 0D 0A";
        public static string hearbeatresponsehex = "78 78 05 13 00 05 AF D5 0D 0A";

    }
}
