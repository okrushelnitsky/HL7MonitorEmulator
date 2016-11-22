using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HL7MonitorEmulator
{
    public partial class MainForm : Form
    {
        private Backend _backend;

        public MainForm()
        {
            _backend = new Backend();
            _backend.OnSend = (measurement) =>
            {
                this.BeginInvoke((MethodInvoker) delegate() { UpdateLastMessage(measurement); });
            };
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int port;
            if (!Int32.TryParse(txtPort.Text, out port))
            {
                return;
            }

            _backend.StartServer(port);

            btnStop.Enabled = true;
            txtPort.ReadOnly = true;
            btnStart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _backend.StopServer();

            btnStart.Enabled = true;
            txtPort.ReadOnly = false;
            btnStop.Enabled = false;
        }

        private void btnLoadSequence_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            fileDialog.FilterIndex = 1;
            fileDialog.Multiselect = false;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filename = fileDialog.FileNames.FirstOrDefault();

                    _backend.LoadMessages(filename);
                    lblSequenceStatus.Text = $"Loaded {filename}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void rdb2s_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2s.Checked)
            {
                _backend.ChangeDelay(2000);
            }
        }

        private void rdb10s_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb10s.Checked)
            {
                _backend.ChangeDelay(10000);
            }
        }

        private void rdb30s_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb30s.Checked)
            {
                _backend.ChangeDelay(30000);
            }
        }

        private void rdb1m_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1m.Checked)
            {
                _backend.ChangeDelay(60000);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _backend.StopServer();
        }

        private void UpdateLastMessage(Measurement measurement)
        {
            this.lblLastMessage.Text = $"Last sent message:\n" +
                $"  Hearth rhytm: {measurement.HearthRhytm}bpm,\n" +
                $"  SpO2: {measurement.SpO2}%";
        }
    }
}
