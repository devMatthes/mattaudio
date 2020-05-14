using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mattaudio.Data;
using System;
using System.Linq;

namespace mattaudio.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new mattaudioContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<mattaudioContext>>()))
            {
                if (context.Track.Any())
                {
                    return;
                }
                context.Track.AddRange(
                    new Track
                    {
                        Title = "PORTOFINO",
                        Artist = "TUZZA Globale"
                    },
                    
                    new Track
                    {
                        Title = "Moana",
                        Artist = "G-Eazy, Jack Harlow"
                    },

                    new Track
                    {
                        Title = "0 To 100 / The Catch Up",
                        Artist = "Drake"
                    },

                    new Track
                    {
                        Title = "JoHn Muir",
                        Artist = "Schoolboy Q"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}