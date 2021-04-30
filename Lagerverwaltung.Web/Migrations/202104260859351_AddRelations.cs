namespace Lagerverwaltung.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Geschäftsfall",
                c => new
                    {
                        GeschäftsfallId = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(),
                        MitarbeiterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GeschäftsfallId)
                .ForeignKey("dbo.Mitarbeiters", t => t.MitarbeiterId, cascadeDelete: true)
                .Index(t => t.MitarbeiterId);
            
            CreateTable(
                "dbo.Mitarbeiters",
                c => new
                    {
                        MitarbeiterId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.MitarbeiterId);
            
            CreateTable(
                "dbo.Lagerartikels",
                c => new
                    {
                        LagerartikelId = c.Int(nullable: false, identity: true),
                        L_Bezeichnung = c.String(nullable: false, maxLength: 100),
                        L_Preis = c.Double(nullable: false),
                        Lagerstand = c.Int(nullable: false),
                        L_MengenEinheit = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.LagerartikelId);
            
            CreateTable(
                "dbo.Lagerbewegungs",
                c => new
                    {
                        LagerbewegungId = c.Int(nullable: false, identity: true),
                        B_Menge = c.Int(nullable: false),
                        LagerartikelId = c.Int(nullable: false),
                        GeschäftsfallId = c.Int(nullable: false),
                        VorgangsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LagerbewegungId)
                .ForeignKey("dbo.Geschäftsfall", t => t.GeschäftsfallId, cascadeDelete: true)
                .ForeignKey("dbo.Lagerartikels", t => t.LagerartikelId, cascadeDelete: true)
                .ForeignKey("dbo.Vorgangstyps", t => t.VorgangsId, cascadeDelete: true)
                .Index(t => t.LagerartikelId)
                .Index(t => t.GeschäftsfallId)
                .Index(t => t.VorgangsId);
            
            CreateTable(
                "dbo.Vorgangstyps",
                c => new
                    {
                        VorgangsId = c.Int(nullable: false, identity: true),
                        Vorgang = c.String(nullable: false, maxLength: 7),
                    })
                .PrimaryKey(t => t.VorgangsId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MitarbeiterId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mitarbeiters", t => t.MitarbeiterId, cascadeDelete: true)
                .Index(t => t.MitarbeiterId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "MitarbeiterId", "dbo.Mitarbeiters");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Lagerbewegungs", "VorgangsId", "dbo.Vorgangstyps");
            DropForeignKey("dbo.Lagerbewegungs", "LagerartikelId", "dbo.Lagerartikels");
            DropForeignKey("dbo.Lagerbewegungs", "GeschäftsfallId", "dbo.Geschäftsfall");
            DropForeignKey("dbo.Geschäftsfall", "MitarbeiterId", "dbo.Mitarbeiters");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "MitarbeiterId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Lagerbewegungs", new[] { "VorgangsId" });
            DropIndex("dbo.Lagerbewegungs", new[] { "GeschäftsfallId" });
            DropIndex("dbo.Lagerbewegungs", new[] { "LagerartikelId" });
            DropIndex("dbo.Geschäftsfall", new[] { "MitarbeiterId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Vorgangstyps");
            DropTable("dbo.Lagerbewegungs");
            DropTable("dbo.Lagerartikels");
            DropTable("dbo.Mitarbeiters");
            DropTable("dbo.Geschäftsfall");
        }
    }
}
