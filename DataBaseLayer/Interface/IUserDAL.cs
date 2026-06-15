using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public interface IUserDAL
    {
        User RegisterUser(User user);

        User LoginUser(string Email);

        bool ForgotPassword(string email);

        bool ResetPassword(string email, string newPassword);







    }
}
