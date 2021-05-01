using SPM.Core;
using SPM.Core.DTO;
using SPM.Core.DTO;
using SPM.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Services.City
{
    public interface ICityService
    {
        PagingViewModel GetAll(PagingDto dto);
        Task Create(CreateCityDto dto);
        Task Update(UpdateCityDto dto);
        void Delete(int id);
    }
}
