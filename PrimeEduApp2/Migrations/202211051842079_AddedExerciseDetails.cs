namespace PrimeEduApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedExerciseDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExercisesDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.ExerciseId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExercisesDetails", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ExercisesDetails", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.ExercisesDetails", new[] { "StudentId" });
            DropIndex("dbo.ExercisesDetails", new[] { "ExerciseId" });
            DropTable("dbo.ExercisesDetails");
        }
    }
}
