using Microsoft.AspNetCore.Mvc;

namespace InanceMVC.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
