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
    public class BookController : ControllerBase
    {
        private readonly IBookDao bookDao;

        public BookController(IBookDao bookDao)
        {
            this.bookDao = bookDao;
        }


        [HttpGet("{searchTerms}")]
        public ActionResult<List<Book>> SearchResult (Book searchTerms)
        {
            List<Book> result = bookDao.GetBooks(searchTerms);

            if(result != null)
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
