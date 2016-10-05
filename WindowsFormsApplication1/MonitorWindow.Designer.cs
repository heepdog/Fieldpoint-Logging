using System;

namespace WindowsFormsApplication1
{
    partial class MonitorWindow
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM6ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_meterTemp = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_probeTemp = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_deltaH = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_CFM = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_ftCubed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.gasValues = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_weight = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_timeElapsed = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ResetCounters = new System.Windows.Forms.Button();
            this.btn_StartTest = new System.Windows.Forms.Button();
            this.btn_EditModules = new System.Windows.Forms.Button();
            this.btn_UpdateValues = new System.Windows.Forms.Button();
            this.btn_getnetwork = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ApplianceBTUs = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.LoadBTUs = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.LoadOutTemp = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ApplianceOutTemp = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ApplianceTempIn = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.LoadInTemp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ApploianceFlow = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.LoadFlow = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduleConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ConnectionStatusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.UpdateForm = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gasValues.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOM6ToolStripMenuItem,
            this.cOM6ToolStripMenuItem1});
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.connectToolStripMenuItem.Text = "Connect...";
            // 
            // cOM6ToolStripMenuItem
            // 
            this.cOM6ToolStripMenuItem.Name = "cOM6ToolStripMenuItem";
            this.cOM6ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cOM6ToolStripMenuItem.Text = "192.168.1.109";
            this.cOM6ToolStripMenuItem.Click += new System.EventHandler(this.cOM6ToolStripMenuItem_Click);
            // 
            // cOM6ToolStripMenuItem1
            // 
            this.cOM6ToolStripMenuItem1.Name = "cOM6ToolStripMenuItem1";
            this.cOM6ToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.cOM6ToolStripMenuItem1.Text = "COM6";
            // 
            // lbl_meterTemp
            // 
            this.lbl_meterTemp.AutoSize = true;
            this.lbl_meterTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_meterTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_meterTemp.Location = new System.Drawing.Point(123, 91);
            this.lbl_meterTemp.Name = "lbl_meterTemp";
            this.lbl_meterTemp.Size = new System.Drawing.Size(112, 20);
            this.lbl_meterTemp.TabIndex = 9;
            this.lbl_meterTemp.Text = "label11";
            this.lbl_meterTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Meter Temp.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_probeTemp
            // 
            this.lbl_probeTemp.AutoSize = true;
            this.lbl_probeTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_probeTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_probeTemp.Location = new System.Drawing.Point(123, 70);
            this.lbl_probeTemp.Name = "lbl_probeTemp";
            this.lbl_probeTemp.Size = new System.Drawing.Size(112, 20);
            this.lbl_probeTemp.TabIndex = 7;
            this.lbl_probeTemp.Text = "label9";
            this.lbl_probeTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Probe Temp.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_deltaH
            // 
            this.lbl_deltaH.AutoSize = true;
            this.lbl_deltaH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_deltaH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_deltaH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_deltaH.Location = new System.Drawing.Point(123, 49);
            this.lbl_deltaH.Name = "lbl_deltaH";
            this.lbl_deltaH.Size = new System.Drawing.Size(112, 20);
            this.lbl_deltaH.TabIndex = 5;
            this.lbl_deltaH.Text = "label7";
            this.lbl_deltaH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "dH";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CFM
            // 
            this.lbl_CFM.AutoSize = true;
            this.lbl_CFM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_CFM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CFM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_CFM.Location = new System.Drawing.Point(123, 25);
            this.lbl_CFM.Name = "lbl_CFM";
            this.lbl_CFM.Size = new System.Drawing.Size(112, 23);
            this.lbl_CFM.TabIndex = 3;
            this.lbl_CFM.Text = "label5";
            this.lbl_CFM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "CFM";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ftCubed
            // 
            this.lbl_ftCubed.AutoSize = true;
            this.lbl_ftCubed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ftCubed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ftCubed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ftCubed.Location = new System.Drawing.Point(123, 1);
            this.lbl_ftCubed.Name = "lbl_ftCubed";
            this.lbl_ftCubed.Size = new System.Drawing.Size(112, 23);
            this.lbl_ftCubed.TabIndex = 1;
            this.lbl_ftCubed.Text = "label3";
            this.lbl_ftCubed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ft^3";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 562);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 385);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(974, 174);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 251F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(974, 376);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.gasValues, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(726, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(245, 370);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sample Train";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gasValues
            // 
            this.gasValues.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.gasValues.ColumnCount = 2;
            this.gasValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gasValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gasValues.Controls.Add(this.label3, 0, 6);
            this.gasValues.Controls.Add(this.lb_weight, 0, 6);
            this.gasValues.Controls.Add(this.label20, 0, 5);
            this.gasValues.Controls.Add(this.lbl_timeElapsed, 0, 5);
            this.gasValues.Controls.Add(this.lbl_meterTemp, 1, 4);
            this.gasValues.Controls.Add(this.label10, 0, 4);
            this.gasValues.Controls.Add(this.lbl_probeTemp, 1, 3);
            this.gasValues.Controls.Add(this.label8, 0, 3);
            this.gasValues.Controls.Add(this.lbl_deltaH, 1, 2);
            this.gasValues.Controls.Add(this.label6, 0, 2);
            this.gasValues.Controls.Add(this.lbl_CFM, 1, 1);
            this.gasValues.Controls.Add(this.label4, 0, 1);
            this.gasValues.Controls.Add(this.lbl_ftCubed, 1, 0);
            this.gasValues.Controls.Add(this.label2, 0, 0);
            this.gasValues.Dock = System.Windows.Forms.DockStyle.Top;
            this.gasValues.Location = new System.Drawing.Point(3, 56);
            this.gasValues.Name = "gasValues";
            this.gasValues.RowCount = 7;
            this.gasValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gasValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gasValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gasValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gasValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gasValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gasValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gasValues.Size = new System.Drawing.Size(239, 154);
            this.gasValues.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Weight";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_weight
            // 
            this.lb_weight.AutoSize = true;
            this.lb_weight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_weight.Location = new System.Drawing.Point(123, 133);
            this.lb_weight.Name = "lb_weight";
            this.lb_weight.Size = new System.Drawing.Size(112, 20);
            this.lb_weight.TabIndex = 14;
            this.lb_weight.Text = "Weight";
            this.lb_weight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 20);
            this.label20.TabIndex = 10;
            this.label20.Text = "Time Elapsed";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // lbl_timeElapsed
            // 
            this.lbl_timeElapsed.AutoSize = true;
            this.lbl_timeElapsed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_timeElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeElapsed.Location = new System.Drawing.Point(123, 112);
            this.lbl_timeElapsed.Name = "lbl_timeElapsed";
            this.lbl_timeElapsed.Size = new System.Drawing.Size(112, 20);
            this.lbl_timeElapsed.TabIndex = 12;
            this.lbl_timeElapsed.Text = "label21";
            this.lbl_timeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btn_ResetCounters, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btn_StartTest, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.btn_EditModules, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.btn_UpdateValues, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.btn_getnetwork, 1, 4);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1, 214);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(243, 155);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // btn_ResetCounters
            // 
            this.btn_ResetCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ResetCounters.Location = new System.Drawing.Point(49, 3);
            this.btn_ResetCounters.Name = "btn_ResetCounters";
            this.btn_ResetCounters.Size = new System.Drawing.Size(144, 24);
            this.btn_ResetCounters.TabIndex = 0;
            this.btn_ResetCounters.Text = "Reset Counters";
            this.btn_ResetCounters.UseVisualStyleBackColor = true;
            // 
            // btn_StartTest
            // 
            this.btn_StartTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_StartTest.Enabled = false;
            this.btn_StartTest.Location = new System.Drawing.Point(49, 33);
            this.btn_StartTest.Name = "btn_StartTest";
            this.btn_StartTest.Size = new System.Drawing.Size(144, 24);
            this.btn_StartTest.TabIndex = 1;
            this.btn_StartTest.Text = "Start Test";
            this.btn_StartTest.UseVisualStyleBackColor = true;
            this.btn_StartTest.Click += new System.EventHandler(this.btn_StartTest_Click);
            // 
            // btn_EditModules
            // 
            this.btn_EditModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_EditModules.Enabled = false;
            this.btn_EditModules.Location = new System.Drawing.Point(49, 63);
            this.btn_EditModules.Name = "btn_EditModules";
            this.btn_EditModules.Size = new System.Drawing.Size(144, 24);
            this.btn_EditModules.TabIndex = 2;
            this.btn_EditModules.Text = "Edit Modules";
            this.btn_EditModules.UseVisualStyleBackColor = true;
            this.btn_EditModules.Click += new System.EventHandler(this.btn_EditModules_Click);
            // 
            // btn_UpdateValues
            // 
            this.btn_UpdateValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_UpdateValues.Location = new System.Drawing.Point(49, 93);
            this.btn_UpdateValues.Name = "btn_UpdateValues";
            this.btn_UpdateValues.Size = new System.Drawing.Size(144, 24);
            this.btn_UpdateValues.TabIndex = 3;
            this.btn_UpdateValues.Text = "Update Network";
            this.btn_UpdateValues.UseVisualStyleBackColor = true;
            this.btn_UpdateValues.Click += new System.EventHandler(this.btn_UpdateValues_Click);
            // 
            // btn_getnetwork
            // 
            this.btn_getnetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_getnetwork.Enabled = false;
            this.btn_getnetwork.Location = new System.Drawing.Point(49, 123);
            this.btn_getnetwork.Name = "btn_getnetwork";
            this.btn_getnetwork.Size = new System.Drawing.Size(144, 29);
            this.btn_getnetwork.TabIndex = 4;
            this.btn_getnetwork.Text = "Get Network";
            this.btn_getnetwork.UseVisualStyleBackColor = true;
            this.btn_getnetwork.Click += new System.EventHandler(this.btn_getnetwork_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(717, 370);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ApplianceBTUs);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.LoadBTUs);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.LoadOutTemp);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.ApplianceOutTemp);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.ApplianceTempIn);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.LoadInTemp);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ApploianceFlow);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.LoadFlow);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(61, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 290);
            this.panel1.TabIndex = 2;
            // 
            // ApplianceBTUs
            // 
            this.ApplianceBTUs.Location = new System.Drawing.Point(482, 151);
            this.ApplianceBTUs.Name = "ApplianceBTUs";
            this.ApplianceBTUs.ReadOnly = true;
            this.ApplianceBTUs.Size = new System.Drawing.Size(100, 20);
            this.ApplianceBTUs.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(479, 134);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 15;
            this.label19.Text = "Load Out";
            // 
            // LoadBTUs
            // 
            this.LoadBTUs.Location = new System.Drawing.Point(3, 151);
            this.LoadBTUs.Name = "LoadBTUs";
            this.LoadBTUs.ReadOnly = true;
            this.LoadBTUs.Size = new System.Drawing.Size(100, 20);
            this.LoadBTUs.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 134);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Load Out";
            // 
            // LoadOutTemp
            // 
            this.LoadOutTemp.Location = new System.Drawing.Point(21, 237);
            this.LoadOutTemp.Name = "LoadOutTemp";
            this.LoadOutTemp.ReadOnly = true;
            this.LoadOutTemp.Size = new System.Drawing.Size(100, 20);
            this.LoadOutTemp.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 220);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Load Out";
            // 
            // ApplianceOutTemp
            // 
            this.ApplianceOutTemp.Location = new System.Drawing.Point(466, 237);
            this.ApplianceOutTemp.Name = "ApplianceOutTemp";
            this.ApplianceOutTemp.ReadOnly = true;
            this.ApplianceOutTemp.Size = new System.Drawing.Size(100, 20);
            this.ApplianceOutTemp.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(463, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Appliance Out";
            // 
            // ApplianceTempIn
            // 
            this.ApplianceTempIn.Location = new System.Drawing.Point(466, 23);
            this.ApplianceTempIn.Name = "ApplianceTempIn";
            this.ApplianceTempIn.ReadOnly = true;
            this.ApplianceTempIn.Size = new System.Drawing.Size(100, 20);
            this.ApplianceTempIn.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(463, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Appliance In";
            // 
            // LoadInTemp
            // 
            this.LoadInTemp.Location = new System.Drawing.Point(21, 23);
            this.LoadInTemp.Name = "LoadInTemp";
            this.LoadInTemp.ReadOnly = true;
            this.LoadInTemp.Size = new System.Drawing.Size(100, 20);
            this.LoadInTemp.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Load In";
            // 
            // ApploianceFlow
            // 
            this.ApploianceFlow.Location = new System.Drawing.Point(359, 151);
            this.ApploianceFlow.Name = "ApploianceFlow";
            this.ApploianceFlow.ReadOnly = true;
            this.ApploianceFlow.Size = new System.Drawing.Size(50, 20);
            this.ApploianceFlow.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(356, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Appliance Flow";
            // 
            // LoadFlow
            // 
            this.LoadFlow.Location = new System.Drawing.Point(162, 151);
            this.LoadFlow.Name = "LoadFlow";
            this.LoadFlow.ReadOnly = true;
            this.LoadFlow.Size = new System.Drawing.Size(53, 20);
            this.LoadFlow.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Load Flow";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.exchanger;
            this.pictureBox1.Location = new System.Drawing.Point(31, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(522, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.moduleConfigurationToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // moduleConfigurationToolStripMenuItem
            // 
            this.moduleConfigurationToolStripMenuItem.Name = "moduleConfigurationToolStripMenuItem";
            this.moduleConfigurationToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.moduleConfigurationToolStripMenuItem.Text = "Module Configuration";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionStatusbar,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 586);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(980, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ConnectionStatusbar
            // 
            this.ConnectionStatusbar.Name = "ConnectionStatusbar";
            this.ConnectionStatusbar.Size = new System.Drawing.Size(88, 17);
            this.ConnectionStatusbar.Text = "Not Connected";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(980, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // UpdateForm
            // 
            this.UpdateForm.WorkerReportsProgress = true;
            this.UpdateForm.WorkerSupportsCancellation = true;
            this.UpdateForm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateForm_DoWork);
            this.UpdateForm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateForm_ProgressChanged);
            // 
            // MonitorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 608);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MonitorWindow";
            this.Text = "MonitorWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MonitorWindow_FormClosed);
            this.Shown += new System.EventHandler(this.MonitorWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.gasValues.ResumeLayout(false);
            this.gasValues.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox LoadFlow;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ApploianceFlow;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox LoadInTemp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox ApplianceTempIn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ApplianceOutTemp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox LoadOutTemp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox LoadBTUs;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox ApplianceBTUs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel gasValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_ftCubed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_CFM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_deltaH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_probeTemp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_meterTemp;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_timeElapsed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btn_ResetCounters;
        private System.Windows.Forms.Button btn_StartTest;
        private System.Windows.Forms.Button btn_EditModules;
        private System.Windows.Forms.Button btn_UpdateValues;
        private System.Windows.Forms.Button btn_getnetwork;
        private System.Windows.Forms.ToolStripMenuItem moduleConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM6ToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker UpdateForm;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionStatusbar;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_weight;
    }
}