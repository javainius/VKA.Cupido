using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKA.Cupido.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamContactsToPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Persons");

            // Other operations, if needed (e.g., renaming indexes or columns)
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Contacts");

            // Reverse other operations, if needed
        }
    }
}
