using System.Windows.Forms.DataVisualization.Charting;

namespace AxiaFutures.Forms
{
    partial class Feed
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
            btnDisconnect = new Button();
            checkBox1 = new CheckBox();
            label1 = new Label();
            lblVolume = new Label();
            trackBar1 = new TrackBar();
            txtMessage = new TextBox();
            lblStatus = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // btnDisconnect
            // 
            btnDisconnect.BackColor = Color.Gray;
            btnDisconnect.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDisconnect.ForeColor = Color.Black;
            btnDisconnect.Location = new Point(515, 506);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(126, 32);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Disconect";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Black;
            checkBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            checkBox1.ForeColor = Color.Gold;
            checkBox1.Location = new Point(447, 315);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(280, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Usar reprodutor de voz para ler as mensagens";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(102, 37);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 5;
            label1.Text = "Mensagem";
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVolume.ForeColor = Color.Gold;
            lblVolume.Location = new Point(105, 297);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(49, 15);
            lblVolume.TabIndex = 6;
            lblVolume.Text = "Volume";
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.Black;
            trackBar1.Location = new Point(102, 315);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(157, 45);
            trackBar1.TabIndex = 7;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.Silver;
            txtMessage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtMessage.ForeColor = Color.Black;
            txtMessage.Location = new Point(102, 65);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ReadOnly = true;
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(953, 203);
            txtMessage.TabIndex = 1;
            txtMessage.Text = "Aguardando envio de mensagem...";
            txtMessage.WordWrap = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(636, 286);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.DarkGray;
            label2.Location = new Point(481, 286);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 9;
            label2.Text = "Status do WebSocket:";
            // 
            // button1
            // 
            button1.BackColor = Color.Gold;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(884, 445);
            button1.Name = "button1";
            button1.Size = new Size(171, 31);
            button1.TabIndex = 10;
            button1.Text = "Ler com o TTS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(105, 423);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 11;
            label3.Text = "Digite uma mensagem:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(105, 450);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(595, 32);
            textBox1.TabIndex = 12;
            // 
            // Feed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1156, 567);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(lblStatus);
            Controls.Add(trackBar1);
            Controls.Add(lblVolume);
            Controls.Add(label1);
            Controls.Add(txtMessage);
            Controls.Add(checkBox1);
            Controls.Add(btnDisconnect);
            Name = "Feed";
            Text = "Feed";
            FormClosed += Feed_FormClosed;
            Load += Feed_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDisconnect;
        private CheckBox checkBox1;
        private Label label1;
        private Label lblVolume;
        private TrackBar trackBar1;
        private TextBox txtMessage;
        private Label lblStatus;
        private Label label2;
        private Button button1;
        private Label label3;
        private TextBox textBox1;
    }
}