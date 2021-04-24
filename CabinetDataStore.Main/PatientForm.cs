using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.BusinessService.Enums;
using CabinetDataStore.BusinessService.ExaminationModels;
using CabinetDataStore.BusinessService.PatientModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetDataStore.Main
{
    public partial class PatientForm : Form
    {
        private readonly IPatient patientService;
        private readonly IExamination examinationService;
        private DataTable dt = new DataTable();
        private DataTable dtExamination = new DataTable();

        public PatientForm(IPatient patientService, IExamination examinationService)
        {
            InitializeComponent();
            refreshTimer.Start();
            refreshTimer.Interval = 1;
            this.patientService = patientService;
            this.examinationService = examinationService;
        }

        public PatientForm(IPatient patientService, IExamination examinationService, PatientModel patient)
        {
            InitializeComponent();
            this.patientService = patientService;
            this.examinationService = examinationService;
            List<PatientModel> patients = new List<PatientModel>();
            patients.Add(patient);
            ShowPatientData(patients);
        }

        public void PatientForm_Load(object sender, EventArgs e)
        {
            comboFilter.SelectedIndex = 0;
            dt.Columns.Clear();
            dtExamination.Columns.Clear();
            dtFilterDate.Visible = false;
            АutoCompleteInsert();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Име", typeof(string));
            dt.Columns.Add("Дата на прегледа", typeof(DateTime));
            dt.Columns.Add("Телефон", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Възраст", typeof(int));
            dt.Columns.Add("Прегледи", typeof(int));

            dtExamination.Columns.Add("ID", typeof(string));
            dtExamination.Columns.Add("Пациент", typeof(string));
            dtExamination.Columns.Add("Дата на прегледа", typeof(string));
            dtExamination.Columns.Add("Пациент ID", typeof(string));
            

            RefreshDailyExaminations();

            LoadPatientData();
        }

        private void RefreshDailyExaminations()
        {
            //dt.Clear();
            dtExamination.Clear();
            var examinations = LoadDailyExaminations();
            if (examinations.Count != 0 || examinations.Count > 0)
            {
                foreach (var exam in examinations)
                {
                    var patient = patientService.GetPatientById(exam.PatientId);
                    dtExamination.Rows.Add(new object[]
                        {
                            exam.ExaminationID,
                            patient.PatientName,
                            exam.ExaminationDate,
                            patient.PatientId
                        });
                }
            }
            dgvDaily.DataSource = dtExamination;
            //dgvAll.DataSource = dt;
        }

        private void ExaminationForToday()
        {
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Пациент", typeof(string));
            dt.Columns.Add("Дата на прегледа", typeof(DateTime));
            dt.Columns.Add("Диагноза", typeof(string));
            dt.Columns.Add("Общ брой прегледи", typeof(int));
        }

        private void srchButton_Click(object sender, EventArgs e)
        {
            var PatientData = LoadPatientData();
            ClearPatientData();

            if (PatientData.Count == 1)
            {
                ShowPatientData(PatientData);
            }

            else if (PatientData.Count != 0 && PatientData.Count > 1)
            {

                ChoosePatient choose = new ChoosePatient(this,PatientData, patientService,examinationService);
                choose.ShowDialog();
               
            }
        }



        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearPatientData();
            dt.Clear();
            if (comboFilter.SelectedIndex == (int)SearchTypes.DateOfBirth)
            {
                txtFilter.Visible = false;
                dtFilterDate.Visible = true;
            }
            else
            {
                txtFilter.Visible = true;
                dtFilterDate.Visible = false;
            }
        }

        #region Logic private methods

        public void АutoCompleteInsert()
        {
            var dbpatients = patientService.GetAllPatients();
            var patients = dbpatients.Select(x => x.PatientName).ToArray();

            this.txtFilter.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtFilter.AutoCompleteCustomSource.AddRange(patients);
        }

        private List<PatientModel> LoadPatientData()
        {
            dt.Clear();
            List<PatientModel> patient = new List<PatientModel>();
            if (comboFilter.SelectedIndex == (int)SearchTypes.Name
                || comboFilter.SelectedIndex == (int)SearchTypes.PhoneNumber)
            {
                patient = patientService.GetPatientByFilter((SearchTypes)comboFilter.SelectedIndex, txtFilter.Text);
            }
            else
            {
                patient = patientService.GetPatientByFilter((SearchTypes)comboFilter.SelectedIndex, dtFilterDate.Text);
            }
            return patient;
        }

        private List<ExaminationModel> LoadDailyExaminations()
        {
            return examinationService.GetExaminationsForToday();
        }


        public void ShowPatientData(List<PatientModel> patientData)
        {
            dt.Clear();
            foreach (var patient in patientData)
            {
                txtPatientName.Text = patient.PatientName;
                dtBirthDate.Text = patient.BirthDate.ToString();
                txtPatientPhone.Text = patient.PhoneNumber;
                txtEmail.Text = patient.EmailAddress;
                txtAge.Text = AgeCalculator(patient.BirthDate).ToString();
                pID.Text = patient.PatientId.ToString();
                grpPatientData.Text = $"Пациент N: {patient.PatientId}";

                patient.Examinations = examinationService.GetAllExaminationsByPatientID(patient.PatientId);
                //dtExamination.Clear();
                foreach (var examination in patient.Examinations)
                {
                    dt.Rows.Add(new object[] { examination.ExaminationID, patient.PatientName, examination.ExaminationDate, patient.PhoneNumber, patient.EmailAddress, txtAge.Text, patient.Examinations.Count() });
                }
                dgvAll.DataSource = dt;
                dgvAll.Focus();
            }
        }

        public static int AgeCalculator(DateTime BirthDate)
        {
            int age = DateTime.Now.Year - BirthDate.Year;

            if (DateTime.Now.Month < BirthDate.Month ||
                (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
            {
                age--;
            }

            return age;
        }

        private void ClearPatientData()
        {
            txtPatientName.Text = string.Empty;
            txtPatientPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAge.Text = string.Empty;
            //txtFilter.Text = string.Empty;
            dtFilterDate.Text = string.Format("01.01.1753");
            grpPatientData.Text = "Пациент";
            //dtExamination.Clear();
        }


        #endregion

      

        private void addNewExamButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pID.Text))
            {
                MessageBox.Show("Моля първо изберете пациент, на който да добавите преглед.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var patient = patientService.GetPatientById(int.Parse(pID.Text));
            //this.Hide();
            ExaminationsForm pf = new ExaminationsForm(patient, patientService, examinationService);
            pf.ShowDialog();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void dgvDaily_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dtExamination.Clear();
            dgvDaily.DataSource = dtExamination;

            if (e.RowIndex != -1)
            {
                long ExaminationId = 0;
                var patient = patientService.GetPatientById(int.Parse(dtExamination.Rows[e.RowIndex].ItemArray[3].ToString()));

                ExaminationId = Convert.ToInt32(dgvDaily.Rows[e.RowIndex].Cells[0].Value);

                var examination = examinationService.GetExaminationById(ExaminationId);
                dt.Clear();
               
                ExaminationsForm f = new ExaminationsForm(patient, examination, patientService, examinationService, true);
                f.ShowDialog();
            }
        }

        private void dgvAll_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //List<PatientModel> patients = new List<PatientModel>();
            dt.Clear();
            dgvAll.DataSource = dt;
            long PatientId = 0;
            long ExaminationId = 0;
            var patient = patientService.GetPatientById(int.Parse(pID.Text));
            patient.Examinations = examinationService.GetAllExaminationsByPatientID(patient.PatientId);
            //dtExamination.Clear();
            foreach (var examination in patient.Examinations)
            {
                dt.Rows.Add(new object[] { examination.ExaminationID, patient.PatientName, examination.ExaminationDate, patient.PhoneNumber, patient.EmailAddress, txtAge.Text, patient.Examinations.Count() });
            }
            dgvAll.DataSource = dt;
            dgvAll.Focus();
            if (e.RowIndex != -1)
            {
                PatientId = patient.PatientId;
                ExaminationId = Convert.ToInt32(dgvAll.Rows[e.RowIndex].Cells[0].Value);
                var patientById = patientService.GetPatientById(PatientId);
                var examination = examinationService.GetExaminationById(ExaminationId);
                ExaminationsForm f = new ExaminationsForm(patient, examination, patientService, examinationService, true);
                f.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPatient f = new AddPatient(patientService);
            f.ShowDialog();
        }

        private void PatientForm_Activated(object sender, EventArgs e)
        {
            ////ReloadDailyExaminations();
            //comboFilter.SelectedIndex = 0;
            //dtFilterDate.Visible = false;
            //АutoCompleteInsert();

            //dt.Columns.Add("ID", typeof(int));

            //dt.Columns.Add("Име", typeof(string));
            //dt.Columns.Add("Дата на прегледа", typeof(DateTime));
            //dt.Columns.Add("Телефон", typeof(string));
            //dt.Columns.Add("Email", typeof(string));
            //dt.Columns.Add("Възраст", typeof(int));
            //dt.Columns.Add("Прегледи", typeof(int));

            //dtExamination.Columns.Add("ID", typeof(string));
            //dtExamination.Columns.Add("Пациент", typeof(string));
            //dtExamination.Columns.Add("Дата на прегледа", typeof(string));
            //dtExamination.Columns.Add("Пациент ID", typeof(string));


            //var examinations = LoadDailyExaminations();
            //if (examinations.Count != 0 || examinations.Count > 0)
            //{
            //    foreach (var exam in examinations)
            //    {
            //        var patient = patientService.GetPatientById(exam.PatientId);
            //        dtExamination.Rows.Add(new object[]
            //            {
            //                exam.ExaminationID,
            //                patient.PatientName,
            //                exam.ExaminationDate,
            //                patient.PatientId
            //            });
            //    }
            //}
            //dgvDaily.DataSource = dtExamination;
            //dgvDaily.Columns["ID"].Width = 30;
            //dgvDaily.Columns["Пациент"].Width = 200;
            //dgvDaily.Columns["Дата на прегледа"].Width = 200;
            //dgvDaily.Columns["Пациент ID"].Width = 1;

            //LoadPatientData();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Interval = 10000;
            RefreshDailyExaminations();
            dgvDaily.Columns["ID"].Width = 30;
            dgvDaily.Columns["Пациент"].Width = 200;
            dgvDaily.Columns["Дата на прегледа"].Width = 200;
            dgvDaily.Columns["Пациент ID"].Width = 1;
            this.dgvDaily.Sort(this.dgvDaily.Columns["Дата на прегледа"], ListSortDirection.Descending);
            АutoCompleteInsert();
        }
    }
}
