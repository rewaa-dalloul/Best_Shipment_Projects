using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class PurchaseOrderEntity : BaseEntity 
    {
        public string Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string PaymentType { get; set; }
        public int BranchId { get; set; }
        public BranchEntity Branch { get; set; }
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }

        public List<PurchaseOrderItemEntity> PurchaseOrderItems { get; set; }
        public List<RFQEntity> RFQs { get; set; }
    }
}
