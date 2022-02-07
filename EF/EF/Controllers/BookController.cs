using EF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            SP2bEntities1 db = new SP2bEntities1();
            var data = db.Books.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Book());
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                SP2bEntities1 db = new SP2bEntities1();
                db.Books.Add(b);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}