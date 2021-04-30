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

namespace SPM.Service.Country
{
    public class CountryServices: ICountryServies
    {
        private ApplicationDbContext _Db;


        public CountryServices(ApplicationDbContext db)
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

            var posts = _Db.Countries.Include(x => x.Cities).Select(x => new CountryVM()
                {
                    Id = x.Id,
                    NameAr = x.NameAr,
                    NameEn=x.NameEn,
                  
                    
                    Cities = x.Cities.Select(v => new CityVM()
                    {
                        //vm City
                    }).ToList()
                }).Skip(skip).Take(10).ToList();

            var pagingResult = new PagingViewModel();
            pagingResult.Data = posts;
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
            };

            _Db.Countries.Add(createdCountry);
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
            var deletedPost = _Db.Countries.SingleOrDefault(x => x.Id == id);
            deletedPost.IsDelete = true;
            _Db.Countries.Update(deletedPost);
            _Db.SaveChanges();
        }

    }
}
