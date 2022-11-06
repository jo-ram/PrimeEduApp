namespace PrimeEduApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classrooms", "ClassroomName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Exercises", "ExerciseName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Teachers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "LastName", c => c.String());
            AlterColumn("dbo.Teachers", "FirstName", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Exercises", "ExerciseName", c => c.String());
            AlterColumn("dbo.Classrooms", "ClassroomName", c => c.String());
        }
    }
}
