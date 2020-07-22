namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Int : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ClassDay", name: "ClassID", newName: "ClassRoomID");
            RenameIndex(table: "dbo.ClassDay", name: "IX_ClassID", newName: "IX_ClassRoomID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ClassDay", name: "IX_ClassRoomID", newName: "IX_ClassID");
            RenameColumn(table: "dbo.ClassDay", name: "ClassRoomID", newName: "ClassID");
        }
    }
}
