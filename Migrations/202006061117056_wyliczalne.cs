namespace ProjektMAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wyliczalne : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Actor", "NoumberOfActed");
            DropColumn("dbo.Director", "NumberOfDirectedFilms");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Director", "NumberOfDirectedFilms", c => c.Int(nullable: false));
            AddColumn("dbo.Actor", "NoumberOfActed", c => c.Int(nullable: false));
        }
    }
}
