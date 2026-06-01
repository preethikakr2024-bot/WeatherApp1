   using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
   using Microsoft.Extensions.DependencyInjection;
   using NotesApp.Services;
   using System;
   using System.Net.Http;
   using System.Threading.Tasks;

   namespace NotesApp
   {
       public class Program
       {
           public static async Task Main(string[] args)
           {
               var builder = WebAssemblyHostBuilder.CreateDefault(args);
               builder.RootComponents.Add<App>("#app");

               // Configure Supabase
               var supabaseConfig = new SupabaseConfig
               {
                   Url = "YOUR_SUPABASE_URL", // Replace with your Supabase URL
                   AnonKey = "YOUR_ANON_KEY"   // Replace with your Supabase anon key
               };

               builder.Services.AddSingleton(supabaseConfig);
               builder.Services.AddSingleton<SupabaseService>();
               builder.Services.AddSingleton<NotesService>();

               await builder.Build().RunAsync();
           }
       }
   }
   