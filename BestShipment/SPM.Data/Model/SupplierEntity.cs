using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class SupplierEntity : BaseEntity 
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public CityEntity City { get; set; }
        public List<RFQEntity> RFQs { get; set; }
        public List<ProductEntity> Products { get; set; }
        public List<ProductSupplierEntity> ProductSuppliers { get; set; }
    }
}
