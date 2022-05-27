namespace PS2_GUI_Alpha_v2._0
{
    partial class Status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Status));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.db_psDataSet = new PS2_GUI_Alpha_v2._0.db_psDataSet();
            this.tblstatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_statusTableAdapter = new PS2_GUI_Alpha_v2._0.db_psDataSetTableAdapters.tbl_statusTableAdapter();
            this.rFIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentIDNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDateInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authenticatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblstatusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rFIDDataGridViewTextBoxColumn,
            this.itemSetDataGridViewTextBoxColumn,
            this.studentLastNameDataGridViewTextBoxColumn,
            this.studentFirstNameDataGridViewTextBoxColumn,
            this.studentIDNumberDataGridViewTextBoxColumn,
            this.timeDateInDataGridViewTextBoxColumn,
            this.authenticatedByDataGridViewTextBoxColumn,
            this.projectNumberDataGridViewTextBoxColumn,
            this.projectDescriptionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblstatusBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(826, 456);
            this.dataGridView1.TabIndex = 0;
            // 
            // db_psDataSet
            // 
            this.db_psDataSet.DataSetName = "db_psDataSet";
            this.db_psDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblstatusBindingSource
            // 
            this.tblstatusBindingSource.DataMember = "tbl_status";
            this.tblstatusBindingSource.DataSource = this.db_psDataSet;
            // 
            // tbl_statusTableAdapter
            // 
            this.tbl_statusTableAdapter.ClearBeforeFill = true;
            // 
            // rFIDDataGridViewTextBoxColumn
            // 
            this.rFIDDataGridViewTextBoxColumn.DataPropertyName = "RFID";
            this.rFIDDataGridViewTextBoxColumn.HeaderText = "RFID";
            this.rFIDDataGridViewTextBoxColumn.Name = "rFIDDataGridViewTextBoxColumn";
            this.rFIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemSetDataGridViewTextBoxColumn
            // 
            this.itemSetDataGridViewTextBoxColumn.DataPropertyName = "Item_Set";
            this.itemSetDataGridViewTextBoxColumn.HeaderText = "Item_Set";
            this.itemSetDataGridViewTextBoxColumn.Name = "itemSetDataGridViewTextBoxColumn";
            this.itemSetDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // studentLastNameDataGridViewTextBoxColumn
            // 
            this.studentLastNameDataGridViewTextBoxColumn.DataPropertyName = "StudentLastName";
            this.studentLastNameDataGridViewTextBoxColumn.HeaderText = "StudentLastName";
            this.studentLastNameDataGridViewTextBoxColumn.Name = "studentLastNameDataGridViewTextBoxColumn";
            this.studentLastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // studentFirstNameDataGridViewTextBoxColumn
            // 
            this.studentFirstNameDataGridViewTextBoxColumn.DataPropertyName = "StudentFirstName";
            this.studentFirstNameDataGridViewTextBoxColumn.HeaderText = "StudentFirstName";
            this.studentFirstNameDataGridViewTextBoxColumn.Name = "studentFirstNameDataGridViewTextBoxColumn";
            this.studentFirstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // studentIDNumberDataGridViewTextBoxColumn
            // 
            this.studentIDNumberDataGridViewTextBoxColumn.DataPropertyName = "StudentIDNumber";
            this.studentIDNumberDataGridViewTextBoxColumn.HeaderText = "StudentIDNumber";
            this.studentIDNumberDataGridViewTextBoxColumn.Name = "studentIDNumberDataGridViewTextBoxColumn";
            this.studentIDNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeDateInDataGridViewTextBoxColumn
            // 
            this.timeDateInDataGridViewTextBoxColumn.DataPropertyName = "Time&DateIn";
            this.timeDateInDataGridViewTextBoxColumn.HeaderText = "Time&DateIn";
            this.timeDateInDataGridViewTextBoxColumn.Name = "timeDateInDataGridViewTextBoxColumn";
            this.timeDateInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // authenticatedByDataGridViewTextBoxColumn
            // 
            this.authenticatedByDataGridViewTextBoxColumn.DataPropertyName = "AuthenticatedBy";
            this.authenticatedByDataGridViewTextBoxColumn.HeaderText = "AuthenticatedBy";
            this.authenticatedByDataGridViewTextBoxColumn.Name = "authenticatedByDataGridViewTextBoxColumn";
            this.authenticatedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // projectNumberDataGridViewTextBoxColumn
            // 
            this.projectNumberDataGridViewTextBoxColumn.DataPropertyName = "ProjectNumber";
            this.projectNumberDataGridViewTextBoxColumn.HeaderText = "ProjectNumber";
            this.projectNumberDataGridViewTextBoxColumn.Name = "projectNumberDataGridViewTextBoxColumn";
            this.projectNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // projectDescriptionDataGridViewTextBoxColumn
            // 
            this.projectDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ProjectDescription";
            this.projectDescriptionDataGridViewTextBoxColumn.HeaderText = "ProjectDescription";
            this.projectDescriptionDataGridViewTextBoxColumn.Name = "projectDescriptionDataGridViewTextBoxColumn";
            this.projectDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(850, 480);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Status";
            this.Text = "Status";
            this.Load += new System.EventHandler(this.Status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblstatusBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private db_psDataSet db_psDataSet;
        private System.Windows.Forms.BindingSource tblstatusBindingSource;
        private db_psDataSetTableAdapters.tbl_statusTableAdapter tbl_statusTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rFIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentIDNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDateInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authenticatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectDescriptionDataGridViewTextBoxColumn;
    }
}