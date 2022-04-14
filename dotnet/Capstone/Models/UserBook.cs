using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class UserBook
    {
        public User currentUser { get; set; }
        public List<Book> myBooks { get; set; }
    }
}
