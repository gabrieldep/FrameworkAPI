using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class address
    {
        public int id { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }

        public int idGeo { get; set; }
        public geo geo { get; set; }

        public int idUser { get; set; }
        public user user { get; set; }
    }   
}
