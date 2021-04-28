using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class BranchEntity :BaseEntity
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public List<PurchaseOrderEntity> PurchaseOrders { get; set; }
    }
}
