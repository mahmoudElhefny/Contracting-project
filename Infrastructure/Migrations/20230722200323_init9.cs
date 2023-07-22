using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "titleAR",
                table: "Icon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "headerAR",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "desc1AR",
                table: "ContactInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "descAR",
                table: "ContactInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "subTitle1AR",
                table: "ContactInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "subTitle2AR",
                table: "ContactInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "titleAR",
                table: "ContactInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "titleAR",
                table: "ContactIcons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "titleAR",
                table: "Icon");

            migrationBuilder.DropColumn(
                name: "headerAR",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "desc1AR",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "descAR",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "subTitle1AR",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "subTitle2AR",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "titleAR",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "titleAR",
                table: "ContactIcons");
        }
    }
}
