using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.DTO
{
    public class UpdateSupplierDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }
}
