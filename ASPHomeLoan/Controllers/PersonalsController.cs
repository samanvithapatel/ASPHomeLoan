using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPHome.Models;

namespace ASPHome.Controllers
{
    public class PersonalsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Personals
        public ActionResult Index()
        {
            return View(db.PersonalDetailss.ToList());
        }

        // GET: Personals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.PersonalDetailss.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: Personals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,Id,LastName,EmailId,Phonenumber,Salary,Gender,Nationality,AadharNumber,PanNumber")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDetailss.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personal);
        }

        // GET: Personals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.PersonalDetailss.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,Id,LastName,EmailId,PhoneNumber,Salary,Gender,Nationality,AadharNumber,PanNumber")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personal);
        }

        // GET: Personals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.PersonalDetailss.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal personal = db.PersonalDetailss.Find(id);
            db.PersonalDetailss.Remove(personal);
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

        public ActionResult Tracking(Personal u)
        {

            var obj = db.PersonalDetailss.Where(x => x.Id.Equals(u.Id) && x.PhoneNumber.Equals(u.PhoneNumber)).FirstOrDefault();
            var obj1 = db.PersonalDetailss.Where(x => x.Id !=u.Id && x.PhoneNumber!=u.PhoneNumber);
            if (obj != null)
            {
                return View("Message");
            }
            else if (obj1 == null)
            {
                return View("Message2");
            }
            return View();
           
        }
        public ActionResult Message()
        {
            return View();
        }

        public ActionResult Message2()
        {
            return View();
        }

    }
}
