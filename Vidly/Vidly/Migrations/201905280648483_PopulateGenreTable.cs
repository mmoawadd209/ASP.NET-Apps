namespace Vidly.Migrations
{
 
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Genres (Id,Name) VALUES (1,'Action')");
            Sql("INSERT INTO dbo.Genres (Id,Name) VALUES (2,'Comedy')");
            Sql("INSERT INTO dbo.Genres (Id,Name) VALUES (3,'Horror')");
            Sql("INSERT INTO dbo.Genres (Id,Name) VALUES (4,'Family')");
            Sql("INSERT INTO dbo.Genres (Id,Name) VALUES (5,'Romance')");
            Sql("INSERT INTO dbo.Genres (Id,Name) VALUES (6,'Bio')");
            Sql("INSERT INTO dbo.Genres (Id,Name) VALUES (7,'Animation')");
            Sql("INSERT INTO dbo.Genres (Id,Name) VALUES (8,'Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
