using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.User;
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
        public UserResponse RegsiterUser(RegisterUserRequest userRequest)
        {
            return _userBLL.RegisterUser(userRequest);
        }
        

    }
}
