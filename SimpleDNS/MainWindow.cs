using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace SimpleDNS
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void doResolve(object sender, EventArgs e)
        {
            StreamReader input = new StreamReader(openFileDialog1.OpenFile());

            string line = String.Empty;

            while ((line = input.ReadLine()) != null)
            {

                IPHostEntry MyHost = Dns.Resolve(line);

                textBox2.Text += line + "\r\n";
                foreach (IPAddress MyIP in MyHost.AddressList)
                {
                    textBox2.Text += ("\t" + MyIP.ToString() + "\r\n");
                }
            }
        }
    }
}
