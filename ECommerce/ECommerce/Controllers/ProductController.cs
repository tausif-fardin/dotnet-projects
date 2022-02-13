using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ECommerce.Models.Database;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductEntities2 db = new ProductEntities2();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                ProductEntities2 db = new ProductEntities2();
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductEntities2 db = new ProductEntities2();
            var product = (from s in db.Products
                           where s.ProductId == id
                           select s).FirstOrDefault();
            return View(product);

        }
        [HttpPost]
        public ActionResult Edit(Product sub_s)
        {
            ProductEntities2 db = new ProductEntities2();
            var product = (from s in db.Products
                           where s.ProductId == sub_s.ProductId
                           select s).FirstOrDefault();
            db.Entry(product).CurrentValues.SetValues(sub_s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ProductEntities2 db = new ProductEntities2();
            var product = (from s in db.Products
                           where s.ProductId == id
                           select s).FirstOrDefault();
            return View(product);

        }
        [HttpPost]
        public ActionResult Delete(Product sub_s)
        {
            ProductEntities2 db = new ProductEntities2();
            var product = (from s in db.Products
                           where s.ProductId == sub_s.ProductId
                           select s).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddToCart(int id)
        {
            ProductEntities2 db = new ProductEntities2();
            var p = (from data in db.Products
                     where data.ProductId == id
                     select data).FirstOrDefault();
            if (Session["cart"] = null)
            {
                string json = new JavaScriptSerializer().Serialize(p);
                Session["cart"] = json;
            }
        }
    }
}