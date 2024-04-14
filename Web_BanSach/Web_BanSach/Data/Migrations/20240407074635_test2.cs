using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_BanSach.Data.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorMatacgia",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreTheloaiId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Books_BookMasach",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Nguoidung_UserMaKh",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfos_Nguoidung_NguoidungMaKh",
                table: "OrderInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookMasach",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Nguoidung_NguoidungMaKh",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookMasach",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_NguoidungMaKh",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_OrderInfos_NguoidungMaKh",
                table: "OrderInfos");

            migrationBuilder.DropIndex(
                name: "IX_Carts_BookMasach",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserMaKh",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorMatacgia",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenreTheloaiId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookMasach",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "NguoidungMaKh",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "NguoidungMaKh",
                table: "OrderInfos");

            migrationBuilder.DropColumn(
                name: "BookMasach",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserMaKh",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "AuthorMatacgia",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenreTheloaiId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MaKh",
                table: "Reviews",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Masach",
                table: "Reviews",
                column: "Masach");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_MaKh",
                table: "OrderInfos",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_MaKh",
                table: "Carts",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Masach",
                table: "Carts",
                column: "Masach");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TacgiaId",
                table: "Books",
                column: "TacgiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TheloaiId",
                table: "Books",
                column: "TheloaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_TacgiaId",
                table: "Books",
                column: "TacgiaId",
                principalTable: "Authors",
                principalColumn: "Matacgia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_TheloaiId",
                table: "Books",
                column: "TheloaiId",
                principalTable: "Genres",
                principalColumn: "TheloaiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Books_Masach",
                table: "Carts",
                column: "Masach",
                principalTable: "Books",
                principalColumn: "Masach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Nguoidung_MaKh",
                table: "Carts",
                column: "MaKh",
                principalTable: "Nguoidung",
                principalColumn: "MaKh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfos_Nguoidung_MaKh",
                table: "OrderInfos",
                column: "MaKh",
                principalTable: "Nguoidung",
                principalColumn: "MaKh",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_Masach",
                table: "Reviews",
                column: "Masach",
                principalTable: "Books",
                principalColumn: "Masach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Nguoidung_MaKh",
                table: "Reviews",
                column: "MaKh",
                principalTable: "Nguoidung",
                principalColumn: "MaKh",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_TacgiaId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_TheloaiId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Books_Masach",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Nguoidung_MaKh",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfos_Nguoidung_MaKh",
                table: "OrderInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_Masach",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Nguoidung_MaKh",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MaKh",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_Masach",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_OrderInfos_MaKh",
                table: "OrderInfos");

            migrationBuilder.DropIndex(
                name: "IX_Carts_MaKh",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_Masach",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Books_TacgiaId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_TheloaiId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookMasach",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NguoidungMaKh",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NguoidungMaKh",
                table: "OrderInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookMasach",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserMaKh",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorMatacgia",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreTheloaiId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookMasach",
                table: "Reviews",
                column: "BookMasach");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_NguoidungMaKh",
                table: "Reviews",
                column: "NguoidungMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_NguoidungMaKh",
                table: "OrderInfos",
                column: "NguoidungMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_BookMasach",
                table: "Carts",
                column: "BookMasach");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserMaKh",
                table: "Carts",
                column: "UserMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorMatacgia",
                table: "Books",
                column: "AuthorMatacgia");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreTheloaiId",
                table: "Books",
                column: "GenreTheloaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorMatacgia",
                table: "Books",
                column: "AuthorMatacgia",
                principalTable: "Authors",
                principalColumn: "Matacgia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreTheloaiId",
                table: "Books",
                column: "GenreTheloaiId",
                principalTable: "Genres",
                principalColumn: "TheloaiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Books_BookMasach",
                table: "Carts",
                column: "BookMasach",
                principalTable: "Books",
                principalColumn: "Masach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Nguoidung_UserMaKh",
                table: "Carts",
                column: "UserMaKh",
                principalTable: "Nguoidung",
                principalColumn: "MaKh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfos_Nguoidung_NguoidungMaKh",
                table: "OrderInfos",
                column: "NguoidungMaKh",
                principalTable: "Nguoidung",
                principalColumn: "MaKh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookMasach",
                table: "Reviews",
                column: "BookMasach",
                principalTable: "Books",
                principalColumn: "Masach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Nguoidung_NguoidungMaKh",
                table: "Reviews",
                column: "NguoidungMaKh",
                principalTable: "Nguoidung",
                principalColumn: "MaKh",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
