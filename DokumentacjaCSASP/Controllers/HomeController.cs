using DokumentacjaCSASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DokumentacjaCSASP.Controllers
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
            async Task<int> RetrieveDocsHomePage()
            {
                var client = new HttpClient();
                byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/");

                Console.WriteLine($"{nameof(RetrieveDocsHomePage)}: Finished downloading.");
                return content.Length;
            }
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

    public class HelpAttribute :Attribute {
        string _url;
        string _topic;
        public HelpAttribute(string url) => _url = url;
        public string Url => _url;
        public string Topic
        {
            get=> _topic;
            set => _topic = value;
        }
    }
    [Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/features")]
    public class Widget
    {
        [Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/features",
       Topic = "Display")]
        public void Display(string text) { }

    }
}
