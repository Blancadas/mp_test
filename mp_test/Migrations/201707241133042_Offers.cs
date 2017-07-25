namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Offers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Executor_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Executors", t => t.Executor_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Executor_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.OfferStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfferTrackings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Offer_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offers", t => t.Offer_Id)
                .ForeignKey("dbo.OfferStatus", t => t.Status_Id)
                .Index(t => t.Offer_Id)
                .Index(t => t.Status_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferTrackings", "Status_Id", "dbo.OfferStatus");
            DropForeignKey("dbo.OfferTrackings", "Offer_Id", "dbo.Offers");
            DropForeignKey("dbo.Offers", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Offers", "Executor_Id", "dbo.Executors");
            DropIndex("dbo.OfferTrackings", new[] { "Status_Id" });
            DropIndex("dbo.OfferTrackings", new[] { "Offer_Id" });
            DropIndex("dbo.Offers", new[] { "Order_Id" });
            DropIndex("dbo.Offers", new[] { "Executor_Id" });
            DropTable("dbo.OfferTrackings");
            DropTable("dbo.OfferStatus");
            DropTable("dbo.Offers");
        }
    }
}
