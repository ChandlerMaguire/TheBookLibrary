using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

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

        private string sqlGetReadingList = "select * from books b " +
                "INNER JOIN user_book ub ON b.book_id = ub.book_id INNER JOIN author a ON a.author_id = b.author_id INNER JOIN genre g ON g.genre_id = b.genre_id " +
                "WHERE ub.[user_id] = @userId";

        private string sqlAddToReadingList = "BEGIN TRY BEGIN TRANSACTION INSERT INTO user_book ([user_id], book_id) VALUES (@userId,(select b.book_id from books b where b.isbn = @isbn)); COMMIT TRANSACTION; END TRY BEGIN CATCH ROLLBACK; END CATCH";

        private string sqlDeleteFromMyBooks = "DELETE FROM user_book WHERE [user_id] = @userId;";

        private string sqlUpdateMyBooks = "BEGIN TRY BEGIN TRANSACTION INSERT INTO user_book ([user_id], book_id) VALUES (@userId,(select b.book_id from books b where b.isbn = @isbn)); COMMIT TRANSACTION; END TRY BEGIN CATCH ROLLBACK; END CATCH";
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

        public List<Book> GetReadingList(string userId)
        {
            List<Book> readingList = new List<Book>();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetReadingList, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Book returnBook = GetBookFromReader(reader);
                        readingList.Add(returnBook);
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return readingList;
        }

        public void updateMyBooks(List<Book> myBooks, string userId)
        {
            List<string> isbnList = new List<string>();

            foreach (Book book in myBooks)
            {
                isbnList.Add(book.Isbn);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlDeleteFromMyBooks, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();

                foreach (string isbn in isbnList)
                {
                    SqlCommand cmd2 = new SqlCommand(sqlUpdateMyBooks, conn);
                    cmd2.Parameters.AddWithValue("@isbn", isbn);
                    cmd2.Parameters.AddWithValue("@userId", userId);
                    cmd2.ExecuteNonQuery();
                }
            }
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
