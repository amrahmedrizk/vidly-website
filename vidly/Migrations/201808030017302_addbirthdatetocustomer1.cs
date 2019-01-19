namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbirthdatetocustomer1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.customers", "birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.customers", "birthdate", c => c.DateTime(nullable: false));
        }
    }
}
