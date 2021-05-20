using FrameworkAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public int IdGeo { get; set; }
        public Geo Geo { get; set; }
        
        public IEnumerable<User> Users { get; set; }
    }
}
