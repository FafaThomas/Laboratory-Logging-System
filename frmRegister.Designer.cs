
namespace PS2_GUI_Alpha_v2._0
{
    partial class frmRegister
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SerialMonitor = new System.Windows.Forms.Label();
            this.RegisterPort = new System.IO.Ports.SerialPort(this.components);
            this.CustodianRegisterPanel = new System.Windows.Forms.Panel();
            this.label51 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CustodianRegisterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(58, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "REGISTER CUSTODIAN";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtUsername.Location = new System.Drawing.Point(113, 198);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(149, 26);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(43, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username";
            // 
            // txtLastname
            // 
            this.txtLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtLastname.Location = new System.Drawing.Point(113, 240);
            this.txtLastname.Multiline = true;
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(149, 26);
            this.txtLastname.TabIndex = 7;
            this.txtLastname.TextChanged += new System.EventHandler(this.txtLastname_TextChanged);
            this.txtLastname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLastname_KeyDown);
            this.txtLastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastname_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(43, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Last Name";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtFirstname.Location = new System.Drawing.Point(113, 281);
            this.txtFirstname.Multiline = true;
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(149, 26);
            this.txtFirstname.TabIndex = 9;
            this.txtFirstname.TextChanged += new System.EventHandler(this.txtFirstname_TextChanged);
            this.txtFirstname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFirstname_KeyDown);
            this.txtFirstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstname_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(43, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "First Name";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Impact", 12.75F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(46, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 39);
            this.button1.TabIndex = 14;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(81, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Already Have an Account?";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label9.ForeColor = System.Drawing.Color.Teal;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(110, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Back to Login";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblValue2.Location = new System.Drawing.Point(36, 26);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(41, 13);
            this.lblValue2.TabIndex = 18;
            this.lblValue2.Text = "label10";
            this.lblValue2.Visible = false;
            this.lblValue2.TextChanged += new System.EventHandler(this.lblValue2_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(113, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // SerialMonitor
            // 
            this.SerialMonitor.AutoSize = true;
            this.SerialMonitor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SerialMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SerialMonitor.Location = new System.Drawing.Point(36, 9);
            this.SerialMonitor.Name = "SerialMonitor";
            this.SerialMonitor.Size = new System.Drawing.Size(35, 13);
            this.SerialMonitor.TabIndex = 22;
            this.SerialMonitor.Text = "label1";
            this.SerialMonitor.Visible = false;
            this.SerialMonitor.TextChanged += new System.EventHandler(this.SerialMonitor_TextChanged);
            // 
            // RegisterPort
            // 
            this.RegisterPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.RegisterPort_DataReceived);
            // 
            // CustodianRegisterPanel
            // 
            this.CustodianRegisterPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CustodianRegisterPanel.Controls.Add(this.label51);
            this.CustodianRegisterPanel.Controls.Add(this.label1);
            this.CustodianRegisterPanel.Controls.Add(this.pictureBox3);
            this.CustodianRegisterPanel.Controls.Add(this.pictureBox2);
            this.CustodianRegisterPanel.ForeColor = System.Drawing.Color.Teal;
            this.CustodianRegisterPanel.Location = new System.Drawing.Point(47, 95);
            this.CustodianRegisterPanel.Name = "CustodianRegisterPanel";
            this.CustodianRegisterPanel.Size = new System.Drawing.Size(220, 259);
            this.CustodianRegisterPanel.TabIndex = 24;
            this.CustodianRegisterPanel.Visible = false;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Impact", 11.75F);
            this.label51.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label51.Location = new System.Drawing.Point(29, 209);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(160, 40);
            this.label51.TabIndex = 3;
            this.label51.Text = "Please Tap a Valid Card \r\nto Proceed";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 11.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(5, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Tap the Custodian Card \r\nto Proceed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(11, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 37);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(41, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 151);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(315, 449);
            this.Controls.Add(this.CustodianRegisterPanel);
            this.Controls.Add(this.SerialMonitor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblValue2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegister";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CustodianRegisterPanel.ResumeLayout(false);
            this.CustodianRegisterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SerialMonitor;
        private System.IO.Ports.SerialPort RegisterPort;
        private System.Windows.Forms.Panel CustodianRegisterPanel;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}