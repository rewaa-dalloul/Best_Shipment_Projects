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

namespace SPM.Services.Country
{
    public class CountryService:ICountryService
    {
        private ApplicationDbContext _Db;
        public CountryService(ApplicationDbContext db)
        {
            _Db = db;
        }
        public PagingViewModel GetAll(int page)
        {

            var pages = Math.Ceiling(_Db.Countries.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;

            var countries = _Db.Countries.Include(x => x.Cities).Select(x => new CountryVM()
                {
                    Id = x.Id,
                    NameAr = x.NameAr,
                    NameEn = x.NameEn,
                    CreatedAt=x.CreatedAt,
                    CreatedBy=x.CreatedBy,
                    UpdatedAt=x.UpdatedAt,
                    UpdatedBy=x.UpdatedBy,
                Cities = x.Cities.Select(v => new CityVM()
                {
                    Id = v.Id,
                    NameAr = v.NameAr,
                    NameEn=v.NameEn,
                }).ToList(),
            }).Skip(skip).Take(10).ToList();

            var pagingResult = new PagingViewModel();
            pagingResult.Data = countries;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = page;

            return pagingResult;
        }

        public async Task Create(CreateCountryDTO dto)
        {

            var createdCountry = new CountryEntity()
            {
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                CreatedAt=dto.CreatedAt,
                CreatedBy=dto.CreatedBy
            };

            _Db.Countries.Add(createdCountry);
            _Db.SaveChanges();

            foreach (var x in dto.CityId)
            {
                var city = new CityEntity();
                city.CountryId = createdCountry.Id;

                _Db.Cities.Add(city);
            }
            _Db.SaveChanges();
        }

        public void Update(UpdateCountryDTO dto)
        {
            var country = _Db.Countries.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            country.NameAr = dto.NameAr;
            country.NameEn = dto.NameEn;
            country.UpdatedAt = dto.UpdatedAt;
            country.UpdatedBy = dto.UpdatedBy;
            _Db.Countries.Update(country);
            _Db.SaveChanges();
        }
        public void Delete(int id)
        {
            var deletedCountry = _Db.Countries.SingleOrDefault(x => x.Id == id);
            deletedCountry.IsDelete = true;
            _Db.Countries.Update(deletedCountry);
            _Db.SaveChanges();
        }


    }
}
