using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_5.Core
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Data> Datas { get; set; }

        static DatabaseContext()
        {
            Database.SetInitializer(new DatabasInitializer());
        }

        public DatabaseContext() : base("DBConnection")
        {

        }
    }
}
