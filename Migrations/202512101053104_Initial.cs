namespace InsuranceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        DateOfBirth = c.DateTime(),
                        CarYear = c.Int(nullable: false),
                        CarMake = c.String(),
                        CarModel = c.String(),
                        DUI = c.Boolean(nullable: false),
                        SpeedingTickets = c.Int(nullable: false),
                        FullCoverage = c.Boolean(nullable: false),
                        Quote = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Insurees");
        }
    }
}
