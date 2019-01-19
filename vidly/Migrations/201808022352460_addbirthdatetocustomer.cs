namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbirthdatetocustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "birthdate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.customers", "birthdate");
        }
    }
}
