using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NILogger
{
    public partial class ConnectPort : Form
    {
        public ConnectPort()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            portname1.Enabled = true;
            cbCOM.Checked = false;
            cbTCP.Checked = true;
        }

        private void cbCOM_CheckedChanged(object sender, EventArgs e)
        {
            portname1.Enabled = false;
            cbTCP.Checked = false;
            cbCOM.Checked = true;

        }
    }
}
