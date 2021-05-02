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

namespace SPM.Services.Country
{
    public class CountryService:ICountryService
    {
        private ApplicationDbContext _Db;
        private readonly IMapper _mapper;

        public CountryService(ApplicationDbContext db,IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
        }
        public PagingViewModel GetAll(PagingDto dto)
        {
            
            var pages = Math.Ceiling(_Db.Countries.Count() / dto.PerPage);


            if (dto.Page < 1 || dto.Page > pages)
            {
                dto.Page = 1;
            }

            var skip = (dto.Page - 1) * (int)dto.PerPage;
            var countries = _Db.Countries.Include(x => x.Cities).Skip(skip).Take((int)dto.PerPage).ToList();
            var countriesVM = _mapper.Map<List<CountryEntity>, List<CountryVM>>(countries);
            
            //var countries = _Db.Countries.Include(x => x.Cities).Select(x => new CountryVM()
            //    {
            //        Id = x.Id,
            //        NameAr = x.NameAr,
            //        NameEn = x.NameEn,
                    
            //    Cities = x.Cities.Select(v => new CityVM()
            //    {
            //        Id = v.Id,
            //        NameAr = v.NameAr,
            //        NameEn=v.NameEn,
            //    }).ToList(),
            //}).Skip(skip).Take((int)dto.PerPage).ToList();

            var pagingResult = new PagingViewModel();
            pagingResult.Data = countries;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = dto.Page;

            return pagingResult;
        }

        public async Task Create(CreateCountryDTO dto)
        {
            var CountryDTo = _mapper.Map<CreateCountryDTO, CountryEntity>(dto);

            //var createdCountry = new CountryEntity()
            //{
            //    NameAr = dto.NameAr,
            //    NameEn = dto.NameEn,
            //};

            await _Db.Countries.AddAsync(CountryDTo);
            _Db.SaveChanges();

           
        }

        public void Update(UpdateCountryDTO dto)
        {
            var country = _Db.Countries.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            country.NameAr = dto.NameAr;
            country.NameEn = dto.NameEn;
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
