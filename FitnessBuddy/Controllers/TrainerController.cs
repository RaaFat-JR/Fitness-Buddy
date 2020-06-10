using FitnessBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace FitnessBuddy.Controllers
{
    public class TrainerController : Controller
    {
        ApplicationDbContext Db = new ApplicationDbContext();
        // GET: Trainer
        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult ViewMemberList()
        {
            var List = Db.Members.ToList();
            return View(List);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if(ModelState.IsValid)
            {
                using (Db)
                {
                    var log = Db.Trainer.Where(c => c.Email.Equals(login.UserName) && c.Password.Equals(login.Password)).FirstOrDefault();
                    if(log != null)
                    {
                        Session["username"] = login.UserName;
                        return RedirectToAction("AdminHome", "Trainer");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Username Or Password incorrect");
                    }
                }
            }

            return View("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        [HttpPost]
        public ActionResult LogOff()
        {
            if (Session["username"] != null)
            {
                Session.Abandon();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddProgram ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProgram (Program prog)
        {

            Db.Programs.Add(prog);
            Db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}