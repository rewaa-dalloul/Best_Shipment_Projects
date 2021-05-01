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

namespace SPM.Services.City
{
    public class CityService : ICityService
    {
        private ApplicationDbContext _DB;
        private readonly IMapper _mapper;
        public CityService(ApplicationDbContext DB, IMapper mapper)
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
            var citiesVM = _mapper.Map <List<CityEntity>,List<CityVM)>>().Skip(skip).Take((int)dto.PerPage).ToList();

            var cities = _DB.Cities.Include(x=> x.Country).Select(x => new CityVM()
            //{
            //    Id = x.Id,
            //    NameAr = x.NameAr,
            //    NameEn = x.NameEn,
            //    Country = new CountryVM()
            //    {
            //        Id = x.Id,
            //        NameAr = x.NameAr,
            //        NameEn = x.NameEn,

            //    },
            //}).Skip(skip).Take((int)dto.PerPage).ToList();

            var pagingResult = new PagingViewModel();
            pagingResult.Data = cities;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = dto.Page;

            return pagingResult;
        }
        public async Task Create(CreateCityDto dto)
        {

            var City = new CityEntity()
            {
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                CountryId = dto.CountyId,
               
            };

            await _DB.Cities.AddAsync(City);
            _DB.SaveChanges();
        }
            public async Task Update(UpdateCityDto dto)
        {
            var city = _DB.Cities.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            city.NameAr = dto.NameAr;
            city.NameEn = dto.NameEn;
            city.CountryId = dto.CountyId;
             _DB.Cities.Update(city);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var cities = _DB.Cities.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            cities.IsDelete = true;
            _DB.Cities.Update(cities);
            _DB.SaveChanges();
        }
    }
}
