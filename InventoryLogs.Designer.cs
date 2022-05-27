namespace PS2_GUI_Alpha_v2._0
{
    partial class InventoryLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryLogs));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.FilterDateOut = new System.Windows.Forms.DateTimePicker();
            this.FilterDateIN = new System.Windows.Forms.DateTimePicker();
            this.label40 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox17 = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.comboBox18 = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.db_psDataSet = new PS2_GUI_Alpha_v2._0.db_psDataSet();
            this.tblInventoryLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_InventoryLogsTableAdapter = new PS2_GUI_Alpha_v2._0.db_psDataSetTableAdapters.tbl_InventoryLogsTableAdapter();
            this.productDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryReportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeSubmittedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryLogsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productDataGridViewTextBoxColumn,
            this.brandDataGridViewTextBoxColumn,
            this.inventoryReportDataGridViewTextBoxColumn,
            this.changesDataGridViewTextBoxColumn,
            this.dateTimeSubmittedDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblInventoryLogsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(797, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Impact", 9.75F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(589, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 34);
            this.button1.TabIndex = 67;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Teal;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Impact", 9.75F);
            this.button11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button11.Location = new System.Drawing.Point(503, 469);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(80, 34);
            this.button11.TabIndex = 62;
            this.button11.Text = "Filter";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // FilterDateOut
            // 
            this.FilterDateOut.CalendarFont = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateOut.Font = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FilterDateOut.Location = new System.Drawing.Point(402, 474);
            this.FilterDateOut.Name = "FilterDateOut";
            this.FilterDateOut.Size = new System.Drawing.Size(95, 21);
            this.FilterDateOut.TabIndex = 66;
            // 
            // FilterDateIN
            // 
            this.FilterDateIN.CalendarFont = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateIN.Font = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateIN.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FilterDateIN.Location = new System.Drawing.Point(280, 475);
            this.FilterDateIN.Name = "FilterDateIN";
            this.FilterDateIN.Size = new System.Drawing.Size(92, 21);
            this.FilterDateIN.TabIndex = 65;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label40.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label40.ForeColor = System.Drawing.Color.Teal;
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(245, 473);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 15);
            this.label40.TabIndex = 63;
            this.label40.Text = "From";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label43.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label43.ForeColor = System.Drawing.Color.Teal;
            this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label43.Location = new System.Drawing.Point(378, 473);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(18, 15);
            this.label43.TabIndex = 64;
            this.label43.Text = "To";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Teal;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Impact", 12F);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(675, 469);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 34);
            this.button4.TabIndex = 68;
            this.button4.Text = "Save PDF";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // comboBox17
            // 
            this.comboBox17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox17.Font = new System.Drawing.Font("Impact", 8.25F);
            this.comboBox17.FormattingEnabled = true;
            this.comboBox17.Location = new System.Drawing.Point(134, 483);
            this.comboBox17.Name = "comboBox17";
            this.comboBox17.Size = new System.Drawing.Size(105, 23);
            this.comboBox17.TabIndex = 72;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label56.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label56.ForeColor = System.Drawing.Color.Teal;
            this.label56.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label56.Location = new System.Drawing.Point(131, 465);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(35, 15);
            this.label56.TabIndex = 71;
            this.label56.Text = "Brand";
            this.label56.Click += new System.EventHandler(this.label56_Click);
            // 
            // comboBox18
            // 
            this.comboBox18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox18.Font = new System.Drawing.Font("Impact", 8.25F);
            this.comboBox18.FormattingEnabled = true;
            this.comboBox18.Location = new System.Drawing.Point(12, 483);
            this.comboBox18.Name = "comboBox18";
            this.comboBox18.Size = new System.Drawing.Size(116, 23);
            this.comboBox18.TabIndex = 70;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label57.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label57.ForeColor = System.Drawing.Color.Teal;
            this.label57.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label57.Location = new System.Drawing.Point(9, 465);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(43, 15);
            this.label57.TabIndex = 69;
            this.label57.Text = "Product";
            // 
            // db_psDataSet
            // 
            this.db_psDataSet.DataSetName = "db_psDataSet";
            this.db_psDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblInventoryLogsBindingSource
            // 
            this.tblInventoryLogsBindingSource.DataMember = "tbl_InventoryLogs";
            this.tblInventoryLogsBindingSource.DataSource = this.db_psDataSet;
            // 
            // tbl_InventoryLogsTableAdapter
            // 
            this.tbl_InventoryLogsTableAdapter.ClearBeforeFill = true;
            // 
            // productDataGridViewTextBoxColumn
            // 
            this.productDataGridViewTextBoxColumn.DataPropertyName = "Product";
            this.productDataGridViewTextBoxColumn.HeaderText = "Product";
            this.productDataGridViewTextBoxColumn.Name = "productDataGridViewTextBoxColumn";
            this.productDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // brandDataGridViewTextBoxColumn
            // 
            this.brandDataGridViewTextBoxColumn.DataPropertyName = "Brand";
            this.brandDataGridViewTextBoxColumn.HeaderText = "Brand";
            this.brandDataGridViewTextBoxColumn.Name = "brandDataGridViewTextBoxColumn";
            this.brandDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inventoryReportDataGridViewTextBoxColumn
            // 
            this.inventoryReportDataGridViewTextBoxColumn.DataPropertyName = "Inventory_Report";
            this.inventoryReportDataGridViewTextBoxColumn.HeaderText = "Inventory_Report";
            this.inventoryReportDataGridViewTextBoxColumn.Name = "inventoryReportDataGridViewTextBoxColumn";
            this.inventoryReportDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // changesDataGridViewTextBoxColumn
            // 
            this.changesDataGridViewTextBoxColumn.DataPropertyName = "Changes";
            this.changesDataGridViewTextBoxColumn.HeaderText = "Changes";
            this.changesDataGridViewTextBoxColumn.Name = "changesDataGridViewTextBoxColumn";
            this.changesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateTimeSubmittedDataGridViewTextBoxColumn
            // 
            this.dateTimeSubmittedDataGridViewTextBoxColumn.DataPropertyName = "Date&Time_Submitted";
            this.dateTimeSubmittedDataGridViewTextBoxColumn.HeaderText = "Date&Time_Submitted";
            this.dateTimeSubmittedDataGridViewTextBoxColumn.Name = "dateTimeSubmittedDataGridViewTextBoxColumn";
            this.dateTimeSubmittedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // InventoryLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 515);
            this.Controls.Add(this.comboBox17);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.comboBox18);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.FilterDateOut);
            this.Controls.Add(this.FilterDateIN);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventoryLogs";
            this.Text = "Inventory Logs";
            this.Load += new System.EventHandler(this.InventoryLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryLogsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DateTimePicker FilterDateOut;
        private System.Windows.Forms.DateTimePicker FilterDateIN;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox17;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox comboBox18;
        private System.Windows.Forms.Label label57;
        private db_psDataSet db_psDataSet;
        private System.Windows.Forms.BindingSource tblInventoryLogsBindingSource;
        private db_psDataSetTableAdapters.tbl_InventoryLogsTableAdapter tbl_InventoryLogsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoryReportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn changesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeSubmittedDataGridViewTextBoxColumn;
    }
}