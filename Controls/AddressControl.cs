using FrameworkAPI.DTO;
using FrameworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Controls
{
    public class AddressControl
    {
        public static Address GetAddress(AddressDTO addressDTO)
        {
            return new Address
            {
                Street = addressDTO.street,
                City = addressDTO.city,
                Suite = addressDTO.suite,
                ZipCode = addressDTO.zipcode,
                Geo = GeoControl.GetGeo(addressDTO.geo)
            };
        }
    }
}
