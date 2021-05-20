using FrameworkAPI.DTO;
using FrameworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Controls
{
    public class UserControl
    {
        public static User GetUser(UserDTO userDTO)
        {
            return new User
            {
                Name = userDTO.name,
                Username = userDTO.username,
                Email = userDTO.email,
                Phone = userDTO.phone,
                Website = userDTO.website,
                Guid = string.IsNullOrEmpty(userDTO.guid) ? System.Guid.NewGuid().ToString() : userDTO.guid,
                Address = AddressControl.GetAddress(userDTO.address),
                Company = CompanyControl.GetCompany(userDTO.company)
            };
        }
    }
}
