using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UGIM.Server.Models;

namespace UGIM.Server.Services.Abstract
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);

        Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token);

        Task<UserManagerResponse> ForgetPasswordAsync(string email);

        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}
