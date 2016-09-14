namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaddressIDtopickupstableasforeignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "AddressID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pickups", "AddressID");
            AddForeignKey("dbo.Pickups", "AddressID", "dbo.Addresses", "AddressID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pickups", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Pickups", new[] { "AddressID" });
            DropColumn("dbo.Pickups", "AddressID");
        }
    }
}
