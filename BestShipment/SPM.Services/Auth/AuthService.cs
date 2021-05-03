using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SPM.Core.DTO;
using SPM.Core.ViewModel;
using SPM.Data;
using SPM.Data.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Services.Auth
{
    public class AuthService : IAuthService
    {
        private ApplicationDbContext _DB;
        private SignInManager<SPM.Data.Model.UserEntity> _signInManager;
        private readonly IMapper _mapper;

        public AuthService(ApplicationDbContext DB , SignInManager<SPM.Data.Model.UserEntity> signInManager , IMapper mapper)
        {
            _DB = DB;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task SaveFcmToken(string fcm, string userId)
        {
            var user = await _DB.Users.SingleOrDefaultAsync(x => x.Id == userId && !x.IsDelete);
            user.FCMToken = fcm;
            _DB.Users.Update(user);
            await _DB.SaveChangesAsync();
        }

        public async Task<LoginResponseViewModel> LoginAsync(LoginDto dto)
        {
            var user =  _DB.Users.SingleOrDefault(x => x.UserName == dto.Username && !x.IsDelete);
            if(user == null)
            {
                throw new ("Invalid Username");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if(result.Succeeded)
            {
                user.FCMToken = dto.FCM;
                _DB.Users.Update(user);
                _DB.SaveChanges();

                var token = GenerateAccessToken(user);
                var response = new LoginResponseViewModel();
                response.Token = token;
                response.User = new UserViewModel()
                {
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserType = user.UserType
                };
                return response;
                //var usersVM = _mapper.Map<List<UserEntity>, List<UserViewModel>>();
            }
            return null;
        }

        public TokenViewModel GenerateAccessToken(SPM.Data.Model.UserEntity user)
        {
           // IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>(){
              new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            // new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName),
              new Claim(ClaimTypes.NameIdentifier, user.Id),
              new Claim("UserId", user.Id),
              new Claim(JwtRegisteredClaimNames.Email, user.Email),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("awieugfrugfkaegfikegufweuitgqguoef"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMonths(2);
            var accessToken = new JwtSecurityToken("https://localhost:44348/",
                "https://localhost:44348/",
                claims,
                expires: expires,
                signingCredentials: credentials
            );
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken);
            var response = new TokenViewModel();
            response.AccessToken = AccessToken;
            response.ExpireAt = expires;
            return response;
        }
    }


}
