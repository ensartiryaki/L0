using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Ilkdegisiklik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SonKullanmaTarihi = table.Column<DateTime>(type: "Date", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ParaBirimi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Aktiflik = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urunler");
        }
    }
}
