using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BookSqlDao /*: IBookDao*/
    {
        private readonly string connectionString;
        private string sqlSearchBooks = "SELECT * FROM books b " +
            "INNER JOIN author a ON b.author_id = a.author_id " +
            "INNER JOIN genre g ON g.genre_id = b.genre_id WHERE b.title LIKE '%@title%' AND a.first_name LIKE '%@first_name%' AND" +
            " a.last_name LIKE '%@last_name%' AND b.isbn = '@isbn' AND g.genre_name LIKE '%@genre_name%'";
        //Needs Keywords, Location, and Characters for search
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

            
            book.Title = Convert.ToString(reader["b.title"]);
            book.AuthorFirst = Convert.ToString(reader["a.first_name"]);
            book.AuthorLast = Convert.ToString(reader["a.last_name"]);
            book.Isbn = Convert.ToInt32(reader["b.isbn"]);
            book.Genre = Convert.ToString(reader["g.genre_name"]);
            book.KeyWords = Convert.ToString(reader["b.keywords"]);              //Make sure these match the column names
            book.Characters = Convert.ToString(reader["b.characters"]);
            book.Locations = Convert.ToString(reader["b.locations"]);
            book.DateAdded = Convert.ToDateTime(reader["b.datetime_added"]);
            
            
             
            return book;
        }
    }
}
