namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrentalstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.rentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rentdate = c.DateTime(nullable: false),
                        returndate = c.DateTime(),
                        movieid = c.Int(nullable: false),
                        customerid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.customers", t => t.customerid, cascadeDelete: true)
                .ForeignKey("dbo.movies", t => t.movieid, cascadeDelete: true)
                .Index(t => t.movieid)
                .Index(t => t.customerid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.rentals", "movieid", "dbo.movies");
            DropForeignKey("dbo.rentals", "customerid", "dbo.customers");
            DropIndex("dbo.rentals", new[] { "customerid" });
            DropIndex("dbo.rentals", new[] { "movieid" });
            DropTable("dbo.rentals");
        }
    }
}
