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

        public BusinessController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> GetStaff()
        {
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7110/Staff/");

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

            HttpResponseMessage response = await client.GetAsync($"https://localhost:7110/Staff/{id}");

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

            HttpResponseMessage response = await client.PutAsync($"https://localhost:7110/Staff/", staffDataJson);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetStaff");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7110/Staff/?id={id}");

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

                HttpResponseMessage response = await client.PostAsync("https://localhost:7110/StaffAddress/", staffaddrDataJson);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStaff");
                }
            }
            return View();
        }
    }
}
