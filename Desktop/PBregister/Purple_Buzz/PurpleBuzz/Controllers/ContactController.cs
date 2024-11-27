using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzz.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
