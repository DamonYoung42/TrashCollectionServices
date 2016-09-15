namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKupdatetoaddressemployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "AddressID" });
            AddColumn("dbo.Addresses", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Addresses", "CustomerID");
            CreateIndex("dbo.Employees", "UserId");
            AddForeignKey("dbo.Addresses", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "AddressID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "AddressID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Addresses", new[] { "CustomerID" });
            DropColumn("dbo.Employees", "UserId");
            DropColumn("dbo.Addresses", "CustomerID");
            CreateIndex("dbo.Customers", "AddressID");
            AddForeignKey("dbo.Customers", "AddressID", "dbo.Addresses", "AddressID", cascadeDelete: true);
        }
    }
}
