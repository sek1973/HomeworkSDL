using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HomeworkSDL.Models
{
    public class FileItem
    {
        //class for store file upload history
        public int ID { get; set; }
        public string Name { get; set; }        
        [Display(Name = "Upload date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)] //"{0:d}" for culture
        public DateTime UploadDate { get; set; }
        public int Lines { get; set; }
        public int Words { get; set; }
    }

    public class FileItemsDBContext : DbContext
    {
        public DbSet<FileItem> FileItems { get; set; }
    }
}