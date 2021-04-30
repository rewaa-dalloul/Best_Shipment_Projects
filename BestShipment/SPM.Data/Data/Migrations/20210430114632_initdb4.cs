using Microsoft.EntityFrameworkCore.Migrations;

namespace SPM.Data.Migrations
{
    public partial class initdb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountyId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountyId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "CountyId",
                table: "Cities",
                newName: "CountryId");

            migrationBuilder.AddColumn<int>(
                name: "CounrtyId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CounrtyId",
                table: "Cities",
                column: "CounrtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CounrtyId",
                table: "Cities",
                column: "CounrtyId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CounrtyId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CounrtyId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CounrtyId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountyId",
                table: "Cities",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountyId",
                table: "Cities",
                column: "CountyId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
