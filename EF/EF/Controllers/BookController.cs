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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SP2bEntities1 db = new SP2bEntities1();
            var book = (from b in db.Books 
                       where b.Id == id 
                       select b).FirstOrDefault(); //Only select a single object
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book sub_b)
        {
            SP2bEntities1 db = new SP2bEntities1();
            var book = (from a in db.Books
                        where a.Id == sub_b.Id
                        select a).FirstOrDefault();
            //book.Auth = sub_b.Auth;
            //book.Name = sub_b.Name;
            //book.Price = sub_b.Price;

            db.Entry(book).CurrentValues.SetValues(sub_b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}