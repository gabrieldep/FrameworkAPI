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
    public class AlbumController : ControllerBase
    {
        private readonly FrameworkAPIDbContext _context;

        public AlbumController(FrameworkAPIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona um album de fotos
        /// </summary>
        /// <param name="albumDTO">Album a ser adicionado</param>
        [HttpPost("PostAlbum")]
        public async Task<IActionResult> PostAlbumAsync([FromBody] AlbumDTO albumDTO)
        {
            try
            {
                Album album = new()
                {
                    Title = albumDTO.title,
                    IdUser = albumDTO.userId
                };
                _context.Albums.Add(album);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Solicita um album
        /// </summary>
        /// <param name="id">id do album solicitado</param>
        /// <returns>AlbumDTO com os dados do album solicitado</returns>
        [HttpGet("GetAlbum")]
        public ActionResult<AlbumDTO> GetAlbum(int id)
        {
            try
            {
                Album album = _context.Albums
                    .Include(a => a.Photos)
                    .First(u => u.Id == id);
                return new AlbumDTO
                {
                    title = album.Title,
                    userId = album.IdUser,
                    photos = album.Photos.Select(p => new PhotoDTO
                    {
                        thumbnailUrl = p.ThumbnailUrl,
                        title = p.Title,
                        url = p.Url
                    }).ToList()
                };
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Solicita os albums de determinado usuario
        /// </summary>
        /// <param name="idUser">Id do usuario que os albuns virão</param>
        /// <returns>Lista com os albums de determinado User</returns>
        [HttpGet("GetAlbums")]
        public ActionResult<IEnumerable<AlbumDTO>> GetAlbums(int idUser)
        {
            try
            {
                IEnumerable<Album> albums  = _context.Albums
                    .Where(c => c.IdUser == idUser)
                    .ToList();
                return albums.Select(a => new AlbumDTO
                {
                    title = a.Title,
                    userId = a.IdUser
                }).ToList();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Solicita todos os albuns
        /// </summary>
        /// <returns>Lista com todos os albuns</returns>
        [HttpGet("GetAllAlbums")]
        public ActionResult<IEnumerable<AlbumDTO>> GetAllAlbums()
        {
            try
            {
                IList<Album> albums = _context.Albums.ToList();
                return albums.Select(a => new AlbumDTO
                {
                    title = a.Title,
                    userId = a.IdUser
                }).ToList();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

    }
}
