using FrameworkAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
            Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public string Guid { get; set; }

        public int IdAddress { get; set; }
        public Address Address { get; set; }

        public int IdCompany { get; set; }
        public Company Company { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
