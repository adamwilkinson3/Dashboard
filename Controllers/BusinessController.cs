using Microsoft.AspNetCore.Mvc;
using MovieApp.Models.CustomerModels;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Text.Json;
using MovieApp.Models.BusinessModels;

namespace MovieApp.Controllers
{

    public class BusinessController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        public BusinessController(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }
        [HttpGet]
        public async Task<IActionResult> GetStaff()
        {
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(_config.GetConnectionString("Default") + "Staff/");

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<List<staff>>(stream);

                return View(data);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(_config.GetConnectionString("Default") + $"Staff/{id}");

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<staff>(stream);

                return View(data);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(staff? staff)
        {
            var staffDataJson = new StringContent(
                    JsonSerializer.Serialize(staff),
                    Encoding.UTF8,
                    Application.Json);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.PutAsync(_config.GetConnectionString("Default") + "Staff/", staffDataJson);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetStaff");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.DeleteAsync(_config.GetConnectionString("Default") + $"Staff/?id={id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetStaff");
            }
            return RedirectToAction("GetStaff");
        }
        [HttpGet]
        public IActionResult CreateStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStaff(staff staff)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                var staffaddrDataJson = new StringContent(
                    JsonSerializer.Serialize(staff),
                    Encoding.UTF8,
                    Application.Json);

                HttpResponseMessage response = await client.PostAsync(_config.GetConnectionString("Default") + "StaffAddress/", staffaddrDataJson);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStaff");
                }
            }
            return View();
        }
    }
}
