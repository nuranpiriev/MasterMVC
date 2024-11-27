using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels.Service;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
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
