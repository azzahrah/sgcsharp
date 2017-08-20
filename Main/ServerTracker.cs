using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpServerEngine.cs;
using ServerGps.Model;
using System.Threading;
using System.Collections.Concurrent;
namespace ServerGps.Main
{
    public class ServerTracker : INetworkServerAcceptor, INetworkServerCallback, INetworkSocketCallback
    {
        INetworkServer m_server;
        IGPSDecoder protocol;
        ServerOption option;
        ClientLiveChecker clientChecker;

        /*
         * Client Checker every 10 second, ping, check if response available
         * Send command, and wait response for x second
         */

        Thread thClientChecker;

       // List<ClientInfo> clients;
        Dictionary<INetworkSocket, ClientInfo> clients;

        ConcurrentQueue<PacketClient> queues;
        public ServerTracker(ServerOption option)
        {
            this.option = option;
            m_server = new IocpTcpServer();
            queues = new ConcurrentQueue<PacketClient>();
            clients = new Dictionary<INetworkSocket, ClientInfo>();  
        }

        public void start()
        {
            ServerOps ops = new ServerOps( this, option.port, this);
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
            //if (!clients.ContainsKey(socket))
            //{
            //    ClientInfo client = new ClientInfo();
            //    clients.Add(socket,client);
            //}
        }

        public void OnReceived(INetworkSocket socket, Packet receivedPacket)
        {
            PacketClient pc = new PacketClient(socket,receivedPacket);
            queues.Enqueue(pc);
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
