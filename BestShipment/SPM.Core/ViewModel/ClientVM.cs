using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Core.ViewModel
{
    public class ClientVM
    {
        public int Id { get; set; }

        public string Email { get; set; }
           
        public string Mobile { get; set; }
          
        public string CompanyName { get; set; }
        
        public string Address { get; set; }
      
        public CityVM City { get; set; }
        
    } 
}
