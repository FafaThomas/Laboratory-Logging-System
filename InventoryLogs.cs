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
    public partial class InventoryLogs : Form
    {
        public InventoryLogs()
        {
            InitializeComponent();
        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void InventoryLogs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_InventoryLogs' table. You can move, or remove it, as needed.
            this.tbl_InventoryLogsTableAdapter.Fill(this.db_psDataSet.tbl_InventoryLogs);


        }
    }
}
