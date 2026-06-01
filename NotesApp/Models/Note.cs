namespace note.Models
{
    public class Note
    {
        public int Id { get; set; }  // Assuming you have an id column in Supabase table
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
