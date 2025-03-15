using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.Business.Models;
using CabinetDataStore.BusinessService.ExaminationModels;
using CabinetDataStore.BusinessService.PatientModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetDataStore.Main
{
    public partial class ExaminationsForm : Form
    {
        private readonly IPatient patientService;
        private readonly IExamination examinationService;
        private readonly PatientModel Patient;
        private readonly ExaminationModel Examination;
        private readonly bool isForEdit = false;
        private string printName = string.Empty;

        public ExaminationsForm(PatientModel Patient, IPatient patientService, IExamination examinationService)
        {
            InitializeComponent();
            this.Patient = Patient;
            this.patientService = patientService;
            this.examinationService = examinationService;

            txtPatientName.Text = Patient.PatientName + " - Години: " + PatientForm.AgeCalculator(DateTime.Now, Patient.BirthDate).ToString();
            printName = Patient.PatientName + " - " + PatientForm.AgeCalculator(DateTime.Now, Patient.BirthDate).ToString() + "г.";
            txtExamDate.Text = DateTime.Now.ToString();

            NewExaminationProperties(false);

            this.Focus();
        }

        public ExaminationsForm(PatientModel Patient, ExaminationModel Examination, IPatient patientService, IExamination examinationService, bool isForEdit)
        {
            InitializeComponent();
            this.patientService = patientService;
            this.examinationService = examinationService;
            this.Patient = Patient;
            this.Examination = Examination;
            this.isForEdit = isForEdit;
            LoadExamination(this.Patient, this.Examination);
        }

        private void LoadExamination(PatientModel patient, ExaminationModel examination)
        {
            Logger.LoggerManager.Informational($"Load Examination with ID: [{examination.ExaminationID}] for Patient with ID: [{patient.PatientId}] Name: {patient.PatientName}");
            DisableAllActions(false);
            txtExaminationID.Text = examination.ExaminationID.ToString();
            btnPrint.Visible = true;
            txtPatientName.Text = patient.PatientName + " - Години: " + PatientForm.AgeCalculator(examination.ExaminationDate, patient.BirthDate).ToString();
            printName = patient.PatientName + " - " + PatientForm.AgeCalculator(examination.ExaminationDate, Patient.BirthDate).ToString() + "г.";
            txtExamDate.Text = Convert.ToString(examination.ExaminationDate);
            txtDiagnosis.Text = examination.Diagnosis;
            txtBirths.Text = examination.BirthsCount.ToString();
            txtOperations.Text = examination.Operations;
            txtColposcopy.Text = examination.Colposcopy;
            txtEchography.Text = examination.Echography;
            txtBleeding.Text = examination.Bleeding;
            txtPain.Text = examination.Pain;
            txtFluorine.Text = examination.Fluorine;
            txtOther.Text = examination.Others;
            txtResults.Text = examination.Results;
            txtTherapy.Text = examination.Therapy;
            txtRecommendations.Text = examination.Recommendations;
            if (examination.Photo != null && examination.Photo.Count() > 0)
            {
                MemoryStream ms = new MemoryStream();
                ms = new MemoryStream(examination.Photo);
                picColposcopy.Image = Image.FromStream(ms);
                btnSavePic.Enabled = false;
                btnClearPic.Enabled = false;
            }
            if (examination.PRM == DateTime.MinValue)
            {
                examination.PRM = DateTime.Now;
            }
            dtpPRM.Text = Convert.ToString(examination.PRM);
        }

        private void DisableAllActions(bool isForEdit)
        {
            txtDiagnosis.Enabled = false;
            txtBirths.Enabled = false;
            txtOperations.Enabled = false;
            txtColposcopy.Enabled = false;
            txtEchography.Enabled = false;
            txtBleeding.Enabled = false;
            txtPain.Enabled = false;
            txtFluorine.Enabled = false;
            txtOther.Enabled = false;
            txtResults.Enabled = false;
            txtTherapy.Enabled = false;
            txtRecommendations.Enabled = false;
            btnSave.Visible = true;
            btnEdit.Visible = true;
            btnCancel.Visible = true;
            btnChoosePic.Visible = true;
            btnChoosePic.Enabled = false;
            btnClearPic.Visible = true;
            btnClearPic.Enabled = false;
            btnSavePic.Visible = true;
            btnSavePic.Enabled = false;
            dtpPRM.Enabled = false;
            if(!isForEdit)
            dtpPRM.Text = Convert.ToString(dtpPRM.MinDate);
        }

        private void NewExaminationProperties(bool isEdit)
        {
            txtDiagnosis.Enabled = true;
            txtBirths.Enabled = true;
            txtOperations.Enabled = true;
            txtColposcopy.Enabled = true;
            txtEchography.Enabled = true;
            txtBleeding.Enabled = true;
            txtPain.Enabled = true;
            txtFluorine.Enabled = true;
            txtOther.Enabled = true;
            txtResults.Enabled = true;
            txtTherapy.Enabled = true;
            txtRecommendations.Enabled = true;
            btnSave.Visible = true;
            btnEdit.Visible = true;
            btnCancel.Visible = true;
            btnChoosePic.Visible = true;
            btnChoosePic.Enabled = true;
            btnClearPic.Visible = true;
            btnClearPic.Enabled = true;
            btnSavePic.Visible = true;
            btnSavePic.Enabled = true;
            dtpPRM.Enabled = true;
            btnPrint.Visible = true;
            if (!isEdit)
            {
                dtpPRM.Text = Convert.ToString(dtpPRM.MinDate);
                Logger.LoggerManager.Informational($"Create new examination for Patient ID: [{Patient?.PatientId}] {Patient?.PatientName}");
            }
            else
            {
                Logger.LoggerManager.Informational($"Edit examination for Patient ID: [{Patient?.PatientId}] {Patient?.PatientName}");
            }
        }

        private void btnChoosePic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog newdialog = new OpenFileDialog();
                newdialog.Filter = "Jpg files (*jpg)|*jpg";
                newdialog.InitialDirectory = @"C:\";
                if (newdialog.ShowDialog() == DialogResult.OK)
                {
                    picColposcopy.Image = Image.FromFile(newdialog.FileName);
                }
                else
                {
                    if (picColposcopy.Image == null)
                    {
                        picColposcopy.Image = null;
                    }
                }
            }
            catch
            {
                picColposcopy.Image = null;
            }
        }

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            if (picColposcopy.Image == null)
            {
                MessageBox.Show("Не сте приложили снимка", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Image img = picColposcopy.Image;

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "JPEG Image(.jpeg)|*.jpeg|Bitmap Image(.bmp)|*.bmp|Gif Image(.gif)|*.gif|Png Image(.png)|*.png|Tiff Image(.tiff)|*.tiff|Wmf Image(.wmf)|*.wmf";
                dialog.DefaultExt = "jpeg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    img.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = "Да запишем ли промените, който направихте?";
            string caption = "Информация";
           
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2,
            MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                MessageBox.Show("Промените НЕ бяха записани", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.LoggerManager.Informational($"Create or Edit was canceled for Examination ID: [{Examination?.ExaminationID}]. Patient ID: [{Patient?.PatientId}] {Patient?.PatientName}");
                this.Close();
            }
            else
            {
                ExaminationModel model = new ExaminationModel();
                if (isForEdit)
                {
                    MemoryStream ms = new MemoryStream();
                    if (string.IsNullOrEmpty(txtBirths.Text))
                        model.BirthsCount = 0;
                    else
                        model.BirthsCount = int.Parse(txtBirths.Text);
                    if (picColposcopy.Image != null)
                    {
                        picColposcopy.Image.Save(ms, picColposcopy.Image.RawFormat);
                        model.Photo = ms.GetBuffer();
                    }
                    model.PatientId = Patient.PatientId;
                    model.Bleeding = txtBleeding.Text;
                    model.Colposcopy = txtColposcopy.Text;
                    model.Diagnosis = txtDiagnosis.Text;
                    model.Echography = txtEchography.Text;
                    model.ExaminationDate = DateTime.Now;
                    model.Fluorine = txtFluorine.Text;
                    model.Operations = txtOperations.Text;
                    model.Others = txtOther.Text;
                    model.Pain = txtPain.Text;
                    model.PRM = Convert.ToDateTime(dtpPRM.Text);
                    model.Recommendations = txtRecommendations.Text;
                    model.Results = txtResults.Text;
                    model.Therapy = txtTherapy.Text;

                    bool isUpdated = examinationService.UpdateExamination(model, Examination);
                    if (isUpdated)
                    {
                        DisableAllActions(true);
                        Logger.LoggerManager.Informational($"Edit completed for Examination ID: [{Examination?.ExaminationID}]. Patient ID: [{Patient?.PatientId}] {Patient?.PatientName}");
                    }
                   
                }
                else
                {
                    
                    MemoryStream ms = new MemoryStream();
                    if (string.IsNullOrEmpty(txtBirths.Text))
                        model.BirthsCount = 0;
                    else
                        model.BirthsCount = int.Parse(txtBirths.Text);
                    if (picColposcopy.Image != null)
                    {
                        picColposcopy.Image.Save(ms, picColposcopy.Image.RawFormat);
                        model.Photo = ms.GetBuffer();
                    }
                    model.PatientId = Patient.PatientId;
                    model.Bleeding = txtBleeding.Text;
                    model.Colposcopy = txtColposcopy.Text;
                    model.Diagnosis = txtDiagnosis.Text;
                    model.Echography = txtEchography.Text;
                    model.ExaminationDate = DateTime.Now;
                    model.Fluorine = txtFluorine.Text;
                    model.Operations = txtOperations.Text;
                    model.Others = txtOther.Text;
                    model.Pain = txtPain.Text;
                    model.PRM = Convert.ToDateTime(dtpPRM.Text);
                    model.Recommendations = txtRecommendations.Text;
                    model.Results = txtResults.Text;
                    model.Therapy = txtTherapy.Text;



                    bool isInserted = examinationService.InsertExamination(model);
                    if (isInserted)
                    {
                        Logger.LoggerManager.Informational($"Created Examination with ID: [{Examination?.ExaminationID}]. Patient ID: [{Patient?.PatientId}] {Patient?.PatientName}");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Промените НЕ бяха записани", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Logger.LoggerManager.Informational($"Examination changes was canceled for ID: [{Examination?.ExaminationID}]. Patient ID: [{Patient?.PatientId}] {Patient?.PatientName}");

            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            if(!PatientForm.useOldPrintVersion)
                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(ExaminationPrintV2); //add an event handler that will do the printing
            else
                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(ExemtionPrint);

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        public static Image resizeimage(Image i, Size size)
        {
            if (i != null)
            {
                i = (Image)(new Bitmap(i, size));
            }
            return i;
        }

        public void ExaminationPrintV2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;



            Font label = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            Font datas = new Font("Arial", 10);
            Font names = new Font("Arial", 12, FontStyle.Bold);
            Font sectionName = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            Font font = new Font("Arial", 9, FontStyle.Bold);
            Font only = new Font("Arial", 7);
            Font footer = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);//font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif
            SolidBrush brush = new SolidBrush(Color.Navy);
            SolidBrush footerBrush = new SolidBrush(Color.Navy);
            SolidBrush defaultBrush = new SolidBrush(Color.Gray);
            Point loc = new Point(0, 0);

            g.DrawImage(CabinetDataStore.Main.Properties.Resources.full_header_2025, loc);

            Point loc1 = new Point(10, 170);
            // g.DrawImage(CabinetDataStore.Main.Properties.Resources.anetka2_2025, loc1);

            Point loc2 = new Point(40, 695);
            Image im = picColposcopy.Image;
            if (im != null)
            {
                // Resize and draw image
                im = resizeimage(im, new Size(327, 215));
                g.DrawImage(im, loc2);
            }

            // Draw the header fields
            g.DrawString(label1.Text + ":", font, brush, new Rectangle(30, 250, 100, 30));
            //g.DrawRectangle(Pens.Black, 90, 247, 170, 20);
            g.FillRectangle(defaultBrush, 100, 266, 150, 1);
            g.DrawString(txtExamDate.Text, datas, brush, new Rectangle(100, 249, 170, 20));

            g.DrawString(label2.Text + ":", font, brush, new Rectangle(325, 250, 100, 30));
            //g.DrawRectangle(Pens.Black, 450, 247, 295, 20);
            g.FillRectangle(defaultBrush, 395, 266, 375, 1);
            g.DrawString(printName, datas, brush, new Rectangle(395, 249, 370, 20));

            // Анамнеза Section
            g.DrawString("Анамнеза", sectionName, brush, new Rectangle(30, 300, 230, 40));
            g.FillRectangle(brush, 30, 320, 350, 3);

            g.DrawString("ПРМ", label, defaultBrush, new Rectangle(40, 330, 130, 20));
            g.FillRectangle(defaultBrush, 40, 345, 140, 1);
            g.DrawString(Convert.ToDateTime(dtpPRM.Text).Year < 1900 ? "N/A" : dtpPRM.Text, datas, defaultBrush, new Rectangle(100, 347, 130, 20));

            g.DrawString("Раждания", label, defaultBrush, new Rectangle(240, 330, 130, 20));
            //g.DrawRectangle(Pens.Black, 120, 360, 140, 20);
            g.FillRectangle(defaultBrush, 240, 345, 140, 1);
            g.DrawString(txtBirths.Text + $" ({getBirthsString(txtBirths.Text, out int diff)})", datas, defaultBrush, new Rectangle(310 + diff, 347, 130, 20));

            g.DrawString("Операции", label, defaultBrush, new Rectangle(40, 390, 350, 20));
            //g.DrawRectangle(Pens.Black, 40, 407, 350, 120);
            g.FillRectangle(defaultBrush, 40, 405, 340, 1);
            g.DrawString(txtOperations.Text, datas, defaultBrush, new Rectangle(40, 407, 350, 120));

            // Оплаквания Section
            g.DrawString("Оплаквания", sectionName, brush, new Rectangle(420, 300, 110, 40));
            g.FillRectangle(brush, 420, 320, 350, 3);

            g.DrawString("Болка", label, defaultBrush, new Rectangle(430, 330, 350, 20));
            //g.DrawRectangle(Pens.Black, 310, 345, 445, 40);
            g.FillRectangle(defaultBrush, 430, 345, 340, 1);
            g.DrawString(txtPain.Text, datas, defaultBrush, new Rectangle(430, 347, 340, 40));

            g.DrawString("Кръвене", label, defaultBrush, new Rectangle(430, 390, 350, 20));
            //g.DrawRectangle(Pens.Black, 310, 405, 445, 40);
            g.FillRectangle(defaultBrush, 430, 405, 340, 1);
            g.DrawString(txtBleeding.Text, datas, defaultBrush, new Rectangle(430, 407, 340, 40));

            g.DrawString("Флуор", label, defaultBrush, new Rectangle(430, 450, 340, 20));
            //g.DrawRectangle(Pens.Black, 310, 465, 445, 40);
            g.FillRectangle(defaultBrush, 430, 465, 340, 1);
            g.DrawString(txtFluorine.Text, datas, defaultBrush, new Rectangle(430, 467, 340, 20));

            if (txtOther.Text.Length < 42)
            {
                g.DrawString("Други", label, defaultBrush, new Rectangle(430, 510, 340, 20));
                //g.DrawRectangle(Pens.Black, 310, 525, 445, 40);
                g.FillRectangle(defaultBrush, 430, 525, 340, 1);
                g.DrawString(txtOther.Text, datas, defaultBrush, new Rectangle(430, 527, 340, 20));
            }
            else
            {
                g.DrawString("Други", label, defaultBrush, new Rectangle(430, 490, 340, 20));
                //g.DrawRectangle(Pens.Black, 310, 525, 445, 40);
                g.FillRectangle(defaultBrush, 430, 505, 340, 1);
                g.DrawString(txtOther.Text, datas, defaultBrush, new Rectangle(430, 507, 340, 60));
            }

            // Обективни симптоми Section
            g.DrawString("Обективни симптоми", sectionName, brush, new Rectangle(30, 560, 230, 40));
            g.FillRectangle(brush, 30, 580, 740, 3);

            g.DrawString("Колпоскопия", label, defaultBrush, new Rectangle(40, 590, 80, 20));
            //g.DrawRectangle(Pens.Black, 40, 545, 340, 70);
            g.FillRectangle(defaultBrush, 40, 605, 340, 1);
            g.DrawString(txtColposcopy.Text, datas, defaultBrush, new Rectangle(40, 607, 340, 70));

            g.DrawString("Снимка Колпоскопия", label, defaultBrush, new Rectangle(40, 680, 200, 20));
            g.FillRectangle(defaultBrush, 40, 695, 340, 1);

            g.DrawString("Ехография", label, defaultBrush, new Rectangle(410, 590, 80, 20));
            //g.DrawRectangle(Pens.Black, 410, 545, 340, 70);
            g.FillRectangle(defaultBrush, 410, 605, 360, 1);
            g.DrawString(txtEchography.Text, datas, defaultBrush, new Rectangle(410, 607, 360, 70));

            g.DrawString("Диагноза", label, defaultBrush, new Rectangle(410, 680, 80, 20));
            //g.DrawRectangle(Pens.Black, 410, 635, 340, 90);
            g.FillRectangle(defaultBrush, 410, 695, 360, 1);
            g.DrawString(txtDiagnosis.Text, datas, defaultBrush, new Rectangle(410, 697, 360, 80));

            g.DrawString("Резултати от изследвания", label, defaultBrush, new Rectangle(410, 790, 200, 20));
            //g.DrawRectangle(Pens.Black, 410, 745, 340, 90);
            g.FillRectangle(defaultBrush, 410, 805, 360, 1);
            g.DrawString(txtResults.Text, datas, defaultBrush, new Rectangle(410, 807, 360, 110));

            // Терапия Section
            g.DrawString("Терапия", sectionName, brush, new Rectangle(30, 920, 230, 40));
            g.FillRectangle(brush, 30, 940, 350, 3);
            //g.DrawRectangle(Pens.Black, 25, 950, 350, 100);
            g.DrawString(txtTherapy.Text, datas, defaultBrush, new Rectangle(30, 952, 350, 100));

            // Препоръки Section
            g.DrawString("Препоръки", sectionName, brush, new Rectangle(420, 920, 230, 40));
            g.FillRectangle(brush, 420, 940, 350, 3);
            //g.DrawRectangle(Pens.Black, 415, 950, 350, 100);
            g.DrawString(txtRecommendations.Text, datas, defaultBrush, new Rectangle(420, 952, 350, 100));



            g.DrawString($"Проф. Явор Корновски | © {DateTime.Now.Year.ToString()}", footer, footerBrush, new Rectangle(600, 1080, 550, 40));


        }

        public void ExemtionPrint(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;



            Font label = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            Font datas = new Font("Arial", 10);
            Font names = new Font("Arial", 12, FontStyle.Bold);
            Font font = new Font("Arial", 9, FontStyle.Bold);
            Font only = new Font("Arial", 7);
            SolidBrush brush = new SolidBrush(Color.Black);
            Point loc = new Point(10, 20);
            g.DrawImage(CabinetDataStore.Main.Properties.Resources.konrnovkinewantetka11, loc);

            Point loc1 = new Point(10, 170);
            g.DrawImage(CabinetDataStore.Main.Properties.Resources.konrnovkinewantetka21, loc1);

            Point loc2 = new Point(40, 665);
            Image im = picColposcopy.Image;
            if (im != null)
            {
                g.DrawRectangle(Pens.Black, 25, 380, 250, 200);
                g.DrawRectangle(Pens.Black, 25, 610, 740, 300);
                g.DrawRectangle(Pens.Black, 300, 380, 465, 200);



                im = resizeimage(im, new Size(327, 220));
                g.DrawImage(im, loc2);

                g.DrawString(label1.Text, font, brush, new Rectangle(20, 300, 100, 30));
                g.DrawRectangle(Pens.Black, 90, 297, 170, 20);
                g.DrawString(txtExamDate.Text, datas, brush, new Rectangle(95, 299, 170, 20));

                g.DrawString(label2.Text, font, brush, new Rectangle(400, 300, 100, 30));
                g.DrawRectangle(Pens.Black, 470, 297, 295, 20);
                g.DrawString(printName, datas, brush, new Rectangle(475, 299, 295, 20));

                //Anamneza

                g.DrawString(groupBox3.Text, names, brush, new Rectangle(30, 360, 100, 40));
                g.DrawString(label4.Text, label, brush, new Rectangle(40, 390, 80, 20));
                g.DrawRectangle(Pens.Black, 120, 390, 100, 20);
                g.DrawString(dtpPRM.Text, datas, brush, new Rectangle(122, 392, 109, 20));

                g.DrawString(label5.Text, label, brush, new Rectangle(40, 420, 80, 20));
                g.DrawRectangle(Pens.Black, 120, 420, 70, 20);
                g.DrawString(txtBirths.Text, datas, brush, new Rectangle(125, 422, 70, 20));

                g.DrawString(label6.Text, label, brush, new Rectangle(40, 450, 80, 20));
                g.DrawRectangle(Pens.Black, 120, 450, 140, 100);
                g.DrawString(txtOperations.Text, datas, brush, new Rectangle(125, 452, 140, 100));

                //Obektivni simptomi
                g.DrawString(groupBox1.Text, names, brush, new Rectangle(30, 590, 230, 40));

                g.DrawString(label7.Text, label, brush, new Rectangle(40, 620, 80, 20));
                g.DrawRectangle(Pens.Black, 40, 635, 340, 30);
                g.DrawString(txtColposcopy.Text, datas, brush, new Rectangle(40, 637, 340, 30));

                g.DrawString(label8.Text, label, brush, new Rectangle(410, 620, 80, 20));
                g.DrawRectangle(Pens.Black, 410, 635, 340, 70);
                g.DrawString(txtEchography.Text, datas, brush, new Rectangle(410, 637, 340, 70));


                g.DrawString(groupBox2.Text, names, brush, new Rectangle(305, 360, 110, 40));

                g.DrawString(label10.Text, label, brush, new Rectangle(310, 390, 100, 20));
                g.DrawRectangle(Pens.Black, 310, 405, 200, 40);
                g.DrawString(txtPain.Text, datas, brush, new Rectangle(310, 407, 200, 40));


                g.DrawString(label9.Text, label, brush, new Rectangle(310, 460, 100, 20));
                g.DrawRectangle(Pens.Black, 310, 475, 200, 40);
                g.DrawString(txtBleeding.Text, datas, brush, new Rectangle(310, 477, 200, 40));


                g.DrawString(label11.Text, label, brush, new Rectangle(550, 390, 100, 20));
                g.DrawRectangle(Pens.Black, 550, 405, 200, 40);
                g.DrawString(txtFluorine.Text, datas, brush, new Rectangle(550, 407, 200, 40));


                g.DrawString(label12.Text, label, brush, new Rectangle(550, 460, 100, 20));
                g.DrawRectangle(Pens.Black, 550, 475, 200, 40);
                g.DrawString(txtOther.Text, datas, brush, new Rectangle(550, 477, 200, 40));

                g.DrawString(label13.Text, label, brush, new Rectangle(410, 810, 200, 100));
                g.DrawRectangle(Pens.Black, 410, 825, 340, 70);
                g.DrawString(txtResults.Text, datas, brush, new Rectangle(410, 827, 340, 70));

                g.DrawString(label14.Text, names, brush, new Rectangle(30, 920, 230, 40)); // 30, 820, 80, 20
                g.DrawRectangle(Pens.Black, 25, 940, 350, 100); //40, 620, 80, 20
                g.DrawString(txtTherapy.Text, datas, brush, new Rectangle(30, 942, 350, 100));

                g.DrawString(label15.Text, names, brush, new Rectangle(420, 920, 230, 40));
                g.DrawRectangle(Pens.Black, 415, 940, 350, 100);
                g.DrawString(txtRecommendations.Text, datas, brush, new Rectangle(420, 942, 350, 100));

                g.DrawString(label16.Text, label, brush, new Rectangle(410, 715, 80, 20));
                g.DrawRectangle(Pens.Black, 410, 730, 340, 70); //70
                g.DrawString(txtDiagnosis.Text, datas, brush, new Rectangle(410, 732, 340, 70));


                g.DrawString("Подпис: _____________  Печат:", names, brush, new Rectangle(350, 1090, 500, 170));

            }
            else
            {
                g.DrawRectangle(Pens.Black, 25, 380, 250, 200);
                g.DrawRectangle(Pens.Black, 25, 610, 740, 300);
                g.DrawRectangle(Pens.Black, 300, 380, 465, 200);




                //Data i Chas
                g.DrawString(label1.Text, font, brush, new Rectangle(20, 300, 100, 30));
                g.DrawRectangle(Pens.Black, 90, 297, 170, 20);
                g.DrawString(txtExamDate.Text, datas, brush, new Rectangle(95, 299, 170, 20));


                //Patient
                g.DrawString(label2.Text, font, brush, new Rectangle(400, 300, 100, 30));
                g.DrawRectangle(Pens.Black, 470, 297, 295, 20);
                g.DrawString(printName, datas, brush, new Rectangle(475, 299, 295, 20));


                //Anamneza

                g.DrawString(groupBox3.Text, names, brush, new Rectangle(30, 360, 100, 40));
                g.DrawString(label4.Text, label, brush, new Rectangle(40, 390, 80, 20));
                g.DrawRectangle(Pens.Black, 120, 390, 100, 20);
                g.DrawString(dtpPRM.Text, datas, brush, new Rectangle(122, 392, 109, 20));

                g.DrawString(label5.Text, label, brush, new Rectangle(40, 420, 80, 20));
                g.DrawRectangle(Pens.Black, 120, 420, 70, 20);
                g.DrawString(txtBirths.Text, datas, brush, new Rectangle(125, 422, 70, 20));

                g.DrawString(label6.Text, label, brush, new Rectangle(40, 450, 80, 20));
                g.DrawRectangle(Pens.Black, 120, 450, 140, 100);
                g.DrawString(txtOperations.Text, datas, brush, new Rectangle(125, 452, 140, 100));

                //Obektivni simptomi
                g.DrawString(groupBox1.Text, names, brush, new Rectangle(30, 590, 230, 40));

                g.DrawString(label7.Text, label, brush, new Rectangle(40, 620, 80, 20));
                g.DrawRectangle(Pens.Black, 40, 635, 340, 30);
                g.DrawString(txtColposcopy.Text, datas, brush, new Rectangle(40, 637, 340, 30));

                g.DrawString(label8.Text, label, brush, new Rectangle(410, 620, 80, 20));
                g.DrawRectangle(Pens.Black, 410, 635, 340, 70);
                g.DrawString(txtEchography.Text, datas, brush, new Rectangle(410, 637, 340, 70));

                g.DrawString(groupBox2.Text, names, brush, new Rectangle(305, 360, 110, 40));

                g.DrawString(label10.Text, label, brush, new Rectangle(310, 390, 100, 20));
                g.DrawRectangle(Pens.Black, 310, 405, 200, 40);
                g.DrawString(txtPain.Text, datas, brush, new Rectangle(310, 407, 200, 40));

                g.DrawString(label9.Text, label, brush, new Rectangle(310, 460, 100, 20));
                g.DrawRectangle(Pens.Black, 310, 475, 200, 40);
                g.DrawString(txtBleeding.Text, datas, brush, new Rectangle(310, 477, 200, 40));

                g.DrawString(label11.Text, label, brush, new Rectangle(550, 390, 100, 20));
                g.DrawRectangle(Pens.Black, 550, 405, 200, 40);
                g.DrawString(txtFluorine.Text, datas, brush, new Rectangle(550, 407, 200, 40));

                g.DrawString(label12.Text, label, brush, new Rectangle(550, 460, 100, 20));
                g.DrawRectangle(Pens.Black, 550, 475, 200, 40);
                g.DrawString(txtOther.Text, datas, brush, new Rectangle(550, 477, 200, 40));

                g.DrawString(label13.Text, label, brush, new Rectangle(410, 810, 200, 100));
                g.DrawRectangle(Pens.Black, 410, 825, 340, 70);
                g.DrawString(txtResults.Text, datas, brush, new Rectangle(410, 827, 340, 70));

                g.DrawString(label14.Text, names, brush, new Rectangle(30, 920, 230, 40)); // 30, 820, 80, 20
                g.DrawRectangle(Pens.Black, 25, 940, 350, 100); //40, 620, 80, 20
                g.DrawString(txtTherapy.Text, datas, brush, new Rectangle(30, 942, 350, 100));

                g.DrawString(label15.Text, names, brush, new Rectangle(420, 920, 230, 40));
                g.DrawRectangle(Pens.Black, 415, 940, 350, 100);
                g.DrawString(txtRecommendations.Text, datas, brush, new Rectangle(420, 942, 350, 100));

                g.DrawString(label16.Text, label, brush, new Rectangle(410, 715, 80, 20));
                g.DrawRectangle(Pens.Black, 410, 730, 340, 70); //70
                g.DrawString(txtDiagnosis.Text, datas, brush, new Rectangle(410, 732, 340, 70));


                g.DrawString("Подпис: _____________  Печат:", names, brush, new Rectangle(350, 1090, 500, 170));
            }
        }

        private void btnClearPic_Click(object sender, EventArgs e)
        {
            picColposcopy.Image = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            NewExaminationProperties(true);
        }

        private string getBirthsString(string birthsNumber, out int diff)
        {
            diff = 0;
            switch (birthsNumber)
            {
                case "0":
                    diff = 10;
                    return "Няма";
                case "1":
                    diff = 10;
                    return "Едно";
                case "2":
                    diff = 15;
                    return "Две";
                case "3":
                    diff = 15;
                    return "Три";
                case "4":
                    return "Четири";
                case "5":
                    diff = 15;
                    return "Пет";
                case "6":
                    diff = 10;
                    return "Шест";
                case "7":
                    diff = 5;
                    return "Седем";
                case "8":
                    diff = 10;
                    return "Осем";
                case "9":
                    diff = 10;
                    return "Девет";
                default:
                    return string.Empty;
            }
        }

        //Test button - maybe will be released when HTML rendering of the printing is ready.
        private void button1_Click(object sender, EventArgs e)
        {
            string headerImage1 = "file:///C:/Users/STOYANOV/source/repos/CabinetDataStore/CabinetDataStore.Main/Resources/konrnovkinewantetka11.png";
            string headerImage2 = "file:///C:/Users/STOYANOV/source/repos/CabinetDataStore/CabinetDataStore.Main/Resources/konrnovkinewantetka21.png";
            string colposcopyImage = "file:///C:/Users/STOYANOV/source/repos/CabinetDataStore/CabinetDataStore.Main/Resources/konrnovkinewantetka21.png";

            // Your HTML content
            string htmlContent = @"
              <!DOCTYPE html>
<html lang=""bg"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Медицински Формуляр</title>
    <style>
        /* Глобални стилове */
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f0f4f8;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            padding: 0;
        }

        .container {
            width: 900px;
            background: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 8px 15px rgba(0, 0, 0, 0.1);
            color: #333;
        }

        .section-title {
            font-size: 1.25rem;
            font-weight: bold;
            color: #004e92;
            border-bottom: 3px solid #004e92;
            padding-bottom: 5px;
            margin-top: 20px;
        }

        .row {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            margin-bottom: 20px;
        }

        .column {
            flex: 1;
            min-width: 220px;
            margin-bottom: 10px;
        }

        .wide-column {
            flex: 3;
        }

        .single-column {
            flex: 1;
            display: flex;
            flex-direction: column;
        }

        label {
            font-size: 0.9rem;
            color: #333;
            margin-bottom: 5px;
            display: block;
        }

        input, textarea {
            width: 100%;
            padding: 12px;
            border-radius: 8px;
            border: 1px solid #ccc;
            background-color: #fafafa;
            box-sizing: border-box;
            font-size: 1rem;
            transition: border-color 0.3s ease;
        }

        input:focus, textarea:focus {
            outline: none;
            border-color: #004e92;
            box-shadow: 0 0 8px rgba(0, 78, 146, 0.2);
        }

        textarea {
            resize: vertical;
            min-height: 120px;
        }

        .footer {
            text-align: center;
            font-size: 0.8rem;
            color: #888;
            margin-top: 30px;
        }

        /* Стилове за печат */
        @media print {
            body {
                font-size: 12px;
                margin: 0;
                background: none;
            }

            .container {
                width: 100%;
                max-width: 100%;
                padding: 10px;
                border-radius: 0;
                box-shadow: none;
                page-break-before: always;
            }

            .section-title {
                font-size: 16px;
                margin-top: 10px;
            }

            .row {
                display: flex;
                flex-wrap: wrap;
                gap: 20px;
            }

            .column, .wide-column {
                display: block;
                margin-bottom: 10px;
            }

            input, textarea {
                font-size: 12px;
                padding: 8px;
                width: auto;
                min-width: 200px;
            }

            .footer {
                font-size: 10px;
                color: #333;
                margin-top: 20px;
            }

            /* Промените за секцията ""Оплаквания"" и ""Анамнеза"" */
            .wide-column {
                display: flex;
                flex-direction: column;
            }

            .wide-column .row {
                display: flex;
                flex-wrap: nowrap;
                gap: 20px;
                justify-content: space-between;
            }

            .wide-column .column {
                flex: 1;
                min-width: 220px;
            }

            .wide-column .column input {
                width: 100%;
            }

            /* Поставяне на Анамнеза и Оплаквания на един ред */
            .dual-column {
                display: flex;
                justify-content: space-between;
            }

            .dual-column .single-column {
                flex: 1;
                margin-right: 20px;
            }

            .dual-column .wide-column {
                flex: 2;
            }

            .container {
                page-break-inside: avoid;
            }

            @page {
                size: A4;
                margin: 20mm;
            }

            /* Премахване на маргини и padding за печат */
            h1, h2, h3, p, div {
                margin: 0;
                padding: 0;
            }

            /* Премахване на разместване в колоните при печат */
            .row, .column {
                break-inside: avoid;
            }
        }
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""row"">
            <div class=""column""><label>Дата/час:</label><input type=""text"" value=""Test123""></div>
            <div class=""column""><label>Пациент:</label><input type=""text"" value=""Test123""></div>
        </div>
        
        <!-- Използваме новия контейнер .dual-column за подреждане на Анамнеза и Оплаквания на един ред -->
        <div class=""dual-column"">
            <div class=""single-column"">
                <div class=""section-title"">Анамнеза</div>
                <label>ПРМ:</label><input type=""text"" value=""Test123"">
                <label>Раждания:</label><input type=""text"" value=""Test123"">
                <label>Операции:</label><input type=""text"" value=""Test123"">
            </div>
            
            <div class=""wide-column"">
                <div class=""section-title"">Оплаквания</div>
                
                <!-- Първи ред с Болка и Флуор -->
                <div class=""row"">
                    <div class=""column"">
                        <label>Болка:</label><input type=""text"" value=""Test123"">
                    </div>
                    <div class=""column"">
                        <label>Флуор:</label><input type=""text"" value=""Test123"">
                    </div>
                </div>
                
                <!-- Втори ред с Кръвене и Други -->
                <div class=""row"">
                    <div class=""column"">
                        <label>Кръвене:</label><input type=""text"" value=""Test123"">
                    </div>
                    <div class=""column"">
                        <label>Други:</label><input type=""text"" value=""Test123"">
                    </div>
                </div>

            </div>
        </div>
        
        <div class=""section-title"">Обективни симптоми</div>
        <div class=""row"">
            <div class=""column""><label>Колоноскопия:</label><input type=""text"" value=""Test123""></div>
            <div class=""column""><label>Ехография:</label><input type=""text"" value=""Test123""></div>
        </div>
        <div class=""row"">
            <div class=""column""><label>Диагноза:</label><input type=""text"" value=""Test123""></div>
            <div class=""column""><label>Резултати от изследвания:</label><input type=""text"" value=""Test123""></div>
        </div>
        
        <div class=""section-title"">Терапия и Препоръки</div>
        <div class=""row"">
            <div class=""column""><label>Терапия:</label><input type=""text"" value=""Test123""></div>
            <div class=""column""><label>Препоръки:</label><input type=""text"" value=""Test123""></div>
        </div>
        
        <div class=""footer"">
            <p>Проф. Явор Корновски | © 2025</p>
        </div>
    </div>
</body>
</html>
";

            // Create WebBrowser control and load HTML
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.DocumentText = htmlContent;

            // Wait for the document to fully load before printing
            webBrowser.DocumentCompleted += (s, args) =>
            {
                // Print the document
                webBrowser.Print();
            };
        }


    }
}
