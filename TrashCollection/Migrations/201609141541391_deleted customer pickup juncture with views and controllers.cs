namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedcustomerpickupjuncturewithviewsandcontrollers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerPickupJunctures", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CustomerPickupJunctures", "PickupID", "dbo.Pickups");
            DropIndex("dbo.CustomerPickupJunctures", new[] { "CustomerID" });
            DropIndex("dbo.CustomerPickupJunctures", new[] { "PickupID" });
            DropTable("dbo.CustomerPickupJunctures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerPickupJunctures",
                c => new
                    {
                        CustomerPickupJunctureID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PickupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerPickupJunctureID);
            
            CreateIndex("dbo.CustomerPickupJunctures", "PickupID");
            CreateIndex("dbo.CustomerPickupJunctures", "CustomerID");
            AddForeignKey("dbo.CustomerPickupJunctures", "PickupID", "dbo.Pickups", "PickupID", cascadeDelete: true);
            AddForeignKey("dbo.CustomerPickupJunctures", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
    }
}
