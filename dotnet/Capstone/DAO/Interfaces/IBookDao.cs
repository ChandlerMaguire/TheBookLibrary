using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IBookDao
    {
        List<Book> GetBooks(Book searchTerms);
        List<Book> GetAllBooks();

    }
}
