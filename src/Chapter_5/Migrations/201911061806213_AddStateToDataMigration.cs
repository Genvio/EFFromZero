namespace Chapter_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateToDataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Data", "State", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Data", "State");
        }
    }
}
