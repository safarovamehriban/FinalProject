//using Abp.Webhooks;
//using Core.Models;
//using FinalProject.ViewModels;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace FinalProject.Areas.Admin.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly UserManager<AppUser> _userManager;
//        private readonly SignInManager<AppUser> _signInManager;
//        private readonly RoleManager<IdentityRole> _roleManager;

//        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
//        {

//            _userManager = userManager;
//            _signInManager = signInManager;
//            _roleManager = roleManager;
//        }

//        public async Task<IActionResult> CreateAdmin()
//        {
//            AppUser admn = new AppUser
//            {
//                FullName = "Mehriban",
//                UserName = "AdminMehriban",
//            };
//            await _userManager.CreateAsync(admn, "Admin123");
//            await _userManager.AddToRoleAsync(admn, "AdminMehriban");

//            return Ok("Admin yarandi");

//        }
//        public async Task<IActionResult> CreateRoles()
//        {
//            IdentityRole identityRole = new IdentityRole("AdminMehriban");
//            IdentityRole identityRole2 = new IdentityRole("Admin");
//            IdentityRole identityRole3 = new IdentityRole("Member");
//            await _roleManager.CreateAsync(identityRole);
//            await _roleManager.CreateAsync(identityRole2);
//            await _roleManager.CreateAsync(identityRole3);

//            return Ok("Rollar yarandi");

//        }

//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login(AdminLoginVm adminLoginVm)
//        {
//            if (!ModelState.IsValid)
//                return View();

//            AppUser user = null;
//            user = await _userManager.FindByNameAsync(adminLoginVm.UserName);

//            if (user is not null)
//            {
//                ModelState.AddModelError("UserName", "UserName already exist!");
//                return View();
//            }

//            user = await _userManager.FindByEmailAsync(user, adminLoginVm.Password, adminLoginVm.IsPersistent, false);

//            if (user is not null)
//            {
//                ModelState.AddModelError("Email", "Email already exist!");
//                return View();
//            }

//            user = new AppUser()
//            {
//                FullName = adminLoginVm.UserName,
//                UserName = adminLoginVm.Password,
//                Email = adminLoginVm.IsPersistent,
//            };

//            var result = await _userManager.CreateAsync(user, adminLoginVm.Password);

//            if (!result.Succeeded)
//            {
//                foreach (var err in result.Errors)
//                {
//                    ModelState.AddModelError("", err.Description);
//                    return View();
//                }
//            }

//            await _userManager.AddToRoleAsync(user, "Member");
//            return RedirectToAction("Login");

//        }

//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login(AdminLoginVm adminLoginVm)
//        {
//            if (!ModelState.IsValid)
//                return View();

//            AppUser user = await _userManager.FindByNameAsync(adminLoginVm.UserName);
//            if (user == null)
//            {
//                ModelState.AddModelError("", "Username or password is not valid");
//                return View();
//            }

//            var result = await _signInManager.PasswordSignInAsync(user, adminLoginVm.Password, false, false);

//            if (!result.Succeeded)
//            {
//                ModelState.AddModelError("", "Username or password is not valid");
//                return View();
//            }

//            return RedirectToAction("Index", "dashboard");
//        }

//        public async Task<IActionResult> Signout()
//        {
//            await _signInManager.SignOutAsync();
//            return RedirectToAction("login");
//        }
//    }
//}
