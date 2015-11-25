using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeworkSDL.Models;

namespace HomeworkSDL.Controllers
{
    public class FileItemsController : Controller
    {
        private FileItemsDBContext db = new FileItemsDBContext();

        // GET: FileItems
        public ActionResult Index()
        {
            return View(db.FileItems.ToList());
        }

        // GET: FileItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileItem fileItem = db.FileItems.Find(id);
            if (fileItem == null)
            {
                return HttpNotFound();
            }
            return View(fileItem);
        }

        // GET: FileItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,UploadDate,Lines,Words")] FileItem fileItem)
        {
            if (ModelState.IsValid)
            {
                db.FileItems.Add(fileItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fileItem);
        }

        // GET: FileItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileItem fileItem = db.FileItems.Find(id);
            if (fileItem == null)
            {
                return HttpNotFound();
            }
            return View(fileItem);
        }

        // POST: FileItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UploadDate,Lines,Words")] FileItem fileItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileItem);
        }

        // GET: FileItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileItem fileItem = db.FileItems.Find(id);
            if (fileItem == null)
            {
                return HttpNotFound();
            }
            return View(fileItem);
        }

        // POST: FileItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileItem fileItem = db.FileItems.Find(id);
            db.FileItems.Remove(fileItem);
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
