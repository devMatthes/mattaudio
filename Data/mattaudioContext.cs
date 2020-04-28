using Microsoft.EntityFrameworkCore;
using mattaudio.Models;

namespace mattaudio.Data
{
    public class mattaudioContext : DbContext
    {
        public mattaudioContext (
            DbContextOptions<mattaudioContext> options)
            : base(options)
        {
        }
        public DbSet<mattaudio.Models.Track> Track { get; set; }
    }
}