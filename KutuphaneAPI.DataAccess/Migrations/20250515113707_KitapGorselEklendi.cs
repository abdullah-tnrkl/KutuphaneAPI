using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class KitapGorselEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "GorselVerisi",
                table: "Kitaplar",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GorselVerisi",
                table: "Kitaplar");
        }
    }
}
