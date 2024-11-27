using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzz.Controllers
{
    public class PricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
