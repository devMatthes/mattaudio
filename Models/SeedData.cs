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
                        Title = "Blabla",
                        Duration = TimeSpan.Parse("00:02:45"),
                        Genre = "Rap"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}