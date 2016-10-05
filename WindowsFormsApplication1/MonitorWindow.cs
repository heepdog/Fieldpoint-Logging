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

namespace WindowsFormsApplication1
{
    public partial class MonitorWindow : Form
    {
        public static FPNetwork n = new FPNetwork();
        public static LoggerStream t = new LoggerStream();

        public MonitorWindow()
        {
            InitializeComponent();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void MonitorWindow_Load(object sender, EventArgs e)
        {
            string[] port = Properties.Settings.Default.LastPort.Split(' ');
            if (port.Length == 1)
            {
                t = new LoggerStream(port[0]);
                if (t.IsOpen)
                {
                    btn_getnetwork.Enabled = true;
                    Properties.Settings.Default.LastPort = port[0];
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
                    ConnectionStatusbar.Text = "Port Connected";
                }
            }
            if (t.IsOpen)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + Properties.Settings.Default.NetworkData + ".bin";
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
                     //}
                }

            }

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
            UpdateForm.CancelAsync();
            this.Dispose();
       
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
            t = new WindowsFormsApplication1.LoggerStream("192.168.1.109", 5001);

        }

        private void MonitorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Close();
            this.Dispose();

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
                    foreach (FPModule f in n)
                    {
                        Debug.WriteLine(f.ToString());
                    }

                    worker.ReportProgress(1);
                    Thread.Sleep(500);
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
            if (!UpdateForm.IsBusy)
            {
                UpdateForm.RunWorkerAsync();
                btn_StartTest.Text = "Stop Monitor";
            }
            else
            {
                UpdateForm.CancelAsync();
                btn_StartTest.Text = "Start Monitor";
            }

        }

        private void UpdateForm_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine("update form");
            LoadInTemp.Text = n[7].getChannelDisplayValue(5).ToString("N2");
            LoadOutTemp.Text = n[7].getChannelDisplayValue(4).ToString("N2");
            ApplianceTempIn.Text = n[7].getChannelDisplayValue(0).ToString("N2");
            ApplianceOutTemp.Text = n[7].getChannelDisplayValue(1).ToString("N2");
            lbl_meterTemp.Text = n[6].getChannelDisplayValue(0).ToString("N2");
            lbl_probeTemp.Text = n[6].getChannelDisplayValue(1).ToString("N2");
            lbl_deltaH.Text = n[2].getChannelDisplayValue(2).ToString("N2");
            lb_weight.Text = n[2].getChannelDisplayValue(3).ToString("N2");
            ApploianceFlow.Text = n[3].getChannelDisplayValue(3).ToString("N2");
            LoadFlow.Text = n[3].getChannelDisplayValue(4).ToString("N2");
            lbl_ftCubed.Text = n[1].getChannelDisplayValue(16).ToString("N3");


        }

    }
    }

