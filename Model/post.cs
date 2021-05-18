using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class post
    {
        public post()
        {
            Comments = new HashSet<comment>();
        }
        
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public int userId { get; set; }
        public user user { get; set; }

        public ICollection<comment> Comments { get; set; }
    }
}
