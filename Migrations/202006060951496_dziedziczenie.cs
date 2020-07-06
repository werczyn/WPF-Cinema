namespace ProjektMAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dziedziczenie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Director", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Movies", "ActingDirector_IdPerson", c => c.Int());
            CreateIndex("dbo.Movies", "ActingDirector_IdPerson");
            AddForeignKey("dbo.Movies", "ActingDirector_IdPerson", "dbo.Director", "IdPerson");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ActingDirector_IdPerson", "dbo.Director");
            DropIndex("dbo.Movies", new[] { "ActingDirector_IdPerson" });
            DropColumn("dbo.Movies", "ActingDirector_IdPerson");
            DropColumn("dbo.Director", "Discriminator");
        }
    }
}
