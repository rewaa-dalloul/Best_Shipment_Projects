using Microsoft.AspNetCore.Mvc;
using SPM.Core.DTO;
using SPM.Services.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPM.API.Controllers
{
    public class CityController : BaseController
    {
        private ICityService _cityservice;
        public CityController(ICityService cityservice)
        {
            _cityservice = cityservice;
        }
        [HttpGet]
        public IActionResult GetAllPosts(int page = 1)
        {
            var posts = _cityservice.GetAll(page);
            return Ok(GetRespons(posts, "Done"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateCityDto dto)
        {
            await _cityservice.Create(dto);
            return Ok(GetRespons());
        }

        [HttpPut]
        public IActionResult Update([FromForm] UpdateCityDto dto)
        {
            _cityservice.Update(dto);
            return Ok(GetRespons());
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _cityservice.Delete(id);
            return Ok(GetRespons(null, "Done"));
        }
    }
}
