using EpServerEngine.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGps.Model
{
    public class PacketClient
    {
        public INetworkSocket socket { set; get; }
        public Packet packet{ set; get; }
        public PacketClient(INetworkSocket socket, Packet packet)
        {
            this.socket = socket;
            this.packet = packet;
        }
    }
}
