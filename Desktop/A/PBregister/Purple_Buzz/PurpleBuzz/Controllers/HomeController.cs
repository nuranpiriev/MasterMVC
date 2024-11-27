using PurpleBuzz.DAL;
using PurpleBuzz.Models;
using PurpleBuzz.ViewModels.Service;
using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzz.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDBContext _context;
        public HomeController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Services> services = _context.Services.ToList();
            ServiceVM servicesVM = new ServiceVM()
            {
                servicesVM = services
            };
            return View(servicesVM);
        }
    }
}
