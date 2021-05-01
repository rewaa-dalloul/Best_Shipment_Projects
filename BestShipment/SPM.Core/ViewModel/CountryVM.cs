using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.ViewModel
{
    public class CountryVM
    {
        public int Id { get; set; }
        public String NameAr { get; set; }
        public String NameEn { get; set; }
        public List<CityVM> Cities { get; set; }
    }
}
