using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DailyWeather.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailyWeather.Controllers
{
    public class RainfallController : Controller
    {
        public RainfallController(){
            ApiHelper.InitializeClient();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rainfall()
        {
            RainfallModel result = ProcessRainfallForStation().Result;
            return View(result);
        }

        public async Task<RainfallModel> ProcessRainfallForStation()
        {
            var serializer = new DataContractJsonSerializer(typeof(RainfallModel));
            var streamTask = ApiHelper.APIClient.GetStreamAsync("https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/23/station/53430/period/latest-months/data.json");
            var result = serializer.ReadObject(await streamTask) as RainfallModel;

            String s = Request.Headers["X-requested-With"];
            if(Request.Headers["X-requested-With"] == "XMLHttpRequest")
            {

            }

            return result;
        }

    }
}
