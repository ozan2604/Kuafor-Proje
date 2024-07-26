using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminŞifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hizmets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HizmetAdı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Detay = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizmets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İletişims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İletişimNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    İletişimMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İletişims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kuaför",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KuaförName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KuaförTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kuaför", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Müşteri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MüşteriName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MüşteriTelNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MüşteriMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MüşteriŞifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Müşteri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yorums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YorumDetay = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    YorumTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervasyonTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Müşteri_Id = table.Column<int>(type: "int", nullable: false),
                    Kuaför_Id = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervasyons_Kuaför_Kuaför_Id",
                        column: x => x.Kuaför_Id,
                        principalTable: "Kuaför",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervasyons_Müşteri_Müşteri_Id",
                        column: x => x.Müşteri_Id,
                        principalTable: "Müşteri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyons_Kuaför_Id",
                table: "Rezervasyons",
                column: "Kuaför_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyons_Müşteri_Id",
                table: "Rezervasyons",
                column: "Müşteri_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Hizmets");

            migrationBuilder.DropTable(
                name: "İletişims");

            migrationBuilder.DropTable(
                name: "Rezervasyons");

            migrationBuilder.DropTable(
                name: "Yorums");

            migrationBuilder.DropTable(
                name: "Kuaför");

            migrationBuilder.DropTable(
                name: "Müşteri");
        }
    }
}
