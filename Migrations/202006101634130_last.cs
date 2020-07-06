namespace ProjektMAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CinemaHalls", "NumberOfSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CinemaHalls", "NumberOfSeats", c => c.Int(nullable: false));
        }
    }
}
