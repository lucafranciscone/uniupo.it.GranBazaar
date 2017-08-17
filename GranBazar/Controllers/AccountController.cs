using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GranBazar.Models;
using GranBazar.Data;
using Microsoft.AspNetCore.Http;
using GranBazar.Src;

namespace GranBazar.Controllers
{
    public class AccountController : Controller
    {

        readonly UserManager<IdentityUser> userManager;
        readonly SignInManager<IdentityUser> signInManager;
        readonly BazarContext context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, BazarContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }



        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string repassword)
        {
            if (password != repassword)
            {
                ModelState.AddModelError(string.Empty, "Password don't match");
                return View();
            }

            var newUser = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            var userCreationResult = await userManager.CreateAsync(newUser, password);

            context.Utente.Add(new Utente
            {
                Email = email,
                Psw = password,
                Ruolo = "User"
            });

            context.SaveChanges();

            if (!userCreationResult.Succeeded)
            {
                foreach (var error in userCreationResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }

            return Content("User created");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login");
                    return View();
                }
                var passwordSignInResult = await signInManager.PasswordSignInAsync(user, password,
                    isPersistent: rememberMe, lockoutOnFailure: false);
                if (!passwordSignInResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login");
                    return View();
                }

                HttpContext.Session.SetString("utenteLoggato", email);
                string y = HttpContext.Session.GetString("utenteLoggato");
                // Query query = new Query(context);
                var query =
                 from x in context.Utente
                 where x.Email.Equals(email)
                 select x.Ruolo;
                //e' una prova, se è un Admin viene rindirizzato da una parte, altrimenti da un altra
                var ruolo = query.First();

                //string url = HttpContext.Request.Query["url"];


                //System.Console.WriteLine($"L'URL é : {url}");

                /*
                 System.Console.WriteLine($"Il ruolo e: {ruolo}");
                 if (ruolo.Equals("Admin"))
                     return Redirect(Url.Action("Index", "Prodotti"));
                 else return Redirect(Url.Action("Index", "User"));
                 */
                return Redirect(Url.Action("Index", "Checkout"));

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Clear();            //toglie tutti gli oggetti in sessione
            return Redirect("~/");
        }

    }
}