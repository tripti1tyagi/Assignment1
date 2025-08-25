using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;
using System.Web.Security;
using Assignment1.Utilities;

using MembershipModel = Assignment1.Models.Membership;


namespace Assignment1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MembershipModel model)
        {
            try
            {
                using (var context = new AdbEntities())
                {
                    bool isValid = context.Users.Any(x => x.UserName == model.UserName &&
                    x.Password == model.Password);
                    if (isValid)
                    {
                        Logger.LogEvent($"User '{model.UserName}' logged in successfully.");
                        FormsAuthentication.SetAuthCookie(model.UserName, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Logger.LogEvent($"Failed login attempt for user '{model.UserName}'.");
                        ModelState.AddModelError("", "Invalid username or password");
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Login failed: " + ex.Message);
                return View(model);
            }
        }


        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
            try
            {
                using (var context = new AdbEntities())
                {
                    context.Users.Add(model);
                    context.SaveChanges();
                    Logger.LogEvent($"New user signed up: {model.UserName}");
                }

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                Logger.LogError("Signup failed: " + ex.Message);
                return View(model);
            }
        }

    }
}