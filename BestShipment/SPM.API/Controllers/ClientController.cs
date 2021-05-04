using Microsoft.AspNetCore.Mvc;
using SPM.Core.DTO;
using SPM.Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPM.API.Controllers
{
    public class ClientController : BaseController
    {
        private IClientService _clientservice;
        public ClientController(IClientService clientservice)
        {
            _clientservice = clientservice;
        }
        [HttpGet]
        public IActionResult GetAll(PagingDto dto)
        {
            var clients = _clientservice.GetAll(dto);
            return Ok(GetRespons(clients, "Done"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateClientDTO dto)
        {
            await _clientservice.Create(dto);
            return Ok(GetRespons());
        }

        [HttpPut]
        public IActionResult Update([FromForm] UpdateClientDto dto)
        {
            _clientservice.Update(dto);
            return Ok(GetRespons());
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _clientservice.Delete(id);
            return Ok(GetRespons(null, "Done"));
        }
    }
}
