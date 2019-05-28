namespace Vidly.Migrations
{
 
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateCoulmnToCustomersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
