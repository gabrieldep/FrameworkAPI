using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class user
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }

        public int idAddress { get; set; }
        public address address { get; set; }

        public int idCompany { get; set; }
        public company company { get; set; }
    }
}
