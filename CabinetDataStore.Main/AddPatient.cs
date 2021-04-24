using CabinetDataStore.Business.Abstraction;
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
    public partial class AddPatient : Form
    {
        private readonly IPatient patientService;
        public AddPatient(IPatient patientService)
        {
            InitializeComponent();
            this.patientService = patientService;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PatientModel patientModel = new PatientModel();

            patientModel.PatientName = txtPatientName.Text;
            patientModel.PhoneNumber = txtPatientPhone.Text;
            patientModel.EmailAddress = txtEmail.Text;
            patientModel.BirthDate = Convert.ToDateTime(dtBirthDate.Text);

            // insert patient
            bool result = patientService.InsertPatient(patientModel);
            if (result)
            {
                MessageBox.Show("Пациента е добавен успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Пациента не е записан", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtBirthDate_Leave(object sender, EventArgs e)
        {
            txtAge.Text = PatientForm.AgeCalculator(Convert.ToDateTime(dtBirthDate.Text)).ToString();
        }
    }
}
