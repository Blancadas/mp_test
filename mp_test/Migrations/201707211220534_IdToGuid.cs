namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdToGuid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserId", c => c.String());
            AlterColumn("dbo.Executors", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Executors", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "UserId", c => c.Int(nullable: false));
        }
    }
}
