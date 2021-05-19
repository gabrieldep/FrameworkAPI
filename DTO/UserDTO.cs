using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.DTO
{
    public class UserDTO
    {
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string guid { get; set; }
        public AddressDTO address { get; set; }

        public CompanyDTO company { get; set; }
    }
}
