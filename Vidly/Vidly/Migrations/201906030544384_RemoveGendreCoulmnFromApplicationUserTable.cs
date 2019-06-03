namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGendreCoulmnFromApplicationUserTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Gendre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Gendre", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
