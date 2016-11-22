using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HL7MonitorEmulator
{
    public class Backend
    {
        private MLLPServer _server;
        private Thread _messagesThread;
        private CancellationTokenSource _cts;
        private int _delay;
        private MeasurementSequence _messageSequence;

        public Action<Measurement> OnSend { get; set; }

        public Backend()
        {
            _messageSequence = new MeasurementSequence();
            _delay = 2000;
        }

        public void StartServer(int port)
        {
            if (_server == null || _server.Port != port)
            {
                _server = new MLLPServer(port);
            }

            _server.Start();

            _cts = new CancellationTokenSource();
            _messagesThread = new Thread(() => MessageThread(_server, _messageSequence, _delay, _cts.Token, OnSend));
            _messagesThread.Start();
        }

        public void StopServer()
        {
            if (_messagesThread != null)
            {
                _cts.Cancel();
                _messagesThread.Join();
            }

            if (_server != null)
            {
                _server.Stop();
            }

            _messageSequence.ResetIndex();
        }

        public void ChangeDelay(int delay)
        {
            _delay = delay;

            if (_messagesThread != null && _messagesThread.IsAlive)
            {
                _cts.Cancel();
                _messagesThread.Join();

                _cts = new CancellationTokenSource();
                _messagesThread = new Thread(() => MessageThread(_server, _messageSequence, _delay, _cts.Token, OnSend));
                _messagesThread.Start();
            }
        }

        public void LoadMessages(string fileName)
        {
            _messageSequence.Load(fileName);
        }

        private static void MessageThread(MLLPServer server, MeasurementSequence messageSequence, int delay, CancellationToken token, Action<Measurement> onSend)
        {
            while (!token.IsCancellationRequested)
            {
                var measurement = messageSequence.GetMeasurement();

                if (measurement != null)
                {
                    var message = BuildHL7Message(measurement.Value);

                    List<Task> tasks = new List<Task>();

                    foreach (MLLPClient client in server.Clients())
                    {
                        tasks.Add(client.SendMessageAsync(message));
                    }

                    onSend?.Invoke(measurement.Value);

                    try
                    {
                        Task.WaitAll(tasks.ToArray(), token);
                    }
                    catch {}

                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                }

                token.WaitHandle.WaitOne(delay);
            }
        }

        private static string BuildHL7Message(Measurement measurement)
        {
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

            string message = "MSH|^~\\&|NIHON KOHDEN|NIHON KOHDEN|CLIENT APP|CLIENT FACILITY|{0}||ORU^R01^ORU_R01|{0}|P|2.4|||NE|AL||ASCII||ASCII\r" +
                "PID|||5555||TET^^^^^^L^A|||O\r" +
                "PV1||I|^^Notfall^10.37.80.201:1\r" +
                "ORC|RE\r" +
                "OBR|1|||VITAL|||{0}||||||||||||||||||A\r" +
                "OBX|1|NM|001000^VITAL HR|1|{1}|bpm|||||F|||{0}|||\r" +
                "OBX|2|NM|007000^VITAL SpO2|1|{2}|%|||||F|||{0}|||";

            message = String.Format(message, timestamp, measurement.HearthRhytm, measurement.SpO2);

            return message;
        }
    }
}
