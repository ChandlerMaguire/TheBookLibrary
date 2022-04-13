using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IBookDao
    {
        List<Book> SearchBooks(Book searchTerms);
        List<Book> GetAllBooks();
        List<Book> GetReadingList(User currentUser);
        bool AddToReadingList(User currentUser, Book addedBook);

    }
}
