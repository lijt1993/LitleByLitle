using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace WindowsFormsThread
{
    public partial class Form1 : Form
    {
        private Thread thread;
      
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(fun));
            label1.Text="0";
            thread.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread.Suspend();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread.Resume();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (thread.IsAlive)
            {
                thread.Abort();//撤销线程对象
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }

        }

        public void fun()
        {
            while (true)
            {
                int x = Convert.ToInt32(label1.Text);
                x++;
                label1.Text = Convert.ToString(x);

                Thread.Sleep(1000);
            }
        }
    }
}
