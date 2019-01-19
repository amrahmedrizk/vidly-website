namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmovietable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        releasedate = c.DateTime(nullable: false),
                        dateadded = c.DateTime(nullable: false),
                        numberinstock = c.Int(nullable: false),
                        genraid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.genras", t => t.genraid, cascadeDelete: true)
                .Index(t => t.genraid);
            
            CreateTable(
                "dbo.genras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.movies", "genraid", "dbo.genras");
            DropIndex("dbo.movies", new[] { "genraid" });
            DropTable("dbo.genras");
            DropTable("dbo.movies");
        }
    }
}
