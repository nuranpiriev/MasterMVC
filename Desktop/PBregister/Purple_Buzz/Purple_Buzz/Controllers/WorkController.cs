using Microsoft.AspNetCore.Mvc;

namespace Purple_Buzz.Controllers
{
    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
