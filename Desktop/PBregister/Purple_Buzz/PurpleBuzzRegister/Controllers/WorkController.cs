using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels.Work;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
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
