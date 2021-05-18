using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class company
    {
        public company()
        {
            Users = new HashSet<user>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }

        public ICollection<user> Users { get; set; }
    }
}
