namespace ImNew.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Techonologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserHobbies",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Hobby_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Hobby_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Hobbies", t => t.Hobby_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Hobby_Id);
            
            CreateTable(
                "dbo.TechonologyUsers",
                c => new
                    {
                        Techonology_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Techonology_Id, t.User_Id })
                .ForeignKey("dbo.Techonologies", t => t.Techonology_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Techonology_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechonologyUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TechonologyUsers", "Techonology_Id", "dbo.Techonologies");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserHobbies", "Hobby_Id", "dbo.Hobbies");
            DropForeignKey("dbo.UserHobbies", "User_Id", "dbo.Users");
            DropIndex("dbo.TechonologyUsers", new[] { "User_Id" });
            DropIndex("dbo.TechonologyUsers", new[] { "Techonology_Id" });
            DropIndex("dbo.UserHobbies", new[] { "Hobby_Id" });
            DropIndex("dbo.UserHobbies", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.TechonologyUsers");
            DropTable("dbo.UserHobbies");
            DropTable("dbo.Techonologies");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Hobbies");
        }
    }
}
