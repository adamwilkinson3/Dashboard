using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Text.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using MovieApp.Models.CustomerModels;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {

            //var request = new HttpRequestMessage(
            //    HttpMethod.Get,
            //    "https://localhost:7110/Customers/"); //{ Headers = { HeaderNames. , "" } }

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}