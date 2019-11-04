using System.Data.Entity;

namespace Chapter_4.Core
{
    public class SimpleDataContext : DbContext
    {
        public DbSet<SimpleData> SimpleDatas { get; set; }

        static SimpleDataContext()
        {
            Database.SetInitializer(new SimpleDataContextInitializer());
        }

        public SimpleDataContext() : base("DBConnection")
        {

        }
    }
}
