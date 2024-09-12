using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopingApi.Migrations
{
    /// <inheritdoc />
    public partial class v_fuckingIDK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemSizes_ItemID",
                table: "ItemSizes",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSizes_Items_ItemID",
                table: "ItemSizes",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSizes_Sizes_SizeID",
                table: "ItemSizes",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSizes_Items_ItemID",
                table: "ItemSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSizes_Sizes_SizeID",
                table: "ItemSizes");

            migrationBuilder.DropIndex(
                name: "IX_ItemSizes_ItemID",
                table: "ItemSizes");
        }
    }
}
