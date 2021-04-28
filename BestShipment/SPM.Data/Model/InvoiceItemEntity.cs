using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class InvoiceItemEntity : BaseEntity 
    {
        public int Quantity { get; set; }
        public int Total { get; set; }
        public int SubTotal { get; set; }
        public int VatValue { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int InvoiceId { get; set; }
        public InvoiceEntity Invoice { get; set; }
    }
}
