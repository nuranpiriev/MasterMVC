using PurpleBuzz.DAL;
using PurpleBuzz.DTO.UserDTO;
using PurpleBuzz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzz.Controllers
{
    public class AccountsController : Controller
    {
        readonly AppDBContext _context;
        readonly UserManager<AppUser> _userManager;
        public AccountsController(AppDBContext appDBContext, UserManager<AppUser> userManager)
        {
            _context = appDBContext;
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createUserDto);
            }

            AppUser appUser = new AppUser();
            appUser.FirstName = createUserDto.FirstName;
            appUser.UserName = createUserDto.FirstName;
            appUser.LastName = createUserDto.LastName;
            appUser.Email = createUserDto.Email;
            var result = await _userManager.CreateAsync(appUser, createUserDto.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(createUserDto);
            }
            return RedirectToAction("Index","Home");
        }
    }
}
