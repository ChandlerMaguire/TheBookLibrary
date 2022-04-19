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
        private readonly string sqlGetAllComments = "  SELECT c.comment_id, c.comment_text, c.comment_date, u.username FROM comments c INNER JOIN posts p ON p.post_id = c.post_id  INNER JOIN users u ON u.user_id = p.poster_id WHERE p.post_id = @postId";
        private string sqlAddComment = "BEGIN TRY BEGIN TRANSACTION INSERT INTO comments(post_id, commentor_id, comment_text, comment_date) VALUES (@postId, @commentorId, @commentText, GETDATE()); COMMIT TRANSACTION; END TRY BEGIN CATCH ROLLBACK; END CATCH";
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
                    cmd.Parameters.AddWithValue("@postId", postId);
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
        public bool AddComment(Comment commentToAdd, string commentorId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddComment, conn);
                    cmd.Parameters.AddWithValue("@post_id", commentToAdd.PostId);
                    cmd.Parameters.AddWithValue("@commentor_id", commentorId);
                    cmd.Parameters.AddWithValue("@comment_text", commentToAdd.CommentText);
                    

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        return true;
                    }


                }
            }
            catch (SqlException)
            {
                throw;
            }
            return false;
        }
        private Comment GetCommentFromReader(SqlDataReader reader)
        {
            Comment comment = new Comment();
            comment.CommentId = Convert.ToInt32(reader["comment_id"]);
            comment.Username = Convert.ToString(reader["username"]);
            comment.CommentText = Convert.ToString(reader["comment_text"]);
            comment.CommentDate = Convert.ToString(reader["comment_date"]);
            comment.CommentDate = comment.CommentDate.Substring(0, 9);
            return comment;
        }
    }
}
