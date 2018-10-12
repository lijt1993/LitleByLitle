using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private void btn_Connection_Click_Click(object sender, EventArgs e)
        {
            //连接到的目标IP

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
