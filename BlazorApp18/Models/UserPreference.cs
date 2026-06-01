namespace BlazorApp18.Models
{
    public class UserPreference
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public string FavoriteCity { get; set; } = string.Empty;
        public string FavoriteWeather { get; set; } = string.Empty;
    }
}