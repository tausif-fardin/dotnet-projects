using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationDemo.Models.Database.Entity
{
    public class DepartmentCourseModel : DepartmentModel
    {
        List<CourseModel> Courses = new List<CourseModel>();

        public DepartmentCourseModel()
        {
            Courses = new List<CourseModel>(); 
        }
    }
}