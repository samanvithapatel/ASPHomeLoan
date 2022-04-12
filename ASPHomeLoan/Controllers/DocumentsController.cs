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
    public class DocumentsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Documents
        public ActionResult Index()
        {
            return View(db.Documents.ToList());
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PanCard,VoterId,SalarySlip,LOA,NOCFromBuilder,AgreementToSale")] Document document, HttpPostedFileBase[] upload)
        {
            if (ModelState.IsValid)
            {

                if (upload[0] != null)
                {
                    int filelength = upload[0].ContentLength;
                    byte[] Myfile = new byte[filelength];
                    upload[0].InputStream.Read(Myfile, 0, filelength);
                    document.PanCard = Myfile;
                    db.Documents.Add(document);
                    db.SaveChanges();
                   
                }
                if (upload[1] != null)
                {
                    int filelength = upload[1].ContentLength;
                    byte[] Myfile = new byte[filelength];
                    upload[1].InputStream.Read(Myfile, 0, filelength);
                    document.VoterId = Myfile;
                    db.Documents.Add(document);
                    db.SaveChanges();
     
                }
                if (upload[2] != null)
                {
                    int filelength = upload[2].ContentLength;
                    byte[] Myfile = new byte[filelength];
                    upload[2].InputStream.Read(Myfile, 0, filelength);
                    document.SalarySlip = Myfile;
                    db.Documents.Add(document);
                    db.SaveChanges();
                }
                if (upload[3] != null)
                {
                    int filelength = upload[3].ContentLength;
                    byte[] Myfile = new byte[filelength];
                    upload[3].InputStream.Read(Myfile, 0, filelength);
                    document.LOA = Myfile;
                    db.Documents.Add(document);
                    db.SaveChanges();
                   
                }
                if (upload[4] != null)
                {
                    int filelength = upload[4].ContentLength;
                    byte[] Myfile = new byte[filelength];
                    upload[4].InputStream.Read(Myfile, 0, filelength);
                    document.NOCFromBuilder = Myfile;
                    db.Documents.Add(document);
                    db.SaveChanges();

                }
                if (upload[5] != null)
                {
                    int filelength = upload[5].ContentLength;
                    byte[] Myfile = new byte[filelength];
                    upload[5].InputStream.Read(Myfile, 0, filelength);
                    document.AgreementToSale = Myfile;
                    db.Documents.Add(document);
                    db.SaveChanges();

                }
            }

            return View("Info");
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
