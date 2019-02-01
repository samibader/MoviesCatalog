namespace MoviesCatalog.Data.Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "MovieNameIndex")
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "UserId", "dbo.Users");
            DropIndex("dbo.Movies", new[] { "UserId" });
            DropIndex("dbo.Movies", "MovieNameIndex");
            DropTable("dbo.Movies");
        }
    }
}
