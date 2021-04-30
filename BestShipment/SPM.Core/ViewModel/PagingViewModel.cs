using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.ViewModel
{
    public class PagingViewModel
    {
        public int NumberOfPages { get; set; }

        public int CureentPage { get; set; }

        public object Data { get; set; }
    }
}
