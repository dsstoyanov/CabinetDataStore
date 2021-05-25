namespace CabinetDataStore.Main
{
    partial class ExaminationsForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpPRM = new System.Windows.Forms.DateTimePicker();
            this.txtOperations = new System.Windows.Forms.TextBox();
            this.txtBirths = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSavePic = new System.Windows.Forms.Button();
            this.btnClearPic = new System.Windows.Forms.Button();
            this.btnChoosePic = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEchography = new System.Windows.Forms.TextBox();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.txtColposcopy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picColposcopy = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.txtRecommendations = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTherapy = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFluorine = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBleeding = new System.Windows.Forms.TextBox();
            this.txtPain = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtExamDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExaminationID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColposcopy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(706, 635);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 49;
            this.btnEdit.Text = "Редактирай";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(583, 635);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 23);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.Text = "Принтирай";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpPRM);
            this.groupBox3.Controls.Add(this.txtOperations);
            this.groupBox3.Controls.Add(this.txtBirths);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(21, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 174);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Анамнеза";
            // 
            // dtpPRM
            // 
            this.dtpPRM.CustomFormat = "";
            this.dtpPRM.Enabled = false;
            this.dtpPRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpPRM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPRM.Location = new System.Drawing.Point(79, 27);
            this.dtpPRM.Name = "dtpPRM";
            this.dtpPRM.Size = new System.Drawing.Size(116, 20);
            this.dtpPRM.TabIndex = 31;
            this.dtpPRM.Value = new System.DateTime(1988, 12, 27, 0, 0, 0, 0);
            // 
            // txtOperations
            // 
            this.txtOperations.Enabled = false;
            this.txtOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOperations.Location = new System.Drawing.Point(79, 103);
            this.txtOperations.Multiline = true;
            this.txtOperations.Name = "txtOperations";
            this.txtOperations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOperations.Size = new System.Drawing.Size(241, 58);
            this.txtOperations.TabIndex = 30;
            // 
            // txtBirths
            // 
            this.txtBirths.Enabled = false;
            this.txtBirths.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBirths.Location = new System.Drawing.Point(79, 65);
            this.txtBirths.Name = "txtBirths";
            this.txtBirths.Size = new System.Drawing.Size(100, 20);
            this.txtBirths.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(18, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Операции";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(18, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Раждания";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "ПРМ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(787, 635);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Отказ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSavePic);
            this.groupBox1.Controls.Add(this.btnClearPic);
            this.groupBox1.Controls.Add(this.btnChoosePic);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEchography);
            this.groupBox1.Controls.Add(this.txtDiagnosis);
            this.groupBox1.Controls.Add(this.txtColposcopy);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.picColposcopy);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtResults);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(21, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 314);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обективни симптоми";
            // 
            // btnSavePic
            // 
            this.btnSavePic.Enabled = false;
            this.btnSavePic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSavePic.Location = new System.Drawing.Point(279, 282);
            this.btnSavePic.Name = "btnSavePic";
            this.btnSavePic.Size = new System.Drawing.Size(116, 25);
            this.btnSavePic.TabIndex = 34;
            this.btnSavePic.Text = "Запиши снимка";
            this.btnSavePic.UseVisualStyleBackColor = true;
            this.btnSavePic.Visible = false;
            this.btnSavePic.Click += new System.EventHandler(this.btnSavePic_Click);
            // 
            // btnClearPic
            // 
            this.btnClearPic.Enabled = false;
            this.btnClearPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClearPic.Location = new System.Drawing.Point(70, 282);
            this.btnClearPic.Name = "btnClearPic";
            this.btnClearPic.Size = new System.Drawing.Size(75, 25);
            this.btnClearPic.TabIndex = 32;
            this.btnClearPic.Text = "Изчисти";
            this.btnClearPic.UseVisualStyleBackColor = true;
            this.btnClearPic.Visible = false;
            this.btnClearPic.Click += new System.EventHandler(this.btnClearPic_Click);
            // 
            // btnChoosePic
            // 
            this.btnChoosePic.Enabled = false;
            this.btnChoosePic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChoosePic.Location = new System.Drawing.Point(151, 282);
            this.btnChoosePic.Name = "btnChoosePic";
            this.btnChoosePic.Size = new System.Drawing.Size(122, 25);
            this.btnChoosePic.TabIndex = 27;
            this.btnChoosePic.Text = "Избери снимка";
            this.btnChoosePic.UseVisualStyleBackColor = true;
            this.btnChoosePic.Visible = false;
            this.btnChoosePic.Click += new System.EventHandler(this.btnChoosePic_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(424, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Диагноза";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Снимка колпоскопия";
            // 
            // txtEchography
            // 
            this.txtEchography.Enabled = false;
            this.txtEchography.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtEchography.Location = new System.Drawing.Point(427, 43);
            this.txtEchography.Multiline = true;
            this.txtEchography.Name = "txtEchography";
            this.txtEchography.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEchography.Size = new System.Drawing.Size(515, 60);
            this.txtEchography.TabIndex = 11;
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Enabled = false;
            this.txtDiagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDiagnosis.Location = new System.Drawing.Point(427, 127);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosis.Size = new System.Drawing.Size(515, 61);
            this.txtDiagnosis.TabIndex = 32;
            // 
            // txtColposcopy
            // 
            this.txtColposcopy.Enabled = false;
            this.txtColposcopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtColposcopy.Location = new System.Drawing.Point(18, 43);
            this.txtColposcopy.Multiline = true;
            this.txtColposcopy.Name = "txtColposcopy";
            this.txtColposcopy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtColposcopy.Size = new System.Drawing.Size(377, 42);
            this.txtColposcopy.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(424, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Ехография";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(15, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Колпоскопия";
            // 
            // picColposcopy
            // 
            this.picColposcopy.BackColor = System.Drawing.Color.White;
            this.picColposcopy.Location = new System.Drawing.Point(15, 106);
            this.picColposcopy.Name = "picColposcopy";
            this.picColposcopy.Size = new System.Drawing.Size(380, 170);
            this.picColposcopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picColposcopy.TabIndex = 12;
            this.picColposcopy.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(424, 193);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Резултати от изследвания";
            // 
            // txtResults
            // 
            this.txtResults.Enabled = false;
            this.txtResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtResults.Location = new System.Drawing.Point(427, 209);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(513, 67);
            this.txtResults.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(868, 635);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Запис";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(502, 635);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 44;
            this.btnNew.Text = "Създай нов";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(115, 635);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 43;
            this.btnNext.Text = "Следващ";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(34, 635);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 42;
            this.btnPrevious.Text = "Предишен";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Visible = false;
            // 
            // txtRecommendations
            // 
            this.txtRecommendations.Enabled = false;
            this.txtRecommendations.Location = new System.Drawing.Point(516, 552);
            this.txtRecommendations.Multiline = true;
            this.txtRecommendations.Name = "txtRecommendations";
            this.txtRecommendations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecommendations.Size = new System.Drawing.Size(450, 73);
            this.txtRecommendations.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(513, 536);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Препоръки";
            // 
            // txtTherapy
            // 
            this.txtTherapy.Enabled = false;
            this.txtTherapy.Location = new System.Drawing.Point(21, 552);
            this.txtTherapy.Multiline = true;
            this.txtTherapy.Name = "txtTherapy";
            this.txtTherapy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTherapy.Size = new System.Drawing.Size(471, 73);
            this.txtTherapy.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 536);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Терапия";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOther);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtFluorine);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtBleeding);
            this.groupBox2.Controls.Add(this.txtPain);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(401, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 174);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Оплаквания";
            // 
            // txtOther
            // 
            this.txtOther.Enabled = false;
            this.txtOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOther.Location = new System.Drawing.Point(306, 121);
            this.txtOther.Multiline = true;
            this.txtOther.Name = "txtOther";
            this.txtOther.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOther.Size = new System.Drawing.Size(261, 40);
            this.txtOther.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(303, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Други";
            // 
            // txtFluorine
            // 
            this.txtFluorine.Enabled = false;
            this.txtFluorine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFluorine.Location = new System.Drawing.Point(306, 41);
            this.txtFluorine.Multiline = true;
            this.txtFluorine.Name = "txtFluorine";
            this.txtFluorine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFluorine.Size = new System.Drawing.Size(261, 47);
            this.txtFluorine.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(305, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Флуор";
            // 
            // txtBleeding
            // 
            this.txtBleeding.Enabled = false;
            this.txtBleeding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBleeding.Location = new System.Drawing.Point(21, 119);
            this.txtBleeding.Multiline = true;
            this.txtBleeding.Name = "txtBleeding";
            this.txtBleeding.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBleeding.Size = new System.Drawing.Size(261, 42);
            this.txtBleeding.TabIndex = 11;
            // 
            // txtPain
            // 
            this.txtPain.Enabled = false;
            this.txtPain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPain.Location = new System.Drawing.Point(21, 43);
            this.txtPain.Multiline = true;
            this.txtPain.Name = "txtPain";
            this.txtPain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPain.Size = new System.Drawing.Size(261, 45);
            this.txtPain.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(18, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Кървене";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(18, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Болка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Пациент";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(563, 9);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(307, 20);
            this.txtPatientName.TabIndex = 34;
            this.txtPatientName.TabStop = false;
            // 
            // txtExamDate
            // 
            this.txtExamDate.BackColor = System.Drawing.Color.White;
            this.txtExamDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtExamDate.ForeColor = System.Drawing.Color.Black;
            this.txtExamDate.Location = new System.Drawing.Point(221, 9);
            this.txtExamDate.Name = "txtExamDate";
            this.txtExamDate.ReadOnly = true;
            this.txtExamDate.Size = new System.Drawing.Size(161, 20);
            this.txtExamDate.TabIndex = 33;
            this.txtExamDate.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Дата/час";
            // 
            // txtExaminationID
            // 
            this.txtExaminationID.Enabled = false;
            this.txtExaminationID.Location = new System.Drawing.Point(39, 9);
            this.txtExaminationID.Name = "txtExaminationID";
            this.txtExaminationID.Size = new System.Drawing.Size(85, 20);
            this.txtExaminationID.TabIndex = 50;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(8, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 18);
            this.label17.TabIndex = 51;
            this.label17.Text = "N:";
            // 
            // ExaminationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 679);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtExaminationID);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.txtRecommendations);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTherapy);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.txtExamDate);
            this.Controls.Add(this.label1);
            this.Name = "ExaminationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examinations";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColposcopy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpPRM;
        private System.Windows.Forms.TextBox txtOperations;
        private System.Windows.Forms.TextBox txtBirths;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSavePic;
        private System.Windows.Forms.Button btnClearPic;
        private System.Windows.Forms.Button btnChoosePic;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEchography;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.TextBox txtColposcopy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picColposcopy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TextBox txtRecommendations;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTherapy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFluorine;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBleeding;
        private System.Windows.Forms.TextBox txtPain;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtExamDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExaminationID;
        private System.Windows.Forms.Label label17;
    }
}