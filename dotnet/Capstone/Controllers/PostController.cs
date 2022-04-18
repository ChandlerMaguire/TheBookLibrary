using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("/")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostDao postDao;
        private readonly IUserDao userDao;
        private readonly ICommentDao commentDao;

        public PostController(IPostDao postDao, IUserDao userDao, ICommentDao commentDao)
        {
            this.postDao = postDao;
            this.userDao = userDao;
            this.commentDao = commentDao;
        }

        [HttpGet("forum")]
        public ActionResult<List<Post>> GetAll()
        {
            List<Post> result = postDao.GetAllPosts();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("forum/{id}")]
        public ActionResult<List<Post>> GetAllComments(int id)
        {
            List<Comment> result = commentDao.GetCommentsById(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        public ActionResult AddAPost(Post postToAdd)
        {
            string posterId = User.FindFirst("sub").Value;
            bool result = postDao.AddPost(postToAdd, posterId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
