using FrameworkAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model
{
    public class Geo
    {
        public Geo(GeoDTO geoDTO)
        {
            Lat = geoDTO.lat;
            Lng = geoDTO.lng;
        }
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

        public int IdAddress { get; set; }
        public Address Address { get; set; }
    }
}
