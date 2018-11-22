namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'b6d13a66-a018-4df9-a10c-cdbdb7a570ad', N'guess@vidly.com', 0, N'AMAxiZn1OtvqKPXb5s661AxPmie5N8hn2hr1BA90OU2gEG/EtNxqR42XFOX4EaJ8kw==', N'95957714-87e0-4991-ba8f-0719431b657d', NULL, 0, 0, NULL, 1, 0, N'guess@vidly.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f1c5823e-9307-4851-81a1-248c98e0a1ba', N'admin@vidly.com', 0, N'AGAKORvVxFQSKyONgvBnQN5SU6OeMMYthI1jc2w81xFpfIVMI0Ceum82cfchcHip1w==', N'8197fecf-25eb-496a-9cff-78b6518c115e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6292e240-4c15-45c9-b737-f52541f42658', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f1c5823e-9307-4851-81a1-248c98e0a1ba', N'6292e240-4c15-45c9-b737-f52541f42658')
            ");
        }

        public override void Down()
        {
            Sql(@"
                DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId in (SELECT Id FROM [dbo].[AspNetUsers] WHERE Email = 'admin@vidly.com')
                DELETE FROM [dbo].[AspNetUsers] WHERE Email in ('guess@vidly.com','admin@vidly.com')
                DELETE FROM [dbo].[AspNetRoles] WHERE Name = 'CanManageMovies')
            ");
        }
    }
}
