namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedZipIDtoEmployeesmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ZipID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "ZipID");
            AddForeignKey("dbo.Employees", "ZipID", "dbo.Zipcodes", "ZipID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ZipID", "dbo.Zipcodes");
            DropIndex("dbo.Employees", new[] { "ZipID" });
            DropColumn("dbo.Employees", "ZipID");
        }
    }
}
