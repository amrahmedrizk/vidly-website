namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatemembershiptypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO membershiptypes (name, signupfee, durationmonthes, discountrate) VALUES ('pay as you go', 0 ,0 ,0)");
            Sql("INSERT INTO membershiptypes (name, signupfee, durationmonthes, discountrate) VALUES ('monthly', 30, 1, 10)");
            Sql("INSERT INTO membershiptypes (name, signupfee, durationmonthes, discountrate) VALUES ('quartery', 90, 3, 15)");
            Sql("INSERT INTO membershiptypes (name, signupfee, durationmonthes, discountrate) VALUES ('annaul', 300, 12, 20)");

        }

        public override void Down()
        {
        }
    }
}
