using FrameworkAPI.DTO;
using FrameworkAPI.Model;
using FrameworkAPI.Model.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly FrameworkAPIDbContext _context;

        public PostController(FrameworkAPIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona uma lista de posts
        /// </summary>
        /// <param name="postsDTO">Lista com os posts para adicionar</param>
        [HttpPost("PostPosts")]
        public async Task<IActionResult> PostPostsAsync([FromBody] IList<PostDTO> postsDTO)
        {
            try
            {
                IEnumerable<Post> posts = postsDTO
                    .Select(p => new Post
                    {
                        Body = p.body,
                        Title = p.title,
                        IdUser = p.userId
                    });

                foreach (Post post in posts)
                {
                    try
                    {
                        _context.Posts.Add(post);
                        await _context.SaveChangesAsync();

                    }
                    catch (Exception)
                    {
                        _context.Posts.Remove(post);
                    }
                }
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Adiciona um post
        /// </summary>
        /// <param name="postDTO">Post para adicionar</param>
        [HttpPost("PostPost")]
        public async Task<IActionResult> PostPostAsync([FromBody] PostDTO postDTO)
        {
            try
            {
                Post post = new()
                {
                    Body = postDTO.body,
                    Title = postDTO.title,
                    IdUser = postDTO.userId
                };
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Solicita um post
        /// </summary>
        /// <param name="id">id do Post solicitado</param>
        /// <returns>POstDTO com os dados do Post solicitado</returns>
        [HttpGet("GetPost")]
        public ActionResult<PostDTO> GetPost(int id)
        {
            try
            {
                Post post = _context.Posts
                    .First(u => u.Id == id);
                return new PostDTO
                {
                    body = post.Body,
                    title = post.Title,
                    userId = post.IdUser
                };
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Solicita os posts de determinado usuario
        /// </summary>
        /// <param name="username">Username do usuario que se deseja os posts</param>
        /// <returns>Lista com os posts de determinado usuario</returns>
        [HttpGet("GetPosts")]
        public ActionResult<IEnumerable<PostDTO>> GetPosts(string username)
        {
            try
            {
                IEnumerable<Post> posts = _context.Posts
                    .Include(p => p.User)
                    .Where(p => p.User.Username == username)
                    .ToList();
                return posts.Select(p => new PostDTO
                {
                    body = p.Body,
                    title = p.Title,
                    userId = p.IdUser
                }).ToList();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Solicita todos os posts
        /// </summary>
        /// <returns>Lista com todos os posts</returns>
        [HttpGet("GetAllPosts")]
        public ActionResult<IEnumerable<PostDTO>> GetAllPosts()
        {
            try
            {
                IEnumerable<Post> posts = _context.Posts
                    .Include(p => p.User)
                    .ToList();
                return posts.Select(p => new PostDTO
                {
                    body = p.Body,
                    title = p.Title,
                    userId = p.IdUser
                }).ToList();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }
    }
}
