namespace CabinetDataStore.Main
{
    partial class PatientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRefusal = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewPatient = new System.Windows.Forms.Button();
            this.grpPatientData = new System.Windows.Forms.GroupBox();
            this.addNewExamButton = new System.Windows.Forms.Button();
            this.dtBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPatientPhone = new System.Windows.Forms.TextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.srchButton = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.dtFilterDate = new System.Windows.Forms.DateTimePicker();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.refreshExamDate = new System.Windows.Forms.Button();
            this.pickExam = new System.Windows.Forms.DateTimePicker();
            this.dgvDaily = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.pID = new System.Windows.Forms.TextBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examinationsCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.направиАрхивНаБазатаДанниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpPatientData.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaily)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefusal
            // 
            this.btnRefusal.Enabled = false;
            this.btnRefusal.Location = new System.Drawing.Point(945, 548);
            this.btnRefusal.Name = "btnRefusal";
            this.btnRefusal.Size = new System.Drawing.Size(75, 23);
            this.btnRefusal.TabIndex = 28;
            this.btnRefusal.Text = "Отказ";
            this.btnRefusal.UseVisualStyleBackColor = true;
            this.btnRefusal.Click += new System.EventHandler(this.btnRefusal_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(722, 548);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 23);
            this.btnEdit.TabIndex = 27;
            this.btnEdit.Text = "Редактирай";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(1026, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Запис";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.Location = new System.Drawing.Point(809, 548);
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(131, 23);
            this.btnNewPatient.TabIndex = 23;
            this.btnNewPatient.Text = "Добави нов пациент";
            this.btnNewPatient.UseVisualStyleBackColor = true;
            this.btnNewPatient.Click += new System.EventHandler(this.btnNewPatient_Click);
            // 
            // grpPatientData
            // 
            this.grpPatientData.Controls.Add(this.addNewExamButton);
            this.grpPatientData.Controls.Add(this.dtBirthDate);
            this.grpPatientData.Controls.Add(this.txtAge);
            this.grpPatientData.Controls.Add(this.txtEmail);
            this.grpPatientData.Controls.Add(this.txtPatientPhone);
            this.grpPatientData.Controls.Add(this.txtPatientName);
            this.grpPatientData.Controls.Add(this.label6);
            this.grpPatientData.Controls.Add(this.label5);
            this.grpPatientData.Controls.Add(this.label4);
            this.grpPatientData.Controls.Add(this.label1);
            this.grpPatientData.Controls.Add(this.label2);
            this.grpPatientData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpPatientData.Location = new System.Drawing.Point(12, 134);
            this.grpPatientData.Name = "grpPatientData";
            this.grpPatientData.Size = new System.Drawing.Size(495, 149);
            this.grpPatientData.TabIndex = 21;
            this.grpPatientData.TabStop = false;
            this.grpPatientData.Text = "Пациент";
            // 
            // addNewExamButton
            // 
            this.addNewExamButton.Location = new System.Drawing.Point(367, 103);
            this.addNewExamButton.Name = "addNewExamButton";
            this.addNewExamButton.Size = new System.Drawing.Size(116, 34);
            this.addNewExamButton.TabIndex = 30;
            this.addNewExamButton.Text = "Нов Преглед";
            this.addNewExamButton.UseVisualStyleBackColor = true;
            this.addNewExamButton.Click += new System.EventHandler(this.addNewExamButton_Click);
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.Enabled = false;
            this.dtBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBirthDate.Location = new System.Drawing.Point(113, 72);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(222, 20);
            this.dtBirthDate.TabIndex = 29;
            this.dtBirthDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAge.Location = new System.Drawing.Point(399, 75);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(84, 20);
            this.txtAge.TabIndex = 28;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtEmail.Location = new System.Drawing.Point(47, 111);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(294, 20);
            this.txtEmail.TabIndex = 27;
            // 
            // txtPatientPhone
            // 
            this.txtPatientPhone.Enabled = false;
            this.txtPatientPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPatientPhone.Location = new System.Drawing.Point(399, 41);
            this.txtPatientPhone.Name = "txtPatientPhone";
            this.txtPatientPhone.Size = new System.Drawing.Size(84, 20);
            this.txtPatientPhone.TabIndex = 26;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Enabled = false;
            this.txtPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPatientName.Location = new System.Drawing.Point(41, 41);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(294, 20);
            this.txtPatientName.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(350, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Години";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Дата на раждане";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "E-mail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Име";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(341, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Телефон";
            // 
            // srchButton
            // 
            this.srchButton.Location = new System.Drawing.Point(400, 91);
            this.srchButton.Name = "srchButton";
            this.srchButton.Size = new System.Drawing.Size(95, 23);
            this.srchButton.TabIndex = 15;
            this.srchButton.Text = "Търси";
            this.srchButton.UseVisualStyleBackColor = true;
            this.srchButton.Click += new System.EventHandler(this.srchButton_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFilter.Location = new System.Drawing.Point(177, 21);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFilter.Size = new System.Drawing.Size(275, 22);
            this.txtFilter.TabIndex = 19;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // dtFilterDate
            // 
            this.dtFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFilterDate.Location = new System.Drawing.Point(177, 21);
            this.dtFilterDate.Name = "dtFilterDate";
            this.dtFilterDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtFilterDate.Size = new System.Drawing.Size(194, 22);
            this.dtFilterDate.TabIndex = 26;
            this.dtFilterDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // comboFilter
            // 
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Items.AddRange(new object[] {
            "Име",
            "Телефон",
            "Дата на раждане"});
            this.comboFilter.Location = new System.Drawing.Point(6, 21);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(165, 24);
            this.comboFilter.TabIndex = 30;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboFilter);
            this.groupBox4.Controls.Add(this.txtFilter);
            this.groupBox4.Controls.Add(this.dtFilterDate);
            this.groupBox4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(12, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(483, 59);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Филтър";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.refreshExamDate);
            this.groupBox3.Controls.Add(this.pickExam);
            this.groupBox3.Controls.Add(this.dgvDaily);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(513, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 257);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прегледи за ден";
            // 
            // refreshExamDate
            // 
            this.refreshExamDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshExamDate.BackgroundImage")));
            this.refreshExamDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refreshExamDate.Location = new System.Drawing.Point(155, 13);
            this.refreshExamDate.Name = "refreshExamDate";
            this.refreshExamDate.Size = new System.Drawing.Size(39, 32);
            this.refreshExamDate.TabIndex = 31;
            this.refreshExamDate.UseVisualStyleBackColor = true;
            this.refreshExamDate.Click += new System.EventHandler(this.refreshExamDate_Click);
            // 
            // pickExam
            // 
            this.pickExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pickExam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickExam.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.pickExam.Location = new System.Drawing.Point(15, 20);
            this.pickExam.Name = "pickExam";
            this.pickExam.Size = new System.Drawing.Size(134, 20);
            this.pickExam.TabIndex = 30;
            this.pickExam.Value = new System.DateTime(2023, 2, 11, 0, 0, 0, 0);
            // 
            // dgvDaily
            // 
            this.dgvDaily.AllowUserToAddRows = false;
            this.dgvDaily.AllowUserToDeleteRows = false;
            this.dgvDaily.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDaily.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDaily.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDaily.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDaily.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDaily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaily.EnableHeadersVisualStyles = false;
            this.dgvDaily.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDaily.Location = new System.Drawing.Point(15, 49);
            this.dgvDaily.Name = "dgvDaily";
            this.dgvDaily.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDaily.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDaily.RowHeadersVisible = false;
            this.dgvDaily.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvDaily.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDaily.RowTemplate.DefaultCellStyle.Format = "T";
            this.dgvDaily.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvDaily.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvDaily.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDaily.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDaily.Size = new System.Drawing.Size(562, 190);
            this.dgvDaily.TabIndex = 11;
            this.dgvDaily.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDaily_CellMouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAll);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1094, 253);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Всички прегледи на пациента";
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            this.dgvAll.AllowUserToDeleteRows = false;
            this.dgvAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAll.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAll.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAll.EnableHeadersVisualStyles = false;
            this.dgvAll.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAll.Location = new System.Drawing.Point(15, 31);
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.ReadOnly = true;
            this.dgvAll.RowHeadersVisible = false;
            this.dgvAll.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvAll.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAll.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvAll.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvAll.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.Size = new System.Drawing.Size(1063, 204);
            this.dgvAll.TabIndex = 11;
            this.dgvAll.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAll_CellMouseDoubleClick);
            // 
            // pID
            // 
            this.pID.Location = new System.Drawing.Point(12, 91);
            this.pID.Name = "pID";
            this.pID.Size = new System.Drawing.Size(81, 20);
            this.pID.TabIndex = 35;
            this.pID.Visible = false;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 20000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // timerProgress
            // 
            this.timerProgress.Interval = 1000;
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкиToolStripMenuItem,
            this.файлToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справкиToolStripMenuItem
            // 
            this.справкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientsCountToolStripMenuItem,
            this.examinationsCountToolStripMenuItem});
            this.справкиToolStripMenuItem.Name = "справкиToolStripMenuItem";
            this.справкиToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.справкиToolStripMenuItem.Text = "Справки";
            // 
            // patientsCountToolStripMenuItem
            // 
            this.patientsCountToolStripMenuItem.Name = "patientsCountToolStripMenuItem";
            this.patientsCountToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.patientsCountToolStripMenuItem.Text = "Брой пациенти";
            this.patientsCountToolStripMenuItem.Click += new System.EventHandler(this.patientsCountToolStripMenuItem_Click);
            // 
            // examinationsCountToolStripMenuItem
            // 
            this.examinationsCountToolStripMenuItem.Name = "examinationsCountToolStripMenuItem";
            this.examinationsCountToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.examinationsCountToolStripMenuItem.Text = "Брой прегледи";
            this.examinationsCountToolStripMenuItem.Click += new System.EventHandler(this.examinationsCountToolStripMenuItem_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.направиАрхивНаБазатаДанниToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.файлToolStripMenuItem.Text = "Операции";
            // 
            // направиАрхивНаБазатаДанниToolStripMenuItem
            // 
            this.направиАрхивНаБазатаДанниToolStripMenuItem.Name = "направиАрхивНаБазатаДанниToolStripMenuItem";
            this.направиАрхивНаБазатаДанниToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.направиАрхивНаБазатаДанниToolStripMenuItem.Text = "Database архив";
            this.направиАрхивНаБазатаДанниToolStripMenuItem.Click += new System.EventHandler(this.archiveDatabaseToolStripMenuItem_Click);
            
            // 
            // PatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 575);
            this.Controls.Add(this.pID);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnRefusal);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.srchButton);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNewPatient);
            this.Controls.Add(this.grpPatientData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PatientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patients Data";
            this.Activated += new System.EventHandler(this.PatientForm_Activated);
            this.Load += new System.EventHandler(this.PatientForm_Load);
            this.grpPatientData.ResumeLayout(false);
            this.grpPatientData.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaily)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefusal;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewPatient;
        private System.Windows.Forms.GroupBox grpPatientData;
        private System.Windows.Forms.Button srchButton;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DateTimePicker dtFilterDate;
        private System.Windows.Forms.ComboBox comboFilter;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDaily;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPatientPhone;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.Button addNewExamButton;
        private System.Windows.Forms.TextBox pID;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Timer timerProgress;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem направиАрхивНаБазатаДанниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientsCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examinationsCountToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker pickExam;
        private System.Windows.Forms.Button refreshExamDate;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}

