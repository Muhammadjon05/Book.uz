using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.uz.Migrations
{
    /// <inheritdoc />
    public partial class InitialDdssxa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsAuthorId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BooksBookId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderUser_Orders_OrderId",
                table: "OrderUser");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderUser_Users_UsersUserId",
                table: "OrderUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderUser",
                table: "OrderUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.RenameTable(
                name: "OrderUser",
                newName: "UserOrder");

            migrationBuilder.RenameTable(
                name: "AuthorBook",
                newName: "BookAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_OrderUser_UsersUserId",
                table: "UserOrder",
                newName: "IX_UserOrder_UsersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BooksBookId",
                table: "BookAuthors",
                newName: "IX_BookAuthors_BooksBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrder",
                table: "UserOrder",
                columns: new[] { "OrderId", "UsersUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_AuthorsAuthorId",
                table: "BookAuthors",
                column: "AuthorsAuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_BooksBookId",
                table: "BookAuthors",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrder_Orders_OrderId",
                table: "UserOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrder_Users_UsersUserId",
                table: "UserOrder",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_AuthorsAuthorId",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_BooksBookId",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrder_Orders_OrderId",
                table: "UserOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrder_Users_UsersUserId",
                table: "UserOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrder",
                table: "UserOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.RenameTable(
                name: "UserOrder",
                newName: "OrderUser");

            migrationBuilder.RenameTable(
                name: "BookAuthors",
                newName: "AuthorBook");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrder_UsersUserId",
                table: "OrderUser",
                newName: "IX_OrderUser_UsersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_BooksBookId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BooksBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderUser",
                table: "OrderUser",
                columns: new[] { "OrderId", "UsersUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsAuthorId",
                table: "AuthorBook",
                column: "AuthorsAuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BooksBookId",
                table: "AuthorBook",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderUser_Orders_OrderId",
                table: "OrderUser",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderUser_Users_UsersUserId",
                table: "OrderUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
