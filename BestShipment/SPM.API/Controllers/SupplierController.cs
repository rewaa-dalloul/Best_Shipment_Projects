using Microsoft.AspNetCore.Mvc;
using SPM.Core.DTO;
using SPM.Services.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPM.API.Controllers
{
    public class SupplierController : BaseController
    {
        private ISupplierService _SupplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _SupplierService = supplierService;
        }

        [HttpGet]
        public IActionResult GetAll(PagingDto dto)
        {
            var supplier = _SupplierService.GetAll(dto);
            return Ok(GetRespons(supplier, "Done"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateSupplierDTO dto)
        {
            await _SupplierService.Create(dto);
            return Ok(GetRespons());
        }

        [HttpPut]
        public IActionResult Update([FromForm] UpdateSupplierDTO dto)
        {
            _SupplierService.Update(dto);
            return Ok(GetRespons());
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _SupplierService.Delete(id);
            return Ok(GetRespons(null, "Done"));
        }
    }
}
