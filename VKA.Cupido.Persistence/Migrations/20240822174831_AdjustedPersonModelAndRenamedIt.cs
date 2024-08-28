using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKA.Cupido.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedPersonModelAndRenamedIt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "WhenPaired",
                table: "Pairs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhenPaired",
                table: "Pairs");
        }
    }
}
