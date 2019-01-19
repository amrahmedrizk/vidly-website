namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddrivelicense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "drivelicense", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "drivelicense");
        }
    }
}
