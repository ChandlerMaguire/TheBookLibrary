using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Isbn { get; set; } 
        public string Genre { get; set; } 
        public string Keyword { get; set; }
        public string Character { get; set; }
        public string Location { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
