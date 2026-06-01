using note.Models;
using Supabase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesApp.Services
{
    public class NotesService
    {
        private readonly Supabase.Client _client;

        public NotesService(SupabaseService supabaseService)
        {
            _client = supabaseService.GetClient();
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            var notes = await _client.From<note>().Get();
            return notes.Models;
        }
    }
}
