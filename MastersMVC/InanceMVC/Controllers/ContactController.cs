using Microsoft.AspNetCore.Mvc;

namespace InanceMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
