namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneCoulmnToUsersTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.AspNetUsers SET PhoneNumber = '' ");

            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {

            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            Sql("UPDATE dbo.AspNetUsers SET PhoneNumber = NULL ");
        }
    }
}
