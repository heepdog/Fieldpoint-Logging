using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public DataTable channelDetails;

        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = MonitorWindow.n[5].ToString();
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

            FPModule temp = MonitorWindow.n[1];
            DataRow row = channelDetails.NewRow();
            int i = 0;
            row[i++] = 1;
            row[i++] = temp.getChannelName(5);
            row[i++] = temp.getchannelRange(1);
            row[i++] = temp.getChannelScale(1);
            row[i++] = temp.getChannelRaw(1);
            row[i++] = temp.getChannelDisplayValue(1);
            row[i++] = temp.getChannelUnitValue(1);

            channelDetails.Rows.Add(row);
            dgv_ModuleData.DataSource = channelDetails;



        }


    }
}
