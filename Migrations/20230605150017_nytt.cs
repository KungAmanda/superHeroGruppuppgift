using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace superHeroGruppuppgift.Migrations
{
    /// <inheritdoc />
    public partial class nytt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_superHeros_superHeroTeam_superHeroTeamId",
                table: "superHeros");

            migrationBuilder.AlterColumn<int>(
                name: "superHeroTeamId",
                table: "superHeros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_superHeros_superHeroTeam_superHeroTeamId",
                table: "superHeros",
                column: "superHeroTeamId",
                principalTable: "superHeroTeam",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_superHeros_superHeroTeam_superHeroTeamId",
                table: "superHeros");

            migrationBuilder.AlterColumn<int>(
                name: "superHeroTeamId",
                table: "superHeros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_superHeros_superHeroTeam_superHeroTeamId",
                table: "superHeros",
                column: "superHeroTeamId",
                principalTable: "superHeroTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
