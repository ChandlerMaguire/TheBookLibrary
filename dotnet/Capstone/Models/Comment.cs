using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Username { get; set; }
        public int CommentorId { get; set; }
        public string CommentText { get; set; }
        public string CommentDate { get; set; }
        

    }
}
