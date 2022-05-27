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
using System.Text.RegularExpressions;
using System.IO.Ports;


namespace PS2_GUI_Alpha_v2._0
{
   
    public partial class frmLogin : Form
    {
        public delegate void d1(string indata);
        delegate void serialCalback(string val);
        public frmLogin()
        {
            InitializeComponent();
            LoginPort.PortName = RFID.PORT;
            LoginPort.BaudRate = 9600;
        }
        //Connection to Database
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = " + Application.StartupPath + "\\db_ps.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        //Load Defaults for Login
        public void frmLogin_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button3.Visible = false;
            button1.Enabled = false;
            button1.Visible = true;
            LoginPort.Open();
            try {
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //Reintialize Button
        private void label6_Click(object sender, EventArgs e)
        {
            LoginPort.Close();
            try {
                AC.closeConnection();
            Initializer f5 = new Initializer();

            this.Hide();
            f5.ShowDialog();
            this.Close();
        }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Fetch Arduino Data
        private void LoginPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string indata = LoginPort.ReadExisting();
            setText(indata);
            LoginPort.Close();
            LoginPort.Dispose();
        }


        //Convert Arduino Data to Text
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

            }

            

        }


        //Register Form Button
        private void button2_Click_1(object sender, EventArgs e)
        {
            LoginPort.Close();
            try
            {
                frmRegister f2 = new frmRegister();


                this.Hide();
                f2.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Retry Button
        private void button3_Click_1(object sender, EventArgs e)
        {
            SerialMonitor.Text = "RFID";
            button3.Enabled = false;
            button3.Visible = false;
            button1.Enabled = false;
            button1.Visible = true;
            LoginPort.Open();
        }


        private void SerialMonitor_TextChanged(object sender, EventArgs e)
        {
            if (SerialMonitor.Text != "RFID") {
                con.Open();
                string rfcheck = "SELECT * FROM tbl_users WHERE RFID= '" + SerialMonitor.Text + "'";
                cmd = new OleDbCommand(rfcheck, con);
                OleDbDataReader drr = cmd.ExecuteReader();
                if (drr.Read() == true)
                {
                    string usercheck = "SELECT * FROM tbl_users WHERE RFID= '" + SerialMonitor.Text + "'";
                    cmd = new OleDbCommand(usercheck, con);
                    OleDbDataReader dru = cmd.ExecuteReader();
                    while (dru.Read())
                    {
                        DataVar.usernamedata = drr["username"].ToString();
                    }

                    MessageBox.Show("Welcome " + DataVar.usernamedata + " click Login to proceed to the Dashboard", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    button3.Enabled = false;
                    button3.Visible = false;
                    button1.Enabled = true;
                    button1.Visible = true;

                }
                else
                {
                    MessageBox.Show("RFID is not Registered", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button3.Enabled = true;
                    button3.Visible = true;
                    button1.Enabled = false;
                    button1.Visible = false;
                    con.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPort.Close();
            LoginPort.Dispose();
            Dashboard frm = new Dashboard();
            this.Hide();
            frm.ShowDialog();
            con.Close();
            this.Close();
        }
    }
}
