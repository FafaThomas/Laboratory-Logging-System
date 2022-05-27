
namespace PS2_GUI_Alpha_v2._0
{
    partial class EventLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLogs));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.FilterDateOut = new System.Windows.Forms.DateTimePicker();
            this.label40 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.FilterDateIN = new System.Windows.Forms.DateTimePicker();
            this.db_psDataSet = new PS2_GUI_Alpha_v2._0.db_psDataSet();
            this.tblEventLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_EventLogsTableAdapter = new PS2_GUI_Alpha_v2._0.db_psDataSetTableAdapters.tbl_EventLogsTableAdapter();
            this.eventDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEventLogsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventDataGridViewTextBoxColumn,
            this.dateTimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblEventLogsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(769, 378);
            this.dataGridView1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Teal;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Impact", 12F);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(647, 396);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 34);
            this.button4.TabIndex = 10;
            this.button4.Text = "Save PDF";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Teal;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Impact", 9.75F);
            this.button11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button11.Location = new System.Drawing.Point(475, 396);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(80, 34);
            this.button11.TabIndex = 56;
            this.button11.Text = "Filter";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Impact", 9.75F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(561, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 34);
            this.button1.TabIndex = 61;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FilterDateOut
            // 
            this.FilterDateOut.CalendarFont = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateOut.Font = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FilterDateOut.Location = new System.Drawing.Point(335, 402);
            this.FilterDateOut.Name = "FilterDateOut";
            this.FilterDateOut.Size = new System.Drawing.Size(116, 21);
            this.FilterDateOut.TabIndex = 60;
            this.FilterDateOut.DropDown += new System.EventHandler(this.FilterDateOut_DropDown);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label40.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label40.ForeColor = System.Drawing.Color.Teal;
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(130, 406);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 15);
            this.label40.TabIndex = 57;
            this.label40.Text = "From";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label43.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label43.ForeColor = System.Drawing.Color.Teal;
            this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label43.Location = new System.Drawing.Point(311, 403);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(18, 15);
            this.label43.TabIndex = 58;
            this.label43.Text = "To";
            this.label43.Click += new System.EventHandler(this.label43_Click);
            // 
            // FilterDateIN
            // 
            this.FilterDateIN.CalendarFont = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateIN.Font = new System.Drawing.Font("Impact", 8.25F);
            this.FilterDateIN.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FilterDateIN.Location = new System.Drawing.Point(165, 403);
            this.FilterDateIN.Name = "FilterDateIN";
            this.FilterDateIN.Size = new System.Drawing.Size(116, 21);
            this.FilterDateIN.TabIndex = 59;
            this.FilterDateIN.ValueChanged += new System.EventHandler(this.FilterDateIN_ValueChanged);
            // 
            // db_psDataSet
            // 
            this.db_psDataSet.DataSetName = "db_psDataSet";
            this.db_psDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblEventLogsBindingSource
            // 
            this.tblEventLogsBindingSource.DataMember = "tbl_EventLogs";
            this.tblEventLogsBindingSource.DataSource = this.db_psDataSet;
            // 
            // tbl_EventLogsTableAdapter
            // 
            this.tbl_EventLogsTableAdapter.ClearBeforeFill = true;
            // 
            // eventDataGridViewTextBoxColumn
            // 
            this.eventDataGridViewTextBoxColumn.DataPropertyName = "Event";
            this.eventDataGridViewTextBoxColumn.HeaderText = "Event";
            this.eventDataGridViewTextBoxColumn.Name = "eventDataGridViewTextBoxColumn";
            this.eventDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateTimeDataGridViewTextBoxColumn
            // 
            this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "Date&Time";
            this.dateTimeDataGridViewTextBoxColumn.HeaderText = "Date&Time";
            this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
            this.dateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // EventLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 436);
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
            this.Name = "EventLogs";
            this.Text = "Event Logs";
            this.Load += new System.EventHandler(this.EventLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_psDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEventLogsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker FilterDateOut;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.DateTimePicker FilterDateIN;
        private db_psDataSet db_psDataSet;
        private System.Windows.Forms.BindingSource tblEventLogsBindingSource;
        private db_psDataSetTableAdapters.tbl_EventLogsTableAdapter tbl_EventLogsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
    }
}