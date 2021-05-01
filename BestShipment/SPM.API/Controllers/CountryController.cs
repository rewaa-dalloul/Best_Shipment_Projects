using Microsoft.AspNetCore.Mvc;
using SPM.Core.DTO;
using SPM.Services.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPM.API.Controllers
{
    public class CountryController : BaseController
    {
        private ICountryService _CountryService;

        public CountryController(ICountryService countryService)
        {
            _CountryService = countryService;
        }

        [HttpGet]
        public IActionResult GetAll(PagingDto dto)
        {
            var Country = _CountryService.GetAll(dto);
            return Ok(GetRespons(Country, "Done"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateCountryDTO dto)
        {
            await _CountryService.Create(dto);
            return Ok(GetRespons());
        }

        [HttpPut]
        public IActionResult Update([FromForm] UpdateCountryDTO dto)
        {
            _CountryService.Update(dto);
            return Ok(GetRespons());
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _CountryService.Delete(id);
            return Ok(GetRespons(null, "Done"));
        }
    }
}
