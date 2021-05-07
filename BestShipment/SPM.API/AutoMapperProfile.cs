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
        }


    }
}
