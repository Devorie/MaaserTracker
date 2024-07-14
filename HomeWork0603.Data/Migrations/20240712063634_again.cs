using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork0603.Data.Migrations
{
    /// <inheritdoc />
    public partial class again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SourceId",
                table: "Payments",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Sources_SourceId",
                table: "Payments",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Sources_SourceId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_SourceId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Payments");
        }
    }
}
