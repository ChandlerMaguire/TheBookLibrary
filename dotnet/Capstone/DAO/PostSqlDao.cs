using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PostSqlDao : IPostDao
    {
        private readonly string connectionString;

        private string sqlGetAllPosts = "SELECT * FROM posts p INNER JOIN users u ON u.user_id = p.poster_id";
        private string sqlGetPostDetails = "SELECT * FROM posts WHERE  post_id = @post_id";
        private string sqlAddPost = "BEGIN TRY BEGIN TRANSACTION INSERT INTO posts(title, poster_id, [message], post_date) VALUES (@title, @poster_id, @message, GETDATE()); COMMIT TRANSACTION; END TRY BEGIN CATCH ROLLBACK; END CATCH";
        

        public PostSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Post> GetAllPosts()
        {
            List<Post> returnPosts = new List<Post>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetAllPosts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Post returnPost = GetPostFromReader(reader);
                        returnPosts.Add(returnPost);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPosts;
        }

        public Post GetPostDetails(int postId)
        {
            Post returnPost = new Post();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetPostDetails, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnPost = GetPostFromReader(reader);
                        
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPost;
        }

        public bool AddPost(Post postToAdd)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddPost, conn);
                    cmd.Parameters.AddWithValue("@title", postToAdd.Title);
                    cmd.Parameters.AddWithValue("@poster_id", postToAdd.PosterId);
                    cmd.Parameters.AddWithValue("@message", postToAdd.Message);
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

        

        private Post GetPostFromReader(SqlDataReader reader)
        {
            Post post = new Post();

            post.PostId = Convert.ToInt32(reader["post_id"]);
            post.Title = Convert.ToString(reader["title"]);
            post.PosterId = Convert.ToInt32(reader["poster_id"]);
            post.Message = Convert.ToString(reader["message"]);
            post.PostDate = Convert.ToString(reader["post_date"]);
            post.Username = Convert.ToString(reader["username"]);
            post.PostDate = post.PostDate.Substring(0, 9);
            return post;
        }
    }
}
