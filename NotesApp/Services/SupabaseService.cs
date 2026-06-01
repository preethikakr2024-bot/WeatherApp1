   namespace NotesApp.Services
   {
       public class SupabaseService
       {
           private readonly Supabase.Client _client;

           public SupabaseService(SupabaseConfig config)
           {
               _client = new Supabase.Client(config.Url, config.AnonKey);
           }

           public async Task InitializeAsync()
           {
               await _client.InitializeAsync();
           }

           public Supabase.Client GetClient()
           {
               return _client;
           }
       }
   }
   