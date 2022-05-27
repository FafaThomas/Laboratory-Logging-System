using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;



namespace PS2_GUI_Alpha_v2._0

{
    public partial class Dashboard : Form
    {

        public static Dashboard instance;
        public int mstr;
        public delegate void d1(string indata);
        delegate void serialCalback(string val);
        public TextBox Monitor;

        //Initializes all graphics components of the Dashboard
        public Dashboard()
        {
            
            InitializeComponent();
            NotificationTextBox.SelectionStart = NotificationTextBox.Text.Length;
            NotificationTextBox.ScrollToCaret();
            instance = this;
        }

        //Defines all the parameters for the database
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = " + Application.StartupPath + "\\db_ps.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();


        //Loads all initial states of the Dashboard
        private void Dashboard2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_MachineRegistry' table. You can move, or remove it, as needed.
            this.tbl_MachineRegistryTableAdapter.Fill(this.db_psDataSet.tbl_MachineRegistry);
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_status' table. You can move, or remove it, as needed.
            this.tbl_statusTableAdapter.Fill(this.db_psDataSet.tbl_status);
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_MaintenanceSchedule' table. You can move, or remove it, as needed.
            this.tbl_MaintenanceScheduleTableAdapter.Fill(this.db_psDataSet.tbl_MaintenanceSchedule);
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_users' table. You can move, or remove it, as needed.
            this.tbl_usersTableAdapter.Fill(this.db_psDataSet.tbl_users);
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_ItemRegistry' table. You can move, or remove it, as needed.
            this.tbl_ItemRegistryTableAdapter.Fill(this.db_psDataSet.tbl_ItemRegistry);
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_History' table. You can move, or remove it, as needed.
            this.tbl_HistoryTableAdapter.Fill(this.db_psDataSet.tbl_History);


            username1.Text = DataVar.usernamedata;
            timer.Start();
            DataVar.notification = "User " + username1.Text + " Logged in at ";



            con.Open();
            NotificationUpdate();
            NotificationRefresh();
            fillnsMachine();
            con.Close();


            PnlNav.Height = btnDashboard.Height;
            PnlNav.Top = btnDashboard.Top;
            PnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(0, 139, 139);
            btnHistory.BackColor = Color.FromArgb(0, 128, 128);
            btnMachineRegistry.BackColor = Color.FromArgb(0, 128, 128);
            btnMaintenance.BackColor = Color.FromArgb(0, 128, 128);
            btnUsers.BackColor = Color.FromArgb(0, 128, 128);
            btnNewSession.BackColor = Color.FromArgb(0, 128, 128);
            button16.BackColor = Color.FromArgb(0, 128, 128);
            DashboardStatus.Show();
            DashboardLabel.Show();
            DashboardNotifications.Show();
            InventoryPanel.Hide();
            HistoryPanel.Hide();
            DashboardEndSession.Show();
            NewSessionPanel.Hide();
            MachineRegistryPanel.Hide();
            MaintenanceReportPanel.Hide();
            MaintenanceSchedulePanel.Hide();
            UserPanel.Hide();
            DashboardTime.Show();
            DashboardDate.Show();
            NewSessionConfirmPanel.Hide();
            GnConfirmPnl.Hide();
            EndSessionConfirmPanel.Hide();
            HFilterPanel.Hide();


            Dashport.Close();
            NotificationTextBox.SelectionStart = NotificationTextBox.Text.Length;
            NotificationTextBox.ScrollToCaret();


        }


       

        //Makes entries on the Notification Board
        private void NotificationRefresh()
        {
            NotificationTextBox.Text = "";
            string ntfcheck = "SELECT * FROM tbl_EventLogs";
            cmd = new OleDbCommand(ntfcheck, con);
            OleDbDataReader ndtf = cmd.ExecuteReader();
            while (ndtf.Read())
            {
                NotificationTextBox.Text += string.Join(Environment.NewLine, ndtf["Event"], ndtf["Date&Time"], Environment.NewLine);
                NotificationTextBox.SelectionStart = NotificationTextBox.Text.Length;
                NotificationTextBox.ScrollToCaret();
            }
        }


        //Updates the EventLogs
        private void NotificationUpdate()
        {
                string notif = "INSERT INTO tbl_EventLogs Values('" + DataVar.notification + "','" + DateTime.Now + "')";
                cmd = new OleDbCommand(notif, con);
                cmd.ExecuteNonQuery();

                DataVar.notification = "";
            



        }

        //This fetches the data from Machine Registry to New Session from the RFID
        private void MatchRFID()
        {
            //string rf = "SELECT * FROM tbl_MachineRegistry where MachineName = '" + NsMachine.Text + "'";
            //cmd = new OleDbCommand(rf, con);
            //OleDbDataReader rrf = cmd.ExecuteReader();
            //while (rrf.Read())
            //{
              //  RFID.GnRFID = rrf["Machine_RFID"].ToString();
                //GRFID.Text = RFID.GnRFID;
                //DataVar.MachineCond = rrf["MachineCondition"].ToString();
            //}

        }

        //fills the Combobox for Machines on New Session
        private void fillnsMachine()
        {
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            //NsMachine.Items.Clear();
            string machine = "SELECT * FROM tbl_MachineRegistry";
            cmd = new OleDbCommand(machine, con);
            OleDbDataReader tbl = cmd.ExecuteReader();
            while (tbl.Read())
            {
                //NsMachine.Items.Add(tbl["MachineName"]);
                comboBox4.Items.Add(tbl["MachineName"]);
                comboBox2.Items.Add(tbl["MachineName"]);
            }

        }

        //fills the Combobox for Machines on End Session
        private void statfill()
        {
            string machine = "SELECT * FROM tbl_status";
            cmd = new OleDbCommand(machine, con);
            OleDbDataReader tbl = cmd.ExecuteReader();
            while (tbl.Read())
            {
                comboBox1.Items.Add(tbl["MachineName"]);
            }
        }

