namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SourceAddress", c => c.String());
            AddColumn("dbo.Orders", "DestinationAddress", c => c.String());
            AddColumn("dbo.Orders", "ContactTitle", c => c.String());
            AddColumn("dbo.Orders", "ContactEmail", c => c.String());
            AddColumn("dbo.Orders", "ContactPhoneNumber", c => c.String());
            AddColumn("dbo.Orders", "OrderCost", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderCurrency_Id", c => c.Int());
            AlterColumn("dbo.Orders", "OrderDateTime", c => c.DateTime());
            AlterColumn("dbo.Orders", "OrderDueDateTime", c => c.DateTime());
            CreateIndex("dbo.Orders", "OrderCurrency_Id");
            AddForeignKey("dbo.Orders", "OrderCurrency_Id", "dbo.Currencies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderCurrency_Id", "dbo.Currencies");
            DropIndex("dbo.Orders", new[] { "OrderCurrency_Id" });
            AlterColumn("dbo.Orders", "OrderDueDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "OrderDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderCurrency_Id");
            DropColumn("dbo.Orders", "OrderCost");
            DropColumn("dbo.Orders", "ContactPhoneNumber");
            DropColumn("dbo.Orders", "ContactEmail");
            DropColumn("dbo.Orders", "ContactTitle");
            DropColumn("dbo.Orders", "DestinationAddress");
            DropColumn("dbo.Orders", "SourceAddress");
        }
    }
}
