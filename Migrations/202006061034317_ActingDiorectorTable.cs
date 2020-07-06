namespace ProjektMAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActingDiorectorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActingDiorector",
                c => new
                    {
                        IdPerson = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPerson)
                .ForeignKey("dbo.Director", t => t.IdPerson)
                .Index(t => t.IdPerson);
            
            DropColumn("dbo.Director", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Director", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.ActingDiorector", "IdPerson", "dbo.Director");
            DropIndex("dbo.ActingDiorector", new[] { "IdPerson" });
            DropTable("dbo.ActingDiorector");
        }
    }
}
