using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssociationDemo.Models.Database;

namespace AssociationDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UMSEntities1 db = new UMSEntities1();
            var dept = (from di in db.Departments
                       where di.Id == 1
                       select di).FirstOrDefault();

            var courses = dept.Courses.ToList();
            var students = dept.Students.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}