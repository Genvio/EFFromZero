namespace Chapter_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToDataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Data", "Adress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Data", "Adress");
        }
    }
}
