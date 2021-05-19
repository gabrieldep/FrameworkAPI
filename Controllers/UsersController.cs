using FrameworkAPI.DTO;
using FrameworkAPI.Model;
using FrameworkAPI.Model.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FrameworkAPIDbContext _context;

        public UsersController(FrameworkAPIDbContext context)
        {
            _context = context;
        }

        [HttpPost("PostUsers")]
        public async Task<IActionResult> PostUsersAsync([FromBody] IList<UserDTO> usersDTO)
        {
            try
            {
                IEnumerable<User> users = usersDTO
                    .Select(u => new User
                    {
                        Name = u.name,
                        Username = u.username,
                        Email = u.email,
                        Phone = u.phone,
                        Website = u.website,
                        Guid = Guid.NewGuid().ToString(),
                        Address = new Address
                        {
                            Street = u.address.street,
                            City = u.address.city,
                            Suite = u.address.suite,
                            ZipCode = u.address.zipcode,
                            Geo = new Geo
                            {
                                Lat = u.address.geo.lat,
                                Lng = u.address.geo.lng
                            }
                        },
                        Company = new Company
                        {
                            Name = u.company.name,
                            CatchPhrase = u.company.catchPhrase,
                            Bs = u.company.bs
                        }
                    });

                foreach (User user in users)
                {
                    try
                    {
                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();

                    }
                    catch (Exception)
                    {
                        _context.Users.Remove(user);
                    }
                }
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("PostUser")]
        public async Task<IActionResult> PostUserAsync([FromBody] UserDTO userDTO)
        {
            try
            {
                User user = new()
                {
                    Name = userDTO.name,
                    Username = userDTO.username,
                    Email = userDTO.email,
                    Phone = userDTO.phone,
                    Website = userDTO.website,
                    Guid = Guid.NewGuid().ToString(),
                    Address = new Address
                    {
                        Street = userDTO.address.street,
                        City = userDTO.address.city,
                        Suite = userDTO.address.suite,
                        ZipCode = userDTO.address.zipcode,
                        Geo = new Geo
                        {
                            Lat = userDTO.address.geo.lat,
                            Lng = userDTO.address.geo.lng
                        }
                    },
                    Company = new Company
                    {
                        Name = userDTO.company.name,
                        CatchPhrase = userDTO.company.catchPhrase,
                        Bs = userDTO.company.bs
                    }
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }
    }
}
