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
    public class PhotoController : ControllerBase
    {
        private readonly FrameworkAPIDbContext _context;

        public PhotoController(FrameworkAPIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona uma foto a um album
        /// </summary>
        /// <param name="photoDTO">Foto a ser adicionado</param>
        [HttpPost("PostPhoto")]
        public async Task<IActionResult> PostAlbumAsync([FromBody] PhotoDTO photoDTO)
        {
            try
            {
                Photo photo = new()
                {
                    AlbumId = photoDTO.albumId,
                    ThumbnailUrl = photoDTO.thumbnailUrl,
                    Title = photoDTO.title,
                    Url = photoDTO.url
                };
                _context.Photos.Add(photo);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Adiciona uma lista de fotos
        /// </summary>
        /// <param name="photosDTO">Lista com as fotos para adicionar</param>
        [HttpPost("PostPhotos")]
        public async Task<IActionResult> PostPhotosAsync([FromBody] IList<PhotoDTO> photosDTO)
        {
            try
            {
                IEnumerable<Photo> photos = photosDTO
                    .Select(p => new Photo
                    {
                        AlbumId = p.albumId,
                        ThumbnailUrl = p.thumbnailUrl,
                        Title = p.title,
                        Url = p.url
                    });

                foreach (Photo photo in photos)
                {
                    try
                    {
                        _context.Photos.Add(photo);
                        await _context.SaveChangesAsync();

                    }
                    catch (Exception)
                    {
                        _context.Photos.Remove(photo);
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
        /// Solicita uma foto
        /// </summary>
        /// <param name="id">id da foto solicitada</param>
        /// <returns>PhotoDTO com os dados do foto solicitada</returns>
        [HttpGet("GetPhoto")]
        public ActionResult<PhotoDTO> GetPhoto(int id)
        {
            try
            {
                Photo photo = _context.Photos
                    .First(p => p.Id == id);
                return new PhotoDTO
                {
                    albumId = photo.AlbumId,
                    thumbnailUrl = photo.ThumbnailUrl,
                    title = photo.Title,
                    url = photo.Url
                };
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Solicita as fotos de determinado album
        /// </summary>
        /// <param name="idAlbum">Id do album que as fotos virão</param>
        /// <returns>Lista com as fotos de determinado Album</returns>
        [HttpGet("GetPhotos")]
        public ActionResult<IEnumerable<PhotoDTO>> GetPhotos(int idAlbum)
        {
            try
            {
                IEnumerable<Photo> photos = _context.Photos
                    .Where(p => p.AlbumId == idAlbum)
                    .ToList();
                return photos.Select(p => new PhotoDTO
                {
                    albumId = p.AlbumId,
                    thumbnailUrl = p.ThumbnailUrl,
                    title = p.Title,
                    url = p.Url
                }).ToList();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }
    }
}
