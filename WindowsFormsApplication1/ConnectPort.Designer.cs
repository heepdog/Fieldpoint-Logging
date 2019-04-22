namespace NILogger
{
    partial class ConnectPort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox portname1;
        public System.Windows.Forms.TextBox PortNumber1;

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
            this.portname1 = new System.Windows.Forms.TextBox();
            this.PortNumber1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbTCP = new System.Windows.Forms.CheckBox();
            this.cbCOM = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // portname1
            // 
            this.portname1.Enabled = false;
            this.portname1.Location = new System.Drawing.Point(27, 53);
            this.portname1.Name = "portname1";
            this.portname1.Size = new System.Drawing.Size(139, 20);
            this.portname1.TabIndex = 0;
            // 
            // PortNumber1
            // 
            this.PortNumber1.Location = new System.Drawing.Point(190, 53);
            this.PortNumber1.Name = "PortNumber1";
            this.PortNumber1.Size = new System.Drawing.Size(66, 20);
            this.PortNumber1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Address";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbTCP
            // 
            this.cbTCP.AutoSize = true;
            this.cbTCP.Location = new System.Drawing.Point(7, 15);
            this.cbTCP.Name = "cbTCP";
            this.cbTCP.Size = new System.Drawing.Size(47, 17);
            this.cbTCP.TabIndex = 0;
            this.cbTCP.Text = "TCP";
            this.cbTCP.UseVisualStyleBackColor = true;
            this.cbTCP.Click += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbCOM
            // 
            this.cbCOM.AutoSize = true;
            this.cbCOM.Checked = true;
            this.cbCOM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCOM.Location = new System.Drawing.Point(61, 15);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(50, 17);
            this.cbCOM.TabIndex = 1;
            this.cbCOM.Text = "COM";
            this.cbCOM.UseVisualStyleBackColor = true;
            this.cbCOM.Click += new System.EventHandler(this.cbCOM_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCOM);
            this.groupBox1.Controls.Add(this.cbTCP);
            this.groupBox1.Location = new System.Drawing.Point(37, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 35);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // ConnectPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 149);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortNumber1);
            this.Controls.Add(this.portname1);
            this.Name = "ConnectPort";
            this.Text = "ConnectPort";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox cbTCP;
        public System.Windows.Forms.CheckBox cbCOM;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}