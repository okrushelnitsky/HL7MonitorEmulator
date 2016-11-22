using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7MonitorEmulator
{
    public struct Measurement
    {
        public int HearthRhytm { get; set; }
        public int SpO2 { get; set; }
    }

    public class MeasurementSequence
    {
        private List<Measurement> _sequence;
        private int _currentIndex;
        private object _sync;

        public MeasurementSequence()
        {
            _sequence = new List<Measurement>();
            _sync = new object();
        }

        public void Load(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            var measurements = new List<Measurement>();
            foreach (var line in lines)
            {
                var strValues = line.Split(',').Select(x => x.Trim()).ToArray();

                if (strValues.Length < 2)
                {
                    continue;
                }

                var measurement = new Measurement()
                {
                    HearthRhytm = ParseInt(strValues[0]),
                    SpO2 = ParseInt(strValues[1])
                };

                measurements.Add(measurement);
            }

            lock (_sync)
            {
                _sequence = measurements;
                _currentIndex = 0;
            }
        }

        public void ResetIndex()
        {
            lock (_sync)
            {
                _currentIndex = 0;
            }
        }

        public Measurement? GetMeasurement()
        {
            if (!_sequence.Any())
            {
                return null;
            }

            lock(_sync)
            {
                var measurement = _sequence[_currentIndex];
                _currentIndex += 1;
                if (_currentIndex >= _sequence.Count)
                {
                    _currentIndex = 0;
                }

                return measurement;
            }
        }

        private int ParseInt(string s)
        {
            int value;
            if (!Int32.TryParse(s, out value))
            {
                return 0;
            }

            return value;
        }
    }
}
