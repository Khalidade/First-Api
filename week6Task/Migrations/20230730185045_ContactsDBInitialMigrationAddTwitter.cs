using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace week6Task.Migrations
{
    /// <inheritdoc />
    public partial class ContactsDBInitialMigrationAddTwitter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Contacts");
        }
    }
}
