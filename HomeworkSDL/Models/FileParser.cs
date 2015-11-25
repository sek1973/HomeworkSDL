using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HomeworkSDL.Models
{
    public class FileParser
    {
        //class for read a file - count lines and words
        private String _filepath = "";
        public String filepath { get { return _filepath; } }
        private int _lines = -1;
        public int lines { get {return _lines; } }
        private int _words = -1;
        public int words { get { return _words; } }

        public FileParser(String path)
        {
            parse(path);
        }
        public void parse(String path)
        {
            _filepath = path;
            StreamReader r = new StreamReader(_filepath);
            _lines = 0;
            _words = 0;
            string line = r.ReadLine();
            while (line != null)
            {
                foreach (string word in line.Split(new char[] { ' ' }))
                    if (word.Length > 0) _words++;
                _lines++;
                line = r.ReadLine();
            }
            r.Close();
        }
    }    
}