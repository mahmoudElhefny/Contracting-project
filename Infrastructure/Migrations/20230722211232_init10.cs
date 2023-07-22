using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactIcons_ContactInfos_ContactInfoId",
                table: "ContactIcons");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_Contacts_ContactId",
                table: "ContactInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "ContactInfos",
                newName: "ContactInfo");

            migrationBuilder.RenameIndex(
                name: "IX_ContactInfos_ContactId",
                table: "ContactInfo",
                newName: "IX_ContactInfo_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactIcons_ContactInfo_ContactInfoId",
                table: "ContactIcons",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Contact_ContactId",
                table: "ContactInfo",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactIcons_ContactInfo_ContactInfoId",
                table: "ContactIcons");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Contact_ContactId",
                table: "ContactInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "ContactInfo",
                newName: "ContactInfos");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_ContactInfo_ContactId",
                table: "ContactInfos",
                newName: "IX_ContactInfos_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactIcons_ContactInfos_ContactInfoId",
                table: "ContactIcons",
                column: "ContactInfoId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Contacts_ContactId",
                table: "ContactInfos",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
