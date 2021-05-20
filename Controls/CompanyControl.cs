using FrameworkAPI.DTO;
using FrameworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Controls
{
    public class CompanyControl
    {
        public static Company GetCompany(CompanyDTO companyDTO)
        {
            return new Company
            {
                Bs = companyDTO.bs,
                CatchPhrase = companyDTO.catchPhrase,
                Name = companyDTO.name
            };
        }
    }
}
