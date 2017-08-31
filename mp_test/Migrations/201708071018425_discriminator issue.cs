namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discriminatorissue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Offers", "OrderWithOffers_Id", c => c.Int());
            CreateIndex("dbo.Offers", "OrderWithOffers_Id");
            AddForeignKey("dbo.Offers", "OrderWithOffers_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "OrderWithOffers_Id", "dbo.Orders");
            DropIndex("dbo.Offers", new[] { "OrderWithOffers_Id" });
            DropColumn("dbo.Offers", "OrderWithOffers_Id");
            DropColumn("dbo.Orders", "Discriminator");
        }
    }
}
