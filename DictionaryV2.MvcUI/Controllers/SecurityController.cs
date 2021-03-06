﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictionaryV2.Core.CrossCuttingConcerns.Caching;
using DictionaryV2.Entity.Concreate.Identity;
using DictionaryV2.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryV2.MvcUI.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;
        private ICacheManager _cacheManager;

        public SecurityController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, ICacheManager cacheManager) {

            _userManager = userManager;
            _signInManager = signInManager;
            _cacheManager = cacheManager;
        }
        
        public IActionResult Index() {
            return View();
        }

        public IActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl) {

            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if(user == null) {
                ViewBag.ErrorMessage = "UserNotFound";
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, true);
            if (result.Succeeded) {
                if(!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);

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
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName
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

        [Authorize]
        public IActionResult Cache() {

            List<object> cacheList = _cacheManager.GetAll<object>();
            var cacheModel = new CacheModel();
            cacheModel.Key = new List<string>();

            foreach (var item in cacheList) {
                cacheModel.Key.Add(((System.Collections.DictionaryEntry)item).Key.ToString());
            }

            return View(cacheModel);
        }

        public IActionResult Clear(string key) {

            _cacheManager.Remove(key);

            return RedirectToAction("Cache");
        }
    }
}