using Microsoft.AspNetCore.Mvc;

namespace Purple_Buzz.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
