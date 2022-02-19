using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssociationDemo.Models.Database;
using AssociationDemo.Models.Database.Entity;
using AutoMapper;

namespace AssociationDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UMSEntities1 db = new UMSEntities1();
            var dept = (from d in db.Departments
                       where d.Id == 1
                       select d).FirstOrDefault();
            //Defining configuration for mapper
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Department, DepartmentModel>();
                    cfg.CreateMap<Student, StudentModel>();
                }               
                );
            var mapper = new Mapper(config);
            var deptModel = mapper.Map<DepartmentModel>(dept);
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