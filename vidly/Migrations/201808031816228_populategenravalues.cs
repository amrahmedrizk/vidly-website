namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenravalues : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genras (name) values ('action')");
            Sql("insert into genras (name) values ('drama')");
            Sql("insert into genras (name) values ('comedy')");
            Sql("insert into genras (name) values ('remance')");
        }
        
        public override void Down()
        {
        }
    }
}
