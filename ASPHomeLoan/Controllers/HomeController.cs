using ASPHome.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPHome.Controllers
{

    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        //Get:   Home/Index
        public ActionResult Index()
        {
            return View();
        }
        //Get:   Home/About
        public ActionResult About()
        {
            return View();
        }
        //Get:   Home/Contact
        public ActionResult Contact()
        {
            return View();
        }
        //Get: Home/Calcu
        public ActionResult Calcu()
        {
            return View(new Calculation());
        }

        //Post: Home/Calcu
        [HttpPost]
        public ActionResult Calcu(Calculation u)
        {
            u.LoanAmount = (int)(float)(60 * (0.6 * u.Salary));
            u.ROI = (int)(float)0.085;
            db.Calculations.Add(u);
            db.SaveChanges();
            return View(u);
        }
        //Get:   Home/Ecalculation
        public ActionResult Ecalculation(Calculation u)
        {
            u.ROI = 0.085;
            u.EMI = u.LoanAmount * u.ROI * (1 + u.ROI) * u.LoanTenure / ((1 + u.ROI) * u.LoanTenure - 1);
            return View(u);
        }
       
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "SignIn");
        }

    }
}
