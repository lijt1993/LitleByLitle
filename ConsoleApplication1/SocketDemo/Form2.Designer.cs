namespace SocketDemo
{
    partial class Form2
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
            this.textIP = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.btn_Connection_Click = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btn_Send_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(50, 36);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(170, 21);
            this.textIP.TabIndex = 0;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(270, 36);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(80, 21);
            this.textPort.TabIndex = 1;
            // 
            // btn_Connection_Click
            // 
            this.btn_Connection_Click.Location = new System.Drawing.Point(405, 34);
            this.btn_Connection_Click.Name = "btn_Connection_Click";
            this.btn_Connection_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Connection_Click.TabIndex = 2;
            this.btn_Connection_Click.Text = "连接";
            this.btn_Connection_Click.UseVisualStyleBackColor = true;
            this.btn_Connection_Click.Click += new System.EventHandler(this.btn_Connection_Click_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(50, 122);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(385, 102);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(50, 287);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(385, 109);
            this.textBox4.TabIndex = 4;
            // 
            // btn_Send_Click
            // 
            this.btn_Send_Click.Location = new System.Drawing.Point(515, 468);
            this.btn_Send_Click.Name = "btn_Send_Click";
            this.btn_Send_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Send_Click.TabIndex = 5;
            this.btn_Send_Click.Text = "发送消息";
            this.btn_Send_Click.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 507);
            this.Controls.Add(this.btn_Send_Click);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btn_Connection_Click);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIP);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Button btn_Connection_Click;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btn_Send_Click;
    }
}