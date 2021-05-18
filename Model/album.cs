using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class album
    {
        public int id { get; set; }
        public string title { get; set; }

        public int userId { get; set; }
        public user user { get; set; }

        public ICollection<photo> Photos { get; set; }
    }
}
