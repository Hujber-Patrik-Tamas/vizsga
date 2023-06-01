using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Futoverseny.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TavolsagModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TavolsagModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Versenyzok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rajtszam = table.Column<int>(type: "int", nullable: false),
                    Nev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SzuletesiDatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Neme = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TavolsagId = table.Column<int>(type: "int", nullable: false),
                    Korosztaly = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versenyzok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versenyzok_TavolsagModel_TavolsagId",
                        column: x => x.TavolsagId,
                        principalTable: "TavolsagModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TavolsagModel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "5 km" },
                    { 2, "10 km" },
                    { 3, "félmaraton" },
                    { 4, "maraton" }
                });

            migrationBuilder.InsertData(
                table: "Versenyzok",
                columns: new[] { "Id", "Korosztaly", "Neme", "Nev", "Rajtszam", "SzuletesiDatum", "TavolsagId" },
                values: new object[] { 1, "senior", "ffi", "Béla", 5, null, 4 });

            migrationBuilder.InsertData(
                table: "Versenyzok",
                columns: new[] { "Id", "Korosztaly", "Neme", "Nev", "Rajtszam", "SzuletesiDatum", "TavolsagId" },
                values: new object[] { 2, "junior", "nő", "Tünde", 7, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TavolsagModel_Name",
                table: "TavolsagModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzok_Rajtszam",
                table: "Versenyzok",
                column: "Rajtszam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzok_TavolsagId",
                table: "Versenyzok",
                column: "TavolsagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Versenyzok");

            migrationBuilder.DropTable(
                name: "TavolsagModel");
        }
    }
}
