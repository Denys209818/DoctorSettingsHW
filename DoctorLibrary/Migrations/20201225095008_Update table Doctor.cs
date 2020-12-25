using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorLibrary.DAL.Migrations
{
    public partial class UpdatetableDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "tblDoctors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "tblDoctors",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "tblDoctors",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "tblDoctors");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "tblDoctors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "tblDoctors");
        }
    }
}
