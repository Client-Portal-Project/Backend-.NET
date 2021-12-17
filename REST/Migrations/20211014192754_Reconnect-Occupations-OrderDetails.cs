using Microsoft.EntityFrameworkCore.Migrations;

namespace REST.Migrations
{
    public partial class ReconnectOccupationsOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OccupationsOccupationId",
                table: "OrderDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OccupationsOccupationId",
                table: "OrderDetails",
                column: "OccupationsOccupationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Occupations_OccupationsOccupationId",
                table: "OrderDetails",
                column: "OccupationsOccupationId",
                principalTable: "Occupations",
                principalColumn: "OccupationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Occupations_OccupationsOccupationId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OccupationsOccupationId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OccupationsOccupationId",
                table: "OrderDetails");
        }
    }
}
