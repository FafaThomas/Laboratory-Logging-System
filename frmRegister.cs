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

namespace PS2_GUI_Alpha_v2._0
{
    public partial class frmRegister : Form
    {
        public delegate void d1(string indata);
        delegate void serialCalback(string val);
        public frmRegister()
        {
            InitializeComponent();
        }

        //Connnection to Database
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = " + Application.StartupPath + "\\db_ps.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }



        //Register Button
        private void button1_Click(object sender, EventArgs e)
        {
            RegisterPort.Close();
            CustodianRegisterPanel.Visible = true;
            txtUsername.Enabled = false;
            txtLastname.Enabled = false;
            txtFirstname.Enabled = false;
            button1.Enabled = false;
            label9.Enabled = false;
            RegisterPort.PortName = RFID.PORT;
            RegisterPort.BaudRate = 9600;
            RegisterPort.Open();


        }

        //Back to login button
        private void label9_Click(object sender, EventArgs e)
        {
            RegisterPort.Close();
            try
            {
            frmLogin f1 = new frmLogin();
            txtUsername.Text = "";
            
            txtFirstname.Text = "";
            txtLastname.Text = "";
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        //Load register form default settings
        private void frmRegister_Load(object sender, EventArgs e)
        {

           
        }

        //Fetch Arduino Data
        private void RegisterPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string indata = RegisterPort.ReadExisting();
            setText(indata);
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
                if (CustodianRegisterPanel.Visible == true)
                {
                    lblValue2.Text=SerialMonitor.Text;
                }
            }

            
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        //TextBox Stuff
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
            }
        //TextBox Stuff
        private void txtLastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //TextBox Stuff
        private void txtFirstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        //TextBox Stuff

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void SerialMonitor_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            con.Close();
            RegisterPort.Close();
            CustodianRegisterPanel.Visible = false;
            txtUsername.Enabled = true;
            txtLastname.Enabled = true;
            txtFirstname.Enabled = true;
            button1.Enabled = true;
            label9.Enabled = true;
        }

        private void lblValue2_TextChanged(object sender, EventArgs e)
        {
            if (lblValue2.Text != "label10")
            {

                try
                {
                    CustodianRegisterPanel.Visible = false;
                    txtUsername.Enabled = true;
                    txtLastname.Enabled = true;
                    txtFirstname.Enabled = true;
                    button1.Enabled = true;
                    label9.Enabled = true;

                    con.Open();
                    string rfcheck = "SELECT * FROM tbl_users WHERE RFID= '" + SerialMonitor.Text + "'";
                    cmd = new OleDbCommand(rfcheck, con);
                    OleDbDataReader drr = cmd.ExecuteReader();
                    if (drr.Read() == true)
                    {

                        MessageBox.Show("RFID is already taken", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        string usercheck = "SELECT * FROM tbl_users WHERE username= '" + txtUsername.Text + "'";
                        cmd = new OleDbCommand(usercheck, con);
                        OleDbDataReader dru = cmd.ExecuteReader();
                        if (dru.Read() == true)
                        {
                            MessageBox.Show("Username is already taken", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Text = "";
                        }
                        else
                        {
                            con.Close();
                            con.Open();
                            DataVar.UserRegNotif = "User " + txtUsername.Text + " has been registered at ";
                            string mdcheck = "SELECT * FROM tbl_EventLogs WHERE Event= '" + DataVar.UserRegNotif + "'";
                            cmd = new OleDbCommand(mdcheck, con);
                            OleDbDataReader ndm = cmd.ExecuteReader();
                            if (ndm.Read() == true)
                            {
                                DataVar.UserRegNotif = "";
                            }
                            else
                            {
                                string notif = "INSERT INTO tbl_EventLogs Values('" + DataVar.UserRegNotif + "','" + DateTime.Now + "')";
                                cmd = new OleDbCommand(notif, con);
                                cmd.ExecuteNonQuery();
                                DataVar.UserRegNotif = "";
                            }

                            string register = "INSERT INTO tbl_users Values('" + SerialMonitor.Text + "', '" + txtUsername.Text + "', '" + txtFirstname.Text + "', '" + txtLastname.Text + "','" + DateTime.Now + "')";
                            cmd = new OleDbCommand(register, con);
                            cmd.ExecuteNonQuery();



                            txtUsername.Text = "";
                            txtFirstname.Text = "";
                            txtLastname.Text = "";
                            MessageBox.Show("Welcome Custodian, You may now proceed to Login", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        }

                    }
                    
                    con.Close();
                    lblValue2.Text = "label10";
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
    }
}
