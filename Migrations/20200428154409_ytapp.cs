using Microsoft.EntityFrameworkCore.Migrations;

namespace mattaudio.Migrations
{
    public partial class ytapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoID",
                table: "Track",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoID",
                table: "Track");
        }
    }
}
