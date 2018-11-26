using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class BasketballsController : Controller
    {
        private BasketballEntities db = new BasketballEntities();

        // GET: Basketballs
        public ActionResult Index()
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;

            return View(db.Basketballs.ToList());
        }

        public ActionResult ListOfAllMembers()
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;

            return View(db.Basketballs.ToList());
        }
        public ActionResult Passed()
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            return View(db.Basketballs.ToList());
        }
        public ActionResult Paid(string email)
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;

            if (email == null)
            {
                return View(db.Basketballs.ToList());
            }
            List<Basketball> coffeDate = db.Basketballs.Where(x => x.PaidCourtId == email).ToList();
            if (coffeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeDate);
        }
        // GET: Basketballs/Details/5
        public ActionResult Details(int? id)
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basketball basketball = db.Basketballs.Find(id);
            if (basketball == null)
            {
                return HttpNotFound();
            }
            return View(basketball);
        }

        // GET: Basketballs/Create
        public ActionResult Create()
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            return View();
        }

        // POST: Basketballs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Time,Date,Passed,Venue,PaidCourtId,PaidAmmount")] Basketball basketball)
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            if (ModelState.IsValid)
            {
                db.Basketballs.Add(basketball);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basketball);
        }

        // GET: Basketballs/Edit/5
        public ActionResult Edit(int? id)
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basketball basketball = db.Basketballs.Find(id);
            if (basketball == null)
            {
                return HttpNotFound();
            }
            return View(basketball);
        }

        // POST: Basketballs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Time,Date,Passed,Venue,PaidCourtId,PaidAmmount")] Basketball basketball)
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            if (ModelState.IsValid)
            {
                db.Entry(basketball).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basketball);
        }

        // GET: Basketballs/Delete/5
        public ActionResult Delete(int? id)
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basketball basketball = db.Basketballs.Find(id);
            if (basketball == null)
            {
                return HttpNotFound();
            }
            return View(basketball);
        }

        // POST: Basketballs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            Basketball basketball = db.Basketballs.Find(id);
            db.Basketballs.Remove(basketball);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
