namespace CabinetDataStore.Main
{
    partial class SMSReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.smsReportView = new System.Windows.Forms.DataGridView();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NotificationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.smsReportView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // smsReportView
            // 
            this.smsReportView.AllowUserToAddRows = false;
            this.smsReportView.AllowUserToDeleteRows = false;
            this.smsReportView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smsReportView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.smsReportView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.smsReportView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.smsReportView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.smsReportView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.smsReportView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NotificationId,
            this.ExamDate,
            this.Patient,
            this.GSM,
            this.columnChk,
            this.PatientId,
            this.ExaminationId});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.smsReportView.DefaultCellStyle = dataGridViewCellStyle3;
            this.smsReportView.EnableHeadersVisualStyles = false;
            this.smsReportView.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.smsReportView.Location = new System.Drawing.Point(51, 186);
            this.smsReportView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.smsReportView.Name = "smsReportView";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.smsReportView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.smsReportView.RowHeadersVisible = false;
            this.smsReportView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.smsReportView.RowTemplate.DefaultCellStyle.Format = "T";
            this.smsReportView.RowTemplate.DefaultCellStyle.NullValue = null;
            this.smsReportView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.smsReportView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.smsReportView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.smsReportView.Size = new System.Drawing.Size(1096, 477);
            this.smsReportView.TabIndex = 12;
            this.smsReportView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.smsReportView_CellContentClick);
            this.smsReportView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.smsReportView_CellValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(81, 75);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(142, 26);
            this.dtFrom.TabIndex = 30;
            this.dtFrom.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.comboFilter);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Location = new System.Drawing.Point(51, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(465, 158);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Филтри";
            // 
            // comboFilter
            // 
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Items.AddRange(new object[] {
            "Преди година",
            "Преди месец",
            "Преди седмица",
            "Ръчно търсене"});
            this.comboFilter.Location = new System.Drawing.Point(34, 34);
            this.comboFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(398, 28);
            this.comboFilter.TabIndex = 36;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "ОТ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(261, 111);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(174, 35);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Приложи";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "ДО";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(81, 115);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(142, 26);
            this.dtTo.TabIndex = 32;
            this.dtTo.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(1070, 18);
            this.send.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(112, 35);
            this.send.TabIndex = 32;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Visible = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(969, 669);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "label1";
            // 
            // NotificationId
            // 
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Lime;
            this.NotificationId.DefaultCellStyle = dataGridViewCellStyle2;
            this.NotificationId.FillWeight = 23.88599F;
            this.NotificationId.HeaderText = "";
            this.NotificationId.Name = "NotificationId";
            this.NotificationId.ReadOnly = true;
            this.NotificationId.Visible = false;
            // 
            // ExamDate
            // 
            this.ExamDate.FillWeight = 175.6927F;
            this.ExamDate.HeaderText = "Дата на преглед";
            this.ExamDate.Name = "ExamDate";
            // 
            // Patient
            // 
            this.Patient.FillWeight = 170.1873F;
            this.Patient.HeaderText = "Пациент";
            this.Patient.Name = "Patient";
            // 
            // GSM
            // 
            this.GSM.FillWeight = 81.7028F;
            this.GSM.HeaderText = "Телефон";
            this.GSM.Name = "GSM";
            // 
            // columnChk
            // 
            this.columnChk.FillWeight = 60.9137F;
            this.columnChk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.columnChk.HeaderText = "Известил";
            this.columnChk.Name = "columnChk";
            this.columnChk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnChk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PatientId
            // 
            this.PatientId.HeaderText = "";
            this.PatientId.Name = "PatientId";
            this.PatientId.Visible = false;
            // 
            // ExaminationId
            // 
            this.ExaminationId.HeaderText = "";
            this.ExaminationId.Name = "ExaminationId";
            this.ExaminationId.Visible = false;
            // 
            // SMSReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.send);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.smsReportView);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SMSReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка годишни известия";
            this.Load += new System.EventHandler(this.SMSReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.smsReportView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView smsReportView;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.ComboBox comboFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotificationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationId;
    }
}