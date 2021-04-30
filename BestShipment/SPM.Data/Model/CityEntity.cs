using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class CityEntity:BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CountryId { get; set; }
        public CountryEntity Counrty { get; set; }
        public List<ClientEntity> Clients { get; set; }
        public List<SupplierEntity> Suppliers { get; set; }
    }
}
