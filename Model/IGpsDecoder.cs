using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGps.Model
{
    public interface IGPSDecoder
    {
        void ParseData(byte[] data);
        void ParseGps();
        void parseAlarm();
        bool IsNeedResponse();
        byte[] getResponse();

    }
}
