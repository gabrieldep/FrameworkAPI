using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.DTO
{
    public class PostDTO
    {
        public string title { get; set; }
        public string body { get; set; }

        public int userId { get; set; }
    }
}
