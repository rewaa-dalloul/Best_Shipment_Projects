using SPM.Core.DTO;
using SPM.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Service.Country
{
    public interface ICountryServies
    {
        PagingViewModel GetAll(int page);
        void Delete(int id);
        Task Create(CreateCountryDTO dto);
        void Update(UpdateCountryDTO dto);
    }
}
