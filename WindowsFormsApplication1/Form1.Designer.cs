namespace NILogger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            portUsing.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CmbPorts = new System.Windows.Forms.ComboBox();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TxbModule = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbCmdChars = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxbData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxbModifier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxbPositon = new System.Windows.Forms.TextBox();
            this.BtnCreateCommand = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxbSerialCmd = new System.Windows.Forms.TextBox();
            this.CmbCommand = new System.Windows.Forms.ComboBox();
            this.CkbUseChecksum = new System.Windows.Forms.CheckBox();
            this.GrbChannels = new System.Windows.Forms.GroupBox();
            this.C16 = new System.Windows.Forms.CheckBox();
            this.C15 = new System.Windows.Forms.CheckBox();
            this.C14 = new System.Windows.Forms.CheckBox();
            this.C13 = new System.Windows.Forms.CheckBox();
            this.C12 = new System.Windows.Forms.CheckBox();
            this.C11 = new System.Windows.Forms.CheckBox();
            this.C10 = new System.Windows.Forms.CheckBox();
            this.C9 = new System.Windows.Forms.CheckBox();
            this.C8 = new System.Windows.Forms.CheckBox();
            this.C7 = new System.Windows.Forms.CheckBox();
            this.C6 = new System.Windows.Forms.CheckBox();
            this.C5 = new System.Windows.Forms.CheckBox();
            this.C4 = new System.Windows.Forms.CheckBox();
            this.C3 = new System.Windows.Forms.CheckBox();
            this.C2 = new System.Windows.Forms.CheckBox();
            this.C1 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.TxtEdit = new System.Windows.Forms.TextBox();
            this.BtnSendCommand = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.txbnewdata = new System.Windows.Forms.TextBox();
            this.txbnewdata2 = new System.Windows.Forms.TextBox();
            this.btngetxml = new System.Windows.Forms.Button();
            this.btMonitor = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataSet1 = new System.Data.DataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TBAddress = new System.Windows.Forms.TextBox();
            this.TBPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.logClassbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Savexml = new System.Windows.Forms.Button();
            this.createModule = new System.Windows.Forms.Button();
            this.GrbChannels.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbPorts
            // 
            this.CmbPorts.FormattingEnabled = true;
            this.CmbPorts.Location = new System.Drawing.Point(12, 32);
            this.CmbPorts.Name = "CmbPorts";
            this.CmbPorts.Size = new System.Drawing.Size(121, 21);
            this.CmbPorts.TabIndex = 0;
            this.CmbPorts.SelectedIndexChanged += new System.EventHandler(this.CmbPorts_SelectedIndexChanged);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(139, 30);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(75, 23);
            this.BtnOpen.TabIndex = 1;
            this.BtnOpen.Text = "OpenPort";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(15, 377);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(549, 96);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // TxbModule
            // 
            this.TxbModule.Location = new System.Drawing.Point(15, 72);
            this.TxbModule.MaxLength = 3;
            this.TxbModule.Name = "TxbModule";
            this.TxbModule.Size = new System.Drawing.Size(80, 20);
            this.TxbModule.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Module Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cmd Chars";
            // 
            // TxbCmdChars
            // 
            this.TxbCmdChars.Enabled = false;
            this.TxbCmdChars.Location = new System.Drawing.Point(101, 99);
            this.TxbCmdChars.Name = "TxbCmdChars";
            this.TxbCmdChars.Size = new System.Drawing.Size(80, 20);
            this.TxbCmdChars.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data";
            // 
            // TxbData
            // 
            this.TxbData.Location = new System.Drawing.Point(681, 89);
            this.TxbData.Name = "TxbData";
            this.TxbData.Size = new System.Drawing.Size(80, 20);
            this.TxbData.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Modifier";
            // 
            // TxbModifier
            // 
            this.TxbModifier.Location = new System.Drawing.Point(595, 89);
            this.TxbModifier.Name = "TxbModifier";
            this.TxbModifier.Size = new System.Drawing.Size(80, 20);
            this.TxbModifier.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(503, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Position";
            // 
            // TxbPositon
            // 
            this.TxbPositon.Location = new System.Drawing.Point(506, 88);
            this.TxbPositon.Name = "TxbPositon";
            this.TxbPositon.Size = new System.Drawing.Size(80, 20);
            this.TxbPositon.TabIndex = 11;
            // 
            // BtnCreateCommand
            // 
            this.BtnCreateCommand.Location = new System.Drawing.Point(460, 170);
            this.BtnCreateCommand.Name = "BtnCreateCommand";
            this.BtnCreateCommand.Size = new System.Drawing.Size(104, 23);
            this.BtnCreateCommand.TabIndex = 13;
            this.BtnCreateCommand.Text = "Create Command";
            this.BtnCreateCommand.UseVisualStyleBackColor = true;
            this.BtnCreateCommand.Click += new System.EventHandler(this.BtnCreateCommand_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Serial Command";
            // 
            // TxbSerialCmd
            // 
            this.TxbSerialCmd.Location = new System.Drawing.Point(15, 210);
            this.TxbSerialCmd.Name = "TxbSerialCmd";
            this.TxbSerialCmd.Size = new System.Drawing.Size(537, 20);
            this.TxbSerialCmd.TabIndex = 15;
            // 
            // CmbCommand
            // 
            this.CmbCommand.FormattingEnabled = true;
            this.CmbCommand.Items.AddRange(new object[] {
            "Read All Module IDs !B",
            "Read Module ID !A",
            "Read Module Status !N",
            "Read Channel Status !O",
            "Read Discrete !J",
            "Write Discrete !K",
            "Read Analog !F",
            "Write Analog !H"});
            this.CmbCommand.Location = new System.Drawing.Point(101, 72);
            this.CmbCommand.Name = "CmbCommand";
            this.CmbCommand.Size = new System.Drawing.Size(172, 21);
            this.CmbCommand.TabIndex = 17;
            this.CmbCommand.SelectedIndexChanged += new System.EventHandler(this.CmbCommand_SelectedIndexChanged);
            // 
            // CkbUseChecksum
            // 
            this.CkbUseChecksum.AutoSize = true;
            this.CkbUseChecksum.Location = new System.Drawing.Point(251, 30);
            this.CkbUseChecksum.Name = "CkbUseChecksum";
            this.CkbUseChecksum.Size = new System.Drawing.Size(98, 17);
            this.CkbUseChecksum.TabIndex = 18;
            this.CkbUseChecksum.Text = "Use Checksum";
            this.CkbUseChecksum.UseVisualStyleBackColor = true;
            this.CkbUseChecksum.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // GrbChannels
            // 
            this.GrbChannels.Controls.Add(this.C16);
            this.GrbChannels.Controls.Add(this.C15);
            this.GrbChannels.Controls.Add(this.C14);
            this.GrbChannels.Controls.Add(this.C13);
            this.GrbChannels.Controls.Add(this.C12);
            this.GrbChannels.Controls.Add(this.C11);
            this.GrbChannels.Controls.Add(this.C10);
            this.GrbChannels.Controls.Add(this.C9);
            this.GrbChannels.Controls.Add(this.C8);
            this.GrbChannels.Controls.Add(this.C7);
            this.GrbChannels.Controls.Add(this.C6);
            this.GrbChannels.Controls.Add(this.C5);
            this.GrbChannels.Controls.Add(this.C4);
            this.GrbChannels.Controls.Add(this.C3);
            this.GrbChannels.Controls.Add(this.C2);
            this.GrbChannels.Controls.Add(this.C1);
            this.GrbChannels.Location = new System.Drawing.Point(279, 56);
            this.GrbChannels.Name = "GrbChannels";
            this.GrbChannels.Size = new System.Drawing.Size(200, 100);
            this.GrbChannels.TabIndex = 20;
            this.GrbChannels.TabStop = false;
            this.GrbChannels.Text = "Channels";
            // 
            // C16
            // 
            this.C16.AutoSize = true;
            this.C16.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C16.Location = new System.Drawing.Point(167, 57);
            this.C16.Name = "C16";
            this.C16.Size = new System.Drawing.Size(23, 31);
            this.C16.TabIndex = 15;
            this.C16.Text = "16";
            this.C16.UseVisualStyleBackColor = true;
            this.C16.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C15
            // 
            this.C15.AutoSize = true;
            this.C15.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C15.Location = new System.Drawing.Point(144, 57);
            this.C15.Name = "C15";
            this.C15.Size = new System.Drawing.Size(23, 31);
            this.C15.TabIndex = 14;
            this.C15.Text = "15";
            this.C15.UseVisualStyleBackColor = true;
            this.C15.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C14
            // 
            this.C14.AutoSize = true;
            this.C14.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C14.Location = new System.Drawing.Point(121, 57);
            this.C14.Name = "C14";
            this.C14.Size = new System.Drawing.Size(23, 31);
            this.C14.TabIndex = 13;
            this.C14.Text = "14";
            this.C14.UseVisualStyleBackColor = true;
            this.C14.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C13
            // 
            this.C13.AutoSize = true;
            this.C13.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C13.Location = new System.Drawing.Point(98, 57);
            this.C13.Name = "C13";
            this.C13.Size = new System.Drawing.Size(23, 31);
            this.C13.TabIndex = 12;
            this.C13.Text = "13";
            this.C13.UseVisualStyleBackColor = true;
            this.C13.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C12
            // 
            this.C12.AutoSize = true;
            this.C12.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C12.Location = new System.Drawing.Point(75, 57);
            this.C12.Name = "C12";
            this.C12.Size = new System.Drawing.Size(23, 31);
            this.C12.TabIndex = 11;
            this.C12.Text = "12";
            this.C12.UseVisualStyleBackColor = true;
            this.C12.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C11
            // 
            this.C11.AutoSize = true;
            this.C11.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C11.Location = new System.Drawing.Point(53, 57);
            this.C11.Name = "C11";
            this.C11.Size = new System.Drawing.Size(23, 31);
            this.C11.TabIndex = 10;
            this.C11.Text = "11";
            this.C11.UseVisualStyleBackColor = true;
            this.C11.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C10
            // 
            this.C10.AutoSize = true;
            this.C10.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C10.Location = new System.Drawing.Point(30, 57);
            this.C10.Name = "C10";
            this.C10.Size = new System.Drawing.Size(23, 31);
            this.C10.TabIndex = 9;
            this.C10.Text = "10";
            this.C10.UseVisualStyleBackColor = true;
            this.C10.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C9
            // 
            this.C9.AutoSize = true;
            this.C9.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C9.Location = new System.Drawing.Point(7, 57);
            this.C9.Name = "C9";
            this.C9.Size = new System.Drawing.Size(17, 31);
            this.C9.TabIndex = 8;
            this.C9.Text = "9";
            this.C9.UseVisualStyleBackColor = true;
            this.C9.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C8
            // 
            this.C8.AutoSize = true;
            this.C8.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C8.Location = new System.Drawing.Point(167, 20);
            this.C8.Name = "C8";
            this.C8.Size = new System.Drawing.Size(17, 31);
            this.C8.TabIndex = 7;
            this.C8.Text = "8";
            this.C8.UseVisualStyleBackColor = true;
            this.C8.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C7
            // 
            this.C7.AutoSize = true;
            this.C7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C7.Location = new System.Drawing.Point(144, 20);
            this.C7.Name = "C7";
            this.C7.Size = new System.Drawing.Size(17, 31);
            this.C7.TabIndex = 6;
            this.C7.Text = "7";
            this.C7.UseVisualStyleBackColor = true;
            this.C7.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C6
            // 
            this.C6.AutoSize = true;
            this.C6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C6.Location = new System.Drawing.Point(121, 20);
            this.C6.Name = "C6";
            this.C6.Size = new System.Drawing.Size(17, 31);
            this.C6.TabIndex = 5;
            this.C6.Text = "6";
            this.C6.UseVisualStyleBackColor = true;
            this.C6.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C5
            // 
            this.C5.AutoSize = true;
            this.C5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C5.Location = new System.Drawing.Point(98, 20);
            this.C5.Name = "C5";
            this.C5.Size = new System.Drawing.Size(17, 31);
            this.C5.TabIndex = 4;
            this.C5.Text = "5";
            this.C5.UseVisualStyleBackColor = true;
            this.C5.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C4
            // 
            this.C4.AutoSize = true;
            this.C4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C4.Location = new System.Drawing.Point(75, 20);
            this.C4.Name = "C4";
            this.C4.Size = new System.Drawing.Size(17, 31);
            this.C4.TabIndex = 3;
            this.C4.Text = "4";
            this.C4.UseVisualStyleBackColor = true;
            this.C4.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C3
            // 
            this.C3.AutoSize = true;
            this.C3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C3.Location = new System.Drawing.Point(53, 20);
            this.C3.Name = "C3";
            this.C3.Size = new System.Drawing.Size(17, 31);
            this.C3.TabIndex = 2;
            this.C3.Text = "3";
            this.C3.UseVisualStyleBackColor = true;
            this.C3.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C2
            // 
            this.C2.AutoSize = true;
            this.C2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C2.Location = new System.Drawing.Point(30, 20);
            this.C2.Name = "C2";
            this.C2.Size = new System.Drawing.Size(17, 31);
            this.C2.TabIndex = 1;
            this.C2.Text = "2";
            this.C2.UseVisualStyleBackColor = true;
            this.C2.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // C1
            // 
            this.C1.AutoSize = true;
            this.C1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C1.Location = new System.Drawing.Point(7, 20);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(17, 31);
            this.C1.TabIndex = 0;
            this.C1.Text = "1";
            this.C1.UseVisualStyleBackColor = true;
            this.C1.CheckedChanged += new System.EventHandler(this.ChannelCheckboxChanged);
            // 
            // listView1
            // 
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(595, 133);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(294, 340);
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // TxtEdit
            // 
            this.TxtEdit.Location = new System.Drawing.Point(595, 113);
            this.TxtEdit.Name = "TxtEdit";
            this.TxtEdit.Size = new System.Drawing.Size(100, 20);
            this.TxtEdit.TabIndex = 22;
            this.TxtEdit.Visible = false;
            this.TxtEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtEdit_KeyUp);
            this.TxtEdit.Leave += new System.EventHandler(this.TxtEdit_Leave);
            // 
            // BtnSendCommand
            // 
            this.BtnSendCommand.Location = new System.Drawing.Point(460, 252);
            this.BtnSendCommand.Name = "BtnSendCommand";
            this.BtnSendCommand.Size = new System.Drawing.Size(75, 23);
            this.BtnSendCommand.TabIndex = 23;
            this.BtnSendCommand.Text = "Send Command";
            this.BtnSendCommand.UseVisualStyleBackColor = true;
            this.BtnSendCommand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnSendCommand_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1311, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabel1.Text = "Not Connected";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1311, 25);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton1.Text = "Open";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(909, 289);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.Legend = "Legend1";
            series4.Name = "BarChart";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(377, 206);
            this.chart1.TabIndex = 26;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 37);
            this.button1.TabIndex = 27;
            this.button1.Text = "calibrate inputs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbnewdata
            // 
            this.txbnewdata.Location = new System.Drawing.Point(886, 66);
            this.txbnewdata.Name = "txbnewdata";
            this.txbnewdata.Size = new System.Drawing.Size(194, 20);
            this.txbnewdata.TabIndex = 28;
            // 
            // txbnewdata2
            // 
            this.txbnewdata2.Location = new System.Drawing.Point(886, 92);
            this.txbnewdata2.Name = "txbnewdata2";
            this.txbnewdata2.Size = new System.Drawing.Size(194, 20);
            this.txbnewdata2.TabIndex = 29;
            // 
            // btngetxml
            // 
            this.btngetxml.Location = new System.Drawing.Point(179, 252);
            this.btngetxml.Name = "btngetxml";
            this.btngetxml.Size = new System.Drawing.Size(75, 23);
            this.btngetxml.TabIndex = 30;
            this.btngetxml.Text = "Get XML";
            this.btngetxml.UseVisualStyleBackColor = true;
            this.btngetxml.Click += new System.EventHandler(this.btngetxml_Click);
            // 
            // btMonitor
            // 
            this.btMonitor.Location = new System.Drawing.Point(347, 318);
            this.btMonitor.Name = "btMonitor";
            this.btMonitor.Size = new System.Drawing.Size(75, 23);
            this.btMonitor.TabIndex = 31;
            this.btMonitor.Text = "Start Monitor";
            this.btMonitor.UseVisualStyleBackColor = true;
            this.btMonitor.Click += new System.EventHandler(this.btMonitor_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(909, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(377, 150);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // TBAddress
            // 
            this.TBAddress.Location = new System.Drawing.Point(33, 339);
            this.TBAddress.Name = "TBAddress";
            this.TBAddress.Size = new System.Drawing.Size(100, 20);
            this.TBAddress.TabIndex = 33;
            this.TBAddress.Text = "192.168.1.109";
            this.TBAddress.TextChanged += new System.EventHandler(this.TBAddress_TextChanged);
            // 
            // TBPort
            // 
            this.TBPort.Location = new System.Drawing.Point(139, 339);
            this.TBPort.Name = "TBPort";
            this.TBPort.Size = new System.Drawing.Size(26, 20);
            this.TBPort.TabIndex = 34;
            this.TBPort.Text = "5001";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Address";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Port";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // logClassbtn
            // 
            this.logClassbtn.Location = new System.Drawing.Point(179, 339);
            this.logClassbtn.Name = "logClassbtn";
            this.logClassbtn.Size = new System.Drawing.Size(94, 23);
            this.logClassbtn.TabIndex = 37;
            this.logClassbtn.Text = "connect logger";
            this.logClassbtn.UseVisualStyleBackColor = true;
            this.logClassbtn.Click += new System.EventHandler(this.logClassbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::NILogger.Properties.Resources.exchanger;
            this.pictureBox1.Location = new System.Drawing.Point(1101, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 28);
            this.button2.TabIndex = 39;
            this.button2.Text = "next window";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(NILogger.Form1);
            this.form1BindingSource.CurrentChanged += new System.EventHandler(this.form1BindingSource_CurrentChanged);
            // 
            // Savexml
            // 
            this.Savexml.Location = new System.Drawing.Point(179, 289);
            this.Savexml.Name = "Savexml";
            this.Savexml.Size = new System.Drawing.Size(75, 23);
            this.Savexml.TabIndex = 40;
            this.Savexml.Text = "save xml";
            this.Savexml.UseVisualStyleBackColor = true;
            this.Savexml.Click += new System.EventHandler(this.Savexml_Click);
            // 
            // createModule
            // 
            this.createModule.Location = new System.Drawing.Point(15, 120);
            this.createModule.Name = "createModule";
            this.createModule.Size = new System.Drawing.Size(90, 49);
            this.createModule.TabIndex = 41;
            this.createModule.Text = "Create module using address";
            this.createModule.UseVisualStyleBackColor = true;
            this.createModule.Click += new System.EventHandler(this.createModule_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 554);
            this.Controls.Add(this.createModule);
            this.Controls.Add(this.Savexml);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logClassbtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TBPort);
            this.Controls.Add(this.TBAddress);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btMonitor);
            this.Controls.Add(this.btngetxml);
            this.Controls.Add(this.txbnewdata2);
            this.Controls.Add(this.txbnewdata);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BtnSendCommand);
            this.Controls.Add(this.TxtEdit);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.GrbChannels);
            this.Controls.Add(this.CkbUseChecksum);
            this.Controls.Add(this.CmbCommand);
            this.Controls.Add(this.TxbSerialCmd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCreateCommand);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxbPositon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxbModifier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxbData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxbCmdChars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxbModule);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.CmbPorts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GrbChannels.ResumeLayout(false);
            this.GrbChannels.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbPorts;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox TxbModule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxbCmdChars;
        private System.Windows.Forms.TextBox TxbPositon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxbModifier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxbData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCreateCommand;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxbSerialCmd;
        private System.Windows.Forms.ComboBox CmbCommand;
        private System.Windows.Forms.CheckBox CkbUseChecksum;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.GroupBox GrbChannels;
        private System.Windows.Forms.CheckBox C1;
        private System.Windows.Forms.CheckBox C16;
        private System.Windows.Forms.CheckBox C15;
        private System.Windows.Forms.CheckBox C14;
        private System.Windows.Forms.CheckBox C13;
        private System.Windows.Forms.CheckBox C12;
        private System.Windows.Forms.CheckBox C11;
        private System.Windows.Forms.CheckBox C10;
        private System.Windows.Forms.CheckBox C9;
        private System.Windows.Forms.CheckBox C8;
        private System.Windows.Forms.CheckBox C7;
        private System.Windows.Forms.CheckBox C6;
        private System.Windows.Forms.CheckBox C5;
        private System.Windows.Forms.CheckBox C4;
        private System.Windows.Forms.CheckBox C3;
        private System.Windows.Forms.CheckBox C2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox TxtEdit;
        private System.Windows.Forms.Button BtnSendCommand;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbnewdata;
        private System.Windows.Forms.TextBox txbnewdata2;
        private System.Windows.Forms.Button btngetxml;
        private System.Windows.Forms.Button btMonitor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TBAddress;
        private System.Windows.Forms.TextBox TBPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button logClassbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Savexml;
        private System.Windows.Forms.Button createModule;
    }
}

