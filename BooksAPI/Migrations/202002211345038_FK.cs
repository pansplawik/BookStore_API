namespace BooksAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "Author_AuthorId", newName: "AuthorId");
            RenameIndex(table: "dbo.Books", name: "IX_Author_AuthorId", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_AuthorId", newName: "IX_Author_AuthorId");
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_AuthorId");
        }
    }
}
