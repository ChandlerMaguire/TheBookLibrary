using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IPostDao postDao;
        private readonly IBookDao bookDao;
        private readonly IUserDao userDao;
        private readonly ICommentDao commentDao;

        public ForumController(IPostDao postDao, IBookDao bookDao, IUserDao userDao, ICommentDao commentDao)
        {
            this.postDao = postDao;
            this.bookDao = bookDao;
            this.userDao = userDao;
            this.commentDao = commentDao;
        }

        [HttpGet()]
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
        [HttpGet("{id}")]
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
        [HttpPost("{id}")]
        public ActionResult AddAComment(Comment commentToAdd, int id)
        {
            string commentorId = User.FindFirst("sub").Value;
            bool result = commentDao.AddComment(commentToAdd, commentorId, id);
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
