using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_BanSach.Data.Migrations
{
    /// <inheritdoc />
    public partial class lan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Taikhoan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Matkhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Taikhoan);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Matacgia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tentacgia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieusuTg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Matacgia);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    TheloaiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.TheloaiId);
                });

            migrationBuilder.CreateTable(
                name: "Nguoidung",
                columns: table => new
                {
                    MaKh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taikhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matkhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenKh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoidung", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Masach = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tensach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheloaiId = table.Column<int>(type: "int", nullable: false),
                    TacgiaId = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: true),
                    Giatien = table.Column<int>(type: "int", nullable: false),
                    Ngayxuatban = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotaVesach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorMatacgia = table.Column<int>(type: "int", nullable: false),
                    GenreTheloaiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Masach);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorMatacgia",
                        column: x => x.AuthorMatacgia,
                        principalTable: "Authors",
                        principalColumn: "Matacgia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreTheloaiId",
                        column: x => x.GenreTheloaiId,
                        principalTable: "Genres",
                        principalColumn: "TheloaiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    Masach = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Giatien = table.Column<int>(type: "int", nullable: false),
                    Tongtien = table.Column<int>(type: "int", nullable: false),
                    UserMaKh = table.Column<int>(type: "int", nullable: false),
                    BookMasach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Books_BookMasach",
                        column: x => x.BookMasach,
                        principalTable: "Books",
                        principalColumn: "Masach",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Nguoidung_UserMaKh",
                        column: x => x.UserMaKh,
                        principalTable: "Nguoidung",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Masach = table.Column<int>(type: "int", nullable: false),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    Nhanxet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoidungMaKh = table.Column<int>(type: "int", nullable: false),
                    BookMasach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookMasach",
                        column: x => x.BookMasach,
                        principalTable: "Books",
                        principalColumn: "Masach",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Nguoidung_NguoidungMaKh",
                        column: x => x.NguoidungMaKh,
                        principalTable: "Nguoidung",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfos",
                columns: table => new
                {
                    MaDh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    HọTên = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<int>(type: "int", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoidungMaKh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfos", x => x.MaDh);
                    table.ForeignKey(
                        name: "FK_OrderInfos_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderInfos_Nguoidung_NguoidungMaKh",
                        column: x => x.NguoidungMaKh,
                        principalTable: "Nguoidung",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorMatacgia",
                table: "Books",
                column: "AuthorMatacgia");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreTheloaiId",
                table: "Books",
                column: "GenreTheloaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_BookMasach",
                table: "Carts",
                column: "BookMasach");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserMaKh",
                table: "Carts",
                column: "UserMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_CartId",
                table: "OrderInfos",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_NguoidungMaKh",
                table: "OrderInfos",
                column: "NguoidungMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookMasach",
                table: "Reviews",
                column: "BookMasach");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_NguoidungMaKh",
                table: "Reviews",
                column: "NguoidungMaKh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "OrderInfos");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Nguoidung");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
