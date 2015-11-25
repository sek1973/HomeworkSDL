using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeworkSDL.Models;

namespace HomeworkSDL.Controllers
{
    public class HomeController : Controller
    {
        private FileItemsDBContext db = new FileItemsDBContext();

        public ActionResult Index()
        {
            return View(db.FileItems.OrderByDescending(f => f.Words).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application for file uploading.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sławomir Kussowski";

            return View();
        }
    }
}