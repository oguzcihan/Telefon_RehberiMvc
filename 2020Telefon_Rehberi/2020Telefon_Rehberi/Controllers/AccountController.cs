using _2020Telefon_Rehberi.Identity;
using _2020Telefon_Rehberi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2020Telefon_Rehberi.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore =
            new UserStore<ApplicationUser>(new telefonContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore =
                new RoleStore<ApplicationRole>(new telefonContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //kayıt işlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;

                IdentityResult result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //kullanıcı oluştu role ata
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Hata", "Hata");
                }

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                //giriş işlemleri
                var user = UserManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    //var olan kullanıcı dahil olur
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.Rememberme;
                    authManager.SignIn(authProperties, identityclaims);

                    return RedirectToAction("Index", "telRehbers");
                }
                else
                {
                    ModelState.AddModelError("Hata", "Hata");

                }


            }
            return View(model);
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}