using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
