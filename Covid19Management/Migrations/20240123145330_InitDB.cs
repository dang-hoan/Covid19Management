using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covid19Management.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONGDAN",
                columns: table => new
                {
                    MaCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    CMND = table.Column<string>(type: "char(9)", maxLength: 9, nullable: false),
                    SoDienThoai = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONGDAN", x => x.MaCD);
                });

            migrationBuilder.CreateTable(
                name: "LOAIVACXIN",
                columns: table => new
                {
                    MaLoaiVX = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiVX = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NuocSX = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SoNgayTiemNhac = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIVACXIN", x => x.MaLoaiVX);
                });

            migrationBuilder.CreateTable(
                name: "LIEUVACXIN",
                columns: table => new
                {
                    MaLieuVX = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLo = table.Column<int>(type: "int", nullable: false),
                    VacxinTypeCode = table.Column<int>(type: "int", nullable: true),
                    NgaySanXuat = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIEUVACXIN", x => x.MaLieuVX);
                    table.ForeignKey(
                        name: "FK_LIEUVACXIN_LOAIVACXIN_VacxinTypeCode",
                        column: x => x.VacxinTypeCode,
                        principalTable: "LOAIVACXIN",
                        principalColumn: "MaLoaiVX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TIEMCHUNG",
                columns: table => new
                {
                    MaTC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacxinCode = table.Column<int>(type: "int", nullable: true),
                    CitizenCode = table.Column<int>(type: "int", nullable: true),
                    NgayTiemMui1 = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayDKTiemMui2 = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayTiemMui2 = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIEMCHUNG", x => x.MaTC);
                    table.ForeignKey(
                        name: "FK_TIEMCHUNG_CONGDAN_CitizenCode",
                        column: x => x.CitizenCode,
                        principalTable: "CONGDAN",
                        principalColumn: "MaCD");
                    table.ForeignKey(
                        name: "FK_TIEMCHUNG_LIEUVACXIN_VacxinCode",
                        column: x => x.VacxinCode,
                        principalTable: "LIEUVACXIN",
                        principalColumn: "MaLieuVX");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LIEUVACXIN_VacxinTypeCode",
                table: "LIEUVACXIN",
                column: "VacxinTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TIEMCHUNG_CitizenCode",
                table: "TIEMCHUNG",
                column: "CitizenCode");

            migrationBuilder.CreateIndex(
                name: "IX_TIEMCHUNG_VacxinCode",
                table: "TIEMCHUNG",
                column: "VacxinCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TIEMCHUNG");

            migrationBuilder.DropTable(
                name: "CONGDAN");

            migrationBuilder.DropTable(
                name: "LIEUVACXIN");

            migrationBuilder.DropTable(
                name: "LOAIVACXIN");
        }
    }
}
