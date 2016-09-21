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

namespace WindowsFormsApplication1
{
    public partial class MonitorWindow : Form
    {
        public static FPNetwork n = new FPNetwork();
        public static LoggerStream t = new LoggerStream("COM6");


        public MonitorWindow()
        {
            InitializeComponent();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void MonitorWindow_Load(object sender, EventArgs e)
        {
            string test = Properties.Settings.Default.LastPort;
        }

        private void btn_getnetwork_Click(object sender, EventArgs e)
        {
            if (!t.IsOpen) t = new LoggerStream("COM6");

            IFormatter formatter = new BinaryFormatter();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//network.bin";
            //Get network from Serial and save//
            n = new FPNetwork();
            n.GetNetwork(t);
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

           



        }

        private void MonitorWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
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
    }
}
