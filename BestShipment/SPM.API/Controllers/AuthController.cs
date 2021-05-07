using Microsoft.AspNetCore.Mvc;
using SPM.Core.DTO;
using SPM.Services.Auth;
using SPM.Services.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPM.API.Controllers
{
    public class AuthController : BaseController
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            var auth = await _authService.LoginAsync(dto);
            return Ok(GetRespons(auth));
        }


        [HttpPost]
        public async Task<IActionResult> AddFCM([FromForm] string token , string userId)
        {
            await _authService.SaveFcmToken(token , userId);
            return Ok(GetRespons());
        }

       
    }
}
