namespace Chapter_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeToDataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Data", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Data", "Age");
        }
    }
}
