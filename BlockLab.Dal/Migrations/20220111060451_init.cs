using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockLab.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabAssistants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Patronymmic = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsInactive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabAssistants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeResearches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    TypeResult = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeResearches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Researches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Text = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    IsNormal = table.Column<bool>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    TypeResearchId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResearchObjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    LabAssistantId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkShiftId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Researches_LabAssistants_LabAssistantId",
                        column: x => x.LabAssistantId,
                        principalTable: "LabAssistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Researches_ResearchObjects_ResearchObjectId",
                        column: x => x.ResearchObjectId,
                        principalTable: "ResearchObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Researches_TypeResearches_TypeResearchId",
                        column: x => x.TypeResearchId,
                        principalTable: "TypeResearches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Researches_WorkShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockQualityReearches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Format = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Trademark = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    SizeX = table.Column<double>(type: "REAL", nullable: false),
                    SizeY = table.Column<double>(type: "REAL", nullable: false),
                    SizeZ = table.Column<double>(type: "REAL", nullable: false),
                    RawDensity = table.Column<double>(type: "REAL", nullable: false),
                    Coefficient = table.Column<double>(type: "REAL", nullable: false),
                    RawWeight = table.Column<double>(type: "REAL", nullable: false),
                    DriedWeight = table.Column<double>(type: "REAL", nullable: false),
                    Humidity = table.Column<double>(type: "REAL", nullable: false),
                    Load = table.Column<double>(type: "REAL", nullable: false),
                    Strength = table.Column<double>(type: "REAL", nullable: false),
                    DriedDensity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockQualityReearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockQualityReearches_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CementResearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Party = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PassportVc = table.Column<double>(type: "REAL", nullable: false),
                    PassportNsh = table.Column<double>(type: "REAL", nullable: false),
                    PassportKsh = table.Column<double>(type: "REAL", nullable: false),
                    ActualVc = table.Column<double>(type: "REAL", nullable: false),
                    ActualNsh = table.Column<double>(type: "REAL", nullable: false),
                    ActualKsh = table.Column<double>(type: "REAL", nullable: false),
                    FromName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CementResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CementResearch_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HammerBinderResearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sieve0_2 = table.Column<double>(type: "REAL", nullable: false),
                    Surface = table.Column<double>(type: "REAL", nullable: false),
                    Perfomance = table.Column<double>(type: "REAL", nullable: false),
                    Activity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HammerBinderResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HammerBinderResearch_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MudReearches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Density = table.Column<double>(type: "REAL", nullable: false),
                    Surface = table.Column<double>(type: "REAL", nullable: false),
                    Sieve0_8 = table.Column<double>(type: "REAL", nullable: false),
                    Sieve0_09 = table.Column<double>(type: "REAL", nullable: false),
                    Sieve0_045 = table.Column<double>(type: "REAL", nullable: false),
                    Gypsum = table.Column<double>(type: "REAL", nullable: false),
                    Humidity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MudReearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MudReearches_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Researches_LabAssistantId",
                table: "Researches",
                column: "LabAssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_ResearchObjectId",
                table: "Researches",
                column: "ResearchObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_TypeResearchId",
                table: "Researches",
                column: "TypeResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_WorkShiftId",
                table: "Researches",
                column: "WorkShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockQualityReearches");

            migrationBuilder.DropTable(
                name: "CementResearch");

            migrationBuilder.DropTable(
                name: "HammerBinderResearch");

            migrationBuilder.DropTable(
                name: "MudReearches");

            migrationBuilder.DropTable(
                name: "Researches");

            migrationBuilder.DropTable(
                name: "LabAssistants");

            migrationBuilder.DropTable(
                name: "ResearchObjects");

            migrationBuilder.DropTable(
                name: "TypeResearches");

            migrationBuilder.DropTable(
                name: "WorkShifts");
        }
    }
}
