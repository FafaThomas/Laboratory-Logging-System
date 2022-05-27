
namespace PS2_GUI_Alpha_v2._0
{
    partial class MachineRegistry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineRegistry));
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.db_psDataSet = new PS2_GUI_Alpha_v2._0.db_psDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_MachineRegistryTableAdapter = new PS2_GUI_Alpha_v2._0.db_psDataSetTableAdapters.tbl_MachineRegistryTableAdapter();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19});
            this.dataGridView2.DataSource = this.bindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(12, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1048, 492);
            this.dataGridView2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Impact", 12F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(744, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save PDF";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Impact", 10F);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Location = new System.Drawing.Point(911, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Decommissioned Machines";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // db_psDataSet
            // 
            this.db_psDataSet.DataSetName = "db_psDataSet";
            this.db_psDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "tbl_MachineRegistry";
            this.bindingSource1.DataSource = this.db_psDataSet;
            // 
            // tbl_MachineRegistryTableAdapter
            // 
            this.tbl_MachineRegistryTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MachineName";
            this.dataGridViewTextBoxColumn10.HeaderText = "MachineName";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ProductType";
            this.dataGridViewTextBoxColumn11.HeaderText = "ProductType";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Brand";
            this.dataGridViewTextBoxColumn12.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Model/Model_Number";
            this.dataGridViewTextBoxColumn13.HeaderText = "Model/Model_Number";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "SerialNumber";
            this.dataGridViewTextBoxColumn14.HeaderText = "SerialNumber";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "DateAcquired";
            this.dataGridViewTextBoxColumn15.HeaderText = "DateAcquired";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "InitialConditionofMachine";
            this.dataGridViewTextBoxColumn16.HeaderText = "InitialConditionofMachine";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "MachineCondition";
            this.dataGridViewTextBoxColumn17.HeaderText = "MachineCondition";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "RegisteredBy";
            this.dataGridViewTextBoxColumn18.HeaderText = "RegisteredBy";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "DateofRegistration";
            this.dataGridViewTextBoxColumn19.HeaderText = "DateofRegistration";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // MachineRegistry
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1072, 569);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MachineRegistry";
            this.Text = "Machine Registry";
            this.Load += new System.EventHandler(this.MachineRegistry_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelModelNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcquiredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialConditionOfMachineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineConditionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registeredByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfRegistrationDataGridViewTextBoxColumn;
       
        private System.Windows.Forms.BindingSource tblMachineRegistryBindingSource;
     
        private System.Windows.Forms.DataGridViewTextBoxColumn machineRFIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private db_psDataSet db_psDataSet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private db_psDataSetTableAdapters.tbl_MachineRegistryTableAdapter tbl_MachineRegistryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
    }
}