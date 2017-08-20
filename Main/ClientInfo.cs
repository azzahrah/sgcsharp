using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpServerEngine.cs;
using ServerGps.Model;
namespace ServerGps.Main
{
    public class ClientInfo
    {
        public INetworkSocket socket {set;get;}
        public Queue<byte[]> queues { set; get; }
        public DateTime connectDate;
        public DateTime receiveDate;
        public DateTime sendDate;

        public ClientInfo()
        {

        }

    }
}
