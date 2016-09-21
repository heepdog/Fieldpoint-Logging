using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication1
{



    public partial class Form1 : Form
    {
        public DataTable log;
        public List<string> testtttt;
        Series numbers1;
        Series numbers2;

        private String[] ExistingPorts = SerialPort.GetPortNames();
        //private SerialPort portUsing;
        private LoggerStream portUsing = new LoggerStream("COM10");
        private Dictionary<string, string> Commands = new Dictionary<string, string>()
        {
            { "", ""},
            { "!A", "Read Module ID"},
            { "!B", "Read All Module IDs"},
            { "!N", "Read Module Status"},
            { "!O", "Read Channel Status"},
            { "!J", "Read Discrete"},
            { "!L", "Write Discrete"},
            { "!F", "Read Analog"},
            { "!H", "Write Analog"},
            { "!E", "Get Attributes"},
            { "!n", "Excecute Channel Command" },
            { "J", "Basic Analog Write" }
        };

       
       public Form1()
        {
            InitializeComponent();
        }

        private static FPModule test;
        public static FPModule sendmod { get { return test; } set { } }

        private void Form1_Load(object sender, EventArgs e)
        {
            log = new DataTable("Datalog");
            DataColumn column;
            dataSet1.Tables.Add(log);
            dataGridView1.DataSource = log;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Datestamp";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            log.Columns.Add(column);

            for (int i=0 ;i<8; i++)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Channel " + i.ToString();
                column.ReadOnly = true;
                column.Unique = false;

                // Add the Column to the DataColumnCollection.
                log.Columns.Add(column);
            }

            foreach (string i in ExistingPorts)
            {
                CmbPorts.Items.Add(i);
            }
            //portUsing = new SerialPort("COM6", 115200, Parity.None, 8, StopBits.One);
            //portUsing.NewLine = "\r";
            
            CmbPorts.Text = "COM6";
            numbers1 = new Series()
            {
                Name = "Series1",
                Color = System.Drawing.Color.Orange,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };
            numbers2 = new Series()
            {
                Name = "Series2",
                Color = System.Drawing.Color.Red,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };
            //chart1.DataSource = log;
            chart1.Series.Clear();
            ////chart1.Series.Add(numbers1);
            chart1.Series.Add("temp" );
            //chart1.Series.Add(numbers2);
            chart1.Series[0].XValueType  = ChartValueType.Time;
            //chart1.Series[1].XValueType = ChartValueType.Time;
            //chart1.DataSource = dataGridView1;

            //Commands = new Dictionary< string, string>() ;
            //Commands.Add("", "");
            //Commands.Add("!A", "Read Module ID");
            //Commands.Add("!B", "Read All Module IDs");
            //Commands.Add("!N", "Read Module Status");
            //Commands.Add("!O", "Read Channel Status");
            //Commands.Add("!J", "Read Discrete");
            //Commands.Add("!L", "Write Discrete");
            //Commands.Add("!F", "Read Analog");
            //Commands.Add("!H", "Write Analog");
            //comboBox1.DataSource = new BindingSource(Commands, null);
            //comboBox1.DisplayMember = "Value";
            //comboBox1.ValueMember = "Key";

            CmbCommand.DataSource = new BindingSource(Commands, null);
            CmbCommand.DisplayMember = "Value";
            CmbCommand.ValueMember = "key";

            listView1.BeginUpdate();
            //foreach(int i in Enumerable.Range(1, 16))
            //{
            //    ListViewItem temp = new ListViewItem("Channel " + i.ToString());
            //    temp.SubItems.Add("0");
            //    listView1.Items.Add(temp);

            //}
            listView1.Columns.Add("Channel Number",150);
            listView1.Columns.Add("Int", 50);
            listView1.Columns.Add("Hex", 50);
            listView1.Sorting = SortOrder.Ascending;
            //listView1.Columns.RemoveByKey("hex");
            //portUsing.Open();
            //if (portUsing.IsOpen)
            //{
            //    CmbPorts.Enabled = false;
            //    BtnOpen.Text = "Close Port";
            //    test = new FPModule(portUsing, 2);

            //}
            listView1.EndUpdate();
            //       timer1.Interval = 3000;
            //       timer1.Start();

            test.ModuleEvent += Test_ModuleEvent;

        }

        private void Test_ModuleEvent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            richTextBox1.AppendText(e.ToString());
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (!portUsing.IsOpen)
            {
                try
                {
                    portUsing =new LoggerStream(CmbPorts.Text) ;
                    BtnOpen.Text = "Close";
                }
                catch (Exception E)
                {
                    MessageBox.Show("Unable to open Port", "Port Error", MessageBoxButtons.OK);
                    Debug.WriteLine(E.Message);
                }
            }
            else
            {
                try
                {
                    portUsing.Close();
                    BtnOpen.Text = "Open Port";
                }
                catch (Exception E)
                {
                    MessageBox.Show("Unable to Close Port", "Port Error", MessageBoxButtons.OK);
                    Debug.WriteLine(E.Message);
                }
            }
        }

        private void BtnCreateCommand_Click(object sender, EventArgs e)
        {
            CreateCommand();
        }

        private void CreateCommand()
        { 

            String NewCommand;
            NewCommand = ">";
            String strmod;

            if (TxbModule.Text.Length != 0)
            {
                //use parse to convert number to ascii
                byte module = byte.Parse(TxbModule.Text);
                byte[] bModule = new byte[1];
                bModule[0] = module;
               
                strmod = BitConverter.ToString(bModule);
                NewCommand = NewCommand + strmod;
            }

            NewCommand = NewCommand + TxbCmdChars.Text;

            if (TxbPositon.Text.Length != 0)
            {
                Int32 position = Int32.Parse(TxbPositon.Text);
                byte[] pos= new byte[2];
                pos[1] = (byte)(position & 0xFF);
                pos[0] = (byte)((position >> 8) & 0xFF);
//                pos[1] = (byte)((position >> 16) & 0xFF);
//                pos[0] = (byte)((position >> 24) & 0xFF);
                strmod = BitConverter.ToString(pos).Replace("-","");
                NewCommand = NewCommand + strmod;

            }

            if (GrbChannels.Enabled)
            {
                if (listView1.Items.Count > 0)
                {
                    NewCommand = NewCommand + getchannels();
                }
            }


            //parse out Text Data from List
            if (TxbData.Enabled)
            {
                try
                {
                    //If analog parse multiple 4char asci out Text Data from List
                    if (CmbCommand.SelectedValue.ToString() == "!H") // Analog Write
                    {
                        string dataString = "";
                        foreach (ListViewItem s in listView1.Items)
                        {
                            int value;
                            if (int.TryParse(s.SubItems[1].Text.ToString(), out value))
                            {
                                //dataString = dataString + getHexstring(value, 2, true);
                                dataString = dataString+ value.ToString("X4");
                            }


                        }
                        NewCommand = NewCommand + dataString;
                    }
                    else if (CmbCommand.SelectedValue.ToString() == "!L") //Discrete Write
                    {
                        int value = 0;
                        foreach (ListViewItem s in listView1.Items)
                        {
                            int channelvalue;
                            int.TryParse(s.SubItems[1].Text.ToString(),out channelvalue);
                            int channelexp;
                            int.TryParse(s.Text.ToString().Replace("Channel ", ""), out channelexp);
                            value = value + (int)(channelvalue * Math.Pow(2, channelexp-1));
                        }
                        NewCommand = NewCommand + value.ToString("X4");
                    }
                    else if (CmbCommand.SelectedValue.ToString() == "!E") //Read Atributes
                    {
                        NewCommand = NewCommand + TxbData.Text.ToString();
                    }
                    else if (CmbCommand.SelectedValue.ToString() == "!n") //Execute Channel Command
                    {
                        NewCommand = NewCommand + TxbData.Text.ToString();
                    }
                }

                catch (Exception E)
                {
                    MessageBox.Show("There Was an Error parsing the Data\n" + E.ToString(), "NI Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            NewCommand = NewCommand + checksum(NewCommand);
            TxbSerialCmd.Text = NewCommand;
        }

        private String checksum(String command)
        {
            if (CkbUseChecksum.Checked)
            {
                //calculate checksum
                int sum = 0;
                //create Byte array without the start character '>'
                byte[] cmdarray = Encoding.ASCII.GetBytes(command.TrimStart( '>' ));
                //add all bytes together
                foreach (byte i in cmdarray)
                {
                    sum = (sum + i);
                }
                return getHexstring((sum % 256),1,true);
            }
            else
            {
                return "??";
            }

        }

        private void CmbCommand_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //Read All Module IDs !B
            //Read Module ID !A
            //Read Module Status !N
            //Read Channel Status !O
            //Read Discrete !J
            //Write Discrete !L
            //Read Analog !F
            //Write Analog !H
            ComboBox cb = (ComboBox)sender;
            switch (cb.SelectedValue.ToString())
            {
                case "!B":  //Read All Module IDs
                    richTextBox1.AppendText("Case B switched\n");
                    TxbModule.Text = "00";
                    TxbModule.Enabled = false;
                    TxbData.Text = "";
                    TxbData.Enabled = false;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = false;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = false;
                    GrbChannels.Enabled = false;
                    TxbCmdChars.Text = "!B";
                    break;

                case "!A": //Read Module ID
                    richTextBox1.AppendText("Case A switched\n");
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = false;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = false;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = false;
                    GrbChannels.Enabled = false;
                    TxbCmdChars.Text = "!A";
                    break;

                case "!N": //Read Module Status
                    richTextBox1.AppendText("Case n switched\n");
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = false;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = false;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = false;
                    GrbChannels.Enabled = false;
                    TxbCmdChars.Text = "!N";
                    break;

                case "!F": //Read Analog
                    richTextBox1.AppendText("Case F switched\n");
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = false;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = false;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = true;
                    GrbChannels.Enabled = true;
                    TxbCmdChars.Text = "!F";
                    break;

                case "!L":    //Write Discrete !L
                    richTextBox1.AppendText("Case L switched\n");
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = true;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = false;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = true;
                    GrbChannels.Enabled = true;
                    TxbCmdChars.Text = "!L";
                    break;

                case "!J":  //Read Discrete !J
                    richTextBox1.AppendText("Case J switched\n");
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = false;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = false;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = true;
                    GrbChannels.Enabled = true;
                    TxbCmdChars.Text = "!J";
                    break;

                case "!H":  //Write Analog !H
                    richTextBox1.AppendText("Case H switched\n");
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = true;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = false;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = true;
                    GrbChannels.Enabled = true;
                    TxbCmdChars.Text = "!H";
                    break;

                case "J":  //Write Analog J
                    richTextBox1.AppendText("Case J switched\n");
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = true;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = false;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = true;
                    GrbChannels.Enabled = true;
                    TxbCmdChars.Text = "J";
                    break;

                case "!E":  //              { "!E", "Get Attributes"},
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = true;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = true;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = true;
                    GrbChannels.Enabled = true;
                    TxbCmdChars.Text = "!E";

                    break;

                case "!n":  //              { "!n", "Execute Channel command"},
                    TxbModule.Enabled = true;
                    TxbData.Text = "";
                    TxbData.Enabled = true;
                    TxbModifier.Text = "";
                    TxbModifier.Enabled = true;
                    TxbPositon.Text = "";
                    TxbPositon.Enabled = true;
                    GrbChannels.Enabled = true;
                    TxbCmdChars.Text = "!n";

                    break;



                default:
                    richTextBox1.AppendText("default switched\n");
                    TxbModule.Enabled = true;
                    TxbData.Enabled = true;
                    TxbModifier.Enabled = true;
                    TxbPositon.Enabled = true;

                    break;

            

            }

           
        }
        private string getchannels()
        {
            Dictionary<string, bool> channels = new Dictionary<string, bool> ();
            int channelstouse = 0;
            int ValueType;
            foreach (CheckBox b in GrbChannels.Controls)
            {
                channels.Add(b.Text, b.Checked );
                if (b.Checked)
                    ValueType = 1;
                else
                    ValueType = 0;
                int shift;
                int.TryParse(b.Text, out shift);
                channelstouse = channelstouse | (ValueType  << (shift-1));
                
            }

            //byte[] ascii = new byte[2];
            //ascii[1] = (byte)(channelstouse & 0xFF);
            //ascii[0] = (byte)((channelstouse >> 8) & 0xFF);
            //string ss = BitConverter.ToString(ascii).Replace("-", "");

            //return getHexstring (channelstouse,2,true);
            return channelstouse.ToString("X4");
        }

        private string getHexstring(int f,int size, bool returnZeros)
        {
            //creates a byte array, each Byte holds 2 ASCII Characters
            byte[] ascii = new byte[size];

            for(int i = size-1, j = 0;i >= 0; i--,j++)
            {
                ascii[i] = (byte)((f >> (8 * j)) & 0xFF);
            }

            if (returnZeros)
                return BitConverter.ToString(ascii).Replace("-", "");
            else
                return BitConverter.ToString(ascii).Replace("-", "").TrimStart('0');
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void form1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            //string test = cb.SelectedValue.ToString();
            //KeyValuePair<string, string> val = (KeyValuePair < string, string>) cb.SelectedValue;
            // String val = (String)cb.SelectedValue;
            //string val = "tyi";
            //string strval = val.Key;
            switch (cb.SelectedValue.ToString())
            {
                case "!A":
                    richTextBox1.AppendText("Case !A switched\n");

                    break;
                default:
                    break;
            }
       }

        private void ChannelCheckboxChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            ListViewItem channeltemp = null;// new ListViewItem();
            listView1.Sorting = SortOrder.None;
            if (listView1.Items.Count != 0)
                channeltemp = listView1.FindItemWithText("Channel " + cb.Text.ToString(), false, 0, false);
            //listView1.FindItemWithText("a",false,0, false)
            if (cb.Checked & (channeltemp == null))
            {
                addListView(cb.Text);
                listView1.ListViewItemSorter = new IntegerComparer(1);
                listView1.Sorting = SortOrder.Ascending;
                listView1.Sort();
            }
            else
            {
                if (channeltemp != null)
                    channeltemp.Remove();

            }

        }

        private void addListView(string channel)
        {
            ListViewItem addlisttemp = new ListViewItem("Channel " + channel);
            addlisttemp.SubItems.Add("0");
            addlisttemp.SubItems.Add("0");
            listView1.Items.Add(addlisttemp);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //listview sub item editing code start

        ListViewItem.ListViewSubItem SelectedLSI;
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo i = listView1.HitTest(e.X, e.Y);
            SelectedLSI = i.SubItem;
            if ((SelectedLSI == null)| (listView1.Columns[0].Width > e.X))
                return;

            int border = 0;
            switch (listView1.BorderStyle)
            {
                case BorderStyle.FixedSingle:
                    border = 1;
                    break;
                case BorderStyle.Fixed3D:
                    border = 2;
                    break;
            }

            int CellWidth = SelectedLSI.Bounds.Width;
            int CellHeight = SelectedLSI.Bounds.Height;
            int CellLeft = border + listView1.Left + i.SubItem.Bounds.Left;
            int CellTop = listView1.Top + i.SubItem.Bounds.Top;
            // First Column
            if (i.SubItem == i.Item.SubItems[0])
                CellWidth = listView1.Columns[0].Width;

            TxtEdit.Location = new Point(CellLeft, CellTop);
            TxtEdit.Size = new Size(CellWidth, CellHeight);
            TxtEdit.Visible = true;
            TxtEdit.BringToFront();
            TxtEdit.Text = i.SubItem.Text;
            TxtEdit.Select();
            TxtEdit.SelectAll();
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            HideAndSaveEditor();
        }
        private void listView1_Scroll(object sender, EventArgs e)
        {
            HideAndSaveEditor();
        }
        private void TxtEdit_Leave(object sender, EventArgs e)
        {
            HideAndSaveEditor();
        }
        private void TxtEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                HideAndSaveEditor();
            else if(e.KeyCode == Keys.Escape)
                HideAndDiscardEditor();
        }
        private void HideAndDiscardEditor()
        {
            // throw new NotImplementedException();
            TxtEdit.Text = "";
            TxtEdit.Visible = false;
            SelectedLSI = null;

        }
        private void HideAndSaveEditor()
        {
            TxtEdit.Visible = false;

            if (SelectedLSI != null)
                if (TxtEdit.Text.All(char.IsDigit) & (TxtEdit.Text.Length > 0))
                {
                    SelectedLSI.Text = TxtEdit.Text;
                }
            SelectedLSI = null;
            TxtEdit.Text = "";
        }

        public class TestListView : System.Windows.Forms.ListView
        {
            private const int WM_HSCROLL = 0x114;
            private const int WM_VSCROLL = 0x115;
            public event EventHandler Scroll;

            protected void OnScroll()
            {

                if (this.Scroll != null)
                    this.Scroll(this, EventArgs.Empty);

            }

            protected override void WndProc(ref System.Windows.Forms.Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
                    this.OnScroll();
            }
        }
        //eiting code end


        //column comparator
        public class IntegerComparer : IComparer
        {
            private int _colIndex;
            public IntegerComparer(int colIndex)
            {
                _colIndex = colIndex;
            }
            public int Compare(object x, object y)
            {
                int nx = int.Parse((x as ListViewItem).Text.ToString().Replace("Channel ", ""));
                int ny = int.Parse((y as ListViewItem).Text.ToString().Replace("Channel ", ""));
                return nx.CompareTo(ny);
            }
        }

        private void CmbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (portUsing.IsOpen)
            {
                try
                {
                    portUsing.Close();
                    BtnOpen.Text = "Open Port";
                }
                catch (Exception)
                {
                    throw;
                }


            }

            portUsing.ComPort = cb.Text.ToString();

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (portUsing.IsOpen)
            {
                portUsing.Close();
            }
        }

        private void BtnSendCommand_MouseClick(object sender, MouseEventArgs e)
        {
            CreateCommand();

            
            try
            {
                //portUsing.ReadTimeout = 5000;
                //byte[] comout = Encoding.ASCII.GetBytes(TxbSerialCmd.Text.ToString() + ".");
                //comout = comout.((byte)10);
                //portUsing.Write(comout,0,comout.Length);
                // richTextBox1.AppendText(portUsing.ReadTo("\r"));
                string Response;
                lock (portUsing)
                {
                    portUsing.WriteLine(TxbSerialCmd.Text.ToString());
                    Response = portUsing.ReadLine();
                }
                richTextBox1.AppendText(Response + "\n");
                parseResponse(Response);


            }
            catch (Exception)
            {
                throw;
            }
        }

        private void parseResponse(string response)
        {
            if (response[0].ToString() == "A")
            {
                if (TxbCmdChars.Text.ToString() == "!F")
                {
                    response = response.Remove(response.Length-2).Trim('A');
                    int numbers = response.Length / 4;
                    string[] next = new string[numbers];
                    for ( int i = 0; i < numbers-1; i++)
                    {
                        next[i] =  response.Remove(4);
                        response = response.Remove(0, 4);
                    }
                    next[numbers - 1] = response;



                    foreach (string s in next)
                    {
                        //int myint = int.Parse(s, System.Globalization.NumberStyles.HexNumber);
                        int myint = int.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier);
                        listView1.Items[--numbers].SubItems[1].Text = myint.ToString();
                        double scaled = ((myint / 65535.0 * (3218 + 454)) - 454);
                        listView1.Items[numbers].SubItems[2].Text = scaled.ToString();
                    }
                }
                else if (TxbCmdChars.Text.ToString() == "L")
                {
                    ;
                }
               
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //richTextBox1.AppendText("timer ticked\n");
            timer1.Interval = 3000;
            test.UpdateValues();
            //txbnewdata.Text = test.getChannelUnitValue(0).ToString("N3");
            //txbnewdata2.Text = test.getChannelUnitValue(3).ToString("N3");
            //numbers1.Points.AddXY(DateTime.Now.ToOADate(), test.getChannelUnitValue(0));
            //numbers2.Points.AddXY(DateTime.Now.ToOADate(), test.getChannelUnitValue(3));
            txbnewdata.Text = test.getChannelDisplayValue(0).ToString("N3");
            txbnewdata2.Text = test.getChannelDisplayValue(2).ToString("N3");
            numbers1.Points.AddXY(DateTime.Now.ToOADate(), test.getChannelDisplayValue(0));
            numbers2.Points.AddXY(DateTime.Now.ToOADate(), test.getChannelDisplayValue(2));
            if (numbers1.Points.Count()>20)
                numbers1.Points.RemoveAt(0);
            if (numbers2.Points.Count() > 20)
                numbers2.Points.RemoveAt(0);

            timer1.Start();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //test = new FPModule(portUsing, 2);
            test.calibrateChannelDisplay(2, 0,(float)23850, (float)2, (float)38750);
            test.calibrateChannelDisplay(0, 0, (float)12317, (float)-10, (float)30925);
            test.UpdateValues();

        }

        private void btnsavexml_Click(object sender, EventArgs e)
        {
            FPModule newtest = new FPModule();
            //newtest.seconds = 100;
            //newtest.seconds2 = 1;

            //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(newtest.GetType());

            //var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview2.xml";
            //System.IO.FileStream file = System.IO.File.Create(path);

            //writer.Serialize(file, newtest);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview2.soap";
            //Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, test);
            //stream.Close();

            //FPModule newtest2 = new FPModule();
            IFormatter formatter2 = new BinaryFormatter();
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview2.soap";
            Stream stream2 = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            //MyObject obj = (MyObject)formatter.Deserialize(stream);
            test = (FPModule)formatter.Deserialize(stream2);
            stream2.Close();
        }

        private void btMonitor_Click(object sender, EventArgs e)
        {
            //if (btMonitor.Text.Equals("Start Monitor"))
            //    test.monitorModule(true);
            //else
            //    test.monitorModule(false);
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            else
                backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (!worker.CancellationPending)
            { 

            //test.UpdateValues();
            //test.onModuleEvent(new CustomEventArgs("Updated Values"));
            worker.ReportProgress(1);
            Debug.WriteLine("module updated");
            Thread.Sleep(1000);
            }
        }
        private void updatetest()
        {
            test.UpdateValues();
            //test.onModuleEvent(new CustomEventArgs("Updated Values"));
            Debug.WriteLine("module updated");
            Thread.Sleep(30000);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DataRow newrow = log.NewRow();

            newrow[0] = DateTime.Now;
            
            for (int j = 1; j < newrow.ItemArray.Length; j++)
            {
                newrow[j] = test.getChannelUnitValue(j-1).ToString("N3") + test.getchannelunits(j-1);
            }
            log.Rows.Add(newrow);

            if (log.Rows.Count > 5)
            {
                log.Rows.RemoveAt(0);
            }

            //test.getChannelDisplayValue(0).ToString("N3")+ " " + test.getChannelUnitValue(0).ToString("N3") + test.getchannelunits(0) + "\n");
            dataGridView1.DataSource = log;

            chart1.DataSource = log;
            chart1.Series[0].XValueMember = "Datestamp";
            chart1.Series[0].YValueMembers = "Channel 1";
            chart1.DataBind();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void logClassbtn_Click(object sender, EventArgs e)
        {
            LoggerStream test;
            if (TBAddress.Text == "")
            {
                test = new LoggerStream(TBPort.Text.ToString());
            }
            else
            {
                test = new LoggerStream(TBAddress.Text.ToString(), int.Parse(TBPort.Text.ToString()));
            }

            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MonitorWindow temp = new MonitorWindow();
            temp.ShowDialog();
        }
    }
}
