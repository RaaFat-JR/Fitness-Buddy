using FitnessBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace FitnessBuddy.Controllers
{
    public class MembersController : Controller
    {
        ApplicationDbContext Db = new ApplicationDbContext();

        // GET: Members
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MemberList()
        {
            var List = Db.Members.Include(c => c.Trainer).ToList();
            return View(List);
        }

        public ActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register (Member member)
        {
            Db.Members.Add(member);
            Db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            using (Db)
                //if (ModelState.IsValid)
            {

                    //using (Db)
                    if (ModelState.IsValid)
                    {
                    var log = Db.Members.Where(c => c.Email.Equals(login.UserName) && c.Password.Equals(login.Password)).FirstOrDefault();
                    if(log != null)
                    {
                        Session["username"] = login.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        login.LoginErrorMessage = "Wrong username or password.";
                        return View("Index", login);
                        //ModelState.AddModelError(string.Empty, "Username Or Password incorrect");

                    }
                }
            }

          return View("Index", "Home");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
     
 
        
    }
}