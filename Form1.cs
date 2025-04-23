using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace GetCourseFromTDSYnnex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbLanguage.Items.AddRange(new string[] { "EN", "FR", "NL" });
            cmbLanguage.SelectedIndex = 0; // Default to English

            // OPTIONAL: Auto-load courses on startup
            // btnLoadCourses.PerformClick();
        }


        // Make sure these match your model structure
        private async Task<List<Course>> FetchCoursesAsync()
        {
            string username = "AC-059137";
            string apiUrl = "https://academy.tdsynnex.com/api/v2/catalog/?vendor=Microsoft";

            using HttpClient client = new HttpClient();

            // Set up basic authentication
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{"Edu25Dex"}");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            try
            {
                // Optional: set a reasonable timeout
                client.Timeout = TimeSpan.FromSeconds(30);

                // Call and parse the JSON response
                var courses = await client.GetFromJsonAsync<List<Course>>(apiUrl, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return courses ?? new List<Course>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
                return new List<Course>();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Ask the user for the password at runtime (e.g., via InputBox or separate textbox)


            var courses = await FetchCoursesAsync();

            dataGridViewCourses.DataSource = courses;
        }


        private string StripHtml(string html)
        {
            return System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", string.Empty);
        }

        private void dataGridViewCourses_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow?.DataBoundItem is Course selectedCourse)
            {
                string selectedLang = cmbLanguage.SelectedItem?.ToString() ?? "EN";

                if (selectedCourse.Descriptions != null &&
                    selectedCourse.Descriptions.TryGetValue(selectedLang, out var desc) &&
                    !string.IsNullOrEmpty(desc.Description))
                {
                    rtbDescription.Text = StripHtml(desc.Description);
                    // Or: webView2Description.NavigateToString(desc.Description); if you're using WebView2
                }
                else
                {
                    rtbDescription.Text = $"No description available in {selectedLang}.";
                }
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewCourses_SelectionChanged_1(null, null);
        }

        private void btnExportToEdudex_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCourses.CurrentRow?.DataBoundItem is Course selectedCourse)
                {
                    var edudexCourse = GetCourseFromTDSYnnex.EdudexMapper.MapCourse(selectedCourse);

                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.Filter = "JSON files (*.json)|*.json";
                        dialog.FileName = $"edudex-{selectedCourse.Name}.json";

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            GetCourseFromTDSYnnex.EdudexMapper.SaveEdudexFile(edudexCourse, dialog.FileName);
                            MessageBox.Show("Course exported successfully!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a course first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task PostSelectedCourseToEdudex(Course selectedCourse)
        {
            // Map to Edudex format
            var edudexCourse = EdudexMapper.MapCourse(selectedCourse);

            // Replace with your actual API URL and secure token
            //string apiUrl = "https://api.edudex.example.com/upload"; // ⬅️ Update this!
            //string bearerToken = "your-edudex-bearer-token"; // ⬅️ Secure this!
            string varProgID = selectedCourse.Name;
            string apiUrl = "https://api.edudex.nl/data/v1/suppliers/tdsynnex/programs/" + varProgID + "/tdsynnex";
            string bearerToken = "secret-token:eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJFZHUtRGV4IiwiaWF0IjoxNzQzNTgyMjc5LCJuYmYiOjE3NDM1ODIyNzksInN1YiI6ImVkdWRleC1hcGktdXNlciIsInNjb3BlIjoiZGF0YSIsIm5vbmNlIjoidHV3LWw3enFnbkRkeU1yXzdHTWFidyJ9.5mdiS8xSmdGJJw-cqjlztkIzxzpgcKEl7izFhSafbn4";


            // Post to Edudex API
            (bool success, string responseText) = await EdudexMapper.PostEdudexToApi(edudexCourse, apiUrl, bearerToken);

            // Display response
            txtResponse.Text = responseText;

         
        }



        private async void btnPostToEdudex_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.Rows.Count == 0)
            {
                MessageBox.Show("⚠️ No courses available to upload.");
                return;
            }

            // Confirm upload with user
            if (MessageBox.Show("Are you sure you want to upload all courses to EduDex?", "Confirm Upload", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            foreach (DataGridViewRow row in dataGridViewCourses.Rows)
            {
                if (row.DataBoundItem is Course course)
                {
                    try
                    {
                        await PostSelectedCourseToEdudex(course);
                        Console.WriteLine($"✅ Uploaded: {course.Name}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Failed to upload {course.Name}: {ex.Message}");
                    }

                    await Task.Delay(250); // optional polite delay
                }
            }

            MessageBox.Show("🎉 All courses processed.");
        }

    }
}
