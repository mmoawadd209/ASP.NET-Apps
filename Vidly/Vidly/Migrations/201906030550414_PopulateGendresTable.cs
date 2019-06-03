namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGendresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Gendres(Id,Name) VALUES(1,'Male')");
            Sql("INSERT INTO dbo.Gendres(Id,Name) VALUES(2,'Female')");
            Sql("INSERT INTO dbo.Gendres(Id,Name) VALUES(3,'Other')");
        }
        
        public override void Down()
        {
        }
    }
}
