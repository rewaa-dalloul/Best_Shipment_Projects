using AutoMapper;
using SPM.Core.DTO;
using SPM.Core.ViewModel;
using SPM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPM.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CityEntity, CityVM>();
            CreateMap<CreateCityDto, CityEntity>();
            CreateMap<CountryEntity, CountryVM>();
            CreateMap<CreateCountryDTO, CountryEntity>();
            CreateMap<ClientEntity, ClientVM>();
            CreateMap<CreateClientDTO, ClientEntity>();
<<<<<<< HEAD
=======
            CreateMap<SupplierEntity, SupplierVM>();
            CreateMap<CreateSupplierDTO, SupplierEntity>();
>>>>>>> 4a8f5fd8edb4bf25bbe2d7b8dd7c8f3ea62625fa
        }


    }
}
