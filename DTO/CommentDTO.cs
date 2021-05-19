using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.DTO
{
    public class CommentDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }

        public int postId { get; set; }
    }
}
