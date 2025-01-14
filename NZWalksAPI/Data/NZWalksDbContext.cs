using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> walks { get; set; }  

        public DbSet<Difficulty> difficulty { get; set; }
    }
}
