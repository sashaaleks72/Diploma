using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    WarrantyInMonths = table.Column<int>(type: "int", nullable: false),
                    CatalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_CatalogItems_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "Id", "ImgUrl", "RouteName", "Title" },
                values: new object[] { 1, "https://content1.rozetka.com.ua/goods/images/big_tile/267792323.jpg", "teapots", "Teapots" });

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "Id", "ImgUrl", "RouteName", "Title" },
                values: new object[] { 2, "https://content.rozetka.com.ua/goods/images/big_tile/160433459.jpg", "coffee-machines", "Coffee machines" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Capacity", "CatalogId", "Description", "ImgUrl", "ManufacturerCountry", "Price", "Quantity", "Title", "WarrantyInMonths" },
                values: new object[,]
                {
                    { new Guid("3b7daba0-c1bb-4c7a-bf8b-ad0111c02f25"), 1.7, 1, "Safety in 3 dimensions: automatic shutdown, protection against leakage and overheating, LED indication.", "https://content.rozetka.com.ua/goods/images/big_tile/10648417.jpg", "China", 1199.0, 8, "Teapot BOSCH TWK3A013", 12 },
                    { new Guid("f6da9012-e106-40b5-a7ad-a711b5e770b6"), 12.0, 2, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/167686386.jpg", "China", 4179.0, 8, "Coffee machine 8", 6 },
                    { new Guid("febc511b-d5d6-472e-a072-3bdf02374aa9"), 12.0, 2, "Good teapot", "https://content1.rozetka.com.ua/goods/images/big_tile/160843463.jpg", "China", 3599.0, 10, "Coffee machine 7", 24 },
                    { new Guid("2fc6639a-b7c7-42e5-b88b-d19a95b5a745"), 12.0, 2, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/45610581.jpg", "China", 2359.0, 9, "Coffee machine 6", 30 },
                    { new Guid("0c865983-1b3f-4f1c-b0c0-a9e5b82c7b2f"), 12.0, 2, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/76717007.jpg", "China", 1989.0, 3, "Coffee machine 5", 6 },
                    { new Guid("06b0ba5a-56b7-47dc-af62-16eb11d68dea"), 12.0, 2, "Good teapot", "https://content2.rozetka.com.ua/goods/images/big_tile/160392353.jpg", "China", 1899.0, 17, "Coffee machine 4", 12 },
                    { new Guid("320a3fee-513d-4cb2-82d2-94ad9994d572"), 12.0, 2, "Good teapot", "https://content2.rozetka.com.ua/goods/images/big_tile/29270053.jpg", "China", 2379.0, 5, "Coffee machine 3", 18 },
                    { new Guid("03dab1ef-89c9-42d4-bb86-d454dcfc0091"), 12.0, 2, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/15790055.jpg", "China", 1579.0, 3, "Coffee machine 2", 24 },
                    { new Guid("0d370839-1c27-420a-a0dc-acc41c83d70e"), 12.0, 2, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/160433459.jpg", "China", 2229.0, 9, "Coffee machine 1", 12 },
                    { new Guid("de581a5b-949a-49eb-9a43-262223877d9a"), 1.5, 1, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/163131692.jpg", "China", 2229.0, 9, "Teapot 12", 12 },
                    { new Guid("4602ed5e-80e0-4a6a-ba6b-2c11f7f7c45c"), 1.5, 1, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/142971427.jpg", "China", 2899.0, 9, "Teapot 11", 12 },
                    { new Guid("64e4e7a5-54f1-4d84-8573-8bf2474ccfd1"), 1.5, 1, "Good teapot", "https://content1.rozetka.com.ua/goods/images/big_tile/81865256.jpg", "China", 2399.0, 9, "Teapot 10", 12 },
                    { new Guid("9e3b080d-9c82-4da8-a80e-24e7815701b6"), 1.5, 1, "Good teapot", "https://content1.rozetka.com.ua/goods/images/big_tile/10626237.jpg", "China", 1599.0, 9, "Teapot 9", 12 },
                    { new Guid("275f2900-9149-49f3-9df8-f986a16fda46"), 1.5, 1, "Good teapot", "https://content1.rozetka.com.ua/goods/images/big_tile/283417981.png", "China", 1469.0, 9, "Teapot 8", 12 },
                    { new Guid("b4d33b5c-0d83-42e4-a5df-1d70f11d15a7"), 1.5, 1, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/14708920.jpg", "China", 1399.0, 9, "Teapot 7", 12 },
                    { new Guid("eef985a1-fc8c-4133-b62b-137d071f263f"), 1.5, 1, "With the AENO EK4 electric kettle, you can boil water in just 5 minutes and have time to prepare tea or coffee for the arrival of guests.", "https://content2.rozetka.com.ua/goods/images/big_tile/248635439.jpg", "China", 1099.0, 9, "Teapot AENO EK4", 24 },
                    { new Guid("82ebd8a1-5ac3-4a5a-9b56-8152568c23e2"), 1.7, 1, "With keep warm function; fast, safe boiling; easy to fill, use and clean", "https://content2.rozetka.com.ua/goods/images/big_tile/274310222.jpg", "China", 2399.0, 7, "Teapot Philips Viva Collection HD9355/92", 24 },
                    { new Guid("77d96428-f409-4946-887d-dcb64cb6a1f7"), 1.7, 1, "Prepare hot drinks in no time with 2200W of power", "https://content1.rozetka.com.ua/goods/images/big_tile/267792323.jpg", "China", 2349.0, 13, "Teapot Philips Eco HD9365/10", 24 },
                    { new Guid("3771da17-3589-477d-bb44-c45a2b318142"), 1.7, 1, "Safety in 3 dimensions: automatic shutdown, protection against leakage and overheating, LED indication.", "https://content1.rozetka.com.ua/goods/images/big_tile/19966325.jpg", "China", 2299.0, 7, "Teapot BOSCH TWK3P423", 24 },
                    { new Guid("3b77a34c-ab3a-4af1-87f1-ebc82b7e6720"), 1.7, 1, "Inspired by traditional British ceramics, the Loft teapot's stunning fluted lines are elegantly paired with modern chrome accents for a timeless design that looks great in any kitchen.", "https://content1.rozetka.com.ua/goods/images/big_tile/64732971.jpg", "China", 1299.0, 12, "Teapot TEFAL LOFT KO250830", 24 },
                    { new Guid("112fe116-9364-45eb-8cb2-b7f3c4b59a35"), 12.0, 2, "Good teapot", "https://content.rozetka.com.ua/goods/images/big_tile/13821301.jpg", "China", 1789.0, 5, "Coffee machine 9", 24 },
                    { new Guid("aa4115ff-61c4-43a7-802a-33b093fbdbb1"), 12.0, 2, "Good teapot", "https://content2.rozetka.com.ua/goods/images/big_tile/11675316.jpg", "China", 6789.0, 7, "Coffee machine 10", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatalogId",
                table: "Products",
                column: "CatalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CatalogItems");
        }
    }
}
