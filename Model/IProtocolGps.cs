using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGps.Model
{
    interface IProtocolGps
    {
        public void ParseData();
        public void ParseGps();
        public void parseAlarm();

    }
}
