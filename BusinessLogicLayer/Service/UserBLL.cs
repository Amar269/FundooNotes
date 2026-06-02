using BCrypt.Net;
using BusinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using ModelLayer.DTO.User;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _UserDAl;

        public UserBLL(IUserDAL userDAl)
        {
            _UserDAl = userDAl;
        }

       public UserResponse RegisterUser(RegisterUserRequest userRequest)
       {
            User user = new User()
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
                CreatedAt = DateTime.UtcNow,
                ChangedAt = DateTime.UtcNow
            };
            user = _UserDAl.RegisterUser(user);

            UserResponse userResponse = new UserResponse()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return userResponse;


        }

    }
}
