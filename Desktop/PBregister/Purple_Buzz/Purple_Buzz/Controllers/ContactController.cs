using Microsoft.AspNetCore.Mvc;

namespace Purple_Buzz.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
