using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.BusinessService.Enums;
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
        private DataTable dt = new DataTable();
        private DataTable dtExamination = new DataTable();

        public PatientForm(IPatient patientService)
        {
            InitializeComponent();
            this.patientService = patientService;
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            comboFilter.SelectedIndex = 0;
            dtFilterDate.Visible = false;
            АutoCompleteInsert();

            dt.Columns.Add("ID", typeof(int));
            
            dt.Columns.Add("Име", typeof(string));
            dt.Columns.Add("Дата на раждане", typeof(DateTime));
            dt.Columns.Add("Телефон", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Възраст", typeof(int));
            dt.Columns.Add("Прегледи", typeof(int));

            dtExamination.Columns.Add("ID", typeof(string));
            dtExamination.Columns.Add("Пациент", typeof(string));
            dtExamination.Columns.Add("Дата на прегледа", typeof(string));
            LoadPatientData();
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

                foreach (var patient in PatientData)
                {
                    dt.Rows.Add(new object[]
                    {
                        patient.PatientId,
                        patient.PatientName,
                        patient.BirthDate,
                        patient.PhoneNumber,
                        patient.EmailAddress,
                        AgeCalculator(patient.BirthDate),
                        patient.Examinations.Count
                    });
                }

                dataGridView2.DataSource = dt;
                dataGridView2.Columns["ID"].Width = 30;
                dataGridView2.Columns["Телефон"].Width = 130;
                dataGridView2.Columns["Възраст"].Width = 60;
                dataGridView2.Columns["Прегледи"].Width = 80;

                dataGridView2.Focus();
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

        private void АutoCompleteInsert()
        {
            var dbpatients = patientService.GetAllPatients();
            var patients = dbpatients.Select(x => x.PatientName).ToArray();

            txtFilter.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtFilter.AutoCompleteCustomSource.AddRange(patients);
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


        private void ShowPatientData(List<PatientModel> patientData)
        {
            foreach (var patient in patientData)
            {
                txtPatientName.Text = patient.PatientName;
                dtBirthDate.Text = patient.BirthDate.ToString();
                txtPatientPhone.Text = patient.PhoneNumber;
                txtEmail.Text = patient.EmailAddress;
                txtAge.Text = AgeCalculator(patient.BirthDate).ToString();

                foreach (var examination in patient.Examinations)
                {
                    dtExamination.Rows.Add(new object[] { examination.ExaminationID, patient.PatientName, examination.ExaminationDate });
                }
                dataGridView3.DataSource = dtExamination;
                dataGridView3.Focus();
            }
        }

        private int AgeCalculator(DateTime BirthDate)
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
            txtFilter.Text = string.Empty;
            dtFilterDate.Text = string.Format("01.01.1753");
            dtExamination.Clear();
        }


        #endregion

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<PatientModel> patients = new List<PatientModel>();
            int PatientId = 0;
            
            ClearPatientData();
            dataGridView2.DefaultCellStyle.SelectionBackColor = SystemColors.ControlDarkDark;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;
            if (e.RowIndex != -1)
            {
                PatientId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString());
                
                var patient = patientService.GetPatientById(PatientId);
                patients.Add(patient);

                ShowPatientData(patients);
            }
        }
    }
}
