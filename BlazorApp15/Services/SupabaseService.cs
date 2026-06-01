using Supabase;
using Supabase.Gotrue;

namespace BlazorApp15.Services
{
    public class SupabaseService
    {
        private Supabase.Client? _client;
        private const string SupabaseUrl = "https://uaijvcuebosrvpqhefum.supabase.co";
        private const string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InVhaWp2Y3VlYm9zcnZwcWhlZnVtIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzkyNTA3NTksImV4cCI6MjA5NDgyNjc1OX0.9zY1ZO63W25Hz0ewPR-qJyap0m14gl6gcFGJpKGUzBU";

        public string FavoriteCity { get; set; } = string.Empty;
        public string FavoriteWeather { get; set; } = string.Empty;

        public async Task Initialize()
        {
            if (_client != null) return;
            var options = new SupabaseOptions { AutoConnectRealtime = false };
            _client = new Supabase.Client(SupabaseUrl, SupabaseKey, options);
            await _client.InitializeAsync();
        }

        public async Task<Session?> Login(string email, string password)
        {
            await Initialize();
            var response = await _client!.Auth.SignInWithPassword(email, password);
            return response;
        }

        public async Task Logout()
        {
            if (_client == null) return;
            await _client.Auth.SignOut();
            FavoriteCity = string.Empty;
            FavoriteWeather = string.Empty;
        }

        public User? GetUser() => _client?.Auth.CurrentUser;

        public bool IsLoggedIn() => _client?.Auth.CurrentSession != null;
    }
}
