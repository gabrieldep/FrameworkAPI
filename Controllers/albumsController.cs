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
    public class albumsController : ControllerBase
    {
        private readonly FrameworkAPIDbContext _context;

        public albumsController(FrameworkAPIDbContext context)
        {
            _context = context;
        }

        // GET: api/albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<album>>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        // GET: api/albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<album>> Getalbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putalbum(int id, album album)
        {
            if (id != album.id)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!albumExists(id))
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

        // POST: api/albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<album>> Postalbum(album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getalbum", new { id = album.id }, album);
        }

        // DELETE: api/albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletealbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool albumExists(int id)
        {
            return _context.Albums.Any(e => e.id == id);
        }
    }
}
