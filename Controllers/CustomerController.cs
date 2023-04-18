using Microsoft.AspNetCore.Mvc;
using MovieApp.Models.CustomerModels;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Text.Json;
using System.IO;

namespace MovieApp.Controllers;

public class CustomerController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _config;

    public CustomerController(IHttpClientFactory clientFactory, IConfiguration config)
    {
        _clientFactory = clientFactory;
        _config = config;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(_config.GetConnectionString("Default") + "Customers/");

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<customer>>(stream);

            return View(data);
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateCustomer(int id)
    {
        var client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(_config.GetConnectionString("Default") + $"Customers/{id}");

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<customer>(stream);

            return View(data);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(customer? customer)
    {
        var customerDataJson = new StringContent(
                JsonSerializer.Serialize(customer),
                Encoding.UTF8,
                Application.Json);

        var client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.PutAsync(_config.GetConnectionString("Default") + "Customers/", customerDataJson);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("GetAllCustomers");
        }
        return View();
    }

    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.DeleteAsync(_config.GetConnectionString("Default") + $"Customers/?id={id}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("GetAllCustomers");
        }
        return RedirectToAction("GetAllCustomers");
    }
    public IActionResult CreateCustomer()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCustomer(customer customerData)
    {
        if (ModelState.IsValid)
        {
            var client = _clientFactory.CreateClient();

            var customerDataJson = new StringContent(
                JsonSerializer.Serialize(customerData),
                Encoding.UTF8,
                Application.Json);

            HttpResponseMessage response = await client.PostAsync(_config.GetConnectionString("Default") + "Customers/", customerDataJson);

            if (response.IsSuccessStatusCode)
            {
                return View("CreateCustomer");
            }
        }
        return View();
    }
    public IActionResult CreateAddress()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAddress(address addressData)
    {
        if (ModelState.IsValid)
        {
            //var request = new HttpRequestMessage(
            //    HttpMethod.Post,
            //    "https://localhost:7110/Customers/");

            var client = _clientFactory.CreateClient();

            var customerDataJson = new StringContent(
                JsonSerializer.Serialize(addressData),
                Encoding.UTF8,
                Application.Json);

            HttpResponseMessage response = await client.PostAsync(_config.GetConnectionString("Default") + "Addresses/", customerDataJson);

            if (response.IsSuccessStatusCode)
            {
                return View("CreateAddress");
            }
        }
        return View();
    }
    [HttpGet]
    public IActionResult Customer_Address()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Customer_Address(customer customer)
    {
        if (ModelState.IsValid)
        {
            var client = _clientFactory.CreateClient();

            var custaddrDataJson = new StringContent(
                JsonSerializer.Serialize(customer),
                Encoding.UTF8,
                Application.Json);

            HttpResponseMessage response = await client.PostAsync(_config.GetConnectionString("Default") + "CustomersAddress/", custaddrDataJson);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCustomers");
            }
        }
        return View();
    }
}
