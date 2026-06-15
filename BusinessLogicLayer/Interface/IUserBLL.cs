using ModelLayer.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IUserBLL
    {
        Task<UserResponse> RegisterUser(RegisterUserRequest userRequest);

        Task<TokenResponse> LoginUser(LoginRequest loginRequest);

        Task <bool> ForgotPassword(string email);

        Task <bool> ResetPassword(string email, ResetPasswordRequest request);





    }
}
