using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Events",
                newName: "ImageDetailEventPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageDetailEventPath",
                table: "Events",
                newName: "ImagePath");
        }
    }
}
