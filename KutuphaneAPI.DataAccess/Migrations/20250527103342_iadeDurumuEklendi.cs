using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class iadeDurumuEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IadeEdildi",
                table: "KitapOduncIslemleri",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IadeEdildi",
                table: "KitapOduncIslemleri");
        }
    }
}
