using SPM.Core.DTO;
using SPM.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Services.Supplier
{
    public interface ISupplierService
    {
        PagingViewModel GetAll(PagingDto dto);
        Task Create(CreateSupplierDTO dto);
        void Update(UpdateSupplierDTO dto);
        void Delete(int id);
    }
}
