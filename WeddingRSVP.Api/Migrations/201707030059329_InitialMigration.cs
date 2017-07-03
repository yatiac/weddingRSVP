namespace WeddingRSVP.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 6, unicode: false),
                        FamilyName = c.String(nullable: false, maxLength: 50, unicode: false),
                        AssignedSeats = c.Int(nullable: false),
                        ConfirmedSeats = c.Int(nullable: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Confirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seats");
        }
    }
}
