namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer2",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Role = c.String(),
                        EmailAddress = c.String(),
                        AddressID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AddressID)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer2", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customer2", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Customer2", new[] { "UserId" });
            DropIndex("dbo.Customer2", new[] { "AddressID" });
            DropTable("dbo.Customer2");
        }
    }
}
