using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS2_GUI_Alpha_v2._0
{
    public partial class Initializer : Form
    {
        public delegate void d1(string indata);
        public Initializer()
        {
            InitializeComponent();
         
        }

       
       //Loading of Initializer Components
            public void Initializer_Load(object sender, EventArgs e)
        {
            try
            {
                PortBox.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                PortBox.SelectedIndex = 0;

                button_open.Enabled = true;
                button_close.Enabled = false;
                button_open.Show();
                button_close.Hide();
                PortBox.Enabled = true;
                button1.Enabled = false;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }


        //Connect Button
        public void button_open_Click(object sender, EventArgs e)
        {
            RFID.PORT = PortBox.Text;
            button_open.Enabled = false;
            button_close.Enabled = true;
            button_close.Show();
            button_open.Hide();
            PortBox.Enabled = false;
            button1.Enabled = true;


        }

        //Disconnect Button
        private void button_close_Click(object sender, EventArgs e)
        {
            button_open.Enabled = true;
            button_close.Enabled = false;
            button_open.Show();
            button_close.Hide();
            PortBox.Enabled = true;
            button1.Enabled = false;
        }

        //Close Button
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
       
        //Proceed Button
        private void button1_Click(object sender, EventArgs e)
        {
            try {

           frmLogin f2 = new frmLogin();
            this.Hide();
                f2.ShowDialog();
            this.Close();
        }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        //Refresh Button
        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            PortBox.Items.Clear();
            PortBox.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            PortBox.SelectedIndex = 0;
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox5.Hide();
            button_open.Enabled = true;
            button_close.Enabled = false;
            button_open.Show();
            button_close.Hide();
            PortBox.Enabled = true;
            button1.Enabled = false;
            await Task.Delay(25);
            pictureBox4.Show();
            await Task.Delay(25);
            pictureBox2.Hide();
            pictureBox5.Hide();
            pictureBox4.Hide();
            pictureBox3.Show();
            await Task.Delay(25);
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Show();
            await Task.Delay(25);
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
