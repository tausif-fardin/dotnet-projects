using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECartDemo.ViewModel
{
    public class ItemViewModel
    {
        public Guid ItemId { get; set; }

        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal ItemPrice { get; set; }

        public HttpPostedFileBase ImagePath { get; set; }
    }
}