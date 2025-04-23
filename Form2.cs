using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetCourseFromTDSYnnex
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private async void btnSubmitCourse_Click(object sender, EventArgs e)
        {
            string programId = "AZ307";


            var course = new EduDexCourse
            {
                clientId = new ClientId { orgUnitId = "tdsynnex" },
                editor = "Test Course Creator Ltd",
                expires = "2026-01-01",
                format = "EDU-DEX 1.0",
                generator = "EduDex WinForms Uploader",
                lastEdited = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                programAdmission = new ProgramAdmission
                {
                    applicationOpen = true,
                    applicationType = "individual",
                    paymentDue = "up-front",
                    startDateDetermination = "fixed starting date"
                },
                programClassification = new ProgramClassification
                {
                    degree = "none",
                    orgUnitId = "tdsynnex",
                    programDuration = new ProgramDuration { days = 1 },
                    programForm = new List<string> { "full-time" },
                    programId = "AZ307",
                    programLevel = "post-hbo",
                    programLocation = new List<ProgramLocation>
            {
                new ProgramLocation
                {
                    description = "Online - Azure Training Platform",
                    id = "online-az307"
                }
            },
                    programType = "regular",
                    salaryScaleBBRA = new List<int> { 1 }
                },
                programDescriptions = new ProgramDescriptions
                {
                    programDescriptionText = new LanguageContent
                    {
                        nl = "Fictieve cursus over geavanceerde Azure-oplossingen en beheer."
                    },
                    programName = new LanguageContent
                    {
                        nl = "Azure Expert Training"
                    },
                    programSummaryText = new LanguageContent
                    {
                        nl = "Leer geavanceerde Azure-vaardigheden zoals governance, security en automatisering."
                    }
                },
                programContacts = new ProgramContacts(),
                programCurriculum = new ProgramCurriculum(),
                programSchedule = new ProgramSchedule()
            };

            string apiUrl = "https://api.edudex.nl/data/v1/suppliers/tdsynnex/programs/AZ307/tdsynnex";
            string token = "secret-token:eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJFZHUtRGV4IiwiaWF0IjoxNzQzNTgyMjc5LCJuYmYiOjE3NDM1ODIyNzksInN1YiI6ImVkdWRleC1hcGktdXNlciIsInNjb3BlIjoiZGF0YSIsIm5vbmNlIjoidHV3LWw3enFnbkRkeU1yXzdHTWFidyJ9.5mdiS8xSmdGJJw-cqjlztkIzxzpgcKEl7izFhSafbn4";

            try
            {
                var json = JsonSerializer.Serialize(course, new JsonSerializerOptions { WriteIndented = true });

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PutAsync(apiUrl, content);

                var responseBody = await response.Content.ReadAsStringAsync();
                txtResponse.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}\r\n{responseBody}";




            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Upload Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

