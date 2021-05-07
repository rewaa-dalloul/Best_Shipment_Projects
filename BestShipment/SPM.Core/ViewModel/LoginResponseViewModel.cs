using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.ViewModel
{
    public class LoginResponseViewModel
    {
        public UserViewModel User { get; set; }
        public TokenViewModel Token { get; set; }
    }
}
