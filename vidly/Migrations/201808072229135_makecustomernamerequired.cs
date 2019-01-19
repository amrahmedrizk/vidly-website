namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makecustomernamerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.customers", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.customers", "name", c => c.String());
        }
    }
}
