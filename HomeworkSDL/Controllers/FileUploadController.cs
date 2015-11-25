using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkSDL.Models
{
    public class FileUploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                if (Path.GetExtension(file.FileName) == ".txt")
                {
                    try
                    {
                        //get unique temporary name for uploaded file
                        string tmpName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"), tmpName);
                        //save the file to server and open it to read the contents (count lines and words)
                        file.SaveAs(path);                        
                        FileParser fp = new FileParser(path);
                        //add the information to upload history and rename the file after getting db record ID                        
                        FileItem f = new FileItem();
                        f.Lines = fp.lines;
                        f.Words = fp.words;
                        f.Name = Path.GetFileName(file.FileName);
                        f.UploadDate = DateTime.Now;
                        FileItemsDBContext db = new FileItemsDBContext();
                        db.FileItems.Add(f);                        
                        db.SaveChanges();
                        System.IO.File.Move(path, Path.Combine(Server.MapPath("~/UploadedFiles"), f.ID + Path.GetExtension(file.FileName)));
                        ViewBag.Message = "File " + file.FileName + " uploaded successfully, it contains " + fp.lines + " line(s) and " + fp.words + " word(s).";                        
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Message = "Only text files (.txt) are supported currently.";
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
    }
}