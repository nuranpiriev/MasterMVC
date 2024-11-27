using FrontToBack.DAL;
using FrontToBack.DTO.UserDTO;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
{
    public class AccountsController : Controller
    {
        readonly AppDBContext _context;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        public AccountsController(AppDBContext appDBContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = appDBContext;
            _userManager = userManager;
            _signInManager = signInManager;
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
            appUser.UserName = createUserDto.UserName;
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
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "Something went wrong.");
            //    return View();
            //}
            AppUser? user = (AppUser?)_context.Users.FirstOrDefault(u => u.Email == loginUserDto.EmailOrUserName || u.UserName == loginUserDto.EmailOrUserName);
            if (user == null || loginUserDto.Password == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View();
            }
            var signInUser = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, isPersistent: true, lockoutOnFailure: false);
            if (!signInUser.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
