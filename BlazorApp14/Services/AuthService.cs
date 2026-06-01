using BlazorApp14.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp14.Services
{
    public class AuthService
    {
        private readonly List<UserModel> users;

        public AuthService()
        {
            users = new List<UserModel>();
        }

        public bool Register(UserModel user)
        {
            if (users.Any(u => u.Username == user.Username))
                return false;

            users.Add(user);
            return true;
        }

        public bool Login(LoginModel login)
        {
            return users.Any(u =>
                u.Username == login.Username &&
                u.Password == login.Password);
        }
    }
}