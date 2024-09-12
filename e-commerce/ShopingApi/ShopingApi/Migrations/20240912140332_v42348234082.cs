using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopingApi.Migrations
{
    /// <inheritdoc />
    public partial class v42348234082 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Items_ItemId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ItemId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Colors");

            migrationBuilder.CreateIndex(
                name: "IX_ItemColors_ItemID",
                table: "ItemColors",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColors_Items_ItemID",
                table: "ItemColors",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemColors_Items_ItemID",
                table: "ItemColors");

            migrationBuilder.DropIndex(
                name: "IX_ItemColors_ItemID",
                table: "ItemColors");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ItemId",
                table: "Colors",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Items_ItemId",
                table: "Colors",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
