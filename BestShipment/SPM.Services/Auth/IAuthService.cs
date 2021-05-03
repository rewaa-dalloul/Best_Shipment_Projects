using SPM.Core.DTO;
using SPM.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.Services.Auth
{
    public interface IAuthService
    {
        Task SaveFcmToken(string fcm, string userId);
        Task<LoginResponseViewModel> LoginAsync(LoginDto dto);
        TokenViewModel GenerateAccessToken(SPM.Data.Model.UserEntity user);
    }
}
