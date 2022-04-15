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

        [HttpGet("mybooks")]
        public ActionResult<List<Book>> GetReadingList()
        {
            string userId = User.FindFirst("sub").Value;
            List<Book> result = bookDao.GetReadingList(userId);

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

        [HttpPost("addbook")]
        public ActionResult AddABook(Book bookToAdd)
        {
            bool result = bookDao.AddBook(bookToAdd);
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
