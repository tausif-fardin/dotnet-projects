using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ECommerce.Models.Database;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Buy(int id)
        {
            ProductEntities2 db = new ProductEntities2();
            var p = (from data in db.Products
                     where data.ProductId == id
                     select data).FirstOrDefault();
            if (Session["cart"] == null)
            {
                string json = new JavaScriptSerializer().Serialize(p);
                Session["cart"] = json;
            }
            else
            {
                string json = Session["cart"].ToString();
                var d = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                Session["cart"] = d.Add(p);
            }
            return RedirectToAction("ViewCart");
        }
        public ActionResult ViewCart()
        {
            return View();
        }
    }
}