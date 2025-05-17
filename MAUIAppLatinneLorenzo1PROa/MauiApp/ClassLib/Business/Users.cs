using ClassLib.Business.Entities;
using ClassLib.Data;
using ClassLib.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Business
{
    public static class Users
    {
        public static SelectResult GetUsers()
        {
            UserData userData = new UserData();
            SelectResult result = userData.Select();
            return result;
        }

        public static InsertResult Add(string username, string password, string email)
        {
            User user = new User();
            user.Username = username;
            user.Password = password;
            user.Email = email;
            UserData userData = new UserData();
            InsertResult result = userData.Insert(user);
            return result;
        }
    }
}
