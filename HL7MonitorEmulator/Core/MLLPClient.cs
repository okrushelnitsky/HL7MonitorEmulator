using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NHapiTools.Base.Util;

namespace HL7MonitorEmulator
{
    public class MLLPClient
    {
        public Guid Id { get; private set; }

        private readonly Socket _socket;
        private readonly NetworkStream _networkStream;

        public MLLPClient(Socket socket)
        {
            Id = new Guid();

            _socket = socket;
            _networkStream = new NetworkStream(_socket, true);
        }

        public async Task SendMessageAsync(string message)
        {
            message = MLLP.CreateMLLPMessage(message);

            var buffer = Encoding.ASCII.GetBytes(message);

            await _networkStream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            await _networkStream.FlushAsync().ConfigureAwait(false);

            var responseBuffer = new byte[4096];
            int responseLength = await _networkStream.ReadAsync(responseBuffer, 0, responseBuffer.Length).ConfigureAwait(false);
        }

        public bool IsConnected()
        {
            return _socket.Connected;
        }

        public void Disconnect()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Disconnect(false);
        }
    }
}