using Microsoft.AspNetCore.Mvc;
using SPM.Core.DTO;
using SPM.Service.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPM.API.Controllers
{
    public class CountryController : BaseController
    {
        private ICountryServies _CountrySerives;

        public CountryController(ICountryServies CountrySerives)
        {
            _CountrySerives = CountrySerives;
        }

        [HttpGet]
        public IActionResult GetAllPosts(int page = 1)
        {
            var Countries = _CountrySerives.GetAll(page);
            return Ok(GetRespons(Countries, "Done"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateCountryDTO dto)
        {
            await _CountrySerives.Create(dto);
            return Ok(GetRespons());
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCountryDTO entity)
        {
            _CountrySerives.Update(entity);
            return Ok("Done");
        }


        [HttpDelete]

        public IActionResult Delete(int id)
        {
            _CountrySerives.Delete(id);

            return Ok(GetRespons(null, "Done"));
        }
    }
}
