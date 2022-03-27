using Microsoft.AspNetCore.Mvc;

namespace da2.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NotEnough()
        {
            return View();
        }
    }
}