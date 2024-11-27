using PurpleBuzz.DAL;
using PurpleBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        readonly AppDBContext _context;
        public ServicesController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Services> services = _context.Services.ToList();
            
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Services service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            service.CreatedAt = DateTime.Now;
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            Services deletedService = _context.Services.Find(Id);
            if (deletedService == null)
            {
                return NotFound("The service you request can not be found.");
            }

            _context.Remove(deletedService);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            Services selectedService = _context.Services.Find(Id);
            if (selectedService == null)
            {
                return NotFound("The service you request can not be found.");
            }
            else
            {
                return View(selectedService);
            }
        }

        [HttpPost]

        public IActionResult Edit(Services updatedService)
        {
            Services currentService = _context.Services.Find(updatedService.Id);
            if (currentService == null)
            {
                return NotFound("The service you request can not be found in system.");
            }
            else
            {
                updatedService.CreatedAt = currentService.CreatedAt;
                updatedService.UpdatedAt = DateTime.Now;
                _context.Services.Update(updatedService);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
