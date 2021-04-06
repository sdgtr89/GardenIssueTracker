using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GardenIssueTracker.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantGenera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScientificName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantGenera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantVarieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PlantGenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantVarieties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantVarieties_PlantGenera_PlantGenusId",
                        column: x => x.PlantGenusId,
                        principalTable: "PlantGenera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GardenId = table.Column<int>(type: "int", nullable: false),
                    DatePlanted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlantVarietyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GardenItems_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenItems_PlantVarieties_PlantVarietyId",
                        column: x => x.PlantVarietyId,
                        principalTable: "PlantVarieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GardenItemId = table.Column<int>(type: "int", nullable: false),
                    IsIssue = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_GardenItems_GardenItemId",
                        column: x => x.GardenItemId,
                        principalTable: "GardenItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_GardenItemId",
                table: "Comments",
                column: "GardenItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenItems_GardenId",
                table: "GardenItems",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenItems_PlantVarietyId",
                table: "GardenItems",
                column: "PlantVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantGenera_CommonName",
                table: "PlantGenera",
                column: "CommonName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantGenera_ScientificName",
                table: "PlantGenera",
                column: "ScientificName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantVarieties_Name",
                table: "PlantVarieties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantVarieties_PlantGenusId",
                table: "PlantVarieties",
                column: "PlantGenusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GardenItems");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "PlantVarieties");

            migrationBuilder.DropTable(
                name: "PlantGenera");
        }
    }
}
