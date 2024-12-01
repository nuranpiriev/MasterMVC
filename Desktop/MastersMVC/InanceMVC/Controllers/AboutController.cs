using Microsoft.AspNetCore.Mvc;

namespace InanceMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
