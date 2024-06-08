using JobForum3._0.Models;
using System.Text.Json;

namespace JobForum3._0.DAL
{
    public class JobAdManagerAPI
    {
        private static Uri BaseAddress = new Uri("https://jobforumapi.azurewebsites.net/");
        public static async Task<Models.JobAd> GetAllJobAds()
        {
            Models.JobAd jobAd = new Models.JobAd();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/JobAd");
                if(response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    jobAd = JsonSerializer.Deserialize<Models.JobAd>(responseString);
                }
            }
            return jobAd;
        }

        public static async Task<Models.Hit> GetJobAds(string municipality)
        {
            Models.Hit jobAd = new Models.Hit();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/JobAd/" + municipality);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    jobAd = JsonSerializer.Deserialize<Models.Hit>(responseString);
                }
            }
            return jobAd;
        }
    }
}
