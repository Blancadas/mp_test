namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Executors", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Executors", "Rating");
        }
    }
}
