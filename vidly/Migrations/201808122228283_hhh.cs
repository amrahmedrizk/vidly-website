namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hhh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.rentals", "customerid", "dbo.customers");
            DropForeignKey("dbo.rentals", "movieid", "dbo.movies");
            DropIndex("dbo.rentals", new[] { "movieid" });
            DropIndex("dbo.rentals", new[] { "customerid" });
            RenameColumn(table: "dbo.rentals", name: "customerid", newName: "customer_id");
            RenameColumn(table: "dbo.rentals", name: "movieid", newName: "movie_id");
            AlterColumn("dbo.rentals", "movie_id", c => c.Int());
            AlterColumn("dbo.rentals", "customer_id", c => c.Int());
            CreateIndex("dbo.rentals", "customer_id");
            CreateIndex("dbo.rentals", "movie_id");
            AddForeignKey("dbo.rentals", "customer_id", "dbo.customers", "id");
            AddForeignKey("dbo.rentals", "movie_id", "dbo.movies", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.rentals", "movie_id", "dbo.movies");
            DropForeignKey("dbo.rentals", "customer_id", "dbo.customers");
            DropIndex("dbo.rentals", new[] { "movie_id" });
            DropIndex("dbo.rentals", new[] { "customer_id" });
            AlterColumn("dbo.rentals", "customer_id", c => c.Int(nullable: false));
            AlterColumn("dbo.rentals", "movie_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.rentals", name: "movie_id", newName: "movieid");
            RenameColumn(table: "dbo.rentals", name: "customer_id", newName: "customerid");
            CreateIndex("dbo.rentals", "customerid");
            CreateIndex("dbo.rentals", "movieid");
            AddForeignKey("dbo.rentals", "movieid", "dbo.movies", "id", cascadeDelete: true);
            AddForeignKey("dbo.rentals", "customerid", "dbo.customers", "id", cascadeDelete: true);
        }
    }
}
