using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int _clickCount = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Increment()
        {
            _clickCount++;
            ViewData["Count"] = _clickCount;
            return View("Index");
        }

        public IActionResult ClicksPage()
        {
            ViewData["ClickCount"] = _clickCount;
            return View();
        }

        public IActionResult ReversePage()
        {
            return View();
        }

        public IActionResult Index()
        {
            ViewData["Count"] = _clickCount;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReversePage(string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                var reversedString = new string(inputString.Reverse().ToArray());
                var reversedWords = string.Join(" ", inputString.Split(' ').Reverse());

                ViewData["Original"] = inputString;
                ViewData["ReversedString"] = reversedString;
                ViewData["ReversedWords"] = reversedWords;
            }
            return View();

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
