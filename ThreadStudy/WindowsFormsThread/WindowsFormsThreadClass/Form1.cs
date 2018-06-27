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

namespace WindowsFormsThreadClass
{
    public partial class Form1 : Form
    {
        
        myThread myThread1, myThread2;
        public Form1()
        {
            InitializeComponent();
           CheckForIllegalCrossThreadCalls = false;
            //myThread1=new myThread(100,progressBar1);
            //myThread2=new myThread(200,progressBar2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myThread1 = new myThread(100, progressBar1);
            myThread2 = new myThread(200, progressBar2);

        }


    }

    public class myThread 
    {
        Form1 form1 = new Form1();
        private int SleepTime;
        private ProgressBar progressbar;
        private Thread thread1;

        public myThread(int Time, ProgressBar p1)
        {
            SleepTime = Time;
            progressbar = p1;
            thread1 = new Thread(new ThreadStart(fun));
            thread1.Start();

        }

        public void fun()
        {
            while (progressbar.Value != 100)
            {
                progressbar.Value += 1;
                Thread.Sleep(SleepTime);
            }
            if (form1.label1.Text == "")
            {
                form1.label1.Text = "第一个线程结束";
            }
            else
            {
                form1.label1.Text = "第二个线程结束";
            }

        }

    }
   
}
