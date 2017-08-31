namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDiscriminator : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "OrderWithOffers_Id", "dbo.Orders");
            DropIndex("dbo.Offers", new[] { "OrderWithOffers_Id" });
            DropColumn("dbo.Orders", "Discriminator");
            DropColumn("dbo.Offers", "OrderWithOffers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offers", "OrderWithOffers_Id", c => c.Int());
            AddColumn("dbo.Orders", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Offers", "OrderWithOffers_Id");
            AddForeignKey("dbo.Offers", "OrderWithOffers_Id", "dbo.Orders", "Id");
        }
    }
}
