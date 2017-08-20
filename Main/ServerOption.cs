﻿using ServerGps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGps.Main
{
    public class ServerOption
    {
        public string port { set; get; }
        public int timeoutIncoming { set; get; }
        public int timeoutOutgoing { set; get; }
        public int timeoutBoth { set; get; }
        public IGPSDecoder protocol { set; get; }
        public ServerOption()
        {

        }
    }
}
