using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class CommentSqlDao : ICommentDao
    {
        private readonly string connectionString;
        private readonly string sqlGetAllComments = "  SELECT comment_text, comment_date, u.username FROM comments c INNER JOIN posts p ON p.post_id = c.post_id  INNER JOIN users u ON u.user_id = p.poster_id WHERE p.post_id = @postId";

        public CommentSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Comment> GetCommentsById(int postId)
        {
            List<Comment> returnComments = new List<Comment>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetAllComments, conn);
                    cmd.Parameters.AddWithValue("post_id", postId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Comment returnComment = GetCommentFromReader(reader);
                        returnComments.Add(returnComment);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnComments;
        }
        private Comment GetCommentFromReader(SqlDataReader reader)
        {
            Comment comment = new Comment();

            comment.PostId = Convert.ToInt32(reader["post_id"]);
            comment.Username = Convert.ToString(reader["username"]);
            comment.CommentText = Convert.ToString(reader["comment_text"]);
            comment.CommentDate = Convert.ToString(reader["comment_date"]);
            comment.CommentDate = comment.CommentDate.Substring(0, 9);
            return comment;
        }
    }
}
