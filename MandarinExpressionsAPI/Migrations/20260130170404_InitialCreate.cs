using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MandarinExpressionsAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expressions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Hanzi = table.Column<string>(type: "TEXT", nullable: false),
                    Pinyin = table.Column<string>(type: "TEXT", nullable: false),
                    MeaningPt = table.Column<string>(type: "TEXT", nullable: false),
                    MeaningEn = table.Column<string>(type: "TEXT", nullable: false),
                    UsageContext = table.Column<string>(type: "TEXT", nullable: false),
                    ExampleSentence = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expressions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expressions");
        }
    }
}
