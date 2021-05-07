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

namespace SPM.Services.Supplier
{
    public class SupplierService:ISupplierService
    {
        private ApplicationDbContext _Db;
        private readonly IMapper _mapper;

        public SupplierService(ApplicationDbContext db, IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
        }
        public PagingViewModel GetAll(PagingDto dto)
        {

            var pages = Math.Ceiling(_Db.Suppliers.Count() / dto.PerPage);

            if (dto.Page < 1 || dto.Page > pages)
            {
                dto.Page = 1;
            }

            var skip = (dto.Page - 1) * (int)dto.PerPage;
            var suppliers = _Db.Suppliers.Include(x => x.City).Skip(skip).Take((int)dto.PerPage).ToList();
            var suppliersVM = _mapper.Map<List<SupplierEntity>, List<SupplierVM>>(suppliers);


            /* var suppliers = _Db.Suppliers.Include(x => x.City).Select(x => new SupplierVM()
                             {
                                 Id = x.Id,
                                 Email = x.Email,
                                 Mobile = x.Mobile,
                                 CompanyName = x.CompanyName,
                                 Address = x.Address,
                                 City = new CityVM()
                                 {
                                     Id = x.Id,
                                     NameAr = x.City.NameAr,
                                     NameEn = x.City.NameEn
                                 },
                                 }).Skip(skip).Take(10).ToList();*/

            var pagingResult = new PagingViewModel();
            pagingResult.Data = suppliers;
            pagingResult.NumberOfPages = (int)pages;
            pagingResult.CureentPage = dto.Page;

            return pagingResult;
        }

        public async Task Create(CreateSupplierDTO dto)
        {
            var SupplierDTo = _mapper.Map<CreateSupplierDTO, SupplierEntity>(dto);

            //var createdCountry = new CountryEntity()
            //{
            //    NameAr = dto.NameAr,
            //    NameEn = dto.NameEn,
            //};

            await _Db.Suppliers.AddAsync(SupplierDTo);
            _Db.SaveChanges();
        }

        public void Update(UpdateSupplierDTO dto)
        {
            var supplier = _Db.Suppliers.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            supplier.Email = dto.Email;
            supplier.Mobile = dto.Mobile;
            supplier.CompanyName = dto.CompanyName;
            supplier.Address = dto.Address;
            supplier.CityId = dto.CityId;
            _Db.Suppliers.Update(supplier);
            _Db.SaveChanges();
        }
        public void Delete(int id)
        {
            var deletedSupplier = _Db.Suppliers.SingleOrDefault(x => x.Id == id);
            deletedSupplier.IsDelete = true;
            _Db.Suppliers.Update(deletedSupplier);
            _Db.SaveChanges();
        }

    }
}
