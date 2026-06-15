using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repository
{
    public class UserDAL : IUserDAL
    {

       private UserDbContext _dbcontext;
       public UserDAL(UserDbContext dbcontext)
       {
        _dbcontext = dbcontext;
       }


       public User RegisterUser(User user)
       {
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
            return user;

       }

     public User LoginUser(string Email)
        {
            return _dbcontext.Users .FirstOrDefault(x => x.Email == Email);

        }

        public bool ForgotPassword(string email)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.Email == email);
            return user != null;
        }

        public bool ResetPassword(string email, string newPassword)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.Email == email);

            if(user == null)
            {
                return false;

            }

            user.Password = newPassword; ;

            user.ChangedAt = DateTime.UtcNow;

            _dbcontext.SaveChanges();

            return true;

        }
    }
}

