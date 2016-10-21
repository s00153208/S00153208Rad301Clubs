namespace S00153208Clubs.Migrations.ClubModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedclubs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        ClubName = c.String(),
                        CreationDate = c.DateTime(nullable: false, storeType: "date"),
                        adminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId);
            
            CreateTable(
                "dbo.ClubEvent",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Venue = c.String(),
                        Location = c.String(),
                        ClubId = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Club", t => t.ClubId, cascadeDelete: true)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        memberID = c.Guid(nullable: false),
                        StudentID = c.Guid(nullable: false),
                        approved = c.Boolean(nullable: false),
                        ClubEvent_EventID = c.Int(),
                        Club_ClubId = c.Int(),
                    })
                .PrimaryKey(t => new { t.memberID, t.StudentID })
                .ForeignKey("dbo.ClubEvent", t => t.ClubEvent_EventID)
                .ForeignKey("dbo.Club", t => t.Club_ClubId)
                .Index(t => t.ClubEvent_EventID)
                .Index(t => t.Club_ClubId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "Club_ClubId", "dbo.Club");
            DropForeignKey("dbo.Member", "ClubEvent_EventID", "dbo.ClubEvent");
            DropForeignKey("dbo.ClubEvent", "ClubId", "dbo.Club");
            DropIndex("dbo.Member", new[] { "Club_ClubId" });
            DropIndex("dbo.Member", new[] { "ClubEvent_EventID" });
            DropIndex("dbo.ClubEvent", new[] { "ClubId" });
            DropTable("dbo.Member");
            DropTable("dbo.ClubEvent");
            DropTable("dbo.Club");
        }
    }
}
