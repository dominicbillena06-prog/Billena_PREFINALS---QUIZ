using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_2_MIDTERM_PORTFOLIO_Billena_Dominic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}