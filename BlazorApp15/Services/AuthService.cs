using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BlazorApp15.Models;

namespace BlazorApp15.Services
{
    public class AuthService
    {
        public event Action? OnChange;
        private void Notify() => OnChange?.Invoke();

        public List<UserModel> Users { get; } = new List<UserModel>();

        public UserModel? CurrentUser { get; private set; }

        // 🔐 HASH FUNCTION (ADDED)
        private string ComputeHash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(bytes);
            }
        }

        // 🟢 REGISTER (STORE HASH INSTEAD OF PASSWORD)
        public bool Register(string username, string password)
        {
            if (Users.Any(u => u.Username == username))
                return false;

            Users.Add(new UserModel
            {
                Username = username,
                Password = ComputeHash(password) // ✅ HASH STORED
            });

            Notify();
            return true;
        }

        // 🟢 LOGIN (COMPARE HASH)
        public bool Login(string email, string password)
        {
            string hashedPassword = ComputeHash(password);

            var user = Users.FirstOrDefault(u =>
                u.Username == email && u.Password == hashedPassword);

            if (user == null)
                return false;

            CurrentUser = user;
            Notify();
            return true;
        }

        public void Logout()
        {
            CurrentUser = null;
            Notify();
        }

        public bool IsLoggedIn => CurrentUser != null;

        public void SaveFavorites(string city, string weather, List<string> forecast)
        {
            if (CurrentUser != null)
            {
                CurrentUser.FavoriteCity = city;
                CurrentUser.FavoriteWeather = weather;
                CurrentUser.FiveDayForecast = forecast;

                Notify();
            }
        }
    }
}