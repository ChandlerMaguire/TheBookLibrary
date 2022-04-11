using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BookSqlDao : IBookDao 
    {
        private readonly string connectionString;
        private string sqlSearchBooks = "SELECT * FROM books WHERE title LIKE '%@title%'AND " +
            "author_id IN(SELECT author_id FROM author WHERE first_name LIKE %@first_name% AND last_name LIKE %@last_name%) " +
            ""
        public BookSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> returnBooks = new List<Book>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM books", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Book returnBook = GetBookFromReader(reader);
                        returnBooks.Add(returnBook);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnBooks;
        }

        public List<Book> GetBooks(Book searchTerms)
        {
            List<Book> returnBooks = new List<Book>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM books WHERE title LIKE '@title' AND ", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Book returnBook = GetBookFromReader(reader);
                        returnBooks.Add(returnBook);
                    }
                } 
            }
            catch(SqlException)
            {
                throw;
            }

            return returnBooks;
        }

        private Book GetBookFromReader(SqlDataReader reader)
        {
            Book book = new Book();

            book.BookId = Convert.ToInt32(reader["book_id"]);
            book.Title = Convert.ToString(reader["title"]);
            book.AuthorId = Convert.ToInt32(reader["author_id"]);
            book.Isbn = Convert.ToInt32(reader["isbn"]);
            book.GenreId = Convert.ToInt32(reader["genre_id"]);
            book.DateAdded = Convert.ToDateTime(reader["datetime_added"]);
            
             
            return book;
        }
    }
}
