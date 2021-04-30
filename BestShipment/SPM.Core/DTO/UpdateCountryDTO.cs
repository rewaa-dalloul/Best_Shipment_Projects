using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.DTO
{
    public class UpdateCountryDTO
    {
        public int  Id{ get; set; }
        public String NameAr { get; set; }
        public String NameEn { get; set; }
        public List<int> CityId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
