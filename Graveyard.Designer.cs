
namespace PS2_GUI_Alpha_v2._0
{
    partial class Graveyard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graveyard));
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.db_psDataSet = new PS2_GUI_Alpha_v2._0.db_psDataSet();
            this.tblDecomMachineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_DecomMachineTableAdapter = new PS2_GUI_Alpha_v2._0.db_psDataSetTableAdapters.tbl_DecomMachineTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDecomMachineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Teal;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Impact", 12F);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(844, 455);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(149, 46);
            this.button4.TabIndex = 9;
            this.button4.Text = "Save PDF";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.dataGridView1.DataSource = this.tblDecomMachineBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(981, 437);
            this.dataGridView1.TabIndex = 10;
            // 
            // db_psDataSet
            // 
            this.db_psDataSet.DataSetName = "db_psDataSet";
            this.db_psDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblDecomMachineBindingSource
            // 
            this.tblDecomMachineBindingSource.DataMember = "tbl_DecomMachine";
            this.tblDecomMachineBindingSource.DataSource = this.db_psDataSet;
            // 
            // tbl_DecomMachineTableAdapter
            // 
            this.tbl_DecomMachineTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MachineName";
            this.dataGridViewTextBoxColumn1.HeaderText = "MachineName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductType";
            this.dataGridViewTextBoxColumn2.HeaderText = "ProductType";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Brand";
            this.dataGridViewTextBoxColumn3.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Model/Model_Number";
            this.dataGridViewTextBoxColumn4.HeaderText = "Model/Model_Number";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SerialNumber";
            this.dataGridViewTextBoxColumn5.HeaderText = "SerialNumber";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DateAcquired";
            this.dataGridViewTextBoxColumn6.HeaderText = "DateAcquired";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "InitialConditionofMachine";
            this.dataGridViewTextBoxColumn7.HeaderText = "InitialConditionofMachine";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "MachineCondition";
            this.dataGridViewTextBoxColumn8.HeaderText = "MachineCondition";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "RegisteredBy";
            this.dataGridViewTextBoxColumn9.HeaderText = "RegisteredBy";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DateofRegistration";
            this.dataGridViewTextBoxColumn10.HeaderText = "DateofRegistration";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DateofDecommission";
            this.dataGridViewTextBoxColumn11.HeaderText = "DateofDecommission";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // Graveyard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 511);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Graveyard";
            this.Text = "Decommissioned Machines";
            this.Load += new System.EventHandler(this.Graveyard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDecomMachineBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.DataGridViewTextBoxColumn machineRFIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelModelNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcquiredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialConditionofMachineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineConditionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registeredByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateofRegistrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateofDecommissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private db_psDataSet db_psDataSet;
        private System.Windows.Forms.BindingSource tblDecomMachineBindingSource;
        private db_psDataSetTableAdapters.tbl_DecomMachineTableAdapter tbl_DecomMachineTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    }
}