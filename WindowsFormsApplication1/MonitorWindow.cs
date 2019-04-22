using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace NILogger
{
    public partial class MonitorWindow : Form
    {
        public static FPNetwork n = new FPNetwork();
        public static LoggerStream t = new LoggerStream();
        private DataTable temptable = new DataTable();

        public MonitorWindow()
        {
            InitializeComponent();
        }

        private void label20_Click(object sender, EventArgs e)
        {
 

        }

        private void MonitorWindow_Load(object sender, EventArgs e)
        {
            temptable.TableName = "TestData";
            temptable.Columns.Add("Time", typeof(DateTime));
            temptable.Columns.Add("Appliance In", typeof(double));
            temptable.Columns.Add("Appliance Out", typeof(double));
            temptable.Columns.Add("Load In", typeof(double));
            temptable.Columns.Add("Load out", typeof(double));
            temptable.Columns.Add("Stack Temp", typeof(double));
            temptable.Columns.Add("Meter Temp", typeof(double));
            temptable.Columns.Add("Ft^2", typeof(double));
            temptable.Columns.Add("CFM", typeof(double));
            temptable.Columns.Add("delta H", typeof(double));
            temptable.Columns.Add("Probe Temp", typeof(double));
            temptable.Columns.Add("Dilution Temp", typeof(double));
            temptable.Columns.Add("Weight", typeof(double));


            dgv_TempData.DataSource = temptable;
            dgv_TempData.Columns["Time"].DefaultCellStyle.Format = "MM/dd HH:mm:ss";
            dgv_TempData.Columns["Appliance In"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Appliance Out"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Load In"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Load out"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Stack Temp"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Meter Temp"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Ft^2"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["CFM"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["delta H"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Probe Temp"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Dilution Temp"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_TempData.Columns["Weight"].SortMode = DataGridViewColumnSortMode.NotSortable;

            string[] port = Properties.Settings.Default.LastPort.Split(' ');
            if (port.Length == 1)
            {
                t = new LoggerStream(port[0]);
                if (t.IsOpen)
                {
                    btn_getnetwork.Enabled = true;
                    Properties.Settings.Default.LastPort = port[0];
                    Properties.Settings.Default.Save();
                    ConnectionStatusbar.Text = "Port Connected";
                }
            }

            if (port.Length == 2)
            {
                t = new LoggerStream(port[0], int.Parse(port[1]));
                if (t.IsOpen)
                {
                    btn_getnetwork.Enabled = true;
                    Properties.Settings.Default.LastPort = port[0] + " " + port[1];
                    Properties.Settings.Default.Save();
                    ConnectionStatusbar.Text = "Port Connected";
                }
            }
            if (t.IsOpen)
            {
                setupPort();
            }
            else
            {
                MessageBox.Show("Could Not Setup Port");
            }

        }

        private bool setupPort()
        {

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + Properties.Settings.Default.NetworkData + ".bin";
            btn_getnetwork.Enabled = true;
            if (File.Exists(path))
            {
                //if (MessageBox.Show("Do you want to load the network from a file?", "Open file?", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
                //{

                IFormatter formatter = new BinaryFormatter();
                Stream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                n = (FPNetwork)formatter.Deserialize(fs);
                fs.Close();
                n.SetNetworkPort(t);
                btn_EditModules.Enabled = true;
                btn_StartTest.Enabled = true;

                UpdateForm.RunWorkerAsync();

                //}
            }

            return true;

        }

        private void btn_getnetwork_Click(object sender, EventArgs e)
        {
            if (!t.IsOpen)
            {
                MessageBox.Show("port is not connected");
                return;
            }

            IFormatter formatter = new BinaryFormatter();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + Properties.Settings.Default.NetworkData +".bin";
            //Get network from Serial and save//
            n = new FPNetwork();
            n.GetNetwork(t);
            if (n.Length > 0)
            {
                Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, n);

                //Load Network from File
                //Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                //n = (FPNetwork)formatter.Deserialize(stream);
                //n.SetNetworkPort(t);

                stream.Close();

                FPModule temp;
                int i = 0;
                do
                {
                    temp = n[i];
                    Console.WriteLine(temp.ToString());
                    i++;
                } while (i <= n.Length);
                btn_EditModules.Enabled = true;
                btn_StartTest.Enabled = true;
            }
        }

        public static bool saveNetwork()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + Properties.Settings.Default.NetworkData + ".bin";
                Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, n);
                stream.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Error Saving Network" + exception.Message);
                return false;
            }
           
                return true;
        }

        private void MonitorWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpdateForm.IsBusy)
                UpdateForm.CancelAsync();
            Dispose();
       
        }

        private async void btn_UpdateValues_Click(object sender, EventArgs e)
        {

            Task<bool> updatingValues = TaskEx.Run( ()=>n.UpdateNetwork());
            await updatingValues;

        }

        private void btn_EditModules_Click(object sender, EventArgs e)
        {
            Form2 editform = new Form2();
            editform.ShowDialog();
        }

        private void cOM6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t = new NILogger.LoggerStream("192.168.1.114", 5001);
            Properties.Settings.Default.LastPort = "192.168.1.114" + " " + "5001";
            Properties.Settings.Default.Save();

        }

        private void MonitorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t.IsOpen) 
                t.Close();
            Dispose();

        }

        private void UpdateForm_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!t.IsOpen)
            {
                MessageBox.Show("Port is not connected");
            }
            if (!n.IsConfigured)
            {
                MessageBox.Show("Network has not been Configured");
            }

            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                while (!worker.CancellationPending)
                {

                    n.UpdateNetwork();
                    //foreach (FPModule f in n)
                    //{
                    //    Debug.WriteLine(f.ToString());
                    //}

                    worker.ReportProgress(1);
                    Thread.Sleep(5000);
                }


                n.UpdateNetwork();
                foreach (FPModule f in n)
                {
                    Debug.WriteLine(f.ToString());
                }
            }
            catch (Exception exept)
            {
                Debug.WriteLine(exept.ToString());
                btn_StartTest.Text = "Start Test";
                throw;
            }
            }

        private void btn_StartTest_Click(object sender, EventArgs e)
        {
            if (!TableTimer.Enabled)
            {
                 updatetable();
                TableTimer.Start();
                btn_StartTest.Text = "Stop Monitor";
            }
            else
            {
                //UpdateForm.CancelAsync();
                btn_StartTest.Text = "Start Monitor";
                TableTimer.Stop();
            }

        }

        private void UpdateForm_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Debug.WriteLine("update form");
            LoadInTemp.Text = n[7].getChannelDisplayValue(5).ToString("N2");
            LoadOutTemp.Text = n[7].getChannelDisplayValue(4).ToString("N2");
            ApplianceTempIn.Text = n[7].getChannelDisplayValue(0).ToString("N2");
            ApplianceOutTemp.Text = n[7].getChannelDisplayValue(1).ToString("N2");
            lbl_meterTemp.Text = n[6].getChannelDisplayValue(0).ToString("N2");
            lbl_probeTemp.Text = n[6].getChannelDisplayValue(1).ToString("N2");
            lbl_deltaH.Text = n[2].getChannelDisplayValue(2).ToString("N2");
            lbl_weight.Text = n[2].getChannelDisplayValue(3).ToString("N2");
            ApploianceFlow.Text = n[3].getChannelDisplayValue(3).ToString("N2");
            LoadFlow.Text = n[3].getChannelDisplayValue(4).ToString("N2");
            lbl_ftCubed.Text = n[1].getChannelDisplayValue(16).ToString("N3");
            tb_dilution.Text = n[5].getChannelDisplayValue(1).ToString("N2");
            tb_stack.Text = n[5].getChannelDisplayValue(0).ToString("N2");
            lbl_VAC.Text = n[2].getChannelDisplayValue(0).ToString("N2");
            if (temptable.Rows.Count > 0)
            {
                DateTime last = temptable.Rows[0].Field<DateTime>("Time");
                TimeSpan a = DateTime.Now.Subtract(last);
                lbl_timeElapsed.Text = a.ToString(@"hh\:mm\:ss");
            }
        }

        private void TableTimer_Tick(object sender, EventArgs e)
        {

            updatetable();

        }
        public void updatetable()
        {
            //temptable.Rows.Add(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss"),
            //                    ApplianceTempIn.Text,
            //                    ApplianceOutTemp.Text,
            //                    LoadInTemp.Text,
            //                    LoadOutTemp.Text,
            //                    tb_stack.Text,
            //                    lbl_meterTemp.Text,
            //                    lbl_ftCubed.Text,
            //                    lbl_CFM.Text,
            //                    lbl_deltaH.Text,
            //                    lbl_probeTemp.Text,
            //                    "001", //Insert dilution temp here
            //                    lbl_weight.Text);
            DataRow newrow = temptable.NewRow();
            newrow.SetField("Time", DateTime.Now);
            newrow.SetField("Appliance In", double.Parse(ApplianceTempIn.Text));
            newrow.SetField("Appliance Out", ApplianceOutTemp.Text);
            newrow.SetField("Load In", LoadInTemp.Text);
            newrow.SetField("Load out", LoadOutTemp.Text);
            newrow.SetField("Stack Temp", tb_stack.Text);
            newrow.SetField("Meter Temp", lbl_meterTemp.Text);
            newrow.SetField("Ft^2", lbl_ftCubed.Text);
            newrow.SetField("CFM", lbl_VAC.Text);
            newrow.SetField("delta H", lbl_deltaH.Text);
            newrow.SetField("Probe Temp", lbl_probeTemp.Text);
            newrow.SetField("Dilution Temp", 0);
            newrow.SetField("Weight", lbl_weight.Text);
            temptable.Rows.Add(newrow);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + "data";
            var datePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//logger_data//" + DateTime.Now.ToString("yyyy-MM-dd");

            temptable.WriteXml(path + ".xml", XmlWriteMode.WriteSchema, true);
            temptable.WriteXml(datePath + ".xml", XmlWriteMode.WriteSchema, true);

            StringBuilder row = new StringBuilder();
            string value = String.Empty;
            DataRow dr = temptable.Rows[temptable.Rows.Count-1];
            int totalColumns = temptable.Columns.Count;

            for (int x = 0; x < temptable.Columns.Count; x++)
            {
                value = dr[x].ToString();

                if (value.Contains(",") || value.Contains("\""))
                {
                    value = '"' + value.Replace("\"", "\"\"") + '"';
                }

                row.Append(value);

                if (x != (totalColumns - 1))
                {
                    row.Append(" , ");
                }
            }

            WriteCharacters(row.ToString(), datePath);
       }

        static async void WriteCharacters(string mydata, string myfile)
        {
            using (StreamWriter writer = File.AppendText(myfile + ".csv"))
            {
                await writer.WriteLineAsync(mydata);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectPort newport = new ConnectPort();
            if (UpdateForm.IsBusy)
                UpdateForm.CancelAsync();

            newport.ShowDialog();
            if (newport.cbTCP.Checked == true)
            {
                t = new LoggerStream(newport.portname1.Text, int.Parse(newport.PortNumber1.Text));
                Properties.Settings.Default.LastPort = newport.portname1.Text +" "+ newport.PortNumber1.Text;
                Properties.Settings.Default.Save();

            }
            else
            {
                t = new LoggerStream(newport.PortNumber1.Text);
                Properties.Settings.Default.LastPort = newport.PortNumber1.Text;
                Properties.Settings.Default.Save();


            }
            if (t.IsOpen)
            {
                setupPort();
            }
            else
            {
                MessageBox.Show("Could Not Setup Port");
            }
        }

        private void btn_ResetCounters_Click(object sender, EventArgs e)
        {

        }


    }
}

