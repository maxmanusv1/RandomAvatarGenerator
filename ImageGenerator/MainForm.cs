using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageGenerator.Keywords;
using ImageGenerator.LogManager;
using ImageGenerator.ProdiaAI;
using ImageGenerator.PromptGenerator;

namespace ImageGenerator
{
    public partial class MainForm : Form
    {
        private Stopwatch stopwatch;
        public MainForm()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
        }
        Generate Generate = new Generate();
        LogManager.LogManager LogManager = new LogManager.LogManager();   
        ProdiaGenerator ProdiaGenerator = new ProdiaGenerator();    
        private async void MainForm_Load(object sender, EventArgs e)
        {
        }
        public bool isDisposed = false;
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;    
            stopwatch.Start();
            while (IsDisposed==false)
            {
                await ProdiaGenerator.PostProdiaAsync(richTextBox1, label2);
                if (isDisposed != false)
                    break;
            }
            button1.Enabled = true;
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            label3.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isDisposed = true;
            MessageBox.Show("Task will be stopped!");
        }
    }
}
