using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryAPI.Migrations
{
    public partial class InitialSeedMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "AvailableQuantity", "Category", "Description", "Discount", "Image", "Price", "ProductName", "SpecialTag", "Specification" },
                values: new object[,]
                {
                    { 1, 0, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/spring roll.jpg", 7.9900000000000002, "Spring Roll", "", null },
                    { 2, 0, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/idli.jpg", 8.9900000000000002, "Idli", "", null },
                    { 3, 0, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/pani puri.jpg", 8.9900000000000002, "Panu Puri", "Best Seller", null },
                    { 4, 0, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/hakka noodles.jpg", 10.99, "Hakka Noodles", "", null },
                    { 5, 0, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/malai kofta.jpg", 12.99, "Malai Kofta", "Top Rated", null },
                    { 6, 0, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/paneer pizza.jpg", 11.99, "Paneer Pizza", "", null },
                    { 7, 0, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/paneer tikka.jpg", 13.99, "Paneer Tikka", "Chef's Special", null },
                    { 8, 0, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/carrot love.jpg", 4.9900000000000002, "Carrot Love", "", null },
                    { 9, 0, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/rasmalai.jpg", 4.9900000000000002, "Rasmalai", "Chef's Special", null },
                    { 10, 0, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", 0m, "https://temp.blob.core.windows.net/redmango/sweet rolls.jpg", 3.9900000000000002, "Sweet Rolls", "Top Rated", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
