using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBack.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Works_ServicesId",
                table: "Works",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Services_ServicesId",
                table: "Works",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Services_ServicesId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_ServicesId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Works");
        }
    }
}
