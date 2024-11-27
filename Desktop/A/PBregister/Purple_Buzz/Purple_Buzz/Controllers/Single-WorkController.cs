using Microsoft.AspNetCore.Mvc;

namespace Purple_Buzz.Controllers
{
    public class Single_WorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
