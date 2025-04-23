// Clean and corrected EdudexMapper
// Maps GetCourseFromTDSYnnex.Course to GetCourseFromTDSYnnex.EduDexCourse

using GetCourseFromTDSYnnex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GetCourseFromTDSYnnex
{
    public static class EdudexMapper
    {
        static string courseName = string.Empty;
        public static EduDexCourse MapCourse(Course course)
        {
            var descriptionText = course.Descriptions != null && course.Descriptions.ContainsKey("EN")
? StripHtml(course.Descriptions["EN"].Description).Trim().Substring(0, Math.Min(1199, StripHtml(course.Descriptions["EN"].Description).Trim().Length))
: string.Empty;
            courseName = course.Name;
            return new EduDexCourse
            {
                programContacts = new ProgramContacts(),
                programCurriculum = new ProgramCurriculum(),
                programSchedule = new ProgramSchedule { },
                clientId = new ClientId { orgUnitId = "tdsynnex" },
                editor = "mike@solutionsdeveloped.co.uk",
                format = "EDU-DEX 1.0-SolDev",
                generator = "TDSynnex-Edudex-Mapper",
                lastEdited = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                expires = DateTime.UtcNow.AddYears(1).ToString("yyyy-MM-dd"),
                programAdmission = new ProgramAdmission
                {
                    applicationOpen = true,
                    applicationType = "individual",
                    paymentDue = "up-front",
                    startDateDetermination = "agreed starting date"
                },
                programClassification = new ProgramClassification
                {
                    degree = "none",
                    orgUnitId = "tdsynnex",
                    programDuration = new ProgramDuration
                    {
                        days = (int)course.Duration
                    },
                    programForm = new List<string> { "full-time" },
                    programId = course.Name,
                    programLevel = "post-hbo",
                    programLocation = new List<ProgramLocation>
                    {
                        new ProgramLocation
                        {
                            description = $"Online - {course.ClassroomDeliveryMethod}",
                            id = course.Category
                        }
                    },
                    programType = "regular",
                    salaryScaleBBRA = new List<int> { 1 }
                },
                programDescriptions = new ProgramDescriptions
                {
                    programName = new LanguageContent { nl = course.Title },
                    programDescriptionText = new LanguageContent { nl = descriptionText },
                    programSummaryText = new LanguageContent { nl = course.Title },
                    courseSiteLink = new LanguageContent { nl = course.RegistrationLink }
                }

            };
        }

        private static string StripHtml(string html)
        {
            return Regex.Replace(html ?? string.Empty, "<.*?>", string.Empty);
        }

        public static void SaveEdudexFile(EduDexCourse edudexData, string outputPath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(edudexData, options);
            File.WriteAllText(outputPath, json);
        }

        public static async Task<(bool Success, string ResponseText)> PostEdudexToApi(EduDexCourse edudexData, string apiUrl, string bearerToken)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            var json = JsonSerializer.Serialize(edudexData, options);
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

            var content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await httpClient.PutAsync(apiUrl, content);
            var responseBody = await response.Content.ReadAsStringAsync();

           

            await new EduDexPoster().PostProgramAsync(courseName, bearerToken);

            return (response.IsSuccessStatusCode, responseBody);
        }

    }
}


public class EduDexPoster
{
    public async Task PostProgramAsync(string varProgID, string bearerToken)
    {
        string supplierId = "tdsynnex";
        string apiUrl = $"https://api.edudex.nl/data/v1/organizations/{supplierId}/staticcatalogs/40b4279e-2941-41da-b28b-15f79735f626/programs/bulkadd";
        var payload = new[]
{
    new
    {
        supplierId = "tdsynnex",
        programId = varProgID
    }
};

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var json = JsonSerializer.Serialize(payload, options);

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        var content = new StringContent(json);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await httpClient.PostAsync(apiUrl, content);
        var responseBody = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            Debug.WriteLine($"❌ Status: {response.StatusCode}");
            Debug.WriteLine($"💬 Response body: {responseBody}");
        }
        else
        {
            Debug.WriteLine("✅ Success! Program added to static catalog.");
            Debug.WriteLine($"📦 Response: {responseBody}");
        }

    }
}

