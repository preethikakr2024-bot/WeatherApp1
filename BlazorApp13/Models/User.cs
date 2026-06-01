namespace BlazorApp13.Models
{
    public class User
    {
        public string Email { get; set; } = string.Empty;     // ✅ FIX
        public string Password { get; set; } = string.Empty;  // ✅ FIX
    }
}