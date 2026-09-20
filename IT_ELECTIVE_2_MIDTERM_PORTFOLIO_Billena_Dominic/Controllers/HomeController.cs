using IT_ELECTIVE_2_MIDTERM_PORTFOLIO_Billena_Dominic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IT_ELECTIVE_2_MIDTERM_PORTFOLIO_Billena_Dominic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
