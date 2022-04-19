using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface ICommentDao
    {
        List<Comment> GetCommentsById(int postId);
       bool AddComment(Comment commentToAdd, string commentorId, int postId);
       // void DeleteComment(int commentId);
    }
}
