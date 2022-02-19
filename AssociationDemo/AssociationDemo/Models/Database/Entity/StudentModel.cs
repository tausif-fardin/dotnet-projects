using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationDemo.Models.Database.Entity
{
    public class StudentModel
    {
        //Only bring other properties except navigation property from the default db classes.
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public DepartmentModel Department { get; set; }
    }
}