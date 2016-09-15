namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpickupaddressjuncturetableandremovedallclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickupAddressJuncs",
                c => new
                    {
                        PickupAddressJuncID = c.Int(nullable: false, identity: true),
                        AddressID = c.Int(nullable: false),
                        PickupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PickupAddressJuncID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.Pickups", t => t.PickupID, cascadeDelete: true)
                .Index(t => t.AddressID)
                .Index(t => t.PickupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickupAddressJuncs", "PickupID", "dbo.Pickups");
            DropForeignKey("dbo.PickupAddressJuncs", "AddressID", "dbo.Addresses");
            DropIndex("dbo.PickupAddressJuncs", new[] { "PickupID" });
            DropIndex("dbo.PickupAddressJuncs", new[] { "AddressID" });
            DropTable("dbo.PickupAddressJuncs");
        }
    }
}
