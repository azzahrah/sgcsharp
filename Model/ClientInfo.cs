using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpServerEngine.cs;
namespace ServerGps.Model
{
    public class ClientInfo
    {
        INetworkSocket socket {set;get;}
        //Last GPS Command
        GpsDataType LastDataType { set; get; }
        //Datas
        List<byte[]> bytes { set; get; }

        ClientInfo()
        {

        }

    }
}
