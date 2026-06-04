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
            return _dbcontext.Users
                     .FirstOrDefault(x => x.Email == Email);

        }
       








    }
}
