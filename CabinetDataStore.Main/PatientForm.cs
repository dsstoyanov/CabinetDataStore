using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.BusinessService.Enums;
using CabinetDataStore.BusinessService.ExaminationModels;
using CabinetDataStore.BusinessService.PatientModels;
using Logger;
using Ninject.Infrastructure.Introspection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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
        public static bool useOldPrintVersion = false;

        public PatientForm(PatientModel model)
        {
            txtPatientName.Text = model.PatientName;
            txtPatientPhone.Text = model.PhoneNumber;
            txtEmail.Text = model.EmailAddress;
        }

        public PatientForm(IPatient patientService, IExamination examinationService)
        {
            InitializeComponent();
            refreshTimer.Start();
            refreshTimer.Interval = 1;
            
            this.patientService = patientService;
            this.examinationService = examinationService;
            Logger.LoggerManager.Informational($"Load Patients form", this.GetType().Name);
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
            lblVersion.Text = "Cabinet Data Store v2.3.0";
            lblVersion.ForeColor = Color.Green;
            използвайСтароПринтираеToolStripMenuItem.Checked = false;
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
            if (comboFilter.SelectedIndex == (int)SearchTypes.Name)
            {
                var PatientData = LoadPatientData();
                ClearPatientData();

                if (PatientData.Count == 1)
                {
                    ShowPatientData(PatientData);
                    Logger.LoggerManager.Informational($"Search result: {PatientData.Count} Patient found with ID: [{PatientData[0]?.PatientId}] {PatientData[0]?.PatientName} ", this.GetType().Name);
                }

                else if (PatientData.Count != 0 && PatientData.Count > 1)
                {
                    ChoosePatient choose = new ChoosePatient(this, PatientData, patientService, examinationService);
                    Logger.LoggerManager.Informational($"Search result: {PatientData.Count} Patient found - search name: {txtFilter.Text}", this.GetType().Name);
                    choose.ShowDialog();
                }
            }
            else if (comboFilter.SelectedIndex == (int)SearchTypes.PhoneNumber)
            {
                var PatientData = LoadPatientData();
                ClearPatientData();

                if (PatientData.Count == 1)
                {
                    ShowPatientData(PatientData);
                }

                else if (PatientData.Count != 0 && PatientData.Count > 1)
                {
                    ChoosePatient choose = new ChoosePatient(this, PatientData, patientService, examinationService);
                    choose.ShowDialog();
                }
            }
        }



        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
            ClearPatientData();
            pID.Text = string.Empty;
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
            this.txtFilter.AutoCompleteCustomSource = null;
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
                txtAge.Text = AgeCalculator(DateTime.Now, patient.BirthDate).ToString();
                pID.Text = patient.PatientId.ToString();
                grpPatientData.Text = $"Пациент N: {patient.PatientId}";

                patient.Examinations = examinationService.GetAllExaminationsByPatientID(patient.PatientId);
                if (patient.Examinations != null)
                {
                    //dtExamination.Clear();
                    foreach (var examination in patient.Examinations)
                    {
                        dt.Rows.Add(new object[] { examination.ExaminationID, patient.PatientName, examination.ExaminationDate, patient.PhoneNumber, patient.EmailAddress, AgeCalculator(examination.ExaminationDate, patient.BirthDate), patient.Examinations.Count() });
                    }
                    dgvAll.DataSource = dt;
                    dgvAll.Focus();
                }
                else
                {
                    MessageBox.Show($"Не са намерени прегледи. Вероятно е да има проблем.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        public static int AgeCalculator(DateTime Date,DateTime BirthDate)
        {
            int age = Date.Year - BirthDate.Year;

            if (Date.Month < BirthDate.Month ||
                (Date.Month == BirthDate.Month && Date.Day < BirthDate.Day))
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



        private void dgvDaily_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dtExamination.Clear();
            dgvDaily.DataSource = dtExamination;

            if (e.RowIndex != -1)
            {
                long ExaminationId = 0;
                var patient = patientService.GetPatientById(Convert.ToInt64(dgvDaily.Rows[e.RowIndex].Cells[3].Value));

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
                dt.Rows.Add(new object[] { examination.ExaminationID, patient.PatientName, examination.ExaminationDate, patient.PhoneNumber, patient.EmailAddress, AgeCalculator(examination.ExaminationDate, patient.BirthDate), patient.Examinations.Count() });
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

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            AddPatient f = new AddPatient(patientService);
            f.ShowDialog();
        }

        private void PatientForm_Activated(object sender, EventArgs e)
        {
            pickExam.Value = DateTime.Now;
            dt.Clear();
            RefreshDailyExaminations();
            dgvDaily.Columns["ID"].Width = 60;
            dgvDaily.Columns["Пациент"].Width = 250;
            dgvDaily.Columns["Дата на прегледа"].Width = 150;
            dgvDaily.Columns["Пациент ID"].Width = 1;
            this.dgvDaily.Sort(this.dgvDaily.Columns["Дата на прегледа"], ListSortDirection.Descending);
            АutoCompleteInsert();
            if (!string.IsNullOrEmpty(pID.Text))
            {
                var patient = patientService.GetPatientById(int.Parse(pID.Text));
                patient.Examinations = examinationService.GetAllExaminationsByPatientID(patient.PatientId);
                //dtExamination.Clear();
                foreach (var examination in patient.Examinations)
                {
                    dt.Rows.Add(new object[] { examination.ExaminationID, patient.PatientName, examination.ExaminationDate, patient.PhoneNumber, patient.EmailAddress, AgeCalculator(examination.ExaminationDate,patient.BirthDate), patient.Examinations.Count() });
                }
                dgvAll.DataSource = dt;
                dgvAll.Focus();
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            //refreshTimer.Interval = 10000;
            //RefreshDailyExaminations();
            //dgvDaily.Columns["ID"].Width = 80;
            //dgvDaily.Columns["Пациент"].Width = 200;
            //dgvDaily.Columns["Дата на прегледа"].Width = 200;
            //dgvDaily.Columns["Пациент ID"].Width = 1;
            //this.dgvDaily.Sort(this.dgvDaily.Columns["Дата на прегледа"], ListSortDirection.Descending);
            //АutoCompleteInsert();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pID.Text))
            {
                MessageBox.Show("Моля първо изберете пациент, чийто данни да редактирате", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnEdit.Enabled = false;
            btnNewPatient.Enabled = false;
            EnableButtons();

            
            
        }

        private void EnableButtons()
        {
            txtPatientName.Enabled = true;
            txtPatientPhone.Enabled = true;
            txtEmail.Enabled = true;
            dtBirthDate.Enabled = true;
            btnSave.Enabled = true;
            btnRefusal.Enabled = true;
        }

        private void DisableButtons()
        {
            txtPatientName.Enabled = false;
            txtPatientPhone.Enabled = false;
            txtEmail.Enabled = false;
            dtBirthDate.Enabled = false;
            btnSave.Enabled = false;
            btnRefusal.Enabled = false;
        }

        private void btnRefusal_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnNewPatient.Enabled = true;
            DisableButtons();
            var patient = patientService.GetPatientById(int.Parse(pID.Text));

            txtPatientName.Text = patient.PatientName;
            txtPatientPhone.Text = patient.PhoneNumber;
            txtEmail.Text = patient.EmailAddress;
            dtBirthDate.Text = patient.BirthDate.ToString();
            txtAge.Text = AgeCalculator(DateTime.Now, patient.BirthDate).ToString();
            pID.Text = patient.PatientId.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnNewPatient.Enabled = true;
            DisableButtons();
            PatientModel model = new PatientModel();
            model.PatientName = txtPatientName.Text;
            model.PhoneNumber = txtPatientPhone.Text;
            model.EmailAddress = txtEmail.Text;
            model.BirthDate = Convert.ToDateTime(dtBirthDate.Text);
            model.PatientId = int.Parse(pID.Text);
            txtAge.Text = AgeCalculator(DateTime.Now, model.BirthDate).ToString();

            bool updatePatient = patientService.UpdatePatient(model);
            if (updatePatient)
            {
                АutoCompleteInsert();
                MessageBox.Show("Промените бяха записани успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboFilter.SelectedIndex == (int)SearchTypes.PhoneNumber)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    MessageBox.Show("Филтърът за търсене е по телефон. За въвеждане на име моля сменете филтъра.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void archiveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string backupLocation = ConfigurationManager.AppSettings["backup"];
                Logger.LoggerManager.Informational($"[BackUp] Number of patiens: {patientService.PatientsCount()}, number of examinations: {examinationService.ExaminationsCount()}");
                System.Diagnostics.Process.Start(backupLocation);
                LoggerManager.Informational($"Database backup was created successfuly. Filename: BackUP_{ DateTime.Now.ToString("yyyyMMdd")}.dump");
            }
            catch (Exception ex)
            {
                LoggerManager.Informational($"Could not create backup of the database.");
                LoggerManager.Critical(ex);
            }
        }

        private void patientsCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var patientsCount = patientService.PatientsCount();
            MessageBox.Show($"Пациенти: {patientsCount}", "Справка пациенти",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void examinationsCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var examinationsCount = examinationService.ExaminationsCount();
            MessageBox.Show($"Прегледи: {examinationsCount}", "Справка прегледи",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void refreshExamDate_Click(object sender, EventArgs e)
        {
            var dateToPick = pickExam.Value;
            dtExamination.Clear();

            var examinations = examinationService.GetExaminationsByDate(dateToPick);
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

            dgvDaily.Columns["ID"].Width = 60;
            dgvDaily.Columns["Пациент"].Width = 250;
            dgvDaily.Columns["Дата на прегледа"].Width = 150;
            dgvDaily.Columns["Пациент ID"].Width = 1;
            this.dgvDaily.Sort(this.dgvDaily.Columns["Дата на прегледа"], ListSortDirection.Descending);
            dgvDaily.DataSource = dtExamination;
        }

        private void версияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Version: 2.3.0\nRevision: 29d9e11\nTech Stack: .NET Framework 4.7.2\n\nLogs:\n{Directory.GetCurrentDirectory() + "\\Logs\\"}", "Cabinet Data Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void контактToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програмист: Деян Стоянов Стоянов\nТелефон: +359 877 66 0967", "Cabinet Data Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void използвайСтароПринтираеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            използвайСтароПринтираеToolStripMenuItem.CheckOnClick = true;

            if (използвайСтароПринтираеToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                useOldPrintVersion = false;
            }
            else
            {
                useOldPrintVersion = true;
            }

        }
    }
}
