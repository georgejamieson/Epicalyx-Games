using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Epicalyx_Games.Data.Migrations
{
    public partial class idk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeRating = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "AspectReview",
                columns: table => new
                {
                    AspectReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryRating = table.Column<int>(type: "int", nullable: false),
                    SoundtrackRating = table.Column<int>(type: "int", nullable: false),
                    GraphicsRating = table.Column<int>(type: "int", nullable: false),
                    GameplayRating = table.Column<int>(type: "int", nullable: false),
                    MultiplayerRating = table.Column<int>(type: "int", nullable: true),
                    StoryCompletion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCompletion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspectReview", x => x.AspectReviewID);
                    table.ForeignKey(
                        name: "FK_AspectReview_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspectReview_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinalReview",
                columns: table => new
                {
                    FinalReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalRating = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalReview", x => x.FinalReviewID);
                    table.ForeignKey(
                        name: "FK_FinalReview_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalReview_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspectReview_GameID",
                table: "AspectReview",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_AspectReview_UserID",
                table: "AspectReview",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FinalReview_GameID",
                table: "FinalReview",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_FinalReview_UserID",
                table: "FinalReview",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspectReview");

            migrationBuilder.DropTable(
                name: "FinalReview");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
