using Microsoft.AspNetCore.Mvc;

namespace Purple_Buzz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
