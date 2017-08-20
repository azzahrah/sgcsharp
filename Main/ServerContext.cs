using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGps.Main
{
    public class ServerContext
    {
        public ConcurrentDictionary<string, ClientInfo> clients;
        public ServerContext()
        {
            clients = new ConcurrentDictionary<string, ClientInfo>();
        }
    }
}
