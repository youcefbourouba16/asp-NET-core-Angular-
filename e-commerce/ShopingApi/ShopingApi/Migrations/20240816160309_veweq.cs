using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopingApi.Migrations
{
    /// <inheritdoc />
    public partial class veweq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    typeName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.typeName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatName);
                });
        }
    }
}
