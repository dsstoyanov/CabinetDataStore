using CabinetDataStore.Business.Abstraction;
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
    public partial class SMSReportForm : Form
    {
        private readonly IPatient patientService;
        private readonly IExamination examinationService;
        private readonly PatientModel patientModel;
        private readonly ExaminationModel examinationModel;
        private DataTable smsReportDataTable = new DataTable();

        public SMSReportForm()
        {
            InitializeComponent();
        }

        public SMSReportForm(IPatient patientService, IExamination examinationService)
        {
            InitializeComponent();
            this.patientService = patientService;
            this.examinationService = examinationService;
           
            this.Focus();
        }

        private void SMSReportForm_Load(object sender, EventArgs e)
        {
            dtFrom.Visible = false;
            dtTo.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            smsReportDataTable.Clear();
            dtFrom.Value = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month - 1, DateTime.Now.Day);
            dtTo.Value = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month + 1, DateTime.Now.Day);

            smsReportDataTable.Columns.Add("No.", typeof(string));
            smsReportDataTable.Columns.Add("Дата на преглед", typeof(string));
            smsReportDataTable.Columns.Add("Пациент", typeof(string));
            smsReportDataTable.Columns.Add("Телефон", typeof(string));
            smsReportDataTable.Columns.Add("Диагноза", typeof(string));
            
            LoadExaminationsByDateDescending(dtFrom.Value, dtTo.Value);
            
            
        }

        private void LoadExaminationsByDateDescending(DateTime dtFrom, DateTime dtTo)
        {
            int i = 1;
            smsReportDataTable.Clear();
            smsReportDataTable.Rows.Clear();
            List<ExaminationModel> examinations = examinationService.GetExaminationsByTimeRange(dtFrom, dtTo).OrderByDescending(x=>x.ExaminationDate).ToList();
            if (examinations != null && examinations.Count >= 1)
            {
                
                foreach (var examination in examinations)
                {
                    var patient = patientService.GetPatientById(examination.PatientId);
                    smsReportDataTable.Rows.Add(new object[] { i.ToString(), examination.ExaminationDate.ToString("dd/MM/yyyy HH:mm:ss"), patient.PatientName, patient.PhoneNumber, examination.Diagnosis });
                    i++;
                }
            }
            
            smsReportView.DataSource = smsReportDataTable;
            smsReportView.Columns["No."].Width = 60;
            smsReportView.Columns["Дата на преглед"].Width = 150;
            smsReportView.Columns["Пациент"].Width = 250;
            smsReportView.Columns["Телефон"].Width = 150;
            smsReportView.Columns["Диагноза"].Width = 200;
            this.smsReportView.Sort(this.smsReportView.Columns["Дата на преглед"], ListSortDirection.Descending);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadExaminationsByDateDescending(dtFrom.Value, dtTo.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 3)
            {
                label2.Visible = true;
                label3.Visible = true;
                dtFrom.Visible = true;
                dtTo.Visible = true;
            }
            else
            {
                label2.Visible = false;
                label3.Visible = false;
                dtFrom.Visible = false;
                dtTo.Visible = false;
            }
        }
    }
}
