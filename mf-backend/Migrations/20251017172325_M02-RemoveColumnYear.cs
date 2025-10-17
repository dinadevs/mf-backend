using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mf_backend.Migrations
{
    /// <inheritdoc />
    public partial class M02RemoveColumnYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
