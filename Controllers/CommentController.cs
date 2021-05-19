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
    public class CommentController : ControllerBase
    {
        private readonly FrameworkAPIDbContext _context;

        public CommentController(FrameworkAPIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona um comentario a um post
        /// </summary>
        /// <param name="commentDTO">Comentario a ser adicionado para adicionar</param>
        [HttpPost("PostComment")]
        public async Task<IActionResult> PostCommentAsync([FromBody] CommentDTO commentDTO)
        {
            try
            {
                Comment comment = new()
                {
                    Body = commentDTO.body,
                    Email = commentDTO.email,
                    Name = commentDTO.name,
                    PostId = commentDTO.postId                    
                };
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Solicita um comentario
        /// </summary>
        /// <param name="id">id do comentario solicitado</param>
        /// <returns>CommentDTO com os dados do Comment solicitado</returns>
        [HttpGet("GetComment")]
        public ActionResult<CommentDTO> GetComment(int id)
        {
            try
            {
                Comment comment = _context.Comments
                    .First(u => u.Id == id);
                return new CommentDTO
                {
                    body = comment.Body,
                    email = comment.Email,
                    name = comment.Name,
                    postId = comment.PostId
                };
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Solicita os comentarios de determinado post
        /// </summary>
        /// <param name="idPost">Id do post que os comentarios virão</param>
        /// <returns>Lista com os comentarios de determinado post</returns>
        [HttpGet("GetComments")]
        public ActionResult<IEnumerable<CommentDTO>> GetComments(int idPost)
        {
            try
            {
                IEnumerable<Comment> comments = _context.Comments
                    .Where(c => c.PostId == idPost)
                    .ToList();
                return comments.Select(c => new CommentDTO
                {
                    body = c.Body,
                    email = c.Email,
                    name = c.Name,
                    postId = c.PostId
                }).ToList();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }
    }
}
