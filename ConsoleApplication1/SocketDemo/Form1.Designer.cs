namespace SocketDemo
{
    partial class FrmServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textIP = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.btn_Start_Click = new System.Windows.Forms.Button();
            this.btn_Stoplisten_Click = new System.Windows.Forms.Button();
            this.cboIpPort = new System.Windows.Forms.ComboBox();
            this.textLog = new System.Windows.Forms.TextBox();
            this.textMsg = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btn_Select_Click = new System.Windows.Forms.Button();
            this.btn_SendFile_Click = new System.Windows.Forms.Button();
            this.btn_Send_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(12, 25);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(175, 21);
            this.textIP.TabIndex = 0;
            this.textIP.TextChanged += new System.EventHandler(this.textIP_TextChanged);
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(218, 25);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(70, 21);
            this.textPort.TabIndex = 1;
            // 
            // btn_Start_Click
            // 
            this.btn_Start_Click.Location = new System.Drawing.Point(386, 23);
            this.btn_Start_Click.Name = "btn_Start_Click";
            this.btn_Start_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Start_Click.TabIndex = 2;
            this.btn_Start_Click.Text = "开始监听";
            this.btn_Start_Click.UseVisualStyleBackColor = true;
            this.btn_Start_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Stoplisten_Click
            // 
            this.btn_Stoplisten_Click.Location = new System.Drawing.Point(482, 23);
            this.btn_Stoplisten_Click.Name = "btn_Stoplisten_Click";
            this.btn_Stoplisten_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Stoplisten_Click.TabIndex = 3;
            this.btn_Stoplisten_Click.Text = "停止监听";
            this.btn_Stoplisten_Click.UseVisualStyleBackColor = true;
            this.btn_Stoplisten_Click.Click += new System.EventHandler(this.btn_Stoplisten_Click_Click);
            // 
            // cboIpPort
            // 
            this.cboIpPort.FormattingEnabled = true;
            this.cboIpPort.Location = new System.Drawing.Point(592, 26);
            this.cboIpPort.Name = "cboIpPort";
            this.cboIpPort.Size = new System.Drawing.Size(121, 20);
            this.cboIpPort.TabIndex = 4;
            // 
            // textLog
            // 
            this.textLog.HideSelection = false;
            this.textLog.Location = new System.Drawing.Point(12, 89);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(545, 151);
            this.textLog.TabIndex = 5;
            this.textLog.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textMsg
            // 
            this.textMsg.Location = new System.Drawing.Point(12, 278);
            this.textMsg.Multiline = true;
            this.textMsg.Name = "textMsg";
            this.textMsg.Size = new System.Drawing.Size(545, 163);
            this.textMsg.TabIndex = 6;
            this.textMsg.TextChanged += new System.EventHandler(this.textMsg_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(21, 487);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(383, 21);
            this.textBox5.TabIndex = 7;
            // 
            // btn_Select_Click
            // 
            this.btn_Select_Click.Location = new System.Drawing.Point(458, 487);
            this.btn_Select_Click.Name = "btn_Select_Click";
            this.btn_Select_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Select_Click.TabIndex = 8;
            this.btn_Select_Click.Text = "选择";
            this.btn_Select_Click.UseVisualStyleBackColor = true;
            // 
            // btn_SendFile_Click
            // 
            this.btn_SendFile_Click.Location = new System.Drawing.Point(563, 487);
            this.btn_SendFile_Click.Name = "btn_SendFile_Click";
            this.btn_SendFile_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_SendFile_Click.TabIndex = 9;
            this.btn_SendFile_Click.Text = "发送文件";
            this.btn_SendFile_Click.UseVisualStyleBackColor = true;
            // 
            // btn_Send_Click
            // 
            this.btn_Send_Click.Location = new System.Drawing.Point(458, 527);
            this.btn_Send_Click.Name = "btn_Send_Click";
            this.btn_Send_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Send_Click.TabIndex = 10;
            this.btn_Send_Click.Text = "发送消息";
            this.btn_Send_Click.UseVisualStyleBackColor = true;
            this.btn_Send_Click.Click += new System.EventHandler(this.btn_Send_Click_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 562);
            this.Controls.Add(this.btn_Send_Click);
            this.Controls.Add(this.btn_SendFile_Click);
            this.Controls.Add(this.btn_Select_Click);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textMsg);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.cboIpPort);
            this.Controls.Add(this.btn_Stoplisten_Click);
            this.Controls.Add(this.btn_Start_Click);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIP);
            this.Name = "FrmServer";
            this.Text = "客户端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Button btn_Start_Click;
        private System.Windows.Forms.ComboBox cboIpPort;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.TextBox textMsg;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btn_Select_Click;
        private System.Windows.Forms.Button btn_SendFile_Click;
        private System.Windows.Forms.Button btn_Send_Click;
        protected internal System.Windows.Forms.Button btn_Stoplisten_Click;
    }
}

