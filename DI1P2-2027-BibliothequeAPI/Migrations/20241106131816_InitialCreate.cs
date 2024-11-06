using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DI1P2_2027_BibliothequeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    maxBooks = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    isbn = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    publishdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    authorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.isbn);
                    table.ForeignKey(
                        name: "FK_book_author_authorId",
                        column: x => x.authorId,
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    statusId = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_status_statusId",
                        column: x => x.statusId,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "borrow",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookIsbn = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrow", x => x.id);
                    table.ForeignKey(
                        name: "FK_borrow_book_bookIsbn",
                        column: x => x.bookIsbn,
                        principalTable: "book",
                        principalColumn: "isbn",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_borrow_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_authorId",
                table: "book",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_borrow_bookIsbn",
                table: "borrow",
                column: "bookIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_borrow_userId",
                table: "borrow",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_statusId",
                table: "user",
                column: "statusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrow");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "status");
        }
    }
}
