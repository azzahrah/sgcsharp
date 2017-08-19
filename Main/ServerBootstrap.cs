using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGps.Main
{
    class ServerBootstrap
    {
        List<ServerTracker> servers = new List<ServerTracker>();
        //Let's do it
        public ServerBootstrap()
        {

        }

        public void init()
        {
            ServerOption gt06_options = new ServerOption() 
            {
                port="9003"         
            };
            ServerTracker server_gt06 = new ServerTracker(gt06_options);
            servers.Add(server_gt06);
        }
        public void start()
        {
            foreach (ServerTracker st in servers)
            {
                st.start();
            }
        }
    }
}
