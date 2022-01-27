using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockLab.Dal.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_LabAssistants_LabAssistantId",
                table: "Researches");

            migrationBuilder.DropTable(
                name: "LabAssistants");

            migrationBuilder.DropIndex(
                name: "IX_Researches_LabAssistantId",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "LabAssistantId",
                table: "Researches");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Researches",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Researches");

            migrationBuilder.AddColumn<int>(
                name: "LabAssistantId",
                table: "Researches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LabAssistants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    IsInactive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Patronymmic = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    SurName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabAssistants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Researches_LabAssistantId",
                table: "Researches",
                column: "LabAssistantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_LabAssistants_LabAssistantId",
                table: "Researches",
                column: "LabAssistantId",
                principalTable: "LabAssistants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
