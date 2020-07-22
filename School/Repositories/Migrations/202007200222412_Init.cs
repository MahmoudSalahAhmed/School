namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Email = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ClassRoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ClassRoom", t => t.ClassRoomID)
                .ForeignKey("dbo.User", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.ClassRoomID);
            
            CreateTable(
                "dbo.ClassRoom",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassRoomID = c.Int(nullable: false),
                        DayID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Day", t => t.DayID, cascadeDelete: true)
                .ForeignKey("dbo.ClassRoom", t => t.ClassRoomID)
                .Index(t => t.ClassRoomID)
                .Index(t => t.DayID);
            
            CreateTable(
                "dbo.Day",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ScheduleLesson",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        LessonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lesson", t => t.LessonID, cascadeDelete: true)
                .ForeignKey("dbo.Schedule", t => t.ScheduleID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.ScheduleID)
                .Index(t => t.SubjectID)
                .Index(t => t.LessonID);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teacher", "ID", "dbo.User");
            DropForeignKey("dbo.Student", "ID", "dbo.User");
            DropForeignKey("dbo.Student", "ClassRoomID", "dbo.ClassRoom");
            DropForeignKey("dbo.Schedule", "ClassRoomID", "dbo.ClassRoom");
            DropForeignKey("dbo.ScheduleLesson", "TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.ScheduleLesson", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.ScheduleLesson", "ScheduleID", "dbo.Schedule");
            DropForeignKey("dbo.ScheduleLesson", "LessonID", "dbo.Lesson");
            DropForeignKey("dbo.Schedule", "DayID", "dbo.Day");
            DropForeignKey("dbo.Admin", "ID", "dbo.User");
            DropIndex("dbo.Teacher", new[] { "ID" });
            DropIndex("dbo.ScheduleLesson", new[] { "LessonID" });
            DropIndex("dbo.ScheduleLesson", new[] { "SubjectID" });
            DropIndex("dbo.ScheduleLesson", new[] { "ScheduleID" });
            DropIndex("dbo.ScheduleLesson", new[] { "TeacherID" });
            DropIndex("dbo.Schedule", new[] { "DayID" });
            DropIndex("dbo.Schedule", new[] { "ClassRoomID" });
            DropIndex("dbo.Student", new[] { "ClassRoomID" });
            DropIndex("dbo.Student", new[] { "ID" });
            DropIndex("dbo.Admin", new[] { "ID" });
            DropTable("dbo.Teacher");
            DropTable("dbo.Subject");
            DropTable("dbo.Lesson");
            DropTable("dbo.ScheduleLesson");
            DropTable("dbo.Day");
            DropTable("dbo.Schedule");
            DropTable("dbo.ClassRoom");
            DropTable("dbo.Student");
            DropTable("dbo.User");
            DropTable("dbo.Admin");
        }
    }
}
