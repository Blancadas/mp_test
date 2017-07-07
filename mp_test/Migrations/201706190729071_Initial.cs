namespace mp_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ServiceType_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceType_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.ServiceType_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Executors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        PackageType_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageTypes", t => t.PackageType_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.PackageType_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.PackageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PackageCathegory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageCathegories", t => t.PackageCathegory_Id)
                .Index(t => t.PackageCathegory_Id);
            
            CreateTable(
                "dbo.PackageCathegories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ServiceCathegory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceCathegories", t => t.ServiceCathegory_Id)
                .Index(t => t.ServiceCathegory_Id);
            
            CreateTable(
                "dbo.ServiceCathegories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderTrackings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Order_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.OrderStatus", t => t.Status_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PackageType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageTypes", t => t.PackageType_Id)
                .Index(t => t.PackageType_Id);
            
            CreateTable(
                "dbo.PaymentTrackings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayDateTime = c.DateTime(nullable: false),
                        Currency_Id = c.Int(),
                        Executor_Id = c.Int(),
                        PaymentType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .ForeignKey("dbo.Executors", t => t.Executor_Id)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentType_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.Executor_Id)
                .Index(t => t.PaymentType_Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceTrackings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Executor_Id = c.Int(),
                        Order_Id = c.Int(),
                        ServiceStatus_Id = c.Int(),
                        ServiceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Executors", t => t.Executor_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.ServiceStatus", t => t.ServiceStatus_Id)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceType_Id)
                .Index(t => t.Executor_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.ServiceStatus_Id)
                .Index(t => t.ServiceType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceTrackings", "ServiceType_Id", "dbo.ServiceTypes");
            DropForeignKey("dbo.ServiceTrackings", "ServiceStatus_Id", "dbo.ServiceStatus");
            DropForeignKey("dbo.ServiceTrackings", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ServiceTrackings", "Executor_Id", "dbo.Executors");
            DropForeignKey("dbo.PaymentTrackings", "PaymentType_Id", "dbo.PaymentTypes");
            DropForeignKey("dbo.PaymentTrackings", "Executor_Id", "dbo.Executors");
            DropForeignKey("dbo.PaymentTrackings", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Packages", "PackageType_Id", "dbo.PackageTypes");
            DropForeignKey("dbo.OrderTrackings", "Status_Id", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderTrackings", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ServiceType_Id", "dbo.ServiceTypes");
            DropForeignKey("dbo.ServiceTypes", "ServiceCathegory_Id", "dbo.ServiceCathegories");
            DropForeignKey("dbo.Executors", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Executors", "PackageType_Id", "dbo.PackageTypes");
            DropForeignKey("dbo.PackageTypes", "PackageCathegory_Id", "dbo.PackageCathegories");
            DropIndex("dbo.ServiceTrackings", new[] { "ServiceType_Id" });
            DropIndex("dbo.ServiceTrackings", new[] { "ServiceStatus_Id" });
            DropIndex("dbo.ServiceTrackings", new[] { "Order_Id" });
            DropIndex("dbo.ServiceTrackings", new[] { "Executor_Id" });
            DropIndex("dbo.PaymentTrackings", new[] { "PaymentType_Id" });
            DropIndex("dbo.PaymentTrackings", new[] { "Executor_Id" });
            DropIndex("dbo.PaymentTrackings", new[] { "Currency_Id" });
            DropIndex("dbo.Packages", new[] { "PackageType_Id" });
            DropIndex("dbo.OrderTrackings", new[] { "Status_Id" });
            DropIndex("dbo.OrderTrackings", new[] { "Order_Id" });
            DropIndex("dbo.ServiceTypes", new[] { "ServiceCathegory_Id" });
            DropIndex("dbo.PackageTypes", new[] { "PackageCathegory_Id" });
            DropIndex("dbo.Executors", new[] { "Order_Id" });
            DropIndex("dbo.Executors", new[] { "PackageType_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Orders", new[] { "ServiceType_Id" });
            DropTable("dbo.ServiceTrackings");
            DropTable("dbo.ServiceStatus");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.PaymentTrackings");
            DropTable("dbo.Packages");
            DropTable("dbo.OrderTrackings");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.ServiceCathegories");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.PackageCathegories");
            DropTable("dbo.PackageTypes");
            DropTable("dbo.Executors");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Currencies");
        }
    }
}
