namespace Chapter_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceToDataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Data", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Data", "Price");
        }
    }
}
