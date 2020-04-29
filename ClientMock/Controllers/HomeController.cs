using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClientMock.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ClientMock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJFUzI1NiIsImtpZCI6ImFwaWNvbGxlbGxpdHRpY29fa2V5In0.ew0KImlzcyI6ICJ3d3cuaW5haWwuaXQiLA0KImlhdCI6IDE1ODcxMzk2OTQsDQoianRpIjogIkFHQ0NkYjUxNDk4ZC1iM2Y5LTQxZGEtODJjZi1mMDU2YTljOWFjNWMiLA0KImF6cCI6ICJDbGllbnRUZXN0QVBQIiwNCiJleHAiOiAxNTg3MTUwNDk0LA0KImF1ZCI6IFsiSldUU0dQIiwiY29sbHBvcnRhbGUuaW5haWwuaXQiXSwNCiJzdWIiOiAieWVuZzU1MyIsDQoidW5pcXVlX25hbWUiOiAieWVuZzU1MyIsDQoidXNlcl9uYW1lIjogInllbmc1NTMiLA0KImFjciI6ICIiLA0KInJvbGVzIjogW10sDQoiYXV0aG9yaXRpZXMiOiBbXSwNCiJzY29wZSIgOiAiIg0KfQ.jB6LazkmHfDbLuZJnI1-xTfmtXMeUSPAMyjCTaKTJlBq3hFQTaXpppBWx5g9iUX04bKsbbLDbl3FrE0EPc5iPQ";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendRequest(string vista)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            var content = new StringContent(JsonConvert.SerializeObject(new RisultatoTotaleElementiVista()), Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(
                $"https://localhost:44382/viewqlikapi/totaleelementivista?vista={vista}",
                content);
            string responseBody = await response.Content.ReadAsStringAsync();
            RisultatoTotaleElementiVista result = JsonConvert.DeserializeObject<RisultatoTotaleElementiVista>(responseBody);

            if (response.StatusCode == HttpStatusCode.OK)
                ViewData["Result"] = result.TotaleElementiVista;
            else
                ViewData["Result"] = $"KO - {result.RisultatoRichiesta.Messaggio}";


            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
