using PurpleBuzz.DAL;
using PurpleBuzz.Models;
using PurpleBuzz.ViewModels.Work;
using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzz.Controllers
{
    public class WorkController : Controller
    {
        readonly AppDBContext _context;
        public WorkController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Work> works = _context.Works.ToList();
            WorkVM workVM = new WorkVM()
            {
                Works = works
            };
            return View(workVM);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
