using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DailyWeather.Models;
using System.Runtime.Serialization.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailyWeather.Controllers
{
    public class ForecastController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Forecast(Double lng, Double lat)
        {

            double ln = Math.Floor(Convert.ToDouble(lng) * 1000000) / 1000000;
            double la = Math.Floor(Convert.ToDouble(lat) * 1000000) / 1000000;
            ForecastModel result = GetForecast(ln, la).Result;
            return PartialView("PartialForecast", result);
        }



        public async Task<ForecastModel> GetForecast(double lng, double lat)
        {
            var serializer = new DataContractJsonSerializer(typeof(ForecastModel));
            var streamTask = ApiHelper.APIClient.GetStreamAsync("https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/" + lng + "/lat/" + lat + "/data.json");
            var result = serializer.ReadObject(await streamTask) as ForecastModel;

            return result;
        }
    }
}
