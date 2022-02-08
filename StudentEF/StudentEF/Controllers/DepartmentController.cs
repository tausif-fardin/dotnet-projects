using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentEF.Models.Database;

namespace StudentEF.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department

        public ActionResult Index()
        {
            DepartmentEntities db = new DepartmentEntities();
            var data = db.Departments.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(Department p)
        {
            if (ModelState.IsValid)
            {
                DepartmentEntities db = new DepartmentEntities();
                db.Departments.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        

       
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DepartmentEntities db = new DepartmentEntities();
            var department = (from s in db.Departments
                           where s.Deptid == id
                           select s).FirstOrDefault();
            return View(department);

        }
        [HttpPost]
        public ActionResult Edit(Department sub_s)
        {
            DepartmentEntities db = new DepartmentEntities();
            var department = (from s in db.Departments
                           where s.Deptid == sub_s.Deptid
                           select s).FirstOrDefault();
            db.Entry(department).CurrentValues.SetValues(sub_s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DepartmentEntities db = new DepartmentEntities();
            var department = (from s in db.Departments
                           where s.Deptid == id
                           select s).FirstOrDefault();
            return View(department);

        }
        [HttpPost]
        public ActionResult Delete(Department sub_s)
        {
            DepartmentEntities db = new DepartmentEntities();
            var department = (from s in db.Departments
                           where s.Deptid == sub_s.Deptid
                           select s).FirstOrDefault();
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteIndex()
        {
            return View();
        }
    }
}