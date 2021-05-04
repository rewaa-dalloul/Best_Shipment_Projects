using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SPM.Core.DTO;
using SPM.Core.ViewModel;
using SPM.Data;
using SPM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Services.Client
{
    public class ClientService : IClientService
    {
        private ApplicationDbContext _DB;
        private readonly IMapper _mapper;
        public ClientService(ApplicationDbContext DB, IMapper mapper)
        {
            _DB = DB;
            _mapper = mapper;
        }
        public PagingViewModel GetAll(PagingDto dto)
        {

            var pages = Math.Ceiling(_DB.Countries.Count() / dto.PerPage);


            if (dto.Page < 1 || dto.Page > pages)
            {
                dto.Page = 1;
            }

            var skip = (dto.Page - 1) * (int)dto.PerPage;
            var Clients = _DB.Clients.Include(x => x.City).Skip(skip).Take((int)dto.PerPage).ToList();
            var ClientsVM = _mapper.Map<List<ClientEntity>, List<ClientVM>>(Clients);
           
            var pagingResult = new PagingViewModel();
            pagingResult.Data = Clients;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = dto.Page;

            return pagingResult;
        }
        public async Task Create(CreateClientDTO dto)
        {

            var ClientDTo = _mapper.Map<CreateClientDTO, ClientEntity>(dto);


            await _DB.Clients.AddAsync(ClientDTo);
            _DB.SaveChanges();
        }
        public async Task Update(UpdateClientDto dto)
        {
            var client = _DB.Clients.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            client.Email = dto.Email;
            client.Mobile = dto.Mobile;
            client.CompanyName = dto.CompanyName;
            client.Address = dto.Address;
            client.CityId = dto.CityId;
            _DB.Clients.Update(client);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var client = _DB.Clients.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            client.IsDelete = true;
            _DB.Clients.Update(client);
            _DB.SaveChanges();
        }
    }
    
}
