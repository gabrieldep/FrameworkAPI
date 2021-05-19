using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrameworkAPI.Model;
using FrameworkAPI.Model.Context;

namespace FrameworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class photosController : ControllerBase
    {
        private readonly FrameworkAPIDbContext _context;

        public photosController(FrameworkAPIDbContext context)
        {
            _context = context;
        }

        // GET: api/photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<photo>>> GetPhotos()
        {
            return await _context.Photos.ToListAsync();
        }

        // GET: api/photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<photo>> Getphoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        // PUT: api/photos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putphoto(int id, photo photo)
        {
            if (id != photo.id)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!photoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/photos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<photo>> Postphoto(photo photo)
        {
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getphoto", new { id = photo.id }, photo);
        }

        // DELETE: api/photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletephoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool photoExists(int id)
        {
            return _context.Photos.Any(e => e.id == id);
        }
    }
}
