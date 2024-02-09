using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAssesment.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Users_UserId1",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_UserId1",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Apartment",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Apartments");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApartmentId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Apartment",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UserId1",
                table: "Apartments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Users_UserId1",
                table: "Apartments",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
