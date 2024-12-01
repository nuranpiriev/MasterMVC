using InanceMVC.DAL.Contexts;
using InanceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace InanceMVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MastersController : Controller
    {
        readonly AppDbContext _context;
        public MastersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Master> master = await _context.Masters.ToListAsync();
            return View(master);
        }
        public async Task<IActionResult> Info(int Id)
        {
            Master? master = await _context.Masters.FirstOrDefaultAsync(m => m.Id == Id);
            if (master == null)
            {
                return NotFound("Something went wrong!");
            }
            return View(master);
        }
        public IActionResult Create()
        {
            ViewBag.Services = _context.Services;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Master master)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            master.CreatedAt = DateTime.Now;
            await _context.Masters.AddAsync(master);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Masters");
        }

        public async Task<IActionResult> SoftDelete(int Id)
        {
            Master? deletedMaster = await _context.Masters.FirstOrDefaultAsync(m => m.Id == Id);
            if (deletedMaster == null)
            {
                return NotFound("Something went wrong!");
            }
            bool hasOrders = await _context.Orders.AnyAsync(o => o.MasterId == Id);
            if (hasOrders)
            {
                return BadRequest("Cannot delete this master.");
            }
            deletedMaster.isActive = false;
            deletedMaster.DeletedAt = DateTime.Now;
            _context.Masters.Update(deletedMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Masters");
        }

        public async Task<IActionResult> HardDelete(int Id)
        {
            Master? deletedMaster = await _context.Masters.FirstOrDefaultAsync(m => m.Id == Id);
            if (deletedMaster == null)
            {
                return NotFound("Something went wrong!");
            }
            bool hasOrders = await _context.Orders.AnyAsync(o => o.MasterId == Id);
            if (hasOrders)
            {
                return BadRequest("Cannot delete this master.");
            }
            _context.Masters.Remove(deletedMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Masters");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Master? updatedMaster = await _context.Masters.FirstOrDefaultAsync(m => m.Id == Id);
            if (updatedMaster == null)
            {
                return NotFound("Something went wrong!");
            }
            ViewBag.Services = _context.Services;
            return View(updatedMaster);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Master updatedMaster)
        {
            Master? currentMaster = await _context.Masters.FirstOrDefaultAsync(m => m.Id == updatedMaster.Id);
            if (currentMaster == null)
            {
                return NotFound("Not found");
            }
            if (!currentMaster.isActive)
            {
                return BadRequest("Item cannot be modified.");
            }
            updatedMaster.CreatedAt = currentMaster.CreatedAt;
            updatedMaster.UpdatedAt = DateTime.Now;
            _context.Update(updatedMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Masters");
        }

        public async Task<IActionResult> RevertSoftDelete(int Id)
        {
            Master? master = await _context.Masters.FirstOrDefaultAsync(m => m.Id == Id);
            if (master == null)
            {
                return NotFound("Not found");
            }
            if (!master.isActive)
            {
                master.UpdatedAt = DateTime.Now;
                master.isActive = true;
                _context.Update(master);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Masters");
        }
    }
}
