using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IslemLoguTablosuEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IadeEdildi",
                table: "KitapOduncIslemleri");

            migrationBuilder.CreateTable(
                name: "IslemLoglari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IslemTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detaylar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslemLoglari", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IslemLoglari");

            migrationBuilder.AddColumn<bool>(
                name: "IadeEdildi",
                table: "KitapOduncIslemleri",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
