namespace TimeTracking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProjectTask",
                c => new
                    {
                        ProjectTaskId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Billable = c.Boolean(nullable: false),
                        RequireComment = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectTaskId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 255),
                        TimeZoneId = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.TimeEntry",
                c => new
                    {
                        TimeEntryId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProjectTaskId = c.Int(nullable: false),
                        Billable = c.Boolean(nullable: false),
                        TimeInUtc = c.DateTime(nullable: false),
                        TimeOutUtc = c.DateTime(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.TimeEntryId)
                .ForeignKey("dbo.ProjectTask", t => t.ProjectTaskId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.ProjectTaskId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeEntry", "UserId", "dbo.User");
            DropForeignKey("dbo.TimeEntry", "ProjectTaskId", "dbo.ProjectTask");
            DropForeignKey("dbo.Project", "UserId", "dbo.User");
            DropForeignKey("dbo.ProjectTask", "ProjectId", "dbo.Project");
            DropIndex("dbo.TimeEntry", new[] { "UserId" });
            DropIndex("dbo.TimeEntry", new[] { "ProjectTaskId" });
            DropIndex("dbo.Project", new[] { "UserId" });
            DropIndex("dbo.ProjectTask", new[] { "ProjectId" });
            DropTable("dbo.TimeEntry");
            DropTable("dbo.User");
            DropTable("dbo.ProjectTask");
            DropTable("dbo.Project");
        }
    }
}