        //fetches the data from Arduino to GUI
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string indata = Dashport.ReadExisting();
            setText(indata);
        }

        //converts the data into Text
        public void setText(string val)
        {

            if (this.SerialMonitor.InvokeRequired)
            {
                serialCalback scb = new serialCalback(setText);
                this.Invoke(scb, new object[] { val });

            }
            else
            {
                SerialMonitor.Text = val;
                if (SerialMonitor.Text == "02 EC 8F 34")
                {
                    //if (MachineRegistryConfirmPanel.Visible == true)
                    //{
                      //  MrRFID.Text = SerialMonitor.Text;
                    //}
                    if (NewSessionConfirmPanel.Visible == true)
                    {
                        NsRFID.Text = SerialMonitor.Text;
                    }
                    if (EndSessionConfirmPanel.Visible == true)
                    {
                        EsRFID.Text = SerialMonitor.Text;
                    }
                    if (GnConfirmPnl.Visible == true && MaintenanceReportPanel.Visible == true)
                    {
                        if (MShifter.Text == "SHIFT1")
                        {
                            SRRFID.Text = SerialMonitor.Text;
                        }
                        if (MShifter.Text == "SHIFT2")
                        {
                            SMRFID.Text = SerialMonitor.Text;
                        }
                        if (MShifter.Text == "SHIFT3")
                        {
                            MLRFID.Text = SerialMonitor.Text;
                        }
                        if (MShifter.Text == "SHIFT4")
                        {
                            VMRFID.Text = SerialMonitor.Text;
                        }
                        if (MShifter.Text == "SHIFT5") 
                        {
                            RSMRFID.Text = SerialMonitor.Text;
                        }
                    }
                    if (GnConfirmPnl.Visible == true && HistoryPanel.Visible == true)
                    {
                        SPDF1RFID.Text = SerialMonitor.Text;
                    }
                    if (GnConfirmPnl.Visible == false && HistoryPanel.Visible == true && HFilterPanel.Visible == true)
                    {
                        HMACHRFID.Text = "Custodian Card";
                    }
                }

                if (SerialMonitor.Text != "02 EC 8F 34")
                {
                    //if (MachineRegistryConfirmPanel.Visible == true)
                    //{
                      //  MrRFID.Text = SerialMonitor.Text;
                    //}

                    if (NewSessionConfirmPanel.Visible == true)
                    {
                        NsRFID.Text = SerialMonitor.Text;
                    }
                    if (EndSessionConfirmPanel.Visible == true)
                    {
                        EsRFID.Text = SerialMonitor.Text;
                    }
                    if (GnConfirmPnl.Visible == true && MaintenanceReportPanel.Visible == true)
                    {
                        if (MShifter.Text == "SHIFT1")
                        {
                            SRRFID.Text = SerialMonitor.Text;
                        }
                        if (MShifter.Text == "SHIFT2")
                        {
                            SMRFID.Text = SerialMonitor.Text;
                        }
                        if (MShifter.Text == "SHIFT3")
                        {
                            MLRFID.Text = SerialMonitor.Text;
                        }
                        if (MShifter.Text == "SHIFT4")
                        {
                            VMRFID.Text = SerialMonitor.Text;
                        }
                        if (MShifter.Text == "SHIFT5") 
                        {
                            RSMRFID.Text = SerialMonitor.Text;
                        }
                    }
                    if (GnConfirmPnl.Visible == true && HistoryPanel.Visible == true)
                    {
                        SPDF1RFID.Text = SerialMonitor.Text;
                    }
                   if (GnConfirmPnl.Visible == false && HistoryPanel.Visible == true && HFilterPanel.Visible == true)
                    {
                        HMACHRFID.Text = SerialMonitor.Text;
                    }

                }
            }

        }

        //History Button
        private void btnHistory_Click(object sender, EventArgs e)
        {
           // DataView Hv = new DataView(this.db_psDataSet.tbl_History);
            //dataGridView2.DataSource = Hv;

            PnlNav.Height = btnHistory.Height;
            PnlNav.Top = btnHistory.Top;
            PnlNav.Left = btnHistory.Left;
            btnHistory.BackColor = Color.FromArgb(0, 139, 139);
            btnDashboard.BackColor = Color.FromArgb(0, 128, 128);
            btnNewSession.BackColor = Color.FromArgb(0, 128, 128);
            btnMachineRegistry.BackColor = Color.FromArgb(0, 128, 128);
            btnMaintenance.BackColor = Color.FromArgb(0, 128, 128);
            btnUsers.BackColor = Color.FromArgb(0, 128, 128);
            button16.BackColor = Color.FromArgb(0, 128, 128);
            HistoryPanel.Show();
            DashboardStatus.Hide();
            DashboardLabel.Hide();
            DashboardNotifications.Hide();
            DashboardEndSession.Hide();
            NewSessionPanel.Hide();
            MachineRegistryPanel.Hide();
            MaintenanceReportPanel.Hide();
            MaintenanceSchedulePanel.Hide();
            UserPanel.Hide();
            DashboardDate.Hide();
            DashboardTime.Hide();
            NewSessionConfirmPanel.Hide();
            GnConfirmPnl.Hide();
            EndSessionConfirmPanel.Hide();
            InventoryPanel.Hide();
            FilterDateIN.Value = DateTime.Now;
            FilterDateOut.Value = DateTime.Now.AddDays(1);
            Dashport.Close();
        }

        //Dashboard Button
        private void btnDashboard_Click(object sender, EventArgs e)
        {

            PnlNav.Height = btnDashboard.Height;
            PnlNav.Top = btnDashboard.Top;
            PnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(0, 139, 139);
            btnHistory.BackColor = Color.FromArgb(0, 128, 128);
            btnMachineRegistry.BackColor = Color.FromArgb(0, 128, 128);
            btnMaintenance.BackColor = Color.FromArgb(0, 128, 128);
            btnUsers.BackColor = Color.FromArgb(0, 128, 128);
            btnNewSession.BackColor = Color.FromArgb(0, 128, 128);
            button16.BackColor = Color.FromArgb(0, 128, 128);
            DashboardStatus.Show();
            DashboardLabel.Show();
            DashboardNotifications.Show();
            HistoryPanel.Hide();
            DashboardEndSession.Show();
            NewSessionPanel.Hide();
            MachineRegistryPanel.Hide();
            MaintenanceReportPanel.Hide();
            MaintenanceSchedulePanel.Hide();
            UserPanel.Hide();
            DashboardTime.Show();
            DashboardDate.Show();
            NewSessionConfirmPanel.Hide();
            GnConfirmPnl.Hide();
            EndSessionConfirmPanel.Hide();
            InventoryPanel.Hide();
            SerialMonitor.Text = "";
            Dashport.Close();
            NotificationTextBox.SelectionStart = NotificationTextBox.Text.Length;
            NotificationTextBox.ScrollToCaret();
            dataGridView4.Refresh();
            dataGridView4.Update();


        }
        //New Session Button
        private void btnNewSession_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnNewSession.Height;
            PnlNav.Top = btnNewSession.Top;
            PnlNav.Left = btnNewSession.Left;
            btnNewSession.BackColor = Color.FromArgb(0, 139, 139);
            btnHistory.BackColor = Color.FromArgb(0, 128, 128);
            btnDashboard.BackColor = Color.FromArgb(0, 128, 128);
            btnMachineRegistry.BackColor = Color.FromArgb(0, 128, 128);
            btnMaintenance.BackColor = Color.FromArgb(0, 128, 128);
            btnUsers.BackColor = Color.FromArgb(0, 128, 128);
            button16.BackColor = Color.FromArgb(0, 128, 128);
            NewSessionPanel.Show();
            HistoryPanel.Hide();
            DashboardStatus.Hide();
            DashboardLabel.Hide();
            DashboardNotifications.Hide();
            DashboardNotifications.Hide();
            DashboardEndSession.Hide();
            MachineRegistryPanel.Hide();
            MaintenanceReportPanel.Hide();
            MaintenanceSchedulePanel.Hide();
            UserPanel.Hide();
            DashboardDate.Hide();
            DashboardTime.Hide();
            NewSessionButton.Enabled = false;
            checkBox1.Checked = false;
            NewSessionConfirmPanel.Hide();
            GnConfirmPnl.Hide();
            EndSessionConfirmPanel.Hide();
            InventoryPanel.Hide();
            NsRFID.Text = "RFID";
            Dashport.Close();

        }

        //Machine Registry Button
        private void btnMachineRegistry_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnMachineRegistry.Height;
            PnlNav.Top = btnMachineRegistry.Top;
            PnlNav.Left = btnMachineRegistry.Left;
            btnMachineRegistry.BackColor = Color.FromArgb(0, 139, 139);
            btnNewSession.BackColor = Color.FromArgb(0, 128, 128);
            btnHistory.BackColor = Color.FromArgb(0, 128, 128);
            btnDashboard.BackColor = Color.FromArgb(0, 128, 128);
            btnMaintenance.BackColor = Color.FromArgb(0, 128, 128);
            btnUsers.BackColor = Color.FromArgb(0, 128, 128);
            button16.BackColor = Color.FromArgb(0, 128, 128);
            MachineRegistryPanel.Show();
            NewSessionPanel.Hide();
            HistoryPanel.Hide();
            DashboardStatus.Hide();
            DashboardLabel.Hide();
            DashboardNotifications.Hide();
            DashboardEndSession.Hide();
            MaintenanceReportPanel.Hide();
            MaintenanceSchedulePanel.Hide();
            UserPanel.Hide();
            DashboardDate.Hide();
            DashboardTime.Hide();
            NewSessionConfirmPanel.Hide();
            //MachineRegistryConfirmPanel.Hide();
            GnConfirmPnl.Hide();
            checkBox2.Checked = false;
            RegisterMachineButton.Enabled = false;
            EndSessionConfirmPanel.Hide();
            InventoryPanel.Hide();
            MrRFID.Text = "RFID";
            Dashport.Close();
        }

        //Maintenance Button
        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            MaintenanceDatePicker.MinDate = DateTime.Today;
            PnlNav.Height = btnMaintenance.Height;
            PnlNav.Top = btnMaintenance.Top;
            PnlNav.Left = btnMaintenance.Left;
            btnMaintenance.BackColor = Color.FromArgb(0, 139, 139);
            btnMachineRegistry.BackColor = Color.FromArgb(0, 128, 128);
            btnNewSession.BackColor = Color.FromArgb(0, 128, 128);
            btnHistory.BackColor = Color.FromArgb(0, 128, 128);
            btnDashboard.BackColor = Color.FromArgb(0, 128, 128);
            btnUsers.BackColor = Color.FromArgb(0, 128, 128);
            button16.BackColor = Color.FromArgb(0, 128, 128);
            MaintenanceSchedulePanel.Show();
            MaintenanceReportPanel.Show();
            MachineRegistryPanel.Hide();
            HistoryPanel.Hide();
            DashboardStatus.Hide();
            DashboardLabel.Hide();
            DashboardNotifications.Hide();
            DashboardEndSession.Hide();
            UserPanel.Hide();
            DashboardDate.Hide();
            DashboardTime.Hide();
            NewSessionPanel.Hide();
            NewSessionConfirmPanel.Hide();
            GnConfirmPnl.Hide();
            EndSessionConfirmPanel.Hide();
            InventoryPanel.Hide();
            Dashport.Close();

        }

        //Users Buttonm
        private void btnUsers_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnUsers.Height;
            PnlNav.Top = btnUsers.Top;
            PnlNav.Left = btnUsers.Left;
            btnUsers.BackColor = Color.FromArgb(0, 139, 139);
            btnHistory.BackColor = Color.FromArgb(0, 128, 128);
            btnDashboard.BackColor = Color.FromArgb(0, 128, 128);
            btnMachineRegistry.BackColor = Color.FromArgb(0, 128, 128);
            btnNewSession.BackColor = Color.FromArgb(0, 128, 128);
            btnMaintenance.BackColor = Color.FromArgb(0, 128, 128);
            button16.BackColor = Color.FromArgb(0, 128, 128);
            UserPanel.Show();
            InventoryPanel.Hide();
            MaintenanceSchedulePanel.Hide();
            MaintenanceReportPanel.Hide();
            MachineRegistryPanel.Hide();
            HistoryPanel.Hide();
            DashboardStatus.Hide();
            DashboardLabel.Hide();
            DashboardNotifications.Hide();
            DashboardEndSession.Hide();
            DashboardDate.Hide();
            DashboardTime.Hide();
            NewSessionPanel.Hide();
            NewSessionConfirmPanel.Hide();
            GnConfirmPnl.Hide();
            EndSessionConfirmPanel.Hide();
            Dashport.Close();
        }

        //Walang ginagawa to
        private void DashboardDate_Click(object sender, EventArgs e)
        {

        }

        //Walang ginagawa to
        private void DashboardTime_Click(object sender, EventArgs e)
        {

        }

        //Walang ginagawa to
        private void DashboardLabel_Click(object sender, EventArgs e)
        {

        }

        //Walang ginagawa to
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Logout Button
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
               
                Dashport.Close();
                if (MessageBox.Show("Are you sure want to Log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DataVar.notification = "User "+ username1.Text +" logged out at ";
                    con.Open();
                    NotificationUpdate();
                    con.Close();
                    Initializer f3 = new Initializer();
                    this.Hide();
                    f3.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        //View Machine Button
        private void button7_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            VMRFID.Text = "RFID";
            MShifter.Text = "SHIFT4";
            Dashport.PortName = RFID.PORT;
            Dashport.BaudRate = (9600);
            Dashport.Open();
            btnDashboard.Enabled = false;
            btnHistory.Enabled = false;
            btnMachineRegistry.Enabled = false;
            btnMaintenance.Enabled = false;
            btnNewSession.Enabled = false;
            btnUsers.Enabled = false;
            btnLogout.Enabled = false;
            MaintenanceReportPanel.Enabled = false;
            MaintenanceSchedulePanel.Enabled = false;
            pictureBox6.Show();
            label33.Show();
            label35.Hide();
            comboBox5.Hide();
            button5.Hide();
            GnConfirmPnl.Show();
        }

        //Maintenance Logs Button
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashport.Close();
            MLRFID.Text = "RFID";
            MShifter.Text = "SHIFT3";
            Dashport.PortName = RFID.PORT;
            Dashport.BaudRate = (9600);
            Dashport.Open();
            btnDashboard.Enabled = false;
            btnHistory.Enabled = false;
            btnMachineRegistry.Enabled = false;
            btnMaintenance.Enabled = false;
            btnNewSession.Enabled = false;
            btnUsers.Enabled = false;
            btnLogout.Enabled = false;
            MaintenanceReportPanel.Enabled = false;
            MaintenanceSchedulePanel.Enabled = false;
            pictureBox6.Show();
            label33.Show();
            label35.Hide();
            comboBox5.Hide();
            button5.Hide();
            GnConfirmPnl.Show();
        }

        //Time&Date
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            DashboardTime.Text = datetime.ToString("hh:mm tt");
            DashboardDate.Text = datetime.ToString("MM/d/yyyy");




        }

        //Textbox Stuffs
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //Textbox Stuffs
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //Textbox Stuffs
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //Textbox Stuffs
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //Textbox Stuffs
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //Textbox Stuffs
        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }

        }
        //Textbox Stuffs
        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //Textbox Stuffs
        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //Textbox Stuffs
        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //Textbox Stuffs
        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //Textbox Stuffs
        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //Textbox Stuffs
        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                button6.PerformClick();
                e.SuppressKeyPress = true;
            }
        }









        //Submit Report Button
        private void button6_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            SRRFID.Text = "RFID";
            MShifter.Text = "SHIFT1";
            Dashport.PortName = RFID.PORT;
            Dashport.BaudRate = (9600);
            Dashport.Open();
            btnDashboard.Enabled = false;
            btnHistory.Enabled = false;
            btnMachineRegistry.Enabled = false;
            btnMaintenance.Enabled = false;
            btnNewSession.Enabled = false;
            btnUsers.Enabled = false;
            btnLogout.Enabled = false;
            MaintenanceReportPanel.Enabled = false;
            MaintenanceSchedulePanel.Enabled = false;
            pictureBox6.Show();
            label33.Show();
            label35.Hide();
            comboBox5.Hide();
            button5.Hide();
            GnConfirmPnl.Show();
        }



        public TextBox tb1;

        //New Session Button
        

        //New Session T&C Checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                NewSessionButton.Enabled = false;
            }
            if (checkBox1.Checked == true)
            {
                NewSessionButton.Enabled = true;
            }
        }

        //Back Button
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            NSFirstName.Enabled = true;
            NsLastName.Enabled = true;
            //NsMachine.Enabled = true;
            NsProjDes.Enabled = true;
            NsProjNum.Enabled = true;
            btnDashboard.Enabled = true;
            btnHistory.Enabled = true;
            btnMachineRegistry.Enabled = true;
            btnMaintenance.Enabled = true;
            btnNewSession.Enabled = true;
            btnUsers.Enabled = true;
            btnLogout.Enabled = true;
            NsIDNumber.Enabled = true;
            checkBox1.Enabled = true;
            NewSessionConfirmPanel.Hide();

        }

        //Walang ginagawa to
        private void NewSessionConfirmPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        //RFID Scan for New Session
        private void NsRFID_TextChanged(object sender, EventArgs e)
        {
            if (DataVar.MachineCond == "Out of Order" || DataVar.MachineCond == "Under Maintenance")
            {

                MessageBox.Show("This machine is '" + DataVar.MachineCond + "'", "Granting Session Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NSFirstName.Enabled = true;
                NsLastName.Enabled = true;
                //NsMachine.Enabled = true;
                NsProjDes.Enabled = true;
                NsProjNum.Enabled = true;
                btnDashboard.Enabled = true;
                btnHistory.Enabled = true;
                btnMachineRegistry.Enabled = true;
                btnMaintenance.Enabled = true;
                btnNewSession.Enabled = true;
                btnUsers.Enabled = true;
                btnLogout.Enabled = true;
                NsIDNumber.Enabled = true;
                checkBox1.Enabled = true;
                NsRFID.Text = "RFID";
                GRFID.Text = "RFID";
                NewSessionConfirmPanel.Hide();



            }
            else
            {
               
            }

        }

        //Machine Registry T&C Checkbox1
        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                checkBox3.Enabled = false;
                checkBox3.Checked = false;
            }
            if (checkBox2.Checked == true)
            {
                checkBox3.Enabled = true;

            }
        }


        //Machine Registry T&C Checkbox2
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {

                RegisterMachineButton.Enabled = false;
            }
            if (checkBox3.Checked == true)
            {
                RegisterMachineButton.Enabled = true;
            }
        }

        //Walang ginagawa to
        private void NewSessionConfirmPanel_VisibleChanged(object sender, EventArgs e)
        {

        }

        //Register Machine Button
        private void RegisterMachineButton_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            try
            {
                MrRFID.Text = "RFID";
                Dashport.PortName = RFID.PORT;
                Dashport.BaudRate = (9600);
                Dashport.Open();
                MrMachineName.Enabled = false;
                checkBox2.Enabled = false;
                checkBox2.Checked = false;
                MrProduct.Enabled = false;
                MrBrand.Enabled = false;
                MrModel.Enabled = false;
                MrSerialNumber.Enabled = false;
                MrDateAcquired.Enabled = false;
                MrInitialCond.Enabled = false;
                btnDashboard.Enabled = false;
                btnHistory.Enabled = false;
                btnMachineRegistry.Enabled = false;
                btnMaintenance.Enabled = false;
                btnNewSession.Enabled = false;
                btnUsers.Enabled = false;
                btnLogout.Enabled = false;

                //MachineRegistryConfirmPanel.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //RFID scan for Machine Registry
        private void MrRFID_TextChanged(object sender, EventArgs e)
        {

            if (MrRFID.Text == "02 EC 8F 34")
            {
                if (MessageBox.Show("You cant use this card to Register the Machine, Please user another Card", "Custodian's Card Detected", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    MrRFID.Text = "RFID";
                    MrMachineName.Enabled = true;
                    MrBrand.Enabled = true;
                    MrProduct.Enabled = true;
                    MrModel.Enabled = true;
                    MrSerialNumber.Enabled = true;
                    MrDateAcquired.Enabled = true;
                    MrInitialCond.Enabled = true;
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    checkBox2.Enabled = true;
                    //MachineRegistryConfirmPanel.Hide();


                }

            }

            if (MrRFID.Text != "02 EC 8F 34" && MrRFID.Text != "RFID")
            {
                if (MessageBox.Show("Are you sure you want to use this card for this machine? Note (You can't use this card to register other Machines)", "You used an Unregistered Card", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        string mrcheck = "SELECT * FROM tbl_MachineRegistry WHERE Machine_RFID= '" + MrRFID.Text + "'";
                        cmd = new OleDbCommand(mrcheck, con);
                        OleDbDataReader dr = cmd.ExecuteReader();

                        if (dr.Read() == true)
                        {
                            con.Close();
                            MessageBox.Show("RFID is already taken", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            con.Close();
                            if (MrMachineName.Text == "" && MrProduct.Text == "" && MrModel.Text == "" && MrSerialNumber.Text == "")
                            {
                                MessageBox.Show("Important fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                MessageBox.Show("This machine is now linked to this RFID card", "Machine Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con.Open();

                                MREPCOND.Text = "Available";
                                string mrregister = "INSERT INTO tbl_MachineRegistry Values('" + MrRFID.Text + "', '" + MrMachineName.Text + "', '" + MrProduct.Text + "', '" + MrBrand.Text + "', '" + MrModel.Text + "', '" + MrSerialNumber.Text + "', '" + MrDateAcquired.Value.ToShortDateString() + "', '" + MrInitialCond.Text + "', '" + MREPCOND.Text + "', '" + username1.Text + "','" + DateTime.Now + "')";
                                cmd = new OleDbCommand(mrregister, con);
                                cmd.ExecuteNonQuery();
                                fillnsMachine();
                                con.Close();
                                //this.tbl_MachineRegistryTableAdapter.Fill(this.db_psDataSet.tbl_MachineRegistry);
                                dataGridView4.Refresh();
                                dataGridView4.Update();
                                //NotificationTextBox.Text += "Machine " + MrMachineName.Text + " is registered at " + DateTime.Now + Environment.NewLine;
                                DataVar.notification = "Machine " + MrMachineName.Text + " is registered at ";
                                con.Open();
                                NotificationUpdate();
                                NotificationRefresh();
                                con.Close();
                            }




                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    MREPCOND.Text = "";
                    MrMachineName.Text = "";
                    MrBrand.Text = "";
                    MrProduct.Text = "";
                    MrModel.Text = "";
                    MrSerialNumber.Text = "";
                    MrDateAcquired.Text = "";
                    MrInitialCond.Text = "";
                    MrRFID.Text = "RFID";
                    MrMachineName.Enabled = true;
                    MrProduct.Enabled = true;
                    MrProduct.Enabled = true;
                    MrBrand.Enabled = true;
                    MrModel.Enabled = true;
                    MrSerialNumber.Enabled = true;
                    MrDateAcquired.Enabled = true;
                    MrInitialCond.Enabled = true;
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    checkBox2.Enabled = true;
                    //MachineRegistryConfirmPanel.Hide();
                }
                else
                {
                    MrRFID.Text = "RFID";
                    MrMachineName.Enabled = true;
                    MrProduct.Enabled = true;
                    MrProduct.Enabled = true;
                    MrBrand.Enabled = true;
                    MrModel.Enabled = true;
                    MrSerialNumber.Enabled = true;
                    MrDateAcquired.Enabled = true;
                    MrInitialCond.Enabled = true;
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    checkBox2.Enabled = true;
                    //MachineRegistryConfirmPanel.Hide();
                }

            }
        }

        //Set Maintenance Schedule Button
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && comboBox3.Text != "")
            {


                DataVar.msdate = MaintenanceDatePicker.Value.ToShortDateString();


                Dashport.Close();
                SMRFID.Text = "RFID";
                MShifter.Text = "SHIFT2";
                Dashport.PortName = RFID.PORT;
                Dashport.BaudRate = (9600);
                Dashport.Open();




                pictureBox6.Show();
                label33.Show();
                label35.Hide();
                comboBox5.Hide();
                button5.Hide();
                btnDashboard.Enabled = false;
                btnHistory.Enabled = false;
                btnMachineRegistry.Enabled = false;
                btnMaintenance.Enabled = false;
                btnNewSession.Enabled = false;
                btnUsers.Enabled = false;
                btnLogout.Enabled = false;
                MaintenanceReportPanel.Enabled = false;
                MaintenanceSchedulePanel.Enabled = false;
                GnConfirmPnl.Show();
            }
            else
            {
                MessageBox.Show("Important Fields are Invalid", "Maintenance Schedule not Set", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //General Back Button
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            MrMachineName.Enabled = true;
            MrBrand.Enabled = true;
            MrProduct.Enabled = true;
            MrModel.Enabled = true;
            MrSerialNumber.Enabled = true;
            MrDateAcquired.Enabled = true;
            MrInitialCond.Enabled = true;
            btnDashboard.Enabled = true;
            btnHistory.Enabled = true;
            btnMachineRegistry.Enabled = true;
            btnMaintenance.Enabled = true;
            btnNewSession.Enabled = true;
            btnUsers.Enabled = true;
            btnLogout.Enabled = true;
            checkBox2.Enabled = true;
            //MachineRegistryConfirmPanel.Hide();
        }

        //End Session Button
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            EsRFID.Text = "RFID";
            btnDashboard.Enabled = true;
            btnHistory.Enabled = true;
            btnMachineRegistry.Enabled = true;
            btnMaintenance.Enabled = true;
            btnNewSession.Enabled = true;
            btnUsers.Enabled = true;
            btnLogout.Enabled = true;
            TimeOutbtn.Enabled = true;
            dataGridView3.Enabled = true;
            dataGridView4.Enabled = true;
            EndSessionConfirmPanel.Hide();
        }

        //fetch data from the status database
        private void fetchdata()
        {
            string rf = "SELECT * FROM tbl_status where MachineName = '" + comboBox1.Text + "'";
            cmd = new OleDbCommand(rf, con);
            OleDbDataReader rrf = cmd.ExecuteReader();
            while (rrf.Read())
            {
                DataVar.ESMachineRFID = rrf["Machine_RFID"].ToString();
                DataVar.ESMachineName = rrf["MachineName"].ToString();
                DataVar.ESStudentLastname = rrf["StudentLastName"].ToString();
                DataVar.ESStudentFirstname = rrf["StudentFirstName"].ToString();
                DataVar.ESStudentIDNum = rrf["StudentIDNumber"].ToString();
                DataVar.ESTimeDate = rrf["Time&DateIn"].ToString();
                DataVar.ESAuthenticatedBy = rrf["AuthenticatedBy"].ToString();
                DataVar.ESPROJNUM = rrf["ProjectNumber"].ToString();
                DataVar.ESPROJDES = rrf["ProjectDescription"].ToString();

            }
        }

        //takes the fetchdata from status and transfers to history
        private void esfetchdata()
        {
            string rf = "SELECT * FROM tbl_status where Machine_RFID = '" + EsRFID.Text + "'";
            cmd = new OleDbCommand(rf, con);
            OleDbDataReader rrf = cmd.ExecuteReader();
            while (rrf.Read())
            {
                DataVar.ESMachineRFID = rrf["Machine_RFID"].ToString();
                DataVar.ESMachineName = rrf["MachineName"].ToString();
                DataVar.ESStudentLastname = rrf["StudentLastName"].ToString();
                DataVar.ESStudentFirstname = rrf["StudentFirstName"].ToString();
                DataVar.ESStudentIDNum = rrf["StudentIDNumber"].ToString();
                DataVar.ESTimeDate = rrf["Time&DateIn"].ToString();
                DataVar.ESAuthenticatedBy = rrf["AuthenticatedBy"].ToString();
                DataVar.ESPROJNUM = rrf["ProjectNumber"].ToString();
                DataVar.ESPROJDES = rrf["ProjectDescription"].ToString();

            }
        }

        //RFID scan for End Session
        private void EsRFID_TextChanged(object sender, EventArgs e)
        {
            if (EsRFID.Text == "02 EC 8F 34")
            {
                if (MessageBox.Show("Would you like to Force End a session?", "Custodian's Card Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    con.Open();
                    statfill();
                    pictureBox8.Hide();
                    label4.Hide();
                    label34.Show();
                    comboBox1.Show();
                    button2.Show();
                    con.Close();

                }
                else
                {
                    EsRFID.Text = "RFID";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    TimeOutbtn.Enabled = true;
                    dataGridView3.Enabled = true;
                    dataGridView4.Enabled = true;
                    EndSessionConfirmPanel.Hide();
                }
            }



            if (EsRFID.Text != "02 EC 8F 34" && EsRFID.Text != "RFID")
            {
                con.Open();

                esfetchdata();
                string mchcheck = "SELECT * FROM tbl_status WHERE Machine_RFID= '" + EsRFID.Text + "'";
                cmd = new OleDbCommand(mchcheck, con);
                OleDbDataReader nsm = cmd.ExecuteReader();
                if (nsm.Read() == true)
                {


                    string endsession = "INSERT INTO tbl_History Values('" + DataVar.ESMachineRFID + "', '" + DataVar.ESMachineName + "', '" + DataVar.ESStudentLastname + "', '" + DataVar.ESStudentFirstname + "', '" + DataVar.ESStudentIDNum + "', '" + DataVar.ESTimeDate + "', '" + DateTime.Now + "', '" + DataVar.ESAuthenticatedBy + "', '" + DataVar.ESPROJNUM + "', '" + DataVar.ESPROJDES + "')";
                    cmd = new OleDbCommand(endsession, con);
                    cmd.ExecuteNonQuery();


                    string eshcheck = "DELETE FROM tbl_status WHERE Machine_RFID= '" + EsRFID.Text + "'";
                    cmd = new OleDbCommand(eshcheck, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();

                    string mcheck = "SELECT * FROM tbl_MachineRegistry WHERE Machine_RFID= '" + EsRFID.Text + "'";
                    cmd = new OleDbCommand(mcheck, con);
                    OleDbDataReader ngm = cmd.ExecuteReader();
                    while (ngm.Read())
                    {
                        DataVar.MachineCond = ngm["MachineCondition"].ToString();
                    }
                    if (DataVar.MachineCond == "In Use")
                    {
                        MREPCOND.Text = "Available";
                        string mrupdate = "update tbl_MachineRegistry set MachineCondition = '" + MREPCOND.Text + "' where Machine_RFID='" + EsRFID.Text + "'";
                        cmd = new OleDbCommand(mrupdate, con);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        DataVar.MachineCond = "Under Maintenance";
                        string mrupdate = "update tbl_MachineRegistry set MachineCondition = '" + DataVar.MachineCond + "' where Machine_RFID='" + EsRFID.Text + "'";
                        cmd = new OleDbCommand(mrupdate, con);
                        cmd.ExecuteNonQuery();
                    }







                    con.Close();
                    dataGridView2.Refresh();
                    dataGridView2.Update();
                    dataGridView3.Refresh();
                    dataGridView3.Update();
                    dataGridView4.Refresh();
                    dataGridView4.Update();
                    
                    DataVar.notification = "Machine " + DataVar.ESMachineName + " Ended its session at ";
                    con.Open();
                    NotificationUpdate();
                    NotificationRefresh();
                    con.Close();

                    MessageBox.Show("This machine is now Available for a New Session", "Session Ended", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    EsRFID.Text = "RFID";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    TimeOutbtn.Enabled = true;
                    dataGridView3.Enabled = true;
                    dataGridView4.Enabled = true;
                    EndSessionConfirmPanel.Hide();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Make sure you Tap a card in Session", "Card is not in Session", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    EsRFID.Text = "RFID";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    TimeOutbtn.Enabled = true;
                    dataGridView3.Enabled = true;
                    dataGridView4.Enabled = true;
                    EndSessionConfirmPanel.Hide();
                }
            }
        }

        //Force End Button
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                con.Open();
                fetchdata();

                string endsession = "INSERT INTO tbl_History Values('" + DataVar.ESMachineRFID + "', '" + DataVar.ESMachineName + "', '" + DataVar.ESStudentLastname + "', '" + DataVar.ESStudentFirstname + "', '" + DataVar.ESStudentIDNum + "', '" + DataVar.ESTimeDate + "', '" + DateTime.Now + "', '" + DataVar.ESAuthenticatedBy + "', '" + DataVar.ESPROJNUM + "', '" + DataVar.ESPROJDES + "')";
                cmd = new OleDbCommand(endsession, con);
                cmd.ExecuteNonQuery();


                string eshcheck = "DELETE FROM tbl_status WHERE MachineName= '" + comboBox1.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();

                MREPCOND.Text = "Available";
                string mrupdate = "update tbl_MachineRegistry set MachineCondition = '" + MREPCOND.Text + "' where MachineName='" + comboBox1.Text + "'";
                cmd = new OleDbCommand(mrupdate, con);
                cmd.ExecuteNonQuery();






                con.Close();
                dataGridView2.Refresh();
                dataGridView2.Update();
                dataGridView3.Refresh();
                dataGridView3.Update();
                dataGridView4.Refresh();
                dataGridView4.Update();
                
                DataVar.notification = "Machine " + comboBox1.Text + " Force Ended its session at ";
                con.Open();
                NotificationUpdate();
                NotificationRefresh();
                con.Close();
                comboBox1.Items.Clear();
                EsRFID.Text = "RFID";
                btnDashboard.Enabled = true;
                btnHistory.Enabled = true;
                btnMachineRegistry.Enabled = true;
                btnMaintenance.Enabled = true;
                btnNewSession.Enabled = true;
                btnUsers.Enabled = true;
                btnLogout.Enabled = true;
                TimeOutbtn.Enabled = true;
                dataGridView3.Enabled = true;
                dataGridView4.Enabled = true;
                EndSessionConfirmPanel.Hide();
            }

        }

        //End Session Button
        private void TimeOutbtn_Click(object sender, EventArgs e)
        {
           
            Dashport.Close();
            EsRFID.Text = "RFID";
            Dashport.PortName = RFID.PORT;
            Dashport.BaudRate = (9600);
            Dashport.Open();
            btnDashboard.Enabled = false;
            btnHistory.Enabled = false;
            btnMachineRegistry.Enabled = false;
            btnMaintenance.Enabled = false;
            btnNewSession.Enabled = false;
            btnUsers.Enabled = false;
            btnLogout.Enabled = false;
            TimeOutbtn.Enabled = false;
            dataGridView3.Enabled = false;
            dataGridView4.Enabled = false;
            pictureBox8.Show();
            label4.Show();
            label34.Hide();
            comboBox1.Hide();
            button2.Hide();
            EndSessionConfirmPanel.Show();
        }

        //Save PDF History Button
        private void button8_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            SPDF1RFID.Text = "RFID";
            Dashport.PortName = RFID.PORT;
            Dashport.BaudRate = (9600);
            Dashport.Open();
            btnDashboard.Enabled = false;
            btnHistory.Enabled = false;
            btnMachineRegistry.Enabled = false;
            btnMaintenance.Enabled = false;
            btnNewSession.Enabled = false;
            btnUsers.Enabled = false;
            btnLogout.Enabled = false;
            HistoryPanel.Enabled = false;
            pictureBox6.Show();
            label33.Show();
            label35.Hide();
            comboBox5.Hide();
            button5.Hide();
            GnConfirmPnl.Show();
        }

        //Submit Report RFID scan
        private void SRRFID_TextChanged(object sender, EventArgs e)
        {
            if (SRRFID.Text == "02 EC 8F 34")
            {
                try
                {
                    con.Open();
                    string mrcheck = "SELECT * FROM tbl_MachineRegistry WHERE MachineName= '" + comboBox4.Text + "'";
                    cmd = new OleDbCommand(mrcheck, con);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read() == true)
                    {

                       


                        string mrscheck = "SELECT * FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                        cmd = new OleDbCommand(mrscheck, con);
                        OleDbDataReader drs = cmd.ExecuteReader();
                        if (drs.Read() == true)
                        {
                            if (MREPCOND.Text == "Available" || MREPCOND.Text == "Out of Order")
                            {
                                if(comboBox8.Text == "Scheduled")
                                {
                                    string mrupdate = "update tbl_MachineRegistry set MachineCondition = '" + MREPCOND.Text + "' where MachineName='" + comboBox4.Text + "'";
                                    cmd = new OleDbCommand(mrupdate, con);
                                    cmd.ExecuteNonQuery();
                                

                                    string mrs1check = "SELECT * FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                                    cmd = new OleDbCommand(mrs1check, con);
                                    OleDbDataReader dr1 = cmd.ExecuteReader();
                                    while (dr1.Read())
                                    {
                                        DataVar.DataFreq = dr1["MaintenanceFrequency"].ToString();
                                        DataVar.OrigDate = dr1["EffectiveBy"].ToString();

                                        MaintenanceDateUpdate();
                                    }

                                    string mrregister = "INSERT INTO tbl_MaintenanceLogs Values('" + comboBox4.Text + "','" + username1.Text + "','" + MREPCOND.Text + "','" + comboBox8.Text + "', '" + textBox14.Text + "','" + DateTime.Now + "')";
                                    cmd = new OleDbCommand(mrregister, con);
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("This machine's condition has been updated. You may check the Maintenance Logs review your entry.", "Maintenance Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    

                                }
                                if (comboBox8.Text == "Breakdown")
                                {

                                    string mrs1check = "SELECT * FROM tbl_MachineRegistry WHERE MachineName= '" + comboBox4.Text + "'";
                                    cmd = new OleDbCommand(mrs1check, con);
                                    OleDbDataReader dr1 = cmd.ExecuteReader();
                                    while (dr1.Read())
                                    {
                                        DataVar.mrMachineCond = dr1["MachineCondition"].ToString();
                                    }

                                   

                                    if (DataVar.mrMachineCond == "Under Maintenance")
                                    {
                                        string mrupdate = "update tbl_MachineRegistry set MachineCondition = '" + DataVar.msaActiveTime + "' where MachineName='" + comboBox4.Text + "'";
                                        cmd = new OleDbCommand(mrupdate, con);
                                        cmd.ExecuteNonQuery();
                                        

                                        DataVar.msaActiveTime = "Under Maintenance";
                                        string mrregister = "INSERT INTO tbl_MaintenanceLogs Values('" + comboBox4.Text + "','" + username1.Text + "','" + DataVar.msaActiveTime + "','" + comboBox8.Text + "', '" + textBox14.Text + "','" + DateTime.Now + "')";
                                        cmd = new OleDbCommand(mrregister, con);
                                        cmd.ExecuteNonQuery();

                                        MessageBox.Show("This machine's condition has been updated. You may check the Maintenance Logs review your entry.", "Maintenance Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }

                                    if (DataVar.mrMachineCond == "Available" || DataVar.mrMachineCond == "Out of Order")
                                    {
                                        string mrregister = "INSERT INTO tbl_MaintenanceLogs Values('" + comboBox4.Text + "','" + username1.Text + "','" + MREPCOND.Text + "','" + comboBox8.Text + "', '" + textBox14.Text + "','" + DateTime.Now + "')";
                                        cmd = new OleDbCommand(mrregister, con);
                                        cmd.ExecuteNonQuery();

                                        MessageBox.Show("This machine's condition has been updated. You may check the Maintenance Logs review your entry.", "Maintenance Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }


                                }


                            }
                            if (MREPCOND.Text == "Decommissioned")
                            {

                                string mrupdate = "update tbl_MachineRegistry set MachineCondition = '" + MREPCOND.Text + "' where MachineName='" + comboBox4.Text + "'";
                                cmd = new OleDbCommand(mrupdate, con);
                                cmd.ExecuteNonQuery();

                                string mrregister = "INSERT INTO tbl_MaintenanceLogs Values('" + comboBox4.Text + "','" + username1.Text + "','" + MREPCOND.Text + "','" + comboBox8.Text + "', '" + textBox14.Text + "','" + DateTime.Now + "')";
                                cmd = new OleDbCommand(mrregister, con);
                                cmd.ExecuteNonQuery();

                                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                                cmd = new OleDbCommand(eshcheck, con);
                                cmd.ExecuteNonQuery();

                                Graveyardshift();

                                string gregister = "INSERT INTO tbl_DecomMachine Values('" + DataVar.GSMachRFID + "','" + DataVar.GSMachName + "','" + DataVar.GSProductType + "','" + DataVar.GSBrand + "','" + DataVar.GSModel + "','" + DataVar.GSSerialNumber + "','" + DataVar.GSDateAcquired + "','" + DataVar.GSInitialConditionofMachine + "','" + MREPCOND.Text + "','" + DataVar.GSRegisteredBy + "','" + DataVar.GSDateofRegistration + "','" + DateTime.Now + "')";
                                cmd = new OleDbCommand(gregister, con);
                                cmd.ExecuteNonQuery();

                                string mchdel = "DELETE FROM tbl_MachineRegistry WHERE MachineName= '" + comboBox4.Text + "'";
                                cmd = new OleDbCommand(mchdel, con);
                                cmd.ExecuteNonQuery();


                                MessageBox.Show("This machine's condition has been updated. You may check the Maintenance Logs review your entry.", "Maintenance Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fillnsMachine();
                            }


                        }

                        DataVar.notification = "Machine " + comboBox4.Text + " Condition has been Updated at ";

                        
                        NotificationUpdate();
                        NotificationRefresh();
                        con.Close();

                        dataGridView4.Update();
                        dataGridView4.Refresh();
                        dataGridView5.Update();
                        dataGridView5.Refresh();

                        DataVar.mrMachineCond = "";
                        DataVar.msaActiveTime = "";
                        SRRFID.Text = "RFID";
                        MShifter.Text = "SHIFT";
                        textBox14.Text = "";
                        btnDashboard.Enabled = true;
                        btnHistory.Enabled = true;
                        btnMachineRegistry.Enabled = true;
                        btnMaintenance.Enabled = true;
                        btnNewSession.Enabled = true;
                        btnUsers.Enabled = true;
                        btnLogout.Enabled = true;
                        MaintenanceReportPanel.Enabled = true;
                        MaintenanceSchedulePanel.Enabled = true;
                        GnConfirmPnl.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                

                if (SRRFID.Text != "02 EC 8F 34" && SRRFID.Text != "RFID")
                {
                    MessageBox.Show("Make sure you Tap a Custodian's Card", "Non-Custodian Card Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    SRRFID.Text = "RFID";
                    MShifter.Text = "SHIFT";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    MaintenanceReportPanel.Enabled = true;
                    MaintenanceSchedulePanel.Enabled = true;
                    GnConfirmPnl.Hide();

                }
            }
        }


        //Fetch data of Decommissioned Machine
        private void Graveyardshift()
        {
            string rf = "SELECT * FROM tbl_MachineRegistry where MachineName = '" + comboBox4.Text + "'";
            cmd = new OleDbCommand(rf, con);
            OleDbDataReader rrf = cmd.ExecuteReader();
            while (rrf.Read())
            {
                DataVar.GSMachRFID = rrf["Machine_RFID"].ToString();
                DataVar.GSMachName = rrf["MachineName"].ToString();
                DataVar.GSProductType = rrf["ProductType"].ToString();
                DataVar.GSBrand = rrf["Brand"].ToString();
                DataVar.GSModel = rrf["Model/Model_Number"].ToString();
                DataVar.GSSerialNumber = rrf["SerialNumber"].ToString();
                DataVar.GSDateAcquired = rrf["DateAcquired"].ToString();
                DataVar.GSInitialConditionofMachine = rrf["InitialConditionofMachine"].ToString();
                DataVar.GSRegisteredBy = rrf["RegisteredBy"].ToString();
                DataVar.GSDateofRegistration = rrf["DateofRegistration"].ToString();

            }
        }

        //Updates the Maintenance Frequency
        private void MaintenanceDateUpdate()
        {
            if (DataVar.DataFreq == "Once")
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
            }
            if (DataVar.DataFreq == "Daily")
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
                string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox4.Text + "','" + DateTime.Now.AddDays(1) + "', '" + DataVar.DataFreq + "', '" + username1.Text + "', '" + DataVar.OrigDate + "','" + DateTime.Now.AddDays(1).ToShortDateString() + "')";
                cmd = new OleDbCommand(ms, con);
                cmd.ExecuteNonQuery();

            }
            if (DataVar.DataFreq == "Weekly")
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
                string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox4.Text + "','" + DateTime.Now.AddDays(7) + "','" + DataVar.DataFreq + "', '" + username1.Text + "', '" + DataVar.OrigDate + "','" + DateTime.Now.AddDays(7).ToShortDateString() + "')";
                cmd = new OleDbCommand(ms, con);
                cmd.ExecuteNonQuery();

            }
            if (DataVar.DataFreq == "Monthly")
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
                string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox4.Text + "','" + DateTime.Now.AddMonths(1) + "', '" + DataVar.DataFreq + "', '" + username1.Text + "', '" + DataVar.OrigDate + "','" + DateTime.Now.AddMonths(1).ToShortDateString() + "')";
                cmd = new OleDbCommand(ms, con);
                cmd.ExecuteNonQuery();

            }
            if (DataVar.DataFreq == "Bi-Monthly")
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
                string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox4.Text + "','" + DateTime.Now.AddMonths(2) + "', '" + DataVar.DataFreq + "', '" + username1.Text + "', '" + DataVar.OrigDate + "','" + DateTime.Now.AddMonths(2).ToShortDateString() + "')";
                cmd = new OleDbCommand(ms, con);
                cmd.ExecuteNonQuery();

            }
            if (DataVar.DataFreq == "Quarterly")
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
                string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox4.Text + "','" + DateTime.Now.AddMonths(3) + "', '" + DataVar.DataFreq + "', '" + username1.Text + "', '" + DataVar.OrigDate + "','" + DateTime.Now.AddMonths(3).ToShortDateString() + "')";
                cmd = new OleDbCommand(ms, con);
                cmd.ExecuteNonQuery();

            }
            if (DataVar.DataFreq == "Semi-Annually")
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
                string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox4.Text + "','" + DateTime.Now.AddMonths(6) + "', '" + DataVar.DataFreq + "', '" + username1.Text + "', '" + DataVar.OrigDate + "','" + DateTime.Now.AddMonths(6).ToShortDateString() + "')";
                cmd = new OleDbCommand(ms, con);
                cmd.ExecuteNonQuery();

            }
            if (DataVar.DataFreq == "Annually")
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox4.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
                string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox4.Text + "','" + DateTime.Now.AddYears(1) + "', '" + DataVar.DataFreq + "', '" + username1.Text + "', '" + DataVar.OrigDate + "','" + DateTime.Now.AddYears(1).ToShortDateString() + "')";
                cmd = new OleDbCommand(ms, con);
                cmd.ExecuteNonQuery();

            }
        }

        //RFID scan for Maintenance Schedule
        private void SMRFID_TextChanged(object sender, EventArgs e)
        {
            if (SMRFID.Text == "02 EC 8F 34")
            {
                con.Open();
                string mchcheck = "SELECT * FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox2.Text + "'";
                cmd = new OleDbCommand(mchcheck, con);
                OleDbDataReader nsm = cmd.ExecuteReader();
                if (nsm.Read() == true)
                {


                    if (MessageBox.Show("This machine already has a Registered Maintenance Schedule. Would you like to Overwrite this schedule?", "Maintenance Schedule not Set", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        string mc2hcheck = "SELECT * FROM tbl_MachineRegistry WHERE MachineName= '" + comboBox2.Text + "'";
                        cmd = new OleDbCommand(mc2hcheck, con);
                        OleDbDataReader nsm2 = cmd.ExecuteReader();
                        while (nsm2.Read())
                        {
                            DataVar.overwritecondition = nsm2["MachineCondition"].ToString();
                        }
                        if (DataVar.overwritecondition == "Under Maintenance")
                        {
                            MessageBox.Show("Cannot overwrite Schedule while the machine is Under Maintenance. Please submit the Maintenance Report before overwriting the schedule.", "Maintenance Schedule cannot be Overwritten", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                        else
                        {
                            string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox2.Text + "'";
                            cmd = new OleDbCommand(eshcheck, con);
                            cmd.ExecuteNonQuery();
                            string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox2.Text + "','" + MaintenanceDatePicker.Value + "', '" + comboBox3.Text + "', '" + username1.Text + "', '" + DateTime.Now + "','" + DataVar.msdate + "')";
                            cmd = new OleDbCommand(ms, con);
                            cmd.ExecuteNonQuery();

                            DataVar.notification = "Machine " + DataVar.msaMachName + " Maintenance Schedule has been Overwritten at ";
                            NotificationUpdate();
                            NotificationRefresh();
                            MaintenanceSchedDateNotif();
                            MaintenanceSchedRefresh();
                            


                            con.Close();
                            dataGridView5.Update();
                            dataGridView5.Refresh();
                            dataGridView4.Refresh();
                            dataGridView4.Update();
                           
                            comboBox2.Text = "";
                            comboBox3.Text = "";
                            SMRFID.Text = "RFID";
                            MShifter.Text = "SHIFT";
                            btnDashboard.Enabled = true;
                            btnHistory.Enabled = true;
                            btnMachineRegistry.Enabled = true;
                            btnMaintenance.Enabled = true;
                            btnNewSession.Enabled = true;
                            btnUsers.Enabled = true;
                            btnLogout.Enabled = true;
                            MaintenanceReportPanel.Enabled = true;
                            MaintenanceSchedulePanel.Enabled = true;
                            GnConfirmPnl.Hide();
                        }
                            
                    }
                    else
                    {
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        SMRFID.Text = "RFID";
                        MShifter.Text = "SHIFT";
                        btnDashboard.Enabled = true;
                        btnHistory.Enabled = true;
                        btnMachineRegistry.Enabled = true;
                        btnMaintenance.Enabled = true;
                        btnNewSession.Enabled = true;
                        btnUsers.Enabled = true;
                        btnLogout.Enabled = true;
                        MaintenanceReportPanel.Enabled = true;
                        MaintenanceSchedulePanel.Enabled = true;
                        GnConfirmPnl.Hide();
                    }

                }
                else
                {

                    string ms = "INSERT INTO tbl_MaintenanceSchedule Values( '" + comboBox2.Text + "','" + MaintenanceDatePicker.Value + "', '" + comboBox3.Text + "', '" + username1.Text + "', '" + DateTime.Now + "','" + DataVar.msdate + "')";
                    cmd = new OleDbCommand(ms, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("You have successfuly Registered a Maintenance Schedule for this Machine " , "Maintenance Schedule Set", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridView5.Update();
                    dataGridView5.Refresh();

                    


                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    SMRFID.Text = "RFID";
                    MShifter.Text = "SHIFT";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    MaintenanceReportPanel.Enabled = true;
                    MaintenanceSchedulePanel.Enabled = true;
                    con.Open();
                    MaintenanceSchedDateNotif();
                    MaintenanceSchedRefresh();
                    con.Close();
                    dataGridView4.Refresh();
                    dataGridView4.Update();
                    
                    GnConfirmPnl.Hide();
                }

            }

            if (SMRFID.Text != "02 EC 8F 34" && SMRFID.Text != "RFID")
            {
                if (MessageBox.Show("Make sure you Tap a Custodian's Card", "Non-Custodian Card Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    SMRFID.Text = "RFID";
                    MShifter.Text = "SHIFT";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    MaintenanceReportPanel.Enabled = true;
                    MaintenanceSchedulePanel.Enabled = true;
                    GnConfirmPnl.Hide();
                }
            }
        }

        //Refresh the Maintenance Schedule Database
        public void MaintenanceSchedRefresh()
        {
            string mdcheck = "SELECT * FROM tbl_MaintenanceSchedule WHERE DateVerification= '" + DateTime.Now.ToShortDateString() + "'";
            cmd = new OleDbCommand(mdcheck, con);
            OleDbDataReader ndm = cmd.ExecuteReader();
            if (ndm.Read() == true)
            {

                

                string rdm = "SELECT * FROM tbl_MaintenanceSchedule where DateVerification= '" + DateTime.Now.ToShortDateString() + "'";
                cmd = new OleDbCommand(rdm, con);
                OleDbDataReader rrdm = cmd.ExecuteReader();
                while (rrdm.Read())
                {
                    DataVar.msaMachName = rrdm["MachineName"].ToString();
                    DataVar.msaActiveTime = "Under Maintenance";
                    DateTime ActivateTime = DateTime.Parse(rrdm["Date&Time"].ToString());
                    int comp = DateTime.Compare(ActivateTime, DateTime.Now);
                    if ( comp <= 0 )
                    {
                        
                        string mrupdate = "update tbl_MachineRegistry set MachineCondition = '" + DataVar.msaActiveTime + "' where MachineName='" + DataVar.msaMachName + "'";
                        cmd = new OleDbCommand(mrupdate, con);
                        cmd.ExecuteNonQuery();
                        //NotificationTextBox.Text += "Machine " + DataVar.msaMachName + " is now " + DataVar.msaActiveTime + ""+Environment.NewLine;
                        if (comp <= 0 && comp>= -1)
                        {
                            DataVar.notification = "Machine " + DataVar.msaMachName + " is now " + DataVar.msaActiveTime + " at ";

                            string mccheck = "SELECT * FROM tbl_EventLogs WHERE Event= '" + DataVar.notification + "'";
                            cmd = new OleDbCommand(mdcheck, con);
                            OleDbDataReader ncm = cmd.ExecuteReader();
                            if (ndm.Read() == true)
                            {
                                DataVar.notification = "";
                            }
                            else
                            {
                                NotificationUpdate();
                                NotificationRefresh();
                            }
                        }
                       
                       

                    }

                }

               
            }
        }

        //Notifies Maintenance Schedule
        public void MaintenanceSchedDateNotif()
        {
            DataVar.msaAdvance = DateTime.Now.AddDays(1).ToShortDateString();
            string mdcheck = "SELECT * FROM tbl_MaintenanceSchedule WHERE DateVerification= '" + DataVar.msaAdvance + "'";
            cmd = new OleDbCommand(mdcheck, con);
            OleDbDataReader ndm = cmd.ExecuteReader();
            if (ndm.Read() == true)
            {
                string rdm = "SELECT * FROM tbl_MaintenanceSchedule where DateVerification= '" + DataVar.msaAdvance + "'";
                cmd = new OleDbCommand(rdm, con);
                OleDbDataReader rrdm = cmd.ExecuteReader();
                while (rrdm.Read())
                {

                    DataVar.msaMachName = rrdm["MachineName"].ToString();

                }
                DataVar.msaActiveTime = DataVar.msatime;

        
                DataVar.notification = "Machine " + DataVar.msaMachName + " is scheduled for maintenance tomorrow at ";
                NotificationUpdate();
                NotificationRefresh();
                return;

            }
        }

        //Basically Display
        private void DashboardDate_TextChanged(object sender, EventArgs e)
        {

            NotificationTextBox.SelectionStart = NotificationTextBox.Text.Length;
            NotificationTextBox.ScrollToCaret();

            if (con.State == ConnectionState.Open)
            {
                MaintenanceSchedDateNotif();
            }
            else
            {
                con.Open();
                MaintenanceSchedDateNotif();
                con.Close();
            }
        }
        //walang ginagawa to
        private void DashboardTime_TextChanged(object sender, EventArgs e)
        {
           
        }
        //RFID scan for History Save to PDF Function
        private void SPDF1RFID_TextChanged(object sender, EventArgs e)
        {
            if (SPDF1RFID.Text == "02 EC 8F 34")
            {
                SaveToPDF(dataGridView2, "LEUMS-History");
                SPDF1RFID.Text = "RFID";
                MShifter.Text = "SHIFT";
                btnDashboard.Enabled = true;
                btnHistory.Enabled = true;
                btnMachineRegistry.Enabled = true;
                btnMaintenance.Enabled = true;
                btnNewSession.Enabled = true;
                btnUsers.Enabled = true;
                btnLogout.Enabled = true;
                HistoryPanel.Enabled = true;
                GnConfirmPnl.Hide();
            }

            if (SPDF1RFID.Text != "02 EC 8F 34" && SPDF1RFID.Text != "RFID")
            {
                MessageBox.Show("Make sure you Tap a Custodian's Card", "Non-Custodian Card Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                    SMRFID.Text = "RFID";
                    SPDF1RFID.Text = "RFID";
                    MShifter.Text = "SHIFT";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    HistoryPanel.Enabled = true;
                    GnConfirmPnl.Hide();
                
            }
        }

        //Save to PDF function
        private void SaveToPDF(DataGridView dgrid, string Filename)
        {
            if (dgrid.Rows.Count > 0)
            {

                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable htable = new PdfPTable(dgrid.Columns.Count);
                htable.DefaultCell.Padding = 3;
                htable.WidthPercentage = 100;
                htable.HorizontalAlignment = Element.ALIGN_LEFT;
                htable.DefaultCell.BorderWidth = 1;

                iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                foreach (DataGridViewColumn col in dgrid.Columns)
                {
                    PdfPCell hcell = new PdfPCell(new Phrase(col.HeaderText, text));
                    hcell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    htable.AddCell(hcell);

                }
                foreach (DataGridViewRow row in dgrid.Rows)
                {
                    foreach (DataGridViewCell hcell in row.Cells)
                    {
                        htable.AddCell(new Phrase(hcell.Value.ToString(), text));
                    }
                }

                var SavePDF = new SaveFileDialog();
                SavePDF.FileName = Filename;
                SavePDF.DefaultExt = ".pdf";
                bool ErrorMessage = false;
                if (SavePDF.ShowDialog() == DialogResult.OK)
                {
                   

                        using (FileStream stream = new FileStream(SavePDF.FileName, FileMode.Create))
                        {
                            Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            PdfWriter.GetInstance(pdfdoc, stream);
                            pdfdoc.Open();
                            pdfdoc.Add(htable);
                            pdfdoc.Close();
                            stream.Close();
                        }
                    
                }
            }
            else
            {
                MessageBox.Show("No Record Found");
            }
        }

        //Machine Maintenance Sched Back button
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            SMRFID.Text = "RFID";
            SRRFID.Text = "RFID";
            SPDF1RFID.Text = "RFID";
            MLRFID.Text = "RFID";
            VMRFID.Text = "RFID";
            MShifter.Text = "SHIFT";
            btnDashboard.Enabled = true;
            btnHistory.Enabled = true;
            btnMachineRegistry.Enabled = true;
            btnMaintenance.Enabled = true;
            btnNewSession.Enabled = true;
            btnUsers.Enabled = true;
            btnLogout.Enabled = true;
            HistoryPanel.Enabled = true;
            MaintenanceReportPanel.Enabled = true;
            MaintenanceSchedulePanel.Enabled = true;
            GnConfirmPnl.Hide();
        }


        //Walang ginagawa to
        private void MLRFID_Click(object sender, EventArgs e)
        {

        }

        //Walang ginagawa to
        private void VMRFID_Click(object sender, EventArgs e)
        {

        }

        //RFID scan for Maintenance Logs
        private void MLRFID_TextChanged(object sender, EventArgs e)
        {
            if (MLRFID.Text == "02 EC 8F 34")
            {

                MLRFID.Text = "RFID";
                MShifter.Text = "SHIFT";
                btnDashboard.Enabled = true;
                btnHistory.Enabled = true;
                btnMachineRegistry.Enabled = true;
                btnMaintenance.Enabled = true;
                btnNewSession.Enabled = true;
                btnUsers.Enabled = true;
                btnLogout.Enabled = true;
                MaintenanceReportPanel.Enabled = true;
                MaintenanceSchedulePanel.Enabled = true;
                MaintenanceLogs f9 = new MaintenanceLogs();
                f9.ShowDialog();
                GnConfirmPnl.Hide();

            }

            if (MLRFID.Text != "02 EC 8F 34" && MLRFID.Text != "RFID")
            {
                if (MessageBox.Show("Make sure you Tap a Custodian's Card", "Non-Custodian Card Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    MLRFID.Text = "RFID";
                    MShifter.Text = "SHIFT";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    MaintenanceReportPanel.Enabled = true;
                    MaintenanceSchedulePanel.Enabled = true;
                    GnConfirmPnl.Hide();
                }
            }
        }

        //RFID scan for Machine Registery
        private void VMRFID_TextChanged(object sender, EventArgs e)
        {
            if (VMRFID.Text == "02 EC 8F 34")
            {
                VMRFID.Text = "RFID";
                MShifter.Text = "SHIFT";
                btnDashboard.Enabled = true;
                btnHistory.Enabled = true;
                btnMachineRegistry.Enabled = true;
                btnMaintenance.Enabled = true;
                btnNewSession.Enabled = true;
                btnUsers.Enabled = true;
                btnLogout.Enabled = true;
                MaintenanceReportPanel.Enabled = true;
                MaintenanceSchedulePanel.Enabled = true;
                GnConfirmPnl.Hide();
                MachineRegistry f5 = new MachineRegistry();
                f5.ShowDialog();

            }

            if (VMRFID.Text != "02 EC 8F 34" && VMRFID.Text != "RFID")
            {
                if (MessageBox.Show("Make sure you Tap a Custodian's Card", "Non-Custodian Card Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    VMRFID.Text = "RFID";
                    MShifter.Text = "SHIFT";
                    btnDashboard.Enabled = true;
                    btnHistory.Enabled = true;
                    btnMachineRegistry.Enabled = true;
                    btnMaintenance.Enabled = true;
                    btnNewSession.Enabled = true;
                    btnUsers.Enabled = true;
                    btnLogout.Enabled = true;
                    MaintenanceReportPanel.Enabled = true;
                    MaintenanceSchedulePanel.Enabled = true;
                    GnConfirmPnl.Hide();
                }
            }
        }

        //Walang ginagawa to
        private void MachineRegistryConfirmPanel_VisibleChanged(object sender, EventArgs e)
        {
        }

        //Walang ginagawa to
        private void MREPCOND_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Walang ginagawa to
        private void UserPanel_Enter(object sender, EventArgs e)
        {

        }

        //EventLogs Button
        private void btnEvenLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventLogs nett = new EventLogs();
            nett.ShowDialog();
        }

        
        //Remove Maintenance Schedule 
        private void button3_Click(object sender, EventArgs e)
        {

            Dashport.Close();
            RSMRFID.Text = "RFID";
            MShifter.Text = "SHIFT5";
            Dashport.PortName = RFID.PORT;
            Dashport.BaudRate = (9600);
            Dashport.Open();

            pictureBox6.Show();
            label33.Show();
            label35.Hide();
            comboBox5.Hide();
            button5.Hide();
            btnDashboard.Enabled = false;
            btnHistory.Enabled = false;
            btnMachineRegistry.Enabled = false;
            btnMaintenance.Enabled = false;
            btnNewSession.Enabled = false;
            btnUsers.Enabled = false;
            btnLogout.Enabled = false;
            MaintenanceReportPanel.Enabled = false;
            MaintenanceSchedulePanel.Enabled = false;
            GnConfirmPnl.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //Remove Maintenance Function
        private void removesched()
        {
            comboBox5.Items.Clear();
            string machine = "SELECT * FROM tbl_MaintenanceSchedule";
            cmd = new OleDbCommand(machine, con);
            OleDbDataReader tbl = cmd.ExecuteReader();
            while (tbl.Read())
            {
                comboBox5.Items.Add(tbl["MachineName"]);
            }
        }

        //RFID scan for Remove Maintenance Schedule 
        private void RSMRFID_TextChanged(object sender, EventArgs e)
        {
            if (RSMRFID.Text == "02 EC 8F 34")
            {

                    con.Open();
                removesched();
                    pictureBox6.Hide();
                    label33.Hide();
                    label35.Show();
                    comboBox5.Show();
                    button5.Show();
                    con.Close();


            }
            if (RSMRFID.Text != "02 EC 8F 34" && RSMRFID.Text != "RFID")
            {
                MessageBox.Show("Please use the Custodian's Card", "Non-Custodian Card Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RSMRFID.Text = "RFID";
                btnDashboard.Enabled = true;
                btnHistory.Enabled = true;
                btnMachineRegistry.Enabled = true;
                btnMaintenance.Enabled = true;
                btnNewSession.Enabled = true;
                btnUsers.Enabled = true;
                btnLogout.Enabled = true;
                MaintenanceReportPanel.Enabled = true;
                MaintenanceSchedulePanel.Enabled = true;
                GnConfirmPnl.Hide();
            }
        }

        //Remove Maintenance Schedule Button
        private void button5_Click_1(object sender, EventArgs e)
        {
            con.Open();
            string mchcheck = "SELECT * FROM tbl_MachineRegistry WHERE MachineName= '" + comboBox5.Text + "'";
            cmd = new OleDbCommand(mchcheck, con);
            OleDbDataReader nsm = cmd.ExecuteReader();
            while (nsm.Read())
            {
                DataVar.removalcondition = nsm["MachineCondition"].ToString();
            }
            if (DataVar.removalcondition == "Under Maintenance")
            {
                MessageBox.Show("Cannot remove Schedule while the machine is Under Maintenance. Please submit the Maintenance Report before removing schedule.", "Maintenance Schedule cannot be removed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            else
            {
                string eshcheck = "DELETE FROM tbl_MaintenanceSchedule WHERE MachineName= '" + comboBox5.Text + "'";
                cmd = new OleDbCommand(eshcheck, con);
                cmd.ExecuteNonQuery();
                con.Close();

                dataGridView4.Update();
                dataGridView4.Refresh();
                dataGridView5.Update();
                dataGridView5.Refresh();

                
                DataVar.notification = "Maintenance Schedule for "+ comboBox5.Text +" has been removed by "+ username1.Text +" at ";



                con.Open();
                NotificationUpdate();
                NotificationRefresh();
                con.Close();

                pictureBox6.Show();
                label33.Show();
                label35.Hide();
                comboBox5.Hide();
                button5.Hide();
                RSMRFID.Text = "RFID";
                btnDashboard.Enabled = true;
                btnHistory.Enabled = true;
                btnMachineRegistry.Enabled = true;
                btnMaintenance.Enabled = true;
                btnNewSession.Enabled = true;
                btnUsers.Enabled = true;
                btnLogout.Enabled = true;
                MaintenanceReportPanel.Enabled = true;
                MaintenanceSchedulePanel.Enabled = true;
                GnConfirmPnl.Hide();
            }
               




        }


        //History Filter Button
        private void button1_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            Dashport.PortName = RFID.PORT;
            Dashport.BaudRate = (9600);
            Dashport.Open();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            FilterDateIN.Value = DateTime.Now;
            FilterDateOut.Value = DateTime.Now.AddDays(1);
            con.Open();
            string users = "SELECT * FROM tbl_users";
            cmd = new OleDbCommand(users, con);
            OleDbDataReader tbl = cmd.ExecuteReader();
            while (tbl.Read())
            {
                comboBox6.Items.Add(tbl["username"]);
            }
          
            string machname = "SELECT * FROM tbl_MachineRegistry";
            cmd = new OleDbCommand(machname, con);
            OleDbDataReader tbl2 = cmd.ExecuteReader();
            while (tbl2.Read())
            {
                comboBox7.Items.Add(tbl2["MachineName"]);
            }
            con.Close();
            HFilterPanel.Show();
            button1.Hide();
            
        }

        //History Filter Search Close Button
        private void button9_Click(object sender, EventArgs e)
        {
            Dashport.Close();
            HFilterPanel.Hide();
            button1.Show();
            HMACHRFID.Text = "Tap a Card";
            HSTUDFRSTNAME.Text = "";
            HSTUDID.Text = "";
            HSTUDLSTNAME.Text = "";
            FilterDateIN.Value = DateTime.Now;
            FilterDateOut.Value = DateTime.Now.AddDays(1);
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();

        }

        //History Filter Search Open Button
        private void button10_Click(object sender, EventArgs e)
        {
            HMACHRFID.Text = "Tap a Card";
            HSTUDFRSTNAME.Text = "";
            HSTUDID.Text = "";
            HSTUDLSTNAME.Text = "";
            FilterDateIN.Value = DateTime.Now;
            FilterDateOut.Value = DateTime.Now.AddDays(1);
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            con.Open();
            string users = "SELECT * FROM tbl_users";
            cmd = new OleDbCommand(users, con);
            OleDbDataReader tbl = cmd.ExecuteReader();
            while (tbl.Read())
            {
                comboBox6.Items.Add(tbl["username"]);
            }

            string machname = "SELECT * FROM tbl_MachineRegistry";
            cmd = new OleDbCommand(machname, con);
            OleDbDataReader tbl2 = cmd.ExecuteReader();
            while (tbl2.Read())
            {
                comboBox7.Items.Add(tbl2["MachineName"]);
            }
            con.Close();
          
        }

        DataTable H1;
        DataTable H2;
        DataTable H3;
        DataTable H4;
        DataTable H5;

        //Search Engine for History
        private void FilterSearchEngine(DataTable HT)
        {

            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV4;
                H4 = HV4.ToTable();
                DataView HV5 = new DataView(H4);
                HV5.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV5;
                H5 = HV5.ToTable();
                DataView HV6 = new DataView(H5);
                HV6.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV6;

            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV4;
                H4 = HV4.ToTable();
                DataView HV5 = new DataView(H4);
                HV5.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV5;

            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV4;
                H4 = HV4.ToTable();
                DataView HV5 = new DataView(H4);
                HV5.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV5;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV4;
                H4 = HV4.ToTable();
                DataView HV5 = new DataView(H4);
                HV5.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV5;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
            }

            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV4;
                H4 = HV4.ToTable();
                DataView HV5 = new DataView(H4);
                HV5.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV5;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;

            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;              
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV2;
            }


            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV4;
                H4 = HV4.ToTable();
                DataView HV5 = new DataView(H4);
                HV5.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV5;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;

            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;

            }

            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                    DataView HV1 = new DataView(HT);
                    HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                    dataGridView2.DataSource = HV1;
                    H1 = HV1.ToTable();
                    DataView HV2 = new DataView(H1);
                    HV2.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                    dataGridView2.DataSource = HV2;
                    H2 = HV2.ToTable();
                    DataView HV3 = new DataView(H2);
                    HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                    dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text != "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_RFID LIKE '%{0}%'", HMACHRFID.Text);
                dataGridView2.DataSource = HV1;

            }



            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV4;
                H4 = HV4.ToTable();
                DataView HV5 = new DataView(H4);
                HV5.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV5;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV2;
            }

            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text != "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("MachineName LIKE '%{0}%'", comboBox7.Text);
                dataGridView2.DataSource = HV1;
            }


            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
                H3 = HV3.ToTable();
                DataView HV4 = new DataView(H3);
                HV4.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV4;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;

            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text != "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentLastName LIKE '%{0}%'", HSTUDLSTNAME.Text);
                dataGridView2.DataSource = HV1;
            }

            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV3;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text != "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentFirstName LIKE '%{0}%'", HSTUDFRSTNAME.Text);
                dataGridView2.DataSource = HV1;

            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV2;
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text != "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("StudentIDNumber LIKE '%{0}%'", HSTUDID.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("AuthenticatedBy LIKE '%{0}%'", comboBox6.Text);
                dataGridView2.DataSource = HV1;
                H1 = HV1.ToTable();
            }
            if (HMACHRFID.Text == "Tap a Card" && comboBox7.Text == "" && HSTUDLSTNAME.Text == "" && HSTUDFRSTNAME.Text == "" && HSTUDID.Text == "" && comboBox6.Text == "")
            {
                DataView HV1 = new DataView(HT);
                H1 = HV1.ToTable();
            }

        }
       
        //Change in RFID Search Filter
        private void HMACHRFID_TextChanged(object sender, EventArgs e)
        {
            if (HMACHRFID.Text != "Tap a Card")
            {

            }
            
        }

        //Change in Machine Name Search Filter
        private void comboBox7_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text != "")
            {
                

            }
        }

        //Change in Student Last Name Search Filter
        private void HSTUDLSTNAME_TextChanged(object sender, EventArgs e)
        {
            if (HSTUDLSTNAME.Text != "")
            {
                
            }
        }

        //Change in Student First Name Search Filter
        private void HSTUDFRSTNAME_TextChanged(object sender, EventArgs e)
        {
            if (HSTUDFRSTNAME.Text != "")
            {
                
            }

        }

        //Change in Student ID Number Search Filter
        private void HSTUDID_TextChanged(object sender, EventArgs e)
        {
            if (HSTUDID.Text != "") 
            {
               
            }

        }

        //Date In Value Change
        private void FilterDateIN_ValueChanged(object sender, EventArgs e)
        {
            FilterDateOut.MinDate = FilterDateIN.Value.AddDays(1);
            FilterDateOut.Value = FilterDateIN.Value.AddDays(1);   
        }

        private void FilterDateOut_ValueChanged(object sender, EventArgs e)
        {

        }

        //Change in Authenticator Search Filter
        private void comboBox6_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (comboBox6.Text != "")
            {
               
            }
        }

        //Walang ginagawa to
        private void label42_Click(object sender, EventArgs e)
        {

        }

        //FilterDateTo
        private void FilterDateOut_DropDown(object sender, EventArgs e)
        {
            FilterDateOut.MinDate = FilterDateIN.Value.AddDays(1);
        }

        DataTable HDT;

        //History Panel RFID scan
        private void button11_Click(object sender, EventArgs e)
        {
            if (HFilterPanel.Visible == true)
            {
                HDT = new DataTable();
                con.Open();
                OleDbDataAdapter Hdt = new OleDbDataAdapter("select * from [tbl_History] where [Time&DateIn] between @datestart and @dateend", con);
                Hdt.SelectCommand.Parameters.AddWithValue("@datestart", FilterDateIN.Value.AddDays(-1).ToString());
                Hdt.SelectCommand.Parameters.AddWithValue("@dateend", FilterDateOut.Value.ToString());
                Hdt.Fill(HDT);
                con.Close();
                dataGridView2.DataSource = HDT;
                FilterSearchEngine(HDT);
            }
            else
            {
                HDT = new DataTable();
                con.Open();
                OleDbDataAdapter Hdt = new OleDbDataAdapter("select * from [tbl_History] where [Time&DateIn] between @datestart and @dateend", con);
                Hdt.SelectCommand.Parameters.AddWithValue("@datestart", FilterDateIN.Value.AddDays(-1).ToString());
                Hdt.SelectCommand.Parameters.AddWithValue("@dateend", FilterDateOut.Value.ToString());
                Hdt.Fill(HDT);
                con.Close();
                dataGridView2.DataSource = HDT;
            }
            

        }

        private void HSTUDLSTNAME_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void HSTUDFRSTNAME_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void HSTUDID_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //Prevent sql injection
        private void HSTUDLSTNAME_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void HSTUDFRSTNAME_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void HSTUDID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void MrMachineName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void MrProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void MrBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void MrModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void MrSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void MrInitialCond_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void NsLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void NSFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void NsIDNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void NsProjNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void NsProjDes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void MaintenanceReportPanel_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MachineRegistryPanel_Enter(object sender, EventArgs e)
        {

        }

        private void NewSessionPanel_Enter(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            PnlNav.Height = button16.Height;
            PnlNav.Top = button16.Top;
            PnlNav.Left = button16.Left;
            btnMachineRegistry.BackColor = Color.FromArgb(0, 128, 128);
            btnNewSession.BackColor = Color.FromArgb(0, 128, 128);
            btnHistory.BackColor = Color.FromArgb(0, 128, 128);
            btnDashboard.BackColor = Color.FromArgb(0, 128, 128);
            btnMaintenance.BackColor = Color.FromArgb(0, 128, 128);
            btnUsers.BackColor = Color.FromArgb(0, 128, 128);
            button16.BackColor = Color.FromArgb(0, 139, 139); 
            MachineRegistryPanel.Hide();
            NewSessionPanel.Hide();
            HistoryPanel.Hide();
            DashboardStatus.Hide();
            DashboardLabel.Hide();
            DashboardNotifications.Hide();
            DashboardEndSession.Hide();
            MaintenanceReportPanel.Hide();
            MaintenanceSchedulePanel.Hide();
            UserPanel.Hide();
            DashboardDate.Hide();
            DashboardTime.Hide();
            NewSessionConfirmPanel.Hide();
            InventoryPanel.Show();
            //MachineRegistryConfirmPanel.Hide();
            GnConfirmPnl.Hide();
            checkBox2.Checked = false;
            RegisterMachineButton.Enabled = false;
            EndSessionConfirmPanel.Hide();
            MrRFID.Text = "RFID";
            Dashport.Close();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text == "Apparatus")
            {
                label49.Visible = false;
                comboBox13.Visible = false;
                label50.Visible = true;
                comboBox12.Visible = true;
            }
            if (comboBox10.Text == "Machine")
            {
                label50.Visible = false;
                comboBox12.Visible = false;
                label49.Visible = true;
                comboBox13.Visible = true;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.Text == "Apparatus")
            {
                MrMachineName.Enabled = false;
                MrInitialCond.Enabled = false;
                MrSerialNumber.Enabled = false;
                MrModel.Enabled = false;
                textBox1.Enabled = true;
            }
            if (comboBox9.Text == "Machine")
            {
                MrMachineName.Enabled = true;
                MrInitialCond.Enabled = true;
                MrSerialNumber.Enabled = true;
                MrModel.Enabled = true;
                textBox1.Enabled = false;
            }
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InventoryLogs nedd = new InventoryLogs();
            nedd.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Status ded = new Status();
            ded.Show();
        }
    }
}
