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
            DisableAllActions();
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

        private void DisableAllActions()
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
            if(!isEdit)
            dtpPRM.Text = Convert.ToString(dtpPRM.MinDate);
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
                        DisableAllActions();
                        //PatientForm pf = new PatientForm(patientService, examinationService);
                        //pf.PatientForm_Load(sender, e);
                        //pf.ShowDialog();
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
                    //if (isInserted)
                    //{
                    //    this.Close();
                    //    //PatientForm pf = new PatientForm(patientService, examinationService);
                    //    //pf.ShowDialog();
                    //}
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Промените НЕ бяха записани", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(ExemtionPrint); //add an event handler that will do the printing

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
            g.DrawImage(CabinetDataStore.Main.Properties.Resources.konrnovki_new_antetka1, loc);

            Point loc1 = new Point(10, 170);
            g.DrawImage(CabinetDataStore.Main.Properties.Resources.konrnovki_new_antetka2, loc1);

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
    }
}
