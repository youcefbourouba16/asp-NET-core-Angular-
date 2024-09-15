using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopingApi.Migrations
{
    /// <inheritdoc />
    public partial class v423942309 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ProductTypes_productTypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "productTypeId",
                table: "Items",
                newName: "ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_productTypeId",
                table: "Items",
                newName: "IX_Items_ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColors_Colors_ColorId",
                table: "ItemColors",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ProductTypes_ProductTypeId",
                table: "Items",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "typeName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemColors_Colors_ColorId",
                table: "ItemColors");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ProductTypes_ProductTypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Items",
                newName: "productTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ProductTypeId",
                table: "Items",
                newName: "IX_Items_productTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ProductTypes_productTypeId",
                table: "Items",
                column: "productTypeId",
                principalTable: "ProductTypes",
                principalColumn: "typeName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
