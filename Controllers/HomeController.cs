using demoform3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace demoform3.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult GetItem()
        {
            return View();
        }
        public Item helper(int id)
        {
            var webClient = new WebClient();
            var jsonString = webClient.DownloadString(@"C:\Users\Acer\Desktop\dotnet-pluralsight\demoform3\wwwroot\lib\jsonData\Items.json");
            var items = JsonConvert.DeserializeObject<Items>(jsonString);
            return items.getElementById(id);
        }
        [HttpPost]
        public ViewResult GetItem(int itemId)
        {
            Item item = helper(itemId);
            ViewBag.Message = item;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
