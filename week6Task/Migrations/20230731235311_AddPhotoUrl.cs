using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace week6Task.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 1,
                column: "PhotoUrl",
                value: "img.jpg");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 2,
                column: "PhotoUrl",
                value: "img.jpg");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 3,
                column: "PhotoUrl",
                value: "img.jpg");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 4,
                column: "PhotoUrl",
                value: "img.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Contacts");
        }
    }
}
