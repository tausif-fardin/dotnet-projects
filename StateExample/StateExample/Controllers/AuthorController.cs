using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateExample.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Log()
        {
            Session.Remove("user");
            return View("Index");
        }
        [HttpPost]
        public ActionResult Index(string userTxt, string passTxt)
        {
            if(userTxt == "tausif" && passTxt == "1234")
            {
                //Make session
                Session["user"] = "Tausif";
                Session.Abandon(); //All current session will be abandoned.
                //Temp data
                TempData["user"] = "Tausif Temp";
                //
                HttpContext.Application["user"] = 12;
                var variable = HttpContext.Application["user"];
                //Making a cookie
                //HttpCookie kt = new HttpCookie("user", "Tausif"); //name the cookie and give it a value (CookieName, Value)
                ////non persistent cookies
                //kt.Expires = DateTime.Now.AddSeconds(30);
                //Response.Cookies.Add(kt);
                ////Another way to make cookie
                ////Response.Cookies["last"].Value = "Fardin";
                return RedirectToAction("index","home");
            }
            else
            {
                return View();
            }
        }
    }
}