using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    //'%' + @first_name + '%'

    public class BookSqlDao : IBookDao
    {
        private readonly string connectionString;
        private string sqlSearchBooks = "SELECT * FROM books " +
        "b " +
        "INNER JOIN author a ON b.author_id = a.author_id " +
        "INNER JOIN genre g ON g.genre_id = b.genre_id WHERE b.title LIKE '%' + @title + '%' " +
        "AND b.keyword LIKE '%' + @keyword + '%' AND b.[character] LIKE '%' + @character + '%'  " +
        "AND b.[location] LIKE '%' + @location + '%' AND a.first_name LIKE '%' + @first_name + '%' AND" +
        " a.last_name LIKE '%' + @last_name + '%' AND b.isbn LIKE '%' + @isbn + '%' AND g.genre_name LIKE '%' + @genre_name + '%'";

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
                    SqlCommand cmd = new SqlCommand(sqlSearchBooks, conn);
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

        public List<Book> SearchBooks(Book searchTerms)
        {
            List<Book> returnBooks = new List<Book>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlSearchBooks, conn);
                    cmd.Parameters.AddWithValue("@title", searchTerms.Title);
                    cmd.Parameters.AddWithValue("@first_name", searchTerms.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", searchTerms.LastName);
                    cmd.Parameters.AddWithValue("@isbn", searchTerms.Isbn);
                    cmd.Parameters.AddWithValue("@genre_name", searchTerms.Genre);
                    cmd.Parameters.AddWithValue("@keyword", searchTerms.Keyword);
                    cmd.Parameters.AddWithValue("@character", searchTerms.Character);
                    cmd.Parameters.AddWithValue("@location", searchTerms.Location);
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

        private Book GetBookFromReader(SqlDataReader reader)
        {
            Book book = new Book();


            book.Title = Convert.ToString(reader["title"]);
            book.FirstName = Convert.ToString(reader["first_name"]);
            book.LastName = Convert.ToString(reader["last_name"]);
            book.Isbn = Convert.ToString(reader["isbn"]);
            book.Genre = Convert.ToString(reader["genre_name"]);
            book.Keyword = Convert.ToString(reader["keyword"]);              //Make sure these match the column names
            book.Character = Convert.ToString(reader["character"]);
            book.Location = Convert.ToString(reader["location"]);
            book.DateAdded = Convert.ToString(reader["added"]);
            book.DateAdded = book.DateAdded.Substring(0, 9);
            return book;
        }
    }
}
