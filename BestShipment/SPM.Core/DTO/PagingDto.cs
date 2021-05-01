using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.DTO
{
    public class PagingDto
    {
        public int Page { get; set; }
        public double PerPage { get; set; }
        public PagingDto(){
            Page = 1;
            PerPage = 10.0;
            }
    }
}
