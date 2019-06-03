namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8aef6275-2fd3-4111-a3f9-72ce97558bf7', N'admin@vidly.com', 0, N'AIrMPCfe70vHQFOb1/60RfG342ce/JpRzwPaOEF3jQ6Hj7dqHIpPjlMHSdbnmIIDRA==', N'abd0be0d-e432-4421-a1e6-24922392654a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'faa6fe6b-7a8f-40c5-9c20-a95bc632f035', N'guest@vidly.com', 0, N'AAEmVhChAPEwuW6y2k1pkpM4+UeNzR/iXJEsNweU+RkGg+mWOu8osfYw2fYSj70Z6g==', N'df7649cf-e3ea-4e8a-a02e-d25f729b6f00', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'CanMangeMoviesAndCustomers')
");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8aef6275-2fd3-4111-a3f9-72ce97558bf7', N'1')
");
        }
        
        public override void Down()
        {
        }
    }
}
