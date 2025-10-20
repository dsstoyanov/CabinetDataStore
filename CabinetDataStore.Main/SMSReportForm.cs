using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.BusinessService.ExaminationModels;
using CabinetDataStore.BusinessService.PatientModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private readonly INotification notificationService;
        private DataTable smsReportDataTable = new DataTable();

        private static readonly HttpClient httpClient = new HttpClient();

        private const string BASE_URL = "https://1gkng9.api.infobip.com";
        private const string API_KEY = "b4166313dab93d897d2653516f3ab235-51f03db1-155c-44ae-9eef-4eead78a7a3b";
        private const string SENDER_ID = "Kornovski"; // Must be approved by Infobip

        public SMSReportForm()
        {
            InitializeComponent();
        }

        public SMSReportForm(IPatient patientService, IExamination examinationService, INotification notificationService)
        {
            InitializeComponent();
            this.patientService = patientService;
            this.examinationService = examinationService;
            this.notificationService = notificationService;

            this.Focus();
        }

        private void SMSReportForm_Load(object sender, EventArgs e)
        {
            smsReportView.ReadOnly = false;
            smsReportView.Columns[0].ReadOnly = true;
            smsReportView.Columns[1].ReadOnly = true;
            smsReportView.Columns[2].ReadOnly = true;
            smsReportView.Columns[3].ReadOnly = true;
            smsReportView.Columns[4].ReadOnly = false;
            smsReportView.Columns[0].Resizable = DataGridViewTriState.False;
            smsReportView.Columns[1].Resizable = DataGridViewTriState.False;
            smsReportView.Columns[2].Resizable = DataGridViewTriState.False;
            smsReportView.Columns[3].Resizable = DataGridViewTriState.False;
            smsReportView.Columns[4].Resizable = DataGridViewTriState.False;
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
            // Get and order the data
            var examinations = (examinationService.GetExaminationsByTimeRange(dtFrom, dtTo) ?? new List<ExaminationModel>())
                .OrderByDescending(x => x.ExaminationDate)
                .ToList();

            // Populate DataGridView
            if (examinations.Count > 0)
            {
                foreach (var exam in examinations)
                {
                    var notif = exam.Notifications?.FirstOrDefault(); // cache once to avoid double lookup
                    
                    smsReportView.Rows.Add(new object[]
                    {
                        notif?.NotificationId.ToString() ?? "",
                        exam.ExaminationDate.ToString(CultureInfo.InvariantCulture),
                        exam.Patient?.PatientName ?? "",
                        exam.Patient?.PhoneNumber ?? "",
                        notif?.isNotified ?? false,
                        exam.Patient?.PatientId,
                        exam.ExaminationID
                    });
                }
            }

            if (smsReportView.Rows.Count > 0)
            {
                label1.Visible = true;
                if (smsReportView.Rows.Count == 1)
                    label1.Text = $"Общо: {smsReportView.Rows.Count} резултат";
                else if (smsReportView.Rows.Count > 1)
                    label1.Text = $"Общо: {smsReportView.Rows.Count} резултата";
                else
                    label1.Visible = false;
                label1.ForeColor = Color.Green;
            }
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

        private void smsReportView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == smsReportView.Columns["columnChk"]?.Index && e.RowIndex >= 0)
            {
                smsReportView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void smsReportView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == smsReportView.Columns["columnChk"]?.Index && e.RowIndex >= 0)
            {
                // if we can parse the notification id from datagridview => operation UPDATE
                if (long.TryParse(smsReportView.Rows[e.RowIndex].Cells["NotificationId"].Value.ToString(), out long notificationId))
                {
                    bool newValue = Convert.ToBoolean(smsReportView.Rows[e.RowIndex].Cells["columnChk"].Value);

                    //Update database here
                    bool updateResult = notificationService.UpdateNotification(notificationId, newValue);

                    //check if it is updated successfully
                    if (!updateResult)
                        MessageBox.Show("Неуспешно маркиране, промените не са запазени!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //otherwise => operation INSERT
                else
                {
                    long PatientId = Convert.ToInt64(smsReportView.Rows[e.RowIndex].Cells["PatientId"].Value);
                    long ExaminationId = Convert.ToInt64(smsReportView.Rows[e.RowIndex].Cells["ExaminationId"].Value);
                    var ExaminationDate = DateTime.Parse(smsReportView.Rows[e.RowIndex].Cells["ExamDate"].Value.ToString(), CultureInfo.CurrentCulture);
                    long? insertedId = notificationService.InsertNotification(PatientId, ExaminationId, ExaminationDate);
                    if (insertedId == null || insertedId <= 0)
                    {
                        MessageBox.Show("Неуспешно маркиране, промените не са запазени!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        smsReportView.Rows[e.RowIndex].Cells["NotificationId"].Value = insertedId.Value.ToString();
                    }
                    
                }

               
            }
        }
    }
}
