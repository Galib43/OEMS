namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Duration = c.Int(nullable: false),
                        Credit = c.Int(nullable: false),
                        Outline = c.String(),
                        Tag = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: false)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ExamTypeId = c.Int(nullable: false),
                        Code = c.String(),
                        Topic = c.String(),
                        FullMarks = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.ExamTypes", t => t.ExamTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: false)
                .Index(t => t.OrganizationId)
                .Index(t => t.CourseId)
                .Index(t => t.ExamTypeId);
            
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 11),
                        About = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        BatchId = c.Int(nullable: false),
                        Name = c.String(),
                        RegNo = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        PostalCode = c.String(),
                        Profession = c.String(),
                        Academy = c.String(),
                        Image = c.Binary(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: false)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: false)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: false)
                .Index(t => t.OrganizationId)
                .Index(t => t.CourseId)
                .Index(t => t.BatchId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: false)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        BatchId = c.Int(nullable: false),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        PostalCode = c.String(),
                        Image = c.Binary(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: false)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: false)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: false)
                .Index(t => t.OrganizationId)
                .Index(t => t.CourseId)
                .Index(t => t.BatchId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        QuestionId = c.Int(nullable: false),
                        IsAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: false)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                        QOrder = c.Int(nullable: false),
                        Marks = c.Double(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAcounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Trainers", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Participants", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Exams", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Participants", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Participants", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Trainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Trainers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Participants", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Participants", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Exams", "ExamTypeId", "dbo.ExamTypes");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.Trainers", new[] { "CityId" });
            DropIndex("dbo.Trainers", new[] { "CountryId" });
            DropIndex("dbo.Trainers", new[] { "BatchId" });
            DropIndex("dbo.Trainers", new[] { "CourseId" });
            DropIndex("dbo.Trainers", new[] { "OrganizationId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Participants", new[] { "CityId" });
            DropIndex("dbo.Participants", new[] { "CountryId" });
            DropIndex("dbo.Participants", new[] { "BatchId" });
            DropIndex("dbo.Participants", new[] { "CourseId" });
            DropIndex("dbo.Participants", new[] { "OrganizationId" });
            DropIndex("dbo.Exams", new[] { "ExamTypeId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Exams", new[] { "OrganizationId" });
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.UserAcounts");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.Trainers");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Participants");
            DropTable("dbo.Organizations");
            DropTable("dbo.ExamTypes");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
            DropTable("dbo.Batches");
        }
    }
}
