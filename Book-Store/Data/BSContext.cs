using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Book_Store.Data.Configurations;
using Book_Store.Models;

namespace Book_Store.Data
{
    public class BSContext : IdentityDbContext
    {
        public BSContext(DbContextOptions<BSContext> options)
            : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
