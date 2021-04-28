using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class CategoryEntity:BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
