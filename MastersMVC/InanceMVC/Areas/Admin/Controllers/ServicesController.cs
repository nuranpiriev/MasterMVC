using InanceMVC.DAL.Contexts;
using InanceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InanceMVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ServicesController : Controller
    {
        readonly AppDbContext _context;
        public ServicesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> service = await _context.Services.ToListAsync();
            return View(service);
        }
        public async Task<IActionResult> Info(int Id)
        {
            Service? service = await _context.Services.FirstOrDefaultAsync(m => m.Id == Id);
            if (service == null)
            {
                return NotFound("Something went wrong!");
            }
            return View(service);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            service.CreatedAt = DateTime.Now;
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Services");
        }

        public async Task<IActionResult> SoftDelete(int Id)
        {
            Service? deletedService = await _context.Services.FirstOrDefaultAsync(m => m.Id == Id);
            if (deletedService == null)
            {
                return NotFound("Something went wrong!");
            }

            bool hasOrders = await _context.Orders.AnyAsync(o=>o.ServiceId == Id);
            bool hasMasters = _context.Orders.Any(o => o.ServiceId == Id && o.MasterId != null);
            if (hasOrders || hasMasters)
            {
                return BadRequest("Cannot delete this service.");
            }

            deletedService.isActive = false;
            deletedService.DeletedAt = DateTime.Now;
            _context.Services.Update(deletedService);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Services");
        }

        public async Task<IActionResult> HardDelete(int Id)
        {
            Service? deletedService = await _context.Services.FirstOrDefaultAsync(m => m.Id == Id);
            if (deletedService == null)
            {
                return NotFound("Something went wrong!");
            }

            bool hasOrders = await _context.Orders.AnyAsync(o => o.ServiceId == Id);
            bool hasMasters = _context.Orders.Any(o => o.ServiceId == Id && o.MasterId != null);
            if (hasOrders || hasMasters)
            {
                return BadRequest("Cannot delete this service.");
            }

            _context.Services.Remove(deletedService);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Services");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Service? updatedService = await _context.Services.FirstOrDefaultAsync(m => m.Id == Id);
            if (updatedService == null)
            {
                return NotFound("Something went wrong!");
            }
            ViewBag.Services = _context.Services;
            return View(updatedService);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Service updatedService)
        {
            Service? currentService = await _context.Services.FirstOrDefaultAsync(m => m.Id == updatedService.Id);
            if (currentService == null)
            {
                return NotFound("Not found");
            }
            if (!currentService.isActive)
            {
                return BadRequest("Item cannot be modified.");
            }
            updatedService.CreatedAt = currentService.CreatedAt;
            updatedService.UpdatedAt = DateTime.Now;
            _context.Update(updatedService);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Services");
        }

        public async Task<IActionResult> RevertSoftDelete(int Id)
        {
            Service? service = await _context.Services.FirstOrDefaultAsync(m => m.Id == Id);
            if (service == null)
            {
                return NotFound("Not found");
            }
            if (!service.isActive)
            {
                service.UpdatedAt = DateTime.Now;
                service.isActive = true;
                _context.Update(service);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Services");
        }
    }
}
