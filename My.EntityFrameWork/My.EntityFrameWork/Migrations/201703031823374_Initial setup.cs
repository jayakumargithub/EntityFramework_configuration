namespace My.EntityFrameWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        BloggerName = c.String(),
                        BlogDetails_DateCreated = c.DateTime(),
                        BlogDetails_Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Key = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Price = c.Decimal(precision: 18, scale: 2),
                        ReleaseDate = c.DateTime(),
                        Category_Key = c.Int(),
                        Category_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Key, t.Name })
                .ForeignKey("dbo.ProductCategory", t => new { t.Category_Key, t.Category_Name })
                .Index(t => new { t.Category_Key, t.Category_Name });
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Key = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Key, t.Name });
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Roles = c.Int(nullable: false),
                        User = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Roles, t.User })
                .ForeignKey("dbo.User", t => t.Roles, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.User, cascadeDelete: true)
                .Index(t => t.Roles)
                .Index(t => t.User);
            
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SectionManaged = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Manager", "Id", "dbo.Employee");
            DropForeignKey("dbo.UserRoles", "User", "dbo.Role");
            DropForeignKey("dbo.UserRoles", "Roles", "dbo.User");
            DropForeignKey("dbo.Product", new[] { "Category_Key", "Category_Name" }, "dbo.ProductCategory");
            DropIndex("dbo.Manager", new[] { "Id" });
            DropIndex("dbo.UserRoles", new[] { "User" });
            DropIndex("dbo.UserRoles", new[] { "Roles" });
            DropIndex("dbo.Product", new[] { "Category_Key", "Category_Name" });
            DropTable("dbo.Manager");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.Employee");
            DropTable("dbo.Blog");
        }
    }
}
