using SPM.Core.DTO;
using SPM.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Services.Country
{
    public interface ICountryService
    {
        PagingViewModel GetAll(int page);
        Task Create(CreateCountryDTO dto);
        void Update(UpdateCountryDTO dto);
        void Delete(int id);
    }
}
