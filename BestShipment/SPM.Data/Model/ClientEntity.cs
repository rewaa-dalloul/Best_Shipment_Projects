using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class ClientEntity:BaseEntity
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public CityEntity City { get; set; }
        public List<PurchaseOrderEntity> PurchaseOrders { get; set; }
        public List<InvoiceEntity> Invoices { get; set; }
        public List<BranchEntity> Branches { get; set; }
    }
}
