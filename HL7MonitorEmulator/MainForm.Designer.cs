namespace HL7MonitorEmulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLastMessage = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdb1m = new System.Windows.Forms.RadioButton();
            this.rdb30s = new System.Windows.Forms.RadioButton();
            this.rdb10s = new System.Windows.Forms.RadioButton();
            this.rdb2s = new System.Windows.Forms.RadioButton();
            this.lblSequenceStatus = new System.Windows.Forms.Label();
            this.btnLoadSequence = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server settings";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(228, 17);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(147, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(41, 19);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "6661";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblLastMessage);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lblSequenceStatus);
            this.groupBox2.Controls.Add(this.btnLoadSequence);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 222);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message settings";
            // 
            // lblLastMessage
            // 
            this.lblLastMessage.AutoSize = true;
            this.lblLastMessage.Location = new System.Drawing.Point(9, 95);
            this.lblLastMessage.Name = "lblLastMessage";
            this.lblLastMessage.Size = new System.Drawing.Size(98, 13);
            this.lblLastMessage.TabIndex = 3;
            this.lblLastMessage.Text = "Last sent message:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdb1m);
            this.groupBox3.Controls.Add(this.rdb30s);
            this.groupBox3.Controls.Add(this.rdb10s);
            this.groupBox3.Controls.Add(this.rdb2s);
            this.groupBox3.Location = new System.Drawing.Point(6, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 44);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Delay between messages";
            // 
            // rdb1m
            // 
            this.rdb1m.AutoSize = true;
            this.rdb1m.Location = new System.Drawing.Point(153, 19);
            this.rdb1m.Name = "rdb1m";
            this.rdb1m.Size = new System.Drawing.Size(42, 17);
            this.rdb1m.TabIndex = 3;
            this.rdb1m.Text = "1 m";
            this.rdb1m.UseVisualStyleBackColor = true;
            this.rdb1m.CheckedChanged += new System.EventHandler(this.rdb1m_CheckedChanged);
            // 
            // rdb30s
            // 
            this.rdb30s.AutoSize = true;
            this.rdb30s.Location = new System.Drawing.Point(102, 19);
            this.rdb30s.Name = "rdb30s";
            this.rdb30s.Size = new System.Drawing.Size(45, 17);
            this.rdb30s.TabIndex = 2;
            this.rdb30s.Text = "30 s";
            this.rdb30s.UseVisualStyleBackColor = true;
            this.rdb30s.CheckedChanged += new System.EventHandler(this.rdb30s_CheckedChanged);
            // 
            // rdb10s
            // 
            this.rdb10s.AutoSize = true;
            this.rdb10s.Location = new System.Drawing.Point(51, 19);
            this.rdb10s.Name = "rdb10s";
            this.rdb10s.Size = new System.Drawing.Size(45, 17);
            this.rdb10s.TabIndex = 1;
            this.rdb10s.Text = "10 s";
            this.rdb10s.UseVisualStyleBackColor = true;
            this.rdb10s.CheckedChanged += new System.EventHandler(this.rdb10s_CheckedChanged);
            // 
            // rdb2s
            // 
            this.rdb2s.AutoSize = true;
            this.rdb2s.Checked = true;
            this.rdb2s.Location = new System.Drawing.Point(6, 19);
            this.rdb2s.Name = "rdb2s";
            this.rdb2s.Size = new System.Drawing.Size(39, 17);
            this.rdb2s.TabIndex = 0;
            this.rdb2s.TabStop = true;
            this.rdb2s.Text = "2 s";
            this.rdb2s.UseVisualStyleBackColor = true;
            this.rdb2s.CheckedChanged += new System.EventHandler(this.rdb2s_CheckedChanged);
            // 
            // lblSequenceStatus
            // 
            this.lblSequenceStatus.AutoSize = true;
            this.lblSequenceStatus.Location = new System.Drawing.Point(90, 24);
            this.lblSequenceStatus.Name = "lblSequenceStatus";
            this.lblSequenceStatus.Size = new System.Drawing.Size(119, 13);
            this.lblSequenceStatus.TabIndex = 1;
            this.lblSequenceStatus.Text = "Sequence is not loaded";
            // 
            // btnLoadSequence
            // 
            this.btnLoadSequence.Location = new System.Drawing.Point(9, 19);
            this.btnLoadSequence.Name = "btnLoadSequence";
            this.btnLoadSequence.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSequence.TabIndex = 0;
            this.btnLoadSequence.Text = "Load";
            this.btnLoadSequence.UseVisualStyleBackColor = true;
            this.btnLoadSequence.Click += new System.EventHandler(this.btnLoadSequence_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 303);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "HL7 Monitor emulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLastMessage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdb1m;
        private System.Windows.Forms.RadioButton rdb30s;
        private System.Windows.Forms.RadioButton rdb10s;
        private System.Windows.Forms.RadioButton rdb2s;
        private System.Windows.Forms.Label lblSequenceStatus;
        private System.Windows.Forms.Button btnLoadSequence;
    }
}