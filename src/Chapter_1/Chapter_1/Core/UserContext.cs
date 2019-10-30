using System.Data.Entity;

namespace Chapter_1.Core
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base("DbConnection") { }
    }
}
