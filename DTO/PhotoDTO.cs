using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.DTO
{
    public class PhotoDTO
    {
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }

        public int albumId { get; set; }
    }
}
