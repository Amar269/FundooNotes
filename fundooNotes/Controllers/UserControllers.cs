using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.User;
using Microsoft.AspNetCore.Authorization;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace fundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserBLL _userBLL;

        public UserControllers(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpPost]
        public async Task<UserResponse> RegsiterUser(RegisterUserRequest userRequest)
        {
            return await _userBLL.RegisterUser(userRequest);
        }

        [HttpPost("Login")]

        public async Task<TokenResponse> LoginUser(LoginRequest loginRequest)
        {
            return await _userBLL.LoginUser(loginRequest);
        }

        [Authorize]
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("JWT Authentication Working Successfully");
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var result = await _userBLL.ForgotPassword(email);
            return Ok( new {
                Success = result,
                Message = "Password reset email sent successfully"

            });

        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email,ResetPasswordRequest request)
        {
            var result = await _userBLL.ResetPassword(email,request);

            return Ok(new
            {
                Success = result,
                Message = "Password reset successful"
            });
        }



    }
}
