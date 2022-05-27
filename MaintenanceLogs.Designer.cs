
namespace PS2_GUI_Alpha_v2._0
{
    partial class MaintenanceLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceLogs));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.FilterDateOut = new System.Windows.Forms.DateTimePicker();
            this.FilterDateIN = new System.Windows.Forms.DateTimePicker();
            this.label40 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.FMachineName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FMaintainedBy = new System.Windows.Forms.TextBox();
            this.db_psDataSet = new PS2_GUI_Alpha_v2._0.db_psDataSet();
            this.tblMaintenanceLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_MaintenanceLogsTableAdapter = new PS2_GUI_Alpha_v2._0.db_psDataSetTableAdapters.tbl_MaintenanceLogsTableAdapter();
            this.machineNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maintainedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineConditionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maintenanceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maintenanceReportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDateSubmitedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaintenanceLogsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.machineNameDataGridViewTextBoxColumn,
            this.maintainedByDataGridViewTextBoxColumn,
            this.machineConditionDataGridViewTextBoxColumn,
            this.maintenanceTypeDataGridViewTextBoxColumn,
            this.maintenanceReportDataGridViewTextBoxColumn,
            this.timeDateSubmitedDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblMaintenanceLogsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(954, 512);
            this.dataGridView1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Teal;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Impact", 12F);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(796, 527);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(149, 46);
            this.button4.TabIndex = 8;
            this.button4.Text = "Save PDF";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Impact", 9.75F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(711, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 34);
            this.button1.TabIndex = 67;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Teal;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Impact", 9.75F);
            this.button11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button11.Location = new System.Drawing.Point(625, 534);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(80, 34);
            this.button11.TabIndex = 62;
            this.button11.Text = "Filter";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // FilterDateOut
            // 
            this.FilterDateOut.CalendarFont = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateOut.Font = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FilterDateOut.Location = new System.Drawing.Point(503, 547);
            this.FilterDateOut.Name = "FilterDateOut";
            this.FilterDateOut.Size = new System.Drawing.Size(116, 21);
            this.FilterDateOut.TabIndex = 66;
            this.FilterDateOut.DropDown += new System.EventHandler(this.FilterDateOut_DropDown);
            // 
            // FilterDateIN
            // 
            this.FilterDateIN.CalendarFont = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateIN.Font = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateIN.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FilterDateIN.Location = new System.Drawing.Point(381, 547);
            this.FilterDateIN.Name = "FilterDateIN";
            this.FilterDateIN.Size = new System.Drawing.Size(116, 21);
            this.FilterDateIN.TabIndex = 65;
            this.FilterDateIN.ValueChanged += new System.EventHandler(this.FilterDateIN_ValueChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label40.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label40.ForeColor = System.Drawing.Color.Teal;
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(378, 527);
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
            this.label43.Location = new System.Drawing.Point(500, 527);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(18, 15);
            this.label43.TabIndex = 64;
            this.label43.Text = "To";
            // 
            // FMachineName
            // 
            this.FMachineName.Font = new System.Drawing.Font("Impact", 8.25F);
            this.FMachineName.Location = new System.Drawing.Point(12, 547);
            this.FMachineName.Name = "FMachineName";
            this.FMachineName.Size = new System.Drawing.Size(127, 21);
            this.FMachineName.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 529);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 69;
            this.label1.Text = "Machine Name";
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.Font = new System.Drawing.Font("Impact", 8.25F);
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "Any",
            "Breakdown",
            "Scheduled"});
            this.comboBox7.Location = new System.Drawing.Point(258, 547);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(117, 23);
            this.comboBox7.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(255, 529);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 71;
            this.label2.Text = "Maintenance Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(142, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 72;
            this.label3.Text = "Maintained By";
            // 
            // FMaintainedBy
            // 
            this.FMaintainedBy.Font = new System.Drawing.Font("Impact", 8.25F);
            this.FMaintainedBy.Location = new System.Drawing.Point(145, 547);
            this.FMaintainedBy.Name = "FMaintainedBy";
            this.FMaintainedBy.Size = new System.Drawing.Size(107, 21);
            this.FMaintainedBy.TabIndex = 73;
            // 
            // db_psDataSet
            // 
            this.db_psDataSet.DataSetName = "db_psDataSet";
            this.db_psDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblMaintenanceLogsBindingSource
            // 
            this.tblMaintenanceLogsBindingSource.DataMember = "tbl_MaintenanceLogs";
            this.tblMaintenanceLogsBindingSource.DataSource = this.db_psDataSet;
            // 
            // tbl_MaintenanceLogsTableAdapter
            // 
            this.tbl_MaintenanceLogsTableAdapter.ClearBeforeFill = true;
            // 
            // machineNameDataGridViewTextBoxColumn
            // 
            this.machineNameDataGridViewTextBoxColumn.DataPropertyName = "Machine_Name";
            this.machineNameDataGridViewTextBoxColumn.HeaderText = "Machine_Name";
            this.machineNameDataGridViewTextBoxColumn.Name = "machineNameDataGridViewTextBoxColumn";
            this.machineNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maintainedByDataGridViewTextBoxColumn
            // 
            this.maintainedByDataGridViewTextBoxColumn.DataPropertyName = "Maintained_By";
            this.maintainedByDataGridViewTextBoxColumn.HeaderText = "Maintained_By";
            this.maintainedByDataGridViewTextBoxColumn.Name = "maintainedByDataGridViewTextBoxColumn";
            this.maintainedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // machineConditionDataGridViewTextBoxColumn
            // 
            this.machineConditionDataGridViewTextBoxColumn.DataPropertyName = "Machine_Condition";
            this.machineConditionDataGridViewTextBoxColumn.HeaderText = "Machine_Condition";
            this.machineConditionDataGridViewTextBoxColumn.Name = "machineConditionDataGridViewTextBoxColumn";
            this.machineConditionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maintenanceTypeDataGridViewTextBoxColumn
            // 
            this.maintenanceTypeDataGridViewTextBoxColumn.DataPropertyName = "Maintenance_Type";
            this.maintenanceTypeDataGridViewTextBoxColumn.HeaderText = "Maintenance_Type";
            this.maintenanceTypeDataGridViewTextBoxColumn.Name = "maintenanceTypeDataGridViewTextBoxColumn";
            this.maintenanceTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maintenanceReportDataGridViewTextBoxColumn
            // 
            this.maintenanceReportDataGridViewTextBoxColumn.DataPropertyName = "Maintenance_Report";
            this.maintenanceReportDataGridViewTextBoxColumn.HeaderText = "Maintenance_Report";
            this.maintenanceReportDataGridViewTextBoxColumn.Name = "maintenanceReportDataGridViewTextBoxColumn";
            this.maintenanceReportDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeDateSubmitedDataGridViewTextBoxColumn
            // 
            this.timeDateSubmitedDataGridViewTextBoxColumn.DataPropertyName = "Time&DateSubmited";
            this.timeDateSubmitedDataGridViewTextBoxColumn.HeaderText = "Time&DateSubmited";
            this.timeDateSubmitedDataGridViewTextBoxColumn.Name = "timeDateSubmitedDataGridViewTextBoxColumn";
            this.timeDateSubmitedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MaintenanceLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 578);
            this.Controls.Add(this.FMaintainedBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FMachineName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.FilterDateOut);
            this.Controls.Add(this.FilterDateIN);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MaintenanceLogs";
            this.Text = "MaintenanceLogs";
            this.Load += new System.EventHandler(this.MaintenanceLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaintenanceLogsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DateTimePicker FilterDateOut;
        private System.Windows.Forms.DateTimePicker FilterDateIN;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox FMachineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FMaintainedBy;
        private db_psDataSet db_psDataSet;
        private System.Windows.Forms.BindingSource tblMaintenanceLogsBindingSource;
        private db_psDataSetTableAdapters.tbl_MaintenanceLogsTableAdapter tbl_MaintenanceLogsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maintainedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineConditionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maintenanceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maintenanceReportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDateSubmitedDataGridViewTextBoxColumn;
    }
}