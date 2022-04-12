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
    public class IncomeDetailsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: IncomeDetails
        public ActionResult Index()
        {
            return View(db.IncomeDetailss.ToList());
        }

        // GET: IncomeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeDetails incomeDetails = db.IncomeDetailss.Find(id);
            if (incomeDetails == null)
            {
                return HttpNotFound();
            }
            return View(incomeDetails);
        }

        // GET: IncomeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncomeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationId,ProperityLocation,ProperityName,EstimatedAmount,TypeOfEmployeement,RetirementAge,OrganizationType,EmployeeName")] IncomeDetails incomeDetails)
        {
            if (ModelState.IsValid)
            {
                db.IncomeDetailss.Add(incomeDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incomeDetails);
        }

        // GET: IncomeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeDetails incomeDetails = db.IncomeDetailss.Find(id);
            if (incomeDetails == null)
            {
                return HttpNotFound();
            }
            return View(incomeDetails);
        }

        // POST: IncomeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationId,ProperityLocation,ProperityName,EstimatedAmount,TypeOfEmployeement,RetirementAge,OrganizationType,EmployeeName")] IncomeDetails incomeDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomeDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomeDetails);
        }

        // GET: IncomeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeDetails incomeDetails = db.IncomeDetailss.Find(id);
            if (incomeDetails == null)
            {
                return HttpNotFound();
            }
            return View(incomeDetails);
        }

        // POST: IncomeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomeDetails incomeDetails = db.IncomeDetailss.Find(id);
            db.IncomeDetailss.Remove(incomeDetails);
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
