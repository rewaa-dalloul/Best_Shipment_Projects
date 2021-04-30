using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.DTO
{
    public class CreateCountryDTO
    {
        public String NameAr { get; set; }
        public String NameEn { get; set; }
        public List<int> CityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
