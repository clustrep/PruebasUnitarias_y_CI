using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Demos.AzureDevOps.UI.Web.Models;
using Demos.AzureDevOps.Common.Config;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Demos.AzureDevOps.Common.Entities;
using Newtonsoft.Json;
using System.Text;

namespace Demos.AzureDevOps.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppConfig> _options;
        private static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger,
                              IOptions<AppConfig> options)
        {
            _logger = logger;
            _options = options;
        }

        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync($"{_options.Value.ApiUrl}/people");
            var peopleJson = await response.Content.ReadAsStringAsync();
            List<Person> model = JsonConvert.DeserializeObject<List<Person>>(peopleJson);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await client.GetAsync($"{_options.Value.ApiUrl}/people/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();
            var peopleJson = await response.Content.ReadAsStringAsync();
            Person model = JsonConvert.DeserializeObject<Person>(peopleJson);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_options.Value.ApiUrl}/people/", data);
            if (!response.IsSuccessStatusCode)
                return NotFound();
            var peopleJson = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<Person>(peopleJson);
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await client.GetAsync($"{_options.Value.ApiUrl}/people/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();
            var peopleJson = await response.Content.ReadAsStringAsync();
            Person model = JsonConvert.DeserializeObject<Person>(peopleJson);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await client.DeleteAsync($"{_options.Value.ApiUrl}/people/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
