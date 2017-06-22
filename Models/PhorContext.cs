using Microsoft.EntityFrameworkCore;

namespace PhorChanAPI.Models
{
    public class PhorContext : DbContext
    {
        public PhorContext(DbContextOptions<PhorContext> options)
            : base(options)
            {             
            }

            public DbSet<PhorItem> PhorItems { get; set; }
    }
}