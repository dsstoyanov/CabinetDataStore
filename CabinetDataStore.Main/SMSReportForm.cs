using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.BusinessService.ExaminationModels;
using CabinetDataStore.BusinessService.PatientModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CabinetDataStore.Main
{
    public partial class SMSReportForm : Form
    {
        private readonly IPatient patientService;
        private readonly IExamination examinationService;
        private readonly PatientModel patientModel;
        private readonly ExaminationModel examinationModel;
        private DataTable smsReportDataTable = new DataTable();

        private static readonly HttpClient httpClient = new HttpClient();

        private const string BASE_URL = "https://1gkng9.api.infobip.com";
        private const string API_KEY = "b4166313dab93d897d2653516f3ab235-51f03db1-155c-44ae-9eef-4eead78a7a3b";
        private const string SENDER_ID = "Kornovski"; // Must be approved by Infobip

        public SMSReportForm()
        {
            InitializeComponent();
        }

        public SMSReportForm(IPatient patientService, IExamination examinationService)
        {
            InitializeComponent();
            this.patientService = patientService;
            this.examinationService = examinationService;

            //smsReportDataTable.Columns.Add("Дата на преглед", typeof(string));
            //smsReportDataTable.Columns.Add("Пациент", typeof(string));
            //smsReportDataTable.Columns.Add("Телефон", typeof(string));
            //smsReportDataTable.Columns.Add("Диагноза", typeof(string));

            this.Focus();
        }

        private void SMSReportForm_Load(object sender, EventArgs e)
        {
            dtFrom.Enabled = false;
            dtTo.Enabled = false;
            label2.Visible = false;
            label3.Visible = false;
            label1.Visible = false;
            comboFilter.SelectedIndex = 0;
            dtFrom.Value = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month - 1, DateTime.Now.Day);
            dtTo.Value = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month + 1, DateTime.Now.Day);

            LoadExaminationsByDateDescending(dtFrom.Value, dtTo.Value);
        }

        private void LoadExaminationsByDateDescending(DateTime dtFrom, DateTime dtTo)
        {
            smsReportDataTable.Clear();
            List<ExaminationModel> examinations = (examinationService.GetExaminationsByTimeRange(dtFrom, dtTo) ?? new List<ExaminationModel>())
                .OrderByDescending(x => x.ExaminationDate)
                .ToList();

            if (examinations != null && examinations.Count >= 1)
            {
                
                foreach (var examination in examinations)
                {
                    var patient = patientService.GetPatientById(examination.PatientId);
                    smsReportView.Rows.Add(new object[] { examination.ExaminationDate.ToString("dd/MM/yyyy HH:mm:ss"), patient.PatientName, patient.PhoneNumber, examination.Diagnosis, false });
                    
                }
            }
            if(smsReportView.Rows.Count > 0)
            {
                label1.Visible = true;
                label1.Text= $"Общо: {smsReportView.Rows.Count} резултата";
                label1.ForeColor = Color.Green;
            }
            //smsReportView.DataSource = smsReportDataTable;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            smsReportView.Rows.Clear();
            LoadExaminationsByDateDescending(dtFrom.Value, dtTo.Value);
        }

        private async void  send_Click(object sender, EventArgs e)
        {
            string phone = "+359882209818";
            string messageText = "Congratulations on sending first message.";

            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(messageText))
            {
                MessageBox.Show("Please enter both phone number and message text.");
                return;
            }

            try
            {
                var json = $@"
                {{
                    ""messages"": [
                        {{
                            ""from"": ""+447491163443"",
                            ""destinations"": [{{ ""to"": ""{phone}"" }}],
                            ""text"": ""{messageText}""
                        }}
                    ]
                }}";

                var request = new HttpRequestMessage(HttpMethod.Post, $"{BASE_URL}/sms/2/text/advanced")
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                request.Headers.Add("Authorization", $"App {API_KEY}");

                HttpResponseMessage response = await httpClient.SendAsync(request);

                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = JObject.Parse(result);
                    var messageInfo = jsonRes["messages"]?[0];
                    string messageId = messageInfo?["messageId"]?.ToString();
                    string status = messageInfo?["status"]?["name"]?.ToString();
                    string description = messageInfo?["status"]?["description"]?.ToString();

                    MessageBox.Show($"✅ SMS sent!\n\nMessage ID: {messageId}\nStatus: {status}\nDescription: {description}");
                }
                else
                {
                    MessageBox.Show($"❌ Failed ({response.StatusCode}): {result}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Error: {ex.Message}");
            }

        }

        private void comboFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboFilter.SelectedIndex == 3)
            {
                label2.Visible = true;
                label3.Visible = true;
                dtFrom.Enabled = true;
                dtTo.Enabled = true;
                label1.Visible = false;
            }
            else if (comboFilter.SelectedIndex == 0)
            {
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
                label1.Visible = false;
                dtFrom.Value = DateTime.Now.AddYears(-1).AddMonths(-1);
                dtTo.Value = DateTime.Now.AddYears(-1).AddMonths(+1); ;

            }
            else if (comboFilter.SelectedIndex == 1)
            {
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
                label1.Visible = false;
                dtFrom.Value = DateTime.Now.AddMonths(-2);
                dtTo.Value = DateTime.Now.AddMonths(-1);

            }
            else if (comboFilter.SelectedIndex == 2)
            {
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
                label1.Visible = false;
                dtFrom.Value = DateTime.Now.AddDays(-14); 
                dtTo.Value = DateTime.Now.AddDays(-7);
            }
            else
            {
                MessageBox.Show("Моля изберете валиден филтър!","Грешка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
