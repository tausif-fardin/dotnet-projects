using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AssociationDemo.Auth;
using AssociationDemo.Models.Database;
using AssociationDemo.Models.Database.Entity;
using AutoMapper;

namespace AssociationDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //UMSEntities1 db = new UMSEntities1();
            //var dept = (from d in db.Departments
            //           where d.Id == 1
            //           select d).FirstOrDefault();
            ////Defining configuration for mapper
            //var config = new MapperConfiguration(
            //    cfg =>
            //    {
            //        cfg.CreateMap<Department, DepartmentModel>();
            //        cfg.CreateMap<Student, StudentModel>();
            //    }               
            //    );
            //var mapper = new Mapper(config);
            //var deptModel = mapper.Map<DepartmentModel>(dept);
            //var courses = dept.Courses.ToList();
            //var students = dept.Students.ToList();

            //Make a login huhu



            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            if (ModelState.IsValid)
            {
                UMSEntities1 db = new UMSEntities1();
                var data = (from u in db.Users
                           where u.Username.Equals(user.Username) &&
                           u.Password.Equals(user.Password)
                           select u).FirstOrDefault();
                if (data!=null)
                {
                    FormsAuthentication.SetAuthCookie(data.Username, false);
                    Session["UserType"] = data.Role;
                    //FormsAuthentication.SignOut(); for logout
                    return RedirectToAction("Dashboard");

                }
            }
            return View();

        }
        [Authorize]
        public ActionResult Dashboard()
        {
            //if(Session["user"] == null)
            //{
            //    return RedirectToAction("Index");
            //}
            UMSEntities1 db = new UMSEntities1();
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Department, DepartmentModel>();
                }
                );

            var deptDb = db.Departments.ToList();
            Mapper mapper = new Mapper(config);
            var data = mapper.Map<List<DepartmentModel>>(deptDb);

            return View(data);
        }
        [AdminAccess]
        public ActionResult AllUsers()
        {
            UMSEntities1 db = new UMSEntities1();
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserModel>();
                }
                );
            var deptDb = db.Users.ToList();
            Mapper mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(deptDb);
            return View(data);
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