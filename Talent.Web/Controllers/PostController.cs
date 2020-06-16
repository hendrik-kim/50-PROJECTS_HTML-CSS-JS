using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Talent.Data.Models;
using Talent.Services.Repository.IRepository;
using Talent.Web.ViewModels;

namespace Talent.Web.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(ILogger<PostController> logger, IPostRepository postRepository, IMapper mapper)
        {
            _logger = logger;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet("/api/post")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPosts()
        {
            _logger.LogInformation("Getting all posts");
            var posts = await _postRepository.GetAllPosts();
            var postDto = new List<PostViewModel>();
            foreach(var post in posts)
            {
                postDto.Add(_mapper.Map<PostViewModel>(post));
            }
            return Ok(posts);
        }

        [HttpGet("/api/post/{postId:int}", Name = "GetPostById")]
        [AllowAnonymous]
        public ActionResult GetPostById(int postId)
        {
            _logger.LogInformation("Getting post by id");
            var obj = _postRepository.GetPostById(postId);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<PostViewModel>(obj);
            return Ok(objDto);
        }

        [HttpPost("/api/post")]
        [AllowAnonymous] // Need to be deleted in production 
        public IActionResult CreatePost([FromBody] PostViewModel postDto)
        {
            if (postDto == null)
            {
                return BadRequest(ModelState);
            }

            //if (_postRepository.GetPostById(postDto.Id) != null)
            //{
            //    ModelState.AddModelError("", "Post already exists!");
            //    return StatusCode(404, ModelState);
            //}

            var postObj = _mapper.Map<Post>(postDto);

            if (_postRepository.CreatePost(postObj) == null)
            {
                ModelState.AddModelError("", $"Somting went wrong while creating {postObj.Title}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetPostById", new { PostId = postObj.Id }, postObj);
        }

        [HttpPatch("/api/post/{postId:int}", Name = "UpdatePost")]
        [AllowAnonymous] // Delete in production
        public ActionResult UpdatePost(int postId, [FromBody] PostViewModel postDto)
        {
            _logger.LogInformation("Update post");
            if (postDto == null /*|| postId != postId*/)
            {
                return BadRequest(ModelState);
            }

            var postObj = _mapper.Map<Post>(postDto);

            if (_postRepository.UpdatePost(postObj) == null)
            {
                ModelState.AddModelError("", $"Somting went wrong while updating {postObj.Title}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetPostById", new { PostId = postId }, postObj);
        }


        [HttpDelete("/api/post/{postId:int}", Name = "DeletePost")]
        [AllowAnonymous] // Delete in production
        public IActionResult DeletePost(int postId)
        {
            _logger.LogInformation("Delete post");

            var postObj = _postRepository.GetPostById(postId);
            if (postObj == null)
            {
                return NotFound();
            }

            if (_postRepository.DeletePost(postObj) == null)
            {
                ModelState.AddModelError("", $"Somting went wrong while updating {postObj.Title}");
                return StatusCode(500, ModelState);
            }

            return Ok("Post deleted");
        }
    }
}
