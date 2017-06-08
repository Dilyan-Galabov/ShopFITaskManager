using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopFI.DbContext;
using ShopFI.Entities.Models;
using ShopFI.Gateway.DTOs;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;

namespace ShopFI.Gateway.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Category).Include(i => i.Performer);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
           // ViewBag.PerformerId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Items/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemEntry entry)
        {
            if (ModelState.IsValid)
            {

                Item item = new Item(
                    User.Identity.GetUserId(),
                    entry.CategoryId,
                    entry.Title,
                    entry.Price,
                    entry.Description,
                    entry.ImgUrl,
                    entry.PhoneNumber,
                    DateTime.Now,
                    null
                    );

                try
                {
                    db.Items.Add(item);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {           
                            Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", entry.CategoryId);
           // ViewBag.PerformerId = new SelectList(db.Users, "Id", "Email", entry.PerformerId);
            return View(entry);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", item.CategoryId);
            ViewBag.PerformerId = new SelectList(db.Users, "Id", "Email", item.PerformerId);
            return View(item);
        }

        // POST: Items/Edit/5      
        [HttpPost]
       
        public ActionResult Edit([Bind(Include = "Id,Title,Price,Description,ImgUrl,PhoneNumber,PerformerId,CategoryId,DateCreated,DateModified")]Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", item.CategoryId);
            ViewBag.PerformerId = new SelectList(db.Users, "Id", "Email", item.PerformerId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
