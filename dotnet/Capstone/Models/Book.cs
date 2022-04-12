using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string AuthorFirst { get; set; }
        public string AuthorLast { get; set; }
        public int Isbn { get; set; } 
        public string Genre { get; set; } 
        public string KeyWords { get; set; }
        public string Characters { get; set; }
        public string Locations { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
