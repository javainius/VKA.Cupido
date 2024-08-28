using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKA.Cupido.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeNameOfColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Rename the columns in the 'Pairs' table
            migrationBuilder.RenameColumn(
                name: "FirstPersonId",
                table: "Pairs",
                newName: "FirstPersonId");

            migrationBuilder.RenameColumn(
                name: "SecondPersonId",
                table: "Pairs",
                newName: "SecondPersonId");

            // Rename the indexes, if they exist
            migrationBuilder.RenameIndex(
                name: "IX_Pairs_FirstPersonId",
                table: "Pairs",
                newName: "IX_Pairs_FirstPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Pairs_SecondPersonId",
                table: "Pairs",
                newName: "IX_Pairs_SecondPersonId");

            // Optionally, rename foreign key constraints if their names changed
            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Contacts_FirstPersonId",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Contacts_SecondPersonId",
                table: "Pairs");

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Persons_FirstPersonId",
                table: "Pairs",
                column: "FirstPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Persons_SecondPersonId",
                table: "Pairs",
                column: "SecondPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverse the column renames
            migrationBuilder.RenameColumn(
                name: "FirstPersonId",
                table: "Pairs",
                newName: "FirstPersonId");

            migrationBuilder.RenameColumn(
                name: "SecondPersonId",
                table: "Pairs",
                newName: "SecondPersonId");

            // Reverse the index renames
            migrationBuilder.RenameIndex(
                name: "IX_Pairs_FirstPersonId",
                table: "Pairs",
                newName: "IX_Pairs_FirstPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Pairs_SecondPersonId",
                table: "Pairs",
                newName: "IX_Pairs_SecondPersonId");

            // Reverse the foreign key constraints if necessary
            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Persons_FirstPersonId",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Persons_SecondPersonId",
                table: "Pairs");

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Contacts_FirstPersonId",
                table: "Pairs",
                column: "FirstPersonId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Contacts_SecondPersonId",
                table: "Pairs",
                column: "SecondPersonId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
