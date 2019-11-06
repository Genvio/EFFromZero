using Chapter_5.Migrations;
using System;
using System.Data.Entity;

namespace Chapter_5.Core
{
    
    class DatabasInitializer : MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>
    {
        //enable automatic migration without droping db
    }
}
