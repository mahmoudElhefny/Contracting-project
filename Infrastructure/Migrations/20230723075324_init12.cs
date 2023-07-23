using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutPage_Section_SectionId",
                table: "AboutPage");

            migrationBuilder.DropIndex(
                name: "IX_AboutPage_SectionId",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "AboutPage");

            migrationBuilder.AddColumn<int>(
                name: "AboutPageId",
                table: "Section",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Section_AboutPageId",
                table: "Section",
                column: "AboutPageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section",
                column: "AboutPageId",
                principalTable: "AboutPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_AboutPageId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "AboutPageId",
                table: "Section");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "AboutPage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AboutPage_SectionId",
                table: "AboutPage",
                column: "SectionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutPage_Section_SectionId",
                table: "AboutPage",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
