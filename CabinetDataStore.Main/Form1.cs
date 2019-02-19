using CabinetDataStore.Business.Abstraction;
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
    public partial class Form1 : Form
    {
        private readonly IPatient patientService;
        public Form1(IPatient patientService)
        {
            InitializeComponent();
            this.patientService = patientService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoCompleteInsert();
        }

        #region private methods

        private void autoCompleteInsert()
        {
            var dbpatients = patientService.GetAllPatients();
            var patients = dbpatients.Select(x => x.PatientName).ToArray();
            {
                PatientNametxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                PatientNametxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                PatientNametxt.AutoCompleteCustomSource.AddRange(patients);
            }
        }
        #endregion
    }
}
