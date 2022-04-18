using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IPostDao
    {
        List<Post> GetAllPosts();
        Post GetPostDetails(int postId);
        bool AddPost(Post postToAdd);
        void DeletePost(int postId);


    }
}
