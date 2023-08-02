using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace week6Task.Migrations
{
    /// <inheritdoc />
    public partial class InitialPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactsId");

            migrationBuilder.AddColumn<int>(
                name: "ContactsId1",
                table: "Contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 1,
                column: "ContactsId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 2,
                column: "ContactsId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 3,
                column: "ContactsId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 4,
                column: "ContactsId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactsId1",
                table: "Contacts",
                column: "ContactsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Contacts_ContactsId1",
                table: "Contacts",
                column: "ContactsId1",
                principalTable: "Contacts",
                principalColumn: "ContactsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Contacts_ContactsId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactsId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactsId1",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ContactsId",
                table: "Contacts",
                newName: "Id");
        }
    }
}
