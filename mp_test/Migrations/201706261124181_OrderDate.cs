namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderDueDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderDueDateTime");
            DropColumn("dbo.Orders", "OrderDateTime");
        }
    }
}
