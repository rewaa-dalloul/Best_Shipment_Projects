using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class ProductEntity:BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public double Size { get; set; }
        public string Code { get; set; }
        public float Price { get; set; }
        public int UnitId { get; set; }
        public UnitEntity Unit { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public List<SupplierEntity> Suppliers { get; set; }
        public List<PurchaseOrderItemEntity> PurchaseOrderItems { get; set; }
        public List<RFQItemEntity> RFQItems { get; set; }
        public List<InvoiceItemEntity> InvoiceItems { get; set; }
        public List<ProductSupplierEntity> ProductSuppliers { get; set; }
    }
}
