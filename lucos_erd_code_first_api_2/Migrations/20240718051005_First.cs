using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lucos_erd_code_first_api_2.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Openings",
                columns: table => new
                {
                    OpeningCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OpeningName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Openings", x => x.OpeningCode);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PlayerWId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpeningPlayedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameNumber);
                    table.ForeignKey(
                        name: "FK_Games_Openings_OpeningPlayedId",
                        column: x => x.OpeningPlayedId,
                        principalTable: "Openings",
                        principalColumn: "OpeningCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerBId",
                        column: x => x.PlayerBId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerWId",
                        column: x => x.PlayerWId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_OpeningPlayedId",
                table: "Games",
                column: "OpeningPlayedId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerBId",
                table: "Games",
                column: "PlayerBId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerWId",
                table: "Games",
                column: "PlayerWId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Openings");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
