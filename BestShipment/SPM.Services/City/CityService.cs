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
        public CityService(ApplicationDbContext DB)
        {
            _DB = DB; 
        }
        public PagingViewModel GetAll(int page)
        {

            var pages = Math.Ceiling(_DB.Cities.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;

            var cities = _DB.Cities.Include(x=> x.Country).Select(x => new CityVM()
            {
                Id = x.Id,
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                Country = new CountryVM()
                {
                    Id = x.Id,
                    NameAr = x.NameAr,
                    NameEn = x.NameEn,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    UpdatedAt = x.UpdatedAt,
                    UpdatedBy = x.UpdatedBy,
                },
            }).Skip(skip).Take(10).ToList();

            var pagingResult = new PagingViewModel();
            pagingResult.Data = cities;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = page;

            return pagingResult;
        }
        public async Task Create(CreateCityDto dto)
        {

            var createdPost = new CityEntity()
            {
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                CountryId = dto.CountyId,
                CreatedAt = dto.CreatedAt,
                CreatedBy = dto.CreatedBy
            };

            _DB.Cities.Add(createdPost);
            _DB.SaveChanges();
        }
            public void Update(UpdateCityDto dto)
        {
            var cities = _DB.Cities.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            cities.NameAr = dto.NameAr;
            cities.NameEn = dto.NameEn;
            cities.UpdatedAt = dto.UpdatedAt;
            cities.UpdatedBy = dto.UpdatedBy;
            cities.CountryId = dto.CountyId;
            _DB.Cities.Update(cities);
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
