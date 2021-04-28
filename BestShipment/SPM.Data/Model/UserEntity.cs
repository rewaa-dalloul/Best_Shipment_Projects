using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Data.Model
{
    public class UserEntity : IdentityUser
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public int SupplierId { get; set; }
        public SupplierEntity Supplier { get; set; }

    }
}
