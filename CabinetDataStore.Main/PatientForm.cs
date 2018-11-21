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

        public PatientForm(IPatient patientService)
        {
            InitializeComponent();
            this.patientService = patientService;
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            comboFilter.SelectedIndex = 0;
            dateTimePicker2.Visible = false;
            АutoCompleteInsert();
            dataGridView2.Focus();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Име", typeof(string));
            dt.Columns.Add("Дата на раждане", typeof(DateTime));
            dt.Columns.Add("Телефон", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Възраст", typeof(int));
            LoadPatientData();
        }

        private void srchButton_Click(object sender, EventArgs e)
        {
            var PatientData = LoadPatientData();

            if (PatientData.Count == 1)
            {
                txtPatientName.Text = PatientData[0].PatientName;
                dtBirthDate.Text = PatientData[0].BirthDate.ToString();
                txtPatientPhone.Text = PatientData[0].PhoneNumber;
                txtEmail.Text = PatientData[0].EmailAddress;
                txtAge.Text = AgeCalculator(PatientData[0].BirthDate).ToString();
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
                        patient.EmailAddress,
                        patient.PhoneNumber,
                        AgeCalculator(patient.BirthDate)
                    });
                }

                dataGridView2.DataSource = dt;
                dataGridView2.Focus();
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
            patient = patientService.GetPatientByFilter((SearchTypes)comboFilter.SelectedIndex, txtFilter.Text);
            
            return patient;
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
        #endregion
    }
}
