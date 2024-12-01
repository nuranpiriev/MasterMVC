using Microsoft.AspNetCore.Mvc;

namespace InanceMVC.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
