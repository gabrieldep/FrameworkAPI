using FrameworkAPI.Controls;
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
    public class UserController : ControllerBase
    {
        private readonly FrameworkAPIDbContext _context;

        public UserController(FrameworkAPIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona uma lista de Users
        /// </summary>
        /// <param name="usersDTO">Lista com os users para adicionar</param>
        [HttpPost("PostUsers")]
        public async Task<IActionResult> PostUsersAsync([FromBody] IList<UserDTO> usersDTO)
        {
            try
            {
                IEnumerable<User> users = usersDTO
                    .Select(userDTO => UserControl.GetUser(userDTO));

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

        /// <summary>
        /// Adiciona um User
        /// </summary>
        /// <param name="userDTO">User para adicionar</param>
        [HttpPost("PostUser")]
        public async Task<IActionResult> PostUserAsync([FromBody] UserDTO userDTO)
        {
            try
            {
                User user = UserControl.GetUser(userDTO);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Login do Usuario
        /// </summary>
        /// <param name="userName">Nome do usuario</param>
        /// <returns>guid de controle do usuario</returns>
        [HttpGet("GetGuid")]
        public ActionResult<string> GetGuid(string userName)
        {
            try
            {
                return _context.Users.First(u => u.Username == userName).Guid;
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Solicita todos os Users
        /// </summary>
        /// <returns>Lista com todos os users</returns>
        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return _context.Users
                    .Include(u => u.Address)
                    .Include(u => u.Company)
                    .Include(u => u.Posts)
                    .Include(u => u.Albums)
                    .ToList();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }
    }
}
