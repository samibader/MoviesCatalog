namespace MoviesCatalog.Data.Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Poster", c => c.String());
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "ReleaseYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ReleaseYear");
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Movies", "Poster");
        }
    }
}
