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
            var List = Db.Members.ToList();
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

            return RedirectToAction("Login", "Members");
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
                    var log = Db.Members.Where(c => c.Email.Equals(login.UserName) && c.Password.Equals(login.Password)).FirstOrDefault();
                    if(log != null)
                    {
                        Session["username"] = login.UserName;
                        return RedirectToAction("Index", "Members");
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

        
        public ActionResult Edit(int id)
        {
            var memb = Db.Members.SingleOrDefault(c => c.Id == id);

            if(memb == null)
               return HttpNotFound();
       
            return View(memb);
        }

        [HttpPost]
        public ActionResult Update (Member memb)
        {
            var membInDb = Db.Members.Single(c => c.Id == memb.Id);

            membInDb.Password = memb.Password;
            membInDb.PhoneNumber = memb.PhoneNumber;
            membInDb.Goal = memb.Goal;
            membInDb.CurrentWeight = memb.CurrentWeight;
            membInDb.ConfirmPassword = memb.ConfirmPassword;
            membInDb.Birthdate = memb.Birthdate;
            membInDb.Email = memb.Email;
            membInDb.Full_Name = memb.Full_Name;

            Db.SaveChanges();
            return RedirectToAction("MemberList");

        }
        
    }
}