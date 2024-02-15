using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edtech.Migrations
{
    /// <inheritdoc />
    public partial class removevideoatrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileVideo10",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo6",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo7",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo8",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo9",
                table: "Students2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo10",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo6",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo7",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo8",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo9",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
