using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.OleDb;


namespace PS2_GUI_Alpha_v2._0
{
    public partial class MaintenanceLogs : Form
    {

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = " + Application.StartupPath + "\\db_ps.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        public MaintenanceLogs()
        {
            InitializeComponent();

        }

        private void MaintenanceLogs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_MaintenanceLogs' table. You can move, or remove it, as needed.
            this.tbl_MaintenanceLogsTableAdapter.Fill(this.db_psDataSet.tbl_MaintenanceLogs);




        }


        //Save to PDF button
        private void button4_Click(object sender, EventArgs e)
        {
            SaveToPDF(dataGridView1, "LEUMS-MaintenanceLogs");
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

        DataTable H1;
        DataTable H2;

        private void FilterSearchEngine(DataTable HT)
        {
            if (comboBox7.Text != "" || comboBox7.Text != "Any" && FMachineName.Text != "" && FMaintainedBy.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Maintenance_Type LIKE '%{0}%'", comboBox7.Text);
                dataGridView1.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("Machine_Name LIKE '%{0}%'", FMachineName.Text);
                dataGridView1.DataSource = HV2;
                H2 = HV2.ToTable();
                DataView HV3 = new DataView(H2);
                HV3.RowFilter = string.Format("Maintained_By LIKE '%{0}%'", FMaintainedBy.Text);
                dataGridView1.DataSource = HV3;

            }
            if (comboBox7.Text != "" || comboBox7.Text != "Any" && FMachineName.Text != "" && FMaintainedBy.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Maintenance_Type LIKE '%{0}%'", comboBox7.Text);
                dataGridView1.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("Machine_Name LIKE '%{0}%'", FMachineName.Text);
                dataGridView1.DataSource = HV2;
                H2 = HV2.ToTable();
            }
            if (comboBox7.Text != "" || comboBox7.Text != "Any" && FMachineName.Text == "" && FMaintainedBy.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Maintenance_Type LIKE '%{0}%'", comboBox7.Text);
                dataGridView1.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("Maintained_By LIKE '%{0}%'", FMaintainedBy.Text);
                dataGridView1.DataSource = HV2;
            }
            if (comboBox7.Text != "" || comboBox7.Text != "Any" && FMachineName.Text == "" && FMaintainedBy.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Maintenance_Type LIKE '%{0}%'", comboBox7.Text);
                dataGridView1.DataSource = HV1;
            }
            if (comboBox7.Text == "" || comboBox7.Text == "Any" && FMachineName.Text != "" && FMaintainedBy.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_Name LIKE '%{0}%'", FMachineName.Text);
                dataGridView1.DataSource = HV1;
                H1 = HV1.ToTable();
                DataView HV2 = new DataView(H1);
                HV2.RowFilter = string.Format("Maintained_By LIKE '%{0}%'", FMaintainedBy.Text);
                dataGridView1.DataSource = HV2;
            }
            if (comboBox7.Text == "" || comboBox7.Text == "Any" && FMachineName.Text != "" && FMaintainedBy.Text == "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Machine_Name LIKE '%{0}%'", FMachineName.Text);
                dataGridView1.DataSource = HV1;
            }
            if (comboBox7.Text == "" || comboBox7.Text == "Any" && FMachineName.Text == "" && FMaintainedBy.Text != "")
            {
                DataView HV1 = new DataView(HT);
                HV1.RowFilter = string.Format("Maintained_By LIKE '%{0}%'", FMaintainedBy.Text);
                dataGridView1.DataSource = HV1;

            }
            if (comboBox7.Text == "" || comboBox7.Text == "Any" && FMachineName.Text == "" && FMaintainedBy.Text == "")
            {
                DataView HV1 = new DataView(HT);
                H1 = HV1.ToTable();

            }
           
        }

        DataTable HDT;
        private void button11_Click(object sender, EventArgs e)
        {
            HDT = new DataTable();
            con.Open();
            OleDbDataAdapter Hdt = new OleDbDataAdapter("select * from [tbl_MaintenanceLogs] where [Time&DateSubmited] between @datestart and @dateend", con);
            Hdt.SelectCommand.Parameters.AddWithValue("@datestart", FilterDateIN.Value.AddDays(-1).ToString());
            Hdt.SelectCommand.Parameters.AddWithValue("@dateend", FilterDateOut.Value.ToString());
            Hdt.Fill(HDT);
            con.Close();
            dataGridView1.DataSource = HDT;
            FilterSearchEngine(HDT);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FMachineName.Text = "";
            FMaintainedBy.Text = "";
            FilterDateIN.Value = DateTime.Now;
            FilterDateOut.Value = DateTime.Now.AddDays(1);
            comboBox7.Text = "Any";
            
        }

        private void FilterDateIN_ValueChanged(object sender, EventArgs e)
        {
            FilterDateOut.MinDate = FilterDateIN.Value.AddDays(1);
            FilterDateOut.Value = FilterDateIN.Value.AddDays(1);
        }

        private void FilterDateOut_DropDown(object sender, EventArgs e)
        {
            FilterDateOut.MinDate = FilterDateIN.Value.AddDays(1);
        }
    }
}
