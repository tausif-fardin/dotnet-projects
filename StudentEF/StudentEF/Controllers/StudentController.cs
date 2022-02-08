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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentEntities1 db = new StudentEntities1();
            var student = (from s in db.Persons
                     where s.Id == id
                     select s).FirstOrDefault();
            return View(student);

        }
        [HttpPost]
        public ActionResult Edit(Person sub_s)
        {
            StudentEntities1 db = new StudentEntities1();
            var student = (from s in db.Persons
                           where s.Id == sub_s.Id
                           select s).FirstOrDefault();
            db.Entry(student).CurrentValues.SetValues(sub_s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentEntities1 db = new StudentEntities1();
            var student = (from s in db.Persons
                           where s.Id == id
                           select s).FirstOrDefault();
            return View(student);

        }
        [HttpPost]
        public ActionResult Delete(Person sub_s)
        {
            StudentEntities1 db = new StudentEntities1();
            var student = (from s in db.Persons
                           where s.Id == sub_s.Id
                           select s).FirstOrDefault();
            db.Persons.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteIndex()
        {
            return View();
        }
    }
}