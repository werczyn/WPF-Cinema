namespace ProjektMAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(maxLength: 450));
            CreateIndex("dbo.Movies", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "Title" });
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
