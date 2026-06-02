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
        UserResponse RegisterUser(RegisterUserRequest userRequest);

    }
}
