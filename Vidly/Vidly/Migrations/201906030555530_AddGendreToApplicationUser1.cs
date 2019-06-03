namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGendreToApplicationUser1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GendreId", c => c.Byte(nullable: true));
            CreateIndex("dbo.AspNetUsers", "GendreId");
            AddForeignKey("dbo.AspNetUsers", "GendreId", "dbo.Gendres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GendreId", "dbo.Gendres");
            DropIndex("dbo.AspNetUsers", new[] { "GendreId" });
            DropColumn("dbo.AspNetUsers", "GendreId");
        }
    }
}
