namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer0 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer2", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Customer2", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customer2", new[] { "AddressID" });
            DropIndex("dbo.Customer2", new[] { "UserId" });
            DropTable("dbo.Customer2");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.CustomerID);
            
            CreateIndex("dbo.Customer2", "UserId");
            CreateIndex("dbo.Customer2", "AddressID");
            AddForeignKey("dbo.Customer2", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customer2", "AddressID", "dbo.Addresses", "AddressID", cascadeDelete: true);
        }
    }
}
