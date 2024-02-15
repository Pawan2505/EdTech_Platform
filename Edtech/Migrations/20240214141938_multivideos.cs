using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edtech.Migrations
{
    /// <inheritdoc />
    public partial class multivideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileVideo",
                table: "Students2",
                newName: "ProfileVideo9");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo1",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo10",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo2",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo3",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo4",
                table: "Students2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileVideo5",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileVideo1",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo10",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo2",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo3",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo4",
                table: "Students2");

            migrationBuilder.DropColumn(
                name: "ProfileVideo5",
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

            migrationBuilder.RenameColumn(
                name: "ProfileVideo9",
                table: "Students2",
                newName: "ProfileVideo");
        }
    }
}
