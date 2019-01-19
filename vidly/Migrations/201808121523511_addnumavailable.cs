namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnumavailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.movies", "numberavailable", c => c.Int(nullable: false));
            Sql("update movies set numberavailable = numberinstock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.movies", "numberavailable");
        }
    }
}
