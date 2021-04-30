using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.ViewModel
{
    public class APIResponseViewModel
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
