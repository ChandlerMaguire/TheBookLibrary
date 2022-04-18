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


    }
}
