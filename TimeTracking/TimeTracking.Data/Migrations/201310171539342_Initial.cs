using System;
using System.Data.Entity.Migrations;

namespace TimeTracking.Data.Migrations
{
	public partial class Initial : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Project",
				c => new
				{
					ProjectId = c.Int(nullable: false, identity: true),
					Name = c.String(nullable: false, maxLength: 100),
				})
				.PrimaryKey(t => t.ProjectId);

			CreateTable(
				"dbo.ProjectTask",
				c => new
				{
					ProjectTaskId = c.Int(nullable: false, identity: true),
					ProjectId = c.Int(nullable: false),
					Name = c.String(nullable: false, maxLength: 100),
				})
				.PrimaryKey(t => t.ProjectTaskId)
				.ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
				.Index(t => t.ProjectId);

			CreateTable(
				"dbo.TimeEntry",
				c => new
				{
					TimeEntryId = c.Int(nullable: false, identity: true),
					UserId = c.Int(nullable: false),
					ProjectTaskId = c.Int(nullable: false),
					TimeIn = c.DateTime(nullable: false),
					TimeOut = c.DateTime(),
					Comment = c.String(),
				})
				.PrimaryKey(t => t.TimeEntryId)
				.ForeignKey("dbo.ProjectTask", t => t.ProjectTaskId)
				.ForeignKey("dbo.User", t => t.UserId)
				.Index(t => t.ProjectTaskId)
				.Index(t => t.UserId);

			CreateTable(
				"dbo.User",
				c => new
				{
					UserId = c.Int(nullable: false, identity: true),
					Username = c.String(nullable: false, maxLength: 50),
					Name = c.String(nullable: false, maxLength: 100),
					Email = c.String(nullable: false, maxLength: 255),
				})
				.PrimaryKey(t => t.UserId);

		}

		public override void Down()
		{
			DropForeignKey("dbo.TimeEntry", "UserId", "dbo.User");
			DropForeignKey("dbo.TimeEntry", "ProjectTaskId", "dbo.ProjectTask");
			DropForeignKey("dbo.ProjectTask", "ProjectId", "dbo.Project");
			DropIndex("dbo.TimeEntry", new[] { "UserId" });
			DropIndex("dbo.TimeEntry", new[] { "ProjectTaskId" });
			DropIndex("dbo.ProjectTask", new[] { "ProjectId" });
			DropTable("dbo.User");
			DropTable("dbo.TimeEntry");
			DropTable("dbo.ProjectTask");
			DropTable("dbo.Project");
		}
	}
}
