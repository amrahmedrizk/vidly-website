namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a8e74197-d088-4ad7-9c27-85e120851ccc', N'admin@vidly.com', 0, N'AIAShnqZgkjMCejS64a3eSDAe5MrQwJbdmLgk2Oywo1YF0FpeLP4hTeEYyLGPjpvHg==', N'3f6805ac-050e-43da-a1d1-595d2262225b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cc0c4025-52e6-4041-a0cd-06bde024583c', N'geust@vidly.com', 0, N'AP4KuOeUdNrW0NW7gEykJNCKTtX+HpRDanPCONGuhB1klDFClJ5ru3NYoQeVG3+4CA==', N'49cf70f3-cdd9-4ef9-beb9-dd787d94ed1d', NULL, 0, 0, NULL, 1, 0, N'geust@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'def97118-5704-46e9-ad80-23913a7dff7f', N'canmanegemovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a8e74197-d088-4ad7-9c27-85e120851ccc', N'def97118-5704-46e9-ad80-23913a7dff7f')
");
        }
        
        public override void Down()
        {
        }
    }
}
