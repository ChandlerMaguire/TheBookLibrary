using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int PosterId { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string PostDate { get; set; }
    }
}
