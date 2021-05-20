using FrameworkAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class Geo
    {        
        public Geo()
        {
            Addresses = new HashSet<Address>();
        }
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

       
        public IEnumerable<Address> Addresses { get; set; }
    }
}
