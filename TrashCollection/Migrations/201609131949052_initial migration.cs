namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        CityID = c.Int(nullable: false),
                        ZipID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Zipcodes", t => t.ZipID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.ZipID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        StateID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.States", t => t.StateID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.String(nullable: false, maxLength: 128),
                        StateName = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Zipcodes",
                c => new
                    {
                        ZipID = c.Int(nullable: false, identity: true),
                        ZipcodeName = c.String(),
                    })
                .PrimaryKey(t => t.ZipID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Role = c.String(),
                        EmailAddress = c.String(),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.CustomerPickupJunctures",
                c => new
                    {
                        CustomerPickupJunctureID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PickupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerPickupJunctureID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Pickups", t => t.PickupID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.PickupID);
            
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        PickupID = c.Int(nullable: false, identity: true),
                        PickupDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PickupID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        SubscriptionID = c.Int(nullable: false, identity: true),
                        PickupID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AutomaticPayments = c.Boolean(nullable: false),
                        PaperlessBilling = c.Boolean(nullable: false),
                        PaymentMethod = c.String(),
                    })
                .PrimaryKey(t => t.SubscriptionID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Pickups", t => t.PickupID, cascadeDelete: true)
                .Index(t => t.PickupID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscriptions", "PickupID", "dbo.Pickups");
            DropForeignKey("dbo.Subscriptions", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CustomerPickupJunctures", "PickupID", "dbo.Pickups");
            DropForeignKey("dbo.Pickups", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.CustomerPickupJunctures", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "ZipID", "dbo.Zipcodes");
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "StateID", "dbo.States");
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Subscriptions", new[] { "CustomerID" });
            DropIndex("dbo.Subscriptions", new[] { "PickupID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pickups", new[] { "EmployeeID" });
            DropIndex("dbo.CustomerPickupJunctures", new[] { "PickupID" });
            DropIndex("dbo.CustomerPickupJunctures", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "AddressID" });
            DropIndex("dbo.States", new[] { "CountryID" });
            DropIndex("dbo.Cities", new[] { "StateID" });
            DropIndex("dbo.Addresses", new[] { "ZipID" });
            DropIndex("dbo.Addresses", new[] { "CityID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Employees");
            DropTable("dbo.Pickups");
            DropTable("dbo.CustomerPickupJunctures");
            DropTable("dbo.Customers");
            DropTable("dbo.Zipcodes");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
        }
    }
}
