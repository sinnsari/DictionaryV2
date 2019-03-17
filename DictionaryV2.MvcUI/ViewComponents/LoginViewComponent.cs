using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DictionaryV2.Entity.Concreate.Identity;

namespace DictionaryV2.MvcUI.ViewComponents {
    public class LoginViewComponent : ViewComponent {

        private UserManager<AppIdentityUser> _userManager;
        public LoginViewComponent(UserManager<AppIdentityUser> userManager) {
            _userManager = userManager;
        }
        
        public IViewComponentResult Invoke() {

            var user = _userManager.GetUserName(HttpContext.User);
            if(user != null) {
                ViewBag.UserName = user;
            }

            return View();
        }
    }
}
