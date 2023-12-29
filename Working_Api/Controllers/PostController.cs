using Microsoft.AspNetCore.Mvc;
using Working_Api.Domain.DTOs;
using Working_Api.Services.Interface;

namespace Working_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController(IPostService postService) : ControllerBase
    {
        private readonly IPostService _postService = postService;
        
        [HttpPut]
        [Route("{id:int}" , Name = "PostUpdate")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(int id ,PostDTO postDTO)
        {
            var postUpdate = await _postService.Update(id, postDTO);

            if (postUpdate.StatusCode == 400)
                return BadRequest(postUpdate.Description);

            if (postUpdate.StatusCode == 404)
                return NotFound(postUpdate.Description);

            return Ok(postUpdate);
        }

        [HttpDelete]
        [Route("PostDeleteAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAll()
        {
            var postDelete = await _postService.DeleteAll();

            if (postDelete.StatusCode == 404)
                return NotFound(postDelete.Description);

            if (postDelete.StatusCode == 500)
                return Problem(postDelete.Description);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}", Name = "PostDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var postDelete = await _postService.Delete(id);

            if (postDelete.StatusCode == 404)
                return NotFound(postDelete.Description);

            if (postDelete.StatusCode == 400)
                return BadRequest(postDelete.Description);

            if (postDelete.StatusCode == 500)
                return Problem(postDelete.Description);

            return NoContent();
        }

        [HttpPost]
        [Route("CreatePost")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Create([FromBody] PostDTO postDTO)
        {
            var post = await _postService.Create(postDTO);

            if (post.StatusCode == 404)
                return NotFound(post.Description);

            if (post.StatusCode == 500)
                return Problem(post.Description);

            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetPostId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetServiceById(int id)
        {
            var post = await _postService.GetPost(id);

            if (post.StatusCode == 400)
                return BadRequest(post);

            if (post.StatusCode == 404)
                return NotFound(post);

            if (post.StatusCode == 500)
                return Problem(post.Description);

            return Ok(post);
        }

        [HttpGet]
        [Route("GetPostAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetServiceAll()
        {
            var posts = await _postService.GetPosts();

            if (posts.StatusCode == 404)
                return NotFound(posts);

            if (posts.StatusCode == 500)
                return Problem(posts.Description);

            return Ok(posts);
        }

    }
}
