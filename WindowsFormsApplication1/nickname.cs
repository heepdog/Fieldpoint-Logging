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
    public partial class nickname : Form
    {
        public nickname()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.btn_cancel.DialogResult = DialogResult.Cancel;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.btn_ok.DialogResult = DialogResult.OK;
        }
    }
}
