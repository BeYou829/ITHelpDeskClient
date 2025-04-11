using ITHelpDeskClient.Data;
using ITHelpDeskClient.Models;
using ITHelpDeskClient.Models.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ITHelpDeskClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {

            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!,model.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
              
                ModelState.AddModelError("","Invalid Login");
                return RedirectToAction("ErrorPage");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ErrorPage()
        {
            ViewBag.ErrorMessage = "Hubo un problema al procesar su solicitud. Por favor, intente nuevamente más tarde.";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = model.FirstName,
                    LastName = model.LastName,
                    Genero = model.Genre,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user,model.Password!);

                if (result.Succeeded) { 
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AboutMe()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index","Home");
            }

            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> AboutMeEdit()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("index", "home");
            }

            var userinfo = new EditUserVM
            {
                Name = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Genero = user.Genero,
                Email = user.Email,
            };


            return View(userinfo);
        }
        [HttpPost]
        public async Task<IActionResult> AboutMeEdit(EditUserVM model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var passwordCheck = await _userManager.CheckPasswordAsync(user, model.CurrentPassword!);
            if (!passwordCheck)
            {
                ModelState.AddModelError(string.Empty, "La contraseña actual es incorrecta.");
                return View();
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword!, model.NewPassword!);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "La contraseña actual es incorrecta.");
                return View();
            }
            //user.Name = model.Name;
            //user.LastName = model.LastName;
            //user.UserName = model.UserName;
            //user.Email = model.Email;
            //user.PhoneNumber = model.PhoneNumber;
            //user.Genero = model.Genero;


            return RedirectToAction("AboutMe");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();    
            return RedirectToAction("Login","Account");
        }
    }
}
