namespace PrimeEduApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelsToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassroomName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExerciseName = c.String(),
                        ClassroomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomID, cascadeDelete: true)
                .Index(t => t.ClassroomID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ClassroomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomID, cascadeDelete: true)
                .Index(t => t.ClassroomID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ClassroomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomID, cascadeDelete: true)
                .Index(t => t.ClassroomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "ClassroomID", "dbo.Classrooms");
            DropForeignKey("dbo.Students", "ClassroomID", "dbo.Classrooms");
            DropForeignKey("dbo.Exercises", "ClassroomID", "dbo.Classrooms");
            DropIndex("dbo.Teachers", new[] { "ClassroomID" });
            DropIndex("dbo.Students", new[] { "ClassroomID" });
            DropIndex("dbo.Exercises", new[] { "ClassroomID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Exercises");
            DropTable("dbo.Classrooms");
        }
    }
}
