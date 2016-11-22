using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace HL7MonitorEmulator
{
    class MLLPServer
    {
        private int _port;
        private TcpListener _tcpListener;
        private Task _listenLoop;
        private CancellationTokenSource _cts;
        ConcurrentDictionary<Guid, MLLPClient> _clients;

        public int Port { get { return _port; } }

        public MLLPServer(int port)
        {
            _port = port;
            _tcpListener = new TcpListener(IPAddress.Any, _port);
            _clients = new ConcurrentDictionary<Guid, MLLPClient>();
        }

        public void Start()
        {
            _tcpListener.Start();
            _cts = new CancellationTokenSource();
            _listenLoop = Task.Factory.StartNew(ListenLoop, _cts.Token);
        }

        public void Stop()
        {
            foreach (var client in _clients)
            {
                client.Value.Disconnect();
            }

            _clients.Clear();

            _cts.Cancel();
            try
            {
                _listenLoop.Wait();
            }
            catch (Exception e)
            {

            }

            _tcpListener.Stop();
        }

        private async Task ListenLoop()
        {
            while (true)
            {
                Socket socket;
                try
                {
                    socket = await _tcpListener.AcceptSocketAsync().ConfigureAwait(false);
                }
                catch
                {
                    socket = null;
                }

                if (socket == null)
                {
                    break;
                }

                var client = new MLLPClient(socket);

                if (!_clients.TryAdd(client.Id, client))
                {
                    //duplicated id
                    client.Disconnect();
                    continue;
                }
            }
        }

        public IEnumerable<MLLPClient> Clients()
        {
            var disconnectedClients = _clients.Values.Where(x => !x.IsConnected()).Select(x => x.Id).ToList();

            foreach (var id in disconnectedClients)
            {
                MLLPClient client;
                _clients.TryRemove(id, out client);
            }

            return _clients.Values.ToList();
        }
    }
}
