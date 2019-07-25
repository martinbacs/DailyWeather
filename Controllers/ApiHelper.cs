using System;
using System.Net.Http;

namespace DailyWeather.Controllers
{
    public static class ApiHelper
    {
        public static HttpClient APIClient { get; set; } = new HttpClient();

        public static void InitializeClient()
        {
            APIClient = new HttpClient();
            //APIClient.BaseAddress = new Uri("https://opendata-download-metobs.smhi.se");
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
