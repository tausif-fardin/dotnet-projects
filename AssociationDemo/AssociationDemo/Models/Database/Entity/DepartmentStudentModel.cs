using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationDemo.Models.Database.Entity
{
    public class DepartmentStudentModel : Department
    {
        List<StudentModel> Students { get; set; }
        public DepartmentStudentModel() {
            Students = new List<StudentModel>();
        }
        

    }
}