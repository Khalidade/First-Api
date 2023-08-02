using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace week6Task.Migrations
{
    /// <inheritdoc />
    public partial class ContactsDBSeededMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Name", "PhoneNumber", "PhotoUrl", "Twitter" },
                values: new object[,]
                {
                    { 1, "lekki", "Khalid", 8023932313L, "img.jpg", "senkou" },
                    { 2, "Ibadan", "james", 8023932313L, "img.jpg", "kiroii" },
                    { 3, "Abuja", "Javier", 8023932313L, "img.jpg", "Bgard" },
                    { 4, "Ondo", "David", 8023932313L, "img.jpg", "davido" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
