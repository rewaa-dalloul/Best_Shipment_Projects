using SPM.Core.DTO;
using SPM.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Services.Client
{
    public interface IClientService
    {
        PagingViewModel GetAll(PagingDto dto);
        Task Create(CreateClientDTO dto);
        Task Update(UpdateClientDto dto);
        void Delete(int id);
    }
}
