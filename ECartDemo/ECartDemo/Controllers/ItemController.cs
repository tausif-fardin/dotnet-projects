using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECartDemo.Controllers
{
    public class ItemController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
    }
}