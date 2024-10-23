using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageSliderlPath",
                table: "Events",
                newName: "ImageSliderEventPath");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Events",
                newName: "ImageDetailEventPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageSliderEventPath",
                table: "Events",
                newName: "ImageSliderlPath");

            migrationBuilder.RenameColumn(
                name: "ImageDetailEventPath",
                table: "Events",
                newName: "ImagePath");
        }
    }
}
