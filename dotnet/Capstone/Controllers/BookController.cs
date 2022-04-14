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
    public class BookController : ControllerBase
    {
        private readonly IBookDao bookDao;

        public BookController(IBookDao bookDao)
        {
            this.bookDao = bookDao;
        }

        [HttpPost("search")]
        public ActionResult<List<Book>> SearchResult(Book searchTerms)
        {
            List<Book> result = bookDao.SearchBooks(searchTerms);


            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("mybooks")]
        public ActionResult<List<Book>> ReadingList(User currentUser)
        {
            List<Book> result = bookDao.GetReadingList(currentUser);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("mybooks")]
        public ActionResult UpdateMyList(List<Book> myBooks)
        {
            string userId = User.FindFirst("sub").Value;
            bookDao.updateMyBooks(myBooks, userId);

            return Ok();
        }


    }
}
