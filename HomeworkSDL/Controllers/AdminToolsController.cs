using HomeworkSDL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkSDL.Controllers
{
    public class AdminToolsController : Controller
    {
        private FileItemsDBContext db = new FileItemsDBContext();
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public String Clear()
        {
            int items = 0, files = 0;
            foreach (int id in db.FileItems.Select(f => f.ID))
            {
                FileItem fi = new FileItem { ID = id };
                db.FileItems.Attach(fi);
                db.FileItems.Remove(fi);
                items++;
            }
            foreach(string f in Directory.GetFiles(Server.MapPath("~/UploadedFiles")))
            {
                System.IO.File.Delete(f);
                files++;
            }
            db.SaveChanges();
            return "File upload history cleared. " + items + " records have been deleted and " + files + " files removed.";
        }
    }
}