namespace ProjektMAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MovieDescription", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "MovieDescription", c => c.String());
        }
    }
}
