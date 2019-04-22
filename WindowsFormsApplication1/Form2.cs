using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NILogger
{
    public partial class Form2 : Form
    {
        public DataTable channelDetails;
        private int moduleNumber;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            moduleNumber = 0;

            textBox1.Text = MonitorWindow.n[moduleNumber].ToString();
            channelDetails = new DataTable("ChannelProp");
            dgv_ModuleData.DataSource = channelDetails;
            DataColumn column;

            //Create Channel position column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Channel";
            column.ReadOnly = true;
            column.Unique = true;
            channelDetails.Columns.Add(column);

            //Create Channel Nickname column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Nickname";
            column.ReadOnly = false;
            column.Unique = true;
            channelDetails.Columns.Add(column);

            //Create Channel Range column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Range";
            column.ReadOnly = false;
            column.Unique = false;
            channelDetails.Columns.Add(column);

            //Create Channel Scale column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Scale";
            column.ReadOnly = false;
            column.Unique = false;
            channelDetails.Columns.Add(column);

            //Create Channel Raw Number column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Raw";
            column.ReadOnly = false;
            column.Unique = false;
            channelDetails.Columns.Add(column);

            //Create Channel Display Value column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Display";
            column.ReadOnly = false;
            column.Unique = false;
            channelDetails.Columns.Add(column);

            //Create Channel input Value column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Input";
            column.ReadOnly = false;
            column.Unique = false;
            channelDetails.Columns.Add(column);

            movemodule(0);


        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Would you like to save changes to the file?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MonitorWindow.saveNetwork();
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            movemodule(1);

        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            movemodule(-1);
        }

        private DataRow getrow(int rownumber, FPModule module)
        {
            DataRow row = channelDetails.NewRow();
            int i = 0;
            row[i++] = rownumber; // channel position
            row[i++] = module.getChannelName(rownumber); //name of channel
            row[i++] = module.getchannelRange(rownumber);// channel range
            row[i++] = module.getChannelScale(rownumber);
            row[i++] = module.getChannelRaw(rownumber);
            row[i++] = module.getChannelDisplayValue(rownumber);
            row[i++] = module.getChannelUnitValue(rownumber);
            return row;
        }

        private void movemodule(int direction)
        {
            moduleNumber = moduleNumber + direction;
            FPModule temp = MonitorWindow.n[moduleNumber];

            if (moduleNumber >= MonitorWindow.n.Length)
                btn_next.Enabled = false;
            else
                btn_next.Enabled = true;

            if (moduleNumber <= 0)
                btn_prev.Enabled = false;
            else
                btn_prev.Enabled = true;

            textBox1.Text = temp.ToString();

            // channelDetails = new DataTable("ChannelProp");
            channelDetails.Clear();
            try
            {
                for (int j = 0; j < temp.size(); j++)
                {
                    channelDetails.Rows.Add(getrow(j, temp));
                }
                //dgv_ModuleData.DataSource = channelDetails;
            }
            catch (Exception err)
            {
                Console.WriteLine("error: " + err.Data);
                MessageBox.Show("error: " + err.Message);
                //throw;
            }

            DataGridViewCell datacell;


        }

        private void dgv_ModuleData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_ModuleData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FPModule temp = MonitorWindow.n[moduleNumber];
            string[] newlist = temp.getchannelattribs(e.RowIndex);
            while (AtribListBox.Items.Count > 0)
            {
                AtribListBox.Items.RemoveAt(0);
            }

            foreach (string s in newlist)
            {
                AtribListBox.Items.Add(s);
            }
            AtribListBox.Visible = true;

        }

        private void dgv_ModuleData_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void dgv_ModuleData_MouseHover(object sender, EventArgs e)
        {
            AtribListBox.Visible = false;
        }

        private void btn_calibrate_Click(object sender, EventArgs e)
        {
            MonitorWindow.n[moduleNumber].calibrateChannelDisplay(0, 0, 0, 10, 20);
        }

        private void dgv_ModuleData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                calibrateform temp = new calibrateform();

                if (temp.ShowDialog(this) == DialogResult.OK)
                {
                    MonitorWindow.n[moduleNumber].calibrateChannelDisplay(e.RowIndex,
                                                                            float.Parse(temp.tb_display1.Text),
                                                                            float.Parse(temp.tb_input1.Text),
                                                                            float.Parse(temp.tb_display2.Text),
                                                                            float.Parse(temp.tb_input2.Text));
                }
            }

            if (e.ColumnIndex == 1)
            {
                nickname temp = new nickname();
                if (temp.ShowDialog(this) == DialogResult.OK)
                {
                    MonitorWindow.n[moduleNumber].setChannelNickname(e.RowIndex, temp.tb_Name.Text);
                }
            }

            MonitorWindow.n.UpdateNetwork();
            movemodule(0);


        }

        private void ReloadModule_Click(object sender, EventArgs e)
        {
           // MonitorWindow.n[moduleNumber].reloadfromnetwork(); // = new WindowsFormsApplication1.FPModule(MonitorWindow.t, moduleNumber);
            MonitorWindow.n[moduleNumber] = new NILogger.FPModule(MonitorWindow.t, moduleNumber);
        }
    }
}
