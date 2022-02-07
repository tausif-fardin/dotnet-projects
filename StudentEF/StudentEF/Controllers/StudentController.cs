using StudentEF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentEF.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentEntities1 db = new StudentEntities1();
            var data = db.Persons.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult Create(Person p)
        {
            if (ModelState.IsValid)
            {
                StudentEntities1 db = new StudentEntities1();
                db.Persons.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult ScholarshipList()
        {
            StudentEntities1 db = new StudentEntities1();
            var SUser = from p in db.Persons where p.Cgpa>=3.75 select p;
            return View(SUser.ToList());
        }
        
        public ActionResult DiscountList()
        {
            StudentEntities1 db = new StudentEntities1();
            DateTime today = DateTime.Today;
            DateTime min = today.AddYears(-30);
            //DateTime max = today.AddYears(-lb);
            var DUsers = db.Persons.Where(e => e.Dob != null && e.Dob <= min);
            return View(DUsers.ToList());
        }


    }
}