namespace BPS0026_MVC_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Item = c.String(maxLength: 50),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Orders");
        }
    }
}
