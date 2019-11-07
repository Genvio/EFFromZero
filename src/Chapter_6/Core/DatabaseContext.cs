using System.Data.Entity;

namespace Chapter_6.Core
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<BigCat> BigCats { get; set; }

        public DbSet<Slime> Slimes { get; set; }
        public DbSet<ColoredSlime> ColoredSlimes { get; set; }

        public DatabaseContext() : base("DBConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slime>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Slimes");
            });

            modelBuilder.Entity<ColoredSlime>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ColoredSlimes");
            });
        }
    }
}
