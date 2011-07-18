using System;
using System.Windows.Forms;

namespace AVNC
{
    public partial class LogViewer : Form
    {
        public LogViewer(string title, string time, string ip, string value)
        {
            InitializeComponent();

            titleTB.Text = title;
            timeTB.Text = time;
            ipTB.Text = ip;
            detailsTB.Text = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            this.Dispose(); //do we need this? is it ok to do this?
        }
    }
}