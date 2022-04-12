using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASPHome.Models;

namespace ASPHome.Controllers
{
    public class SignInsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: SignIns
        public ActionResult Index()
        {
            return View(db.SignIns.ToList());
        }

        // GET: SignIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignIn signIn = db.SignIns.Find(id);
            if (signIn == null)
            {
                return HttpNotFound();
            }
            return View(signIn);
        }

        // GET: SignIns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,UserEmailId,Password,ConfirmPassword")] SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                db.SignIns.Add(signIn);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View("Login");
        }

        // GET: SignIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignIn signIn = db.SignIns.Find(id);
            if (signIn == null)
            {
                return HttpNotFound();
            }
            return View(signIn);
        }

        // POST: SignIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,UserEmailId,Password,ConfirmPassword")] SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signIn);
        }

        // GET: SignIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignIn signIn = db.SignIns.Find(id);
            if (signIn == null)
            {
                return HttpNotFound();
            }
            return View(signIn);
        }

        // POST: SignIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SignIn signIn = db.SignIns.Find(id);
            db.SignIns.Remove(signIn);
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(SignIn u)
        {
            var obj = db.SignIns.Where(x => x.UserName.Equals(u.UserName) && x.Password.Equals(u.Password)).FirstOrDefault();
            if (obj != null)
            {
                return View("Info");
            }
            else if (u.UserName == "admin" && u.Password == "admin")
            {
                return RedirectToAction("Admin");
            }
            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}
