using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToStringForm
{
    public partial class ProcessForm : Form
    {
        public ProcessForm()
        {
            InitializeComponent();
        }
        class ThreadInfo
        {
            public string FileName { get; set; }
            public int SelectIndex { get; set; }

        }

        private delegate bool BarDelegate();

        private void btnStart_Click(object sender, EventArgs e)
        {
            ThreadInfo threadInfo = new ThreadInfo();
            threadInfo.FileName = "XXX";
            threadInfo.SelectIndex = 3;
            var task = new Task(() =>
            {

                if (ProcessFile(threadInfo))
                {
                    MessageBox.Show("执行完成");
                }


            });
            task.Start();
            //ThreadInfo threadInfo = new ThreadInfo();
            //threadInfo.FileName = "XXX";
            //threadInfo.SelectIndex = 3;
            //ThreadPool.SetMinThreads(5, 5);
            //ThreadPool.SetMaxThreads(10, 10);
            //ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessFile), threadInfo);
        }
        private bool ProcessFile(object a)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            bool result = false;
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                ThreadInfo threadInfo = a as ThreadInfo;
                string fileName = threadInfo.FileName;
                int index = threadInfo.SelectIndex;
                result = (bool)Invoke(new BarDelegate(BarUpdate));
            }
            return result;
        }

        public bool BarUpdate()
        {
            bool result = false;
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;

            }
            if (progressBar1.Value == progressBar1.Maximum)
            {
                result = true;
            }
            return result;
        }
    }
}
