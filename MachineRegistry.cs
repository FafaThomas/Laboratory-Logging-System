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

namespace PS2_GUI_Alpha_v2._0
{
    public partial class MachineRegistry : Form
    {

        public MachineRegistry()
        {
            InitializeComponent();
        }

        private void MachineRegistry_Load(object sender, EventArgs e)
        {
           


        }



        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void MachineRegistry_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_psDataSet.tbl_MachineRegistry' table. You can move, or remove it, as needed.
            this.tbl_MachineRegistryTableAdapter.Fill(this.db_psDataSet.tbl_MachineRegistry);



        }

        //Save to PDF Button
        private void button1_Click(object sender, EventArgs e)
        {
            SaveToPDF(dataGridView2, "LEUMS-MachineRegistry");
        }

        //Save to PDF Function
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
        //Decomissioned Button
            private void button2_Click(object sender, EventArgs e)
            {
            Graveyard f2 = new Graveyard();
            f2.ShowDialog();
            }
    }
}
