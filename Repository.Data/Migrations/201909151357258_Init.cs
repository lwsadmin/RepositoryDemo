namespace Repository.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Actions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PassWord = c.String(),
                        TrueName = c.String(),
                        Sex = c.Int(nullable: false),
                        Mobile = c.String(),
                        Email = c.String(),
                        RoleId = c.Int(nullable: false),
                        Roles_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                //.ForeignKey("dbo.Roles", t => t.Roles_Id)
                .Index(t => t.Roles_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Roles_Id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Roles_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
