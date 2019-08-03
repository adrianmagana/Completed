using Microsoft.EntityFrameworkCore;

namespace PcPartsSite.Models
{
    public class PcPartsDataContext : DbContext
    {


        public PcPartsDataContext(DbContextOptions<PcPartsDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<SubCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.SubCategories);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<FilterItem> FilterItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
