using FitnessBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
    }
}