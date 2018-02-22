namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thread : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(),
                        RecepientId = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Messages", "Thread_Id", c => c.Int());
            CreateIndex("dbo.Messages", "Thread_Id");
            AddForeignKey("dbo.Messages", "Thread_Id", "dbo.Threads", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Thread_Id", "dbo.Threads");
            DropIndex("dbo.Messages", new[] { "Thread_Id" });
            DropColumn("dbo.Messages", "Thread_Id");
            DropTable("dbo.Threads");
        }
    }
}
