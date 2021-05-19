using FrameworkAPI.DTO;
using FrameworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Controls
{
    public class GeoControl
    {
        public static Geo GetGeo(GeoDTO geoDTO)
        {
            return new Geo
            {
                Lat = geoDTO.lat,
                Lng = geoDTO.lng
            };
        }
    }
}
