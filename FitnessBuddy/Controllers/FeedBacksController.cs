using FitnessBuddy.Extensions;
using FitnessBuddy.Models;
using System.Web.Mvc;

namespace FitnessBuddy.Controllers
{
    public class FeedBacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.FeedBacks.Add(feedBack);
                db.SaveChanges();
                this.AddNotification("Your feedback created successfully.", NotificationType.SUCCESS);
                return RedirectToAction("Create");
            }

            return View(feedBack);
        }
    }
}
