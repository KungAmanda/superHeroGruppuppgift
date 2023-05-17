using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace superHeroGruppuppgift.Data.Migrations
{
    /// <inheritdoc />
    public partial class superHeroTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "superHeroTeamId",
                table: "superHeros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "superHeroTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_superHeroTeam", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_superHeros_superHeroTeamId",
                table: "superHeros",
                column: "superHeroTeamId");

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

            migrationBuilder.DropTable(
                name: "superHeroTeam");

            migrationBuilder.DropIndex(
                name: "IX_superHeros_superHeroTeamId",
                table: "superHeros");

            migrationBuilder.DropColumn(
                name: "superHeroTeamId",
                table: "superHeros");
        }
    }
}
