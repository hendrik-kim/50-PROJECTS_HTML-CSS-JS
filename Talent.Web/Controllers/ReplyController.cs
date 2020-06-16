using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Talent.Data.Models;
using Talent.Services.Repository.IRepository;
using Talent.Web.ViewModels;

namespace Talent.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IAppUserRepository _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReplyController(ILogger<PostController> logger, IPostRepository postRepository, IAppUserRepository userService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _postRepository = postRepository;
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("/api/post/{postId:int}/reply", Name = "AddReply")]
        [AllowAnonymous]
        public async Task<IActionResult> AddReply(ReplyViewModel model, int postId)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var reply = BuildReply(model, user, postId);

            _postRepository.AddReply(reply);
            //await _userService.UpdateUserRating(userId, typeof(PostReply));

            return Ok(reply.Post);
        }

        [HttpDelete("/api/post/{postId:int}/reply/{replyId:int}", Name = "DeleteReply")]
        [AllowAnonymous] // Delete in production
        public async Task<IActionResult> DeleteReply(int postId, int replyId)
        {
            _logger.LogInformation("Delete reply");

            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            //if (replyId == null)
            //{
            //    return NotFound();
            //}

            var replyDelObj =  _postRepository.DeleteReply(replyId);

            if (replyDelObj == null)
            {
                ModelState.AddModelError("", $"Somting went wrong while updating {replyDelObj.Data}");
                return StatusCode(500, ModelState);
            }

            var postObj = _postRepository.GetPostById(postId);

            return Ok(postObj);
        }
        private PostReply BuildReply(ReplyViewModel model, ApplicationUser user, int postId)
        {
            var post = _postRepository.GetPostById(postId);
            return new PostReply
            {
                Post = post,
                Content = model.Content,
                CreatedOn = DateTime.Now,
                User = user
            };
        }
    }
}