using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpServerEngine.cs;
using ServerGps.Model;
namespace ServerGps.Main
{
    public class ServerTracker : INetworkServerAcceptor, INetworkServerCallback, INetworkSocketCallback
    {
        INetworkServer m_server;
        IProtocolGps protocol;
        ServerOption option;
        List<ClientInfo> clients;
        public ServerTracker(ServerOption option)
        {
            this.option = option;
            m_server = new IocpTcpServer();
            clients = new List<ClientInfo>();            
        }

        public void start()
        {
            ServerOps ops = new ServerOps(this, option.port, this);
            m_server.StartServer(ops);
        }

        public void stop()
        {
            if (m_server.IsServerStarted)
                m_server.StopServer();
        }

        //INetworkServerAcceptor
        public bool OnAccept(INetworkServer server, IPInfo ipInfo)
        {
            return true;
        }

        public INetworkSocketCallback GetSocketCallback()
        {
            return null;
        }

        //INetworkServerCallback


        public void OnServerStarted(INetworkServer server, StartStatus status)
        {
            //throw new NotImplementedException();
        }

        public void OnServerAccepted(INetworkServer server, INetworkSocket socket)
        {
            //throw new NotImplementedException();
        }

        public void OnServerStopped(INetworkServer server)
        {
           // throw new NotImplementedException();
        }

        //INetworkSocketCallback

        public void OnNewConnection(INetworkSocket socket)
        {
            //throw new NotImplementedException();
        }

        public void OnReceived(INetworkSocket socket, Packet receivedPacket)
        {
            //throw new NotImplementedException();
        }

        public void OnSent(INetworkSocket socket, SendStatus status, Packet sentPacket)
        {
            //throw new NotImplementedException();
        }

        public void OnDisconnect(INetworkSocket socket)
        {
            //throw new NotImplementedException();
        }
    }
}
