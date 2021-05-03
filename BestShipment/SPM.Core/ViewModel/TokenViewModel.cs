using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.ViewModel
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; }
        public DateTime ExpireAt { get; set; }

    }
}
