using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopingApi.Migrations
{
    /// <inheritdoc />
    public partial class v_4230942394230 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Items_ItemId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ItemId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Sizes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ItemId",
                table: "Sizes",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Items_ItemId",
                table: "Sizes",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
