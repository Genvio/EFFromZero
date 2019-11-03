using Chapter_3.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_3.Core
{
    public class SimpleContext : DbContext
    {
        public DbSet<Data> Datas { get; set; }

        public SimpleContext() : base("DBConnection2") { }
    }
}
