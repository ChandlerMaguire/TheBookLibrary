using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface ICommentDao
    {
        List<Comment> GetComments(int postId);
        bool AddComment(Comment commentToAdd);
        void DeleteComment(int commentId);
    }
}
