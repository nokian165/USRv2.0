namespace USRv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedDataBase : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'093eed51-7ae0-4c6f-b426-472f90408d6d', N'kipia@sautcom.kiev.ua', 0, N'AL0KShI+cnFYvssvZJzU50e5e1UxAAY1Fd0FhAdds3VF3wbyhoLwyJ/3KCXHc8HSkw==', N'c42f330d-8156-40cf-be1e-f2fe42ab14ef', NULL, 0, 0, NULL, 1, 0, N'kipia@sautcom.kiev.ua')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1caf5755-8568-49c3-b9a2-3f80c1cb6851', N'admin@sautcom.kiev.ua', 0, N'ALF6W1QCjXaHpbPSDYKIf4qHmwf/3UM/vP1nx96vKtlVgAz6k3ieH9FhGALXygEm8g==', N'374fb514-9674-453e-b1ed-b2dddbbf8423', NULL, 0, 0, NULL, 1, 0, N'admin@sautcom.kiev.ua')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'916c78b3-ea1c-41b4-badf-93400ec70faa', N'operator@sautcom.kiev.ua', 0, N'AL/u7gHgTWGLfZrcflsk+FdAABsd+KwSDooBkPITptRJnM4l7QkBVp7qqqiQOGETAQ==', N'a4d752cb-b087-4856-b0ea-0a6c07dd2c2e', NULL, 0, 0, NULL, 1, 0, N'operator@sautcom.kiev.ua')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'10ff2f35-9fb0-43fb-b4d2-7718df8e781a', N'ManageSettings')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'093eed51-7ae0-4c6f-b426-472f90408d6d', N'10ff2f35-9fb0-43fb-b4d2-7718df8e781a')

");
        }
        
        public override void Down()
        {
        }
    }
}
