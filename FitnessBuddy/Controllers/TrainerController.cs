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


        public ActionResult ProgramList()
        {
            var List = Db.Programs.ToList();
            return View(List);
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
        public ActionResult Edit(int id)
        {
            var memb = Db.Members.SingleOrDefault(c => c.Id == id);

            if (memb == null)
                return HttpNotFound();

            return View(memb);
        }

        [HttpPost]
        public ActionResult Update(Member memb)
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
            return RedirectToAction("ViewMemberList");

        }


        public ActionResult EditProgram(int id)
        {
            var prog = Db.Programs.SingleOrDefault(c => c.id == id);

            if (prog == null)
                return HttpNotFound();

            return View(prog);
        }

        [HttpPost]
        public ActionResult Update(Program prog)
        {
            var progInDb = Db.Programs.Single(c => c.id == prog.id);


            progInDb.Type = prog.Type;
            progInDb.WorkOut_Plan = prog.WorkOut_Plan;
            progInDb.Training_Time = prog.Training_Time;
            progInDb.Supplments = prog.Supplments;

            Db.SaveChanges();
            return RedirectToAction("ProgramList");

        }

    }
}