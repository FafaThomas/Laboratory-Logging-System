using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PS2_GUI_Alpha_v2._0
{
    class AC
    {
        public static OleDbConnection con = new OleDbConnection();
        public static OleDbCommand cmd = new OleDbCommand("", con);
        public static OleDbDataReader rd;
        public static OleDbDataAdapter ad;

        public static string username;
        public static string sql;

        public static string getConnectionString()
        {
            string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source =" + Application.StartupPath + "\\db_ps.mdb";

            return connectionString;
        }

        public static void openConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = getConnectionString();
                    con.Open();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Failed to make a connection." + Environment.NewLine + "Description:" + ex.Message.ToString(), "C# Access Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.ConnectionString = getConnectionString();
                    con.Close();
                    con.Dispose(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to make a connection." + Environment.NewLine + "Description:" + ex.Message.ToString(), "C# Closed Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
