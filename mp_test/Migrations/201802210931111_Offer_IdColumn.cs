namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Offer_IdColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Offer_Id", c => c.Int());
            CreateIndex("dbo.Threads", "Offer_Id");
            AddForeignKey("dbo.Threads", "Offer_Id", "dbo.Offers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "Offer_Id", "dbo.Offers");
            DropIndex("dbo.Threads", new[] { "Offer_Id" });
            DropColumn("dbo.Threads", "Offer_Id");
        }
    }
}
