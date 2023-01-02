using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAPI.Migrations
{
    /// <inheritdoc />
    public partial class _2dupdaterabl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalkDifficulties_Walks_WalkId",
                table: "WalkDifficulties");

            migrationBuilder.DropTable(
                name: "RegionWalk");

            migrationBuilder.DropIndex(
                name: "IX_WalkDifficulties_WalkId",
                table: "WalkDifficulties");

            migrationBuilder.DropColumn(
                name: "WalkId",
                table: "WalkDifficulties");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDifficulties_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId",
                principalTable: "WalkDifficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDifficulties_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_RegionId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.AddColumn<Guid>(
                name: "WalkId",
                table: "WalkDifficulties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegionWalk",
                columns: table => new
                {
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionWalk", x => new { x.RegionId, x.WalksId });
                    table.ForeignKey(
                        name: "FK_RegionWalk_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegionWalk_Walks_WalksId",
                        column: x => x.WalksId,
                        principalTable: "Walks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalkDifficulties_WalkId",
                table: "WalkDifficulties",
                column: "WalkId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionWalk_WalksId",
                table: "RegionWalk",
                column: "WalksId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalkDifficulties_Walks_WalkId",
                table: "WalkDifficulties",
                column: "WalkId",
                principalTable: "Walks",
                principalColumn: "Id");
        }
    }
}
