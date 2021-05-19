using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
