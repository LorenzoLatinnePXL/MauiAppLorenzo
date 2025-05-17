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

        public static bool Login(string username, string password)
        {
            UserData userData = new UserData();
            CountResult result = userData.Login(username, password);
            return result.Count == 1;
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

        public static bool CheckIfUsernameIsTaken(string username)
        {
            UserData userData = new UserData();
            return userData.SelectCountUsername(username).Count > 0;
        }

        public static bool CheckIfEmailIsTaken(string email)
        {
            UserData userData = new UserData();
            return userData.SelectCountEmail(email).Count > 0;
        }

        public static bool CheckEmailFormat(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            int atIndex = email.IndexOf('@');
            if (atIndex <= 0 || atIndex == email.Length - 1) return false;

            string domainPart = email[(atIndex + 1)..];
            return domainPart.Contains('.') && !domainPart.Contains("..") && !domainPart.Contains(" ");
        }
    }
}
