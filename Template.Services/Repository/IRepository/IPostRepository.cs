using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.Data.Models;

namespace Talent.Services.Repository.IRepository
{
    public interface IPostRepository
    {
        //int GetReplyCount(int id);
        //bool PostExists(string title);
        //bool PostExists(int id);
        ////bool CreatePost(Post post);
        //bool UpdatePost(Post post);
        //bool DeletePost(Post post);

        Post GetPostById(int postId);
        
        Task<IEnumerable<Post>> GetAllPosts();
        IEnumerable<Post> GetPostsByCategory(int categId);
        IEnumerable<Post> GetPostsByUserId(string userId);
        Task<IEnumerable<Post>> GetLatestPosts(int categoryId);
        IEnumerable<Post> GetFilteredPosts(Category category, string searchQuery);

        ServiceResponse<Post> CreatePost(Post post);
        ServiceResponse<Post> UpdatePost(Post post);
        ServiceResponse<Post> DeletePost(Post post);
        ServiceResponse<PostReply> AddReply(PostReply reply);
        ServiceResponse<PostReply> EditReply(PostReply reply);
        //ServiceResponse<PostReply> DeleteReply(PostReply reply);
        ServiceResponse<PostReply> DeleteReply(int replyId);
    }
}
