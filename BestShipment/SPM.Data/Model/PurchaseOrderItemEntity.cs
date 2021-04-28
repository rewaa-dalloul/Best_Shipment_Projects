using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class PurchaseOrderItemEntity:BaseEntity
    {
        public int OrderedQuantity { get; set; }
        public int ApprovedQuantity { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int PurchaseOrderId { get; set; }
        public PurchaseOrderEntity PurchaseOrder { get; set; }

    }
}
