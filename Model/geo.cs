using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class geo
    {
        public int id { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }

        public int idAddress { get; set; }
        public address address { get; set; }
    }
}
