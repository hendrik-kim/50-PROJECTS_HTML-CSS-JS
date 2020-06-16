using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Data;
using Talent.Data.Models;
using Talent.Services.Repository.IRepository;

namespace Talent.Services.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _db;

        public PostRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ServiceResponse<Post> CreatePost(Post post)
        {
            try
            {
                var newPost = new Post
                {
                    CategoryId = post.Category.Id,
                    Location = post.Location,
                    Tags = post.Tags,
                    CreatedOn = DateTime.UtcNow,
                    Content = post.Content,
                    Title = post.Title,
                    User = post.User
                };


                _db.Posts.Add(newPost);
                _db.SaveChanges();

                return new ServiceResponse<Post>
                {
                    Data = post,
                    DateTime = DateTime.UtcNow,
                    Message = "Post created.",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Post>
                {
                    Data = post,
                    DateTime = DateTime.UtcNow,
                    Message = "Error saving new post.",
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<Post> UpdatePost(Post post)
        {
            try
            {
                var newPost = new Post
                {
                    Category = post.Category,
                    Location = post.Location,
                    Tags = post.Tags,
                    CreatedOn = DateTime.UtcNow,
                    Content = post.Content,
                    Title = post.Title,
                    User = post.User
                };

                _db.Posts.Update(newPost);
                _db.SaveChanges();

                return new ServiceResponse<Post>
                {
                    Data = post,
                    DateTime = DateTime.UtcNow,
                    Message = "Post updated.",
                    IsSuccess = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<Post>
                {
                    Data = post,
                    DateTime = DateTime.UtcNow,
                    Message = "Error updating new post.",
                    IsSuccess = false
                };
            }
        }
        public ServiceResponse<Post> DeletePost(Post post)
        {
            try
            {
                _db.Posts.Remove(post);
                _db.SaveChanges();

                return new ServiceResponse<Post>
                {
                    Data = post,
                    DateTime = DateTime.UtcNow,
                    Message = "Post deleted.",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Post>
                {
                    Data = post,
                    DateTime = DateTime.UtcNow,
                    Message = "Error deleting post.",
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<PostReply> AddReply(PostReply reply)
        {
            try
            {
                var newReply = new PostReply
                {
                    Id = reply.Id,
                    Post = reply.Post,
                    Content = reply.Content,
                    CreatedOn = DateTime.Now,
                    User = reply.User
                };

                _db.PostReplies.Add(newReply);
                _db.SaveChanges();

                return new ServiceResponse<PostReply>
                {
                    Data = reply,
                    DateTime = DateTime.UtcNow,
                    Message = "Reply created.",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<PostReply>
                {
                    Data = reply,
                    DateTime = DateTime.UtcNow,
                    Message = "Error saving new reply.",
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<PostReply> EditReply(PostReply reply)
        {
            try
            {
                _db.PostReplies.Add(reply);

                var newReply = new PostReply
                {
                    Id = reply.Id,
                    Post = reply.Post,
                    Content = reply.Content,
                    CreatedOn = DateTime.UtcNow,
                    User = reply.User
                };

                _db.PostReplies.Update(newReply);
                _db.SaveChanges();

                return new ServiceResponse<PostReply>
                {
                    Data = reply,
                    DateTime = DateTime.UtcNow,
                    Message = "Reply created.",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<PostReply>
                {
                    Data = reply,
                    DateTime = DateTime.UtcNow,
                    Message = "Error saving new reply.",
                    IsSuccess = false
                };
            }
        }
        public ServiceResponse<PostReply> DeleteReply(int replyId)
        {
            var reply = _db.PostReplies.Find(replyId);
            try
            {
                _db.Remove(reply);
                _db.SaveChanges();

                return new ServiceResponse<PostReply>
                {
                    Data = reply,
                    DateTime = DateTime.UtcNow,
                    Message = "Reply deleted.",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<PostReply>
                {
                    Data = reply,
                    DateTime = DateTime.UtcNow,
                    Message = "Error deleting reply.",
                    IsSuccess = false
                };
            }
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
           return await _db.Posts
              .Include(post => post.User)
              .Include(post => post.Tags)
              .Include(post => post.Replies).ThenInclude(reply => reply.User)
              .Include(post => post.Category)
              .ToListAsync();
        }

        public Post GetPostById(int postId)
        {
            return _db.Posts.Where(post => post.Id == postId)
                  .Include(post => post.Category)
                  .Include(post => post.User)
                  .Include(post => post.Tags)
                  .Include(post => post.Replies)
                  .ThenInclude(reply => reply.User)
                  .FirstOrDefault();
        }

        public IEnumerable<Post> GetFilteredPosts(Category category, string searchQuery)
        {
            return string.IsNullOrEmpty(searchQuery) ? category.Posts :
                category.Posts.Where(post => post.Title.Contains(searchQuery) || post.Content.Contains(searchQuery));
        }

        public async Task<IEnumerable<Post>> GetLatestPosts(int categoryId)
        {
            return GetAllPosts().Result.OrderByDescending(post => post.CreatedOn).Take(categoryId);
        }

        public IEnumerable<Post> GetPostsByCategory(int categId)
        {
            return _db.Categories.Where(categ => categ.Id == categId).FirstOrDefault().Posts;
        }

        public IEnumerable<Post> GetPostsByUserId(string userId)
        {
            return _db.Posts.Where(post => post.User.Id == userId);
        }
    }
}
