using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Entity.Concreate.Identity;
using DictionaryV2.Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryV2.MvcUI.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;

        public SecurityController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager) {

            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel, string ReturnUrl) {

            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if(user == null) {
                ViewBag.ErrorMessage = "UserNotFound";
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, true);
            if (result.Succeeded) {
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.ErrorMessage = "LoginError";
            return View();
        }

        public async Task<IActionResult> Register() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel) {

            if(registerModel.Password != registerModel.ConfirmPassword) {
                ViewBag.ErrorMessage = "PasswordDoesNotMatch";

                return View();
            }

            AppIdentityUser identityUser = new AppIdentityUser() {
                UserName = registerModel.UserName,
                Email = registerModel.Email
            };

            var result = await _userManager.CreateAsync(identityUser, registerModel.Password);
            if (result.Succeeded) {
                ViewBag.SuccessMessage = "RegisterCompleted";
            }
            else {
                foreach (var error in result.Errors) {
                    ViewBag.ErrorMessage += error.Description + "\n";
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout() {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}