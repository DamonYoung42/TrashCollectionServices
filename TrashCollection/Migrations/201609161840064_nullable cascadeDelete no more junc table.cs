namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablecascadeDeletenomorejunctable : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.Pickups", "AddressID", c => c.Int(nullable: true));
            CreateIndex("dbo.Pickups", "AddressID");
            AddForeignKey("dbo.Pickups", "AddressID", "dbo.Addresses", "AddressID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PickupAddressJuncs",
                c => new
                    {
                        PickupAddressJuncID = c.Int(nullable: false, identity: true),
                        AddressID = c.Int(nullable: false),
                        PickupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PickupAddressJuncID);
            
            DropForeignKey("dbo.Pickups", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Pickups", new[] { "AddressID" });
            DropColumn("dbo.Pickups", "AddressID");
            CreateIndex("dbo.PickupAddressJuncs", "PickupID");
            CreateIndex("dbo.PickupAddressJuncs", "AddressID");
            AddForeignKey("dbo.PickupAddressJuncs", "PickupID", "dbo.Pickups", "PickupID", cascadeDelete: true);
            AddForeignKey("dbo.PickupAddressJuncs", "AddressID", "dbo.Addresses", "AddressID", cascadeDelete: true);
        }
    }
}
