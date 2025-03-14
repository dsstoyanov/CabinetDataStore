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
    public partial class ChoosePatient : Form
    {
        private readonly IPatient patientService;
        private readonly IExamination examinationService;
        private DataTable dt = new DataTable();
        private PatientForm pf;

        public ChoosePatient(PatientForm pf, List<PatientModel> patients, IPatient patientService, IExamination examinationService)
        {
            InitializeComponent();
            
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Име на пациента", typeof(string));
            dt.Columns.Add("Телефон", typeof(string));
            dt.Columns.Add("Дата на раждане", typeof(string));
            dt.Columns.Add("email", typeof(string));
            this.patientService = patientService;
            this.examinationService = examinationService;
            this.pf = pf;
            foreach(var patient in patients)
            {
                dt.Rows.Add(new object[]
                        {
                            patient.PatientId,
                            patient.PatientName,
                            patient.PhoneNumber,
                            patient.BirthDate,
                            patient.EmailAddress
                        });
            }
            dgvPatients.DataSource = dt;
        }

        private void dgvPatients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                long patientId = Convert.ToInt64(dgvPatients.Rows[e.RowIndex].Cells[0].Value);
                var patient = patientService.GetPatientById(patientId);
                var patients = new List<PatientModel>();
                patients.Add(patient);
                this.Close();
                pf.ShowPatientData(patients);
                
            }
        }
    }
}
