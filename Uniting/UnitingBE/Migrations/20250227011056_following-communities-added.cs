using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitingBE.Migrations
{
    /// <inheritdoc />
    public partial class followingcommunitiesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_AspNetUsers_AppUserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_posts_PostId",
                table: "Bookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.RenameTable(
                name: "Bookmarks",
                newName: "bookmarks");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_PostId",
                table: "bookmarks",
                newName: "IX_bookmarks_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_AppUserId",
                table: "bookmarks",
                newName: "IX_bookmarks_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookmarks",
                table: "bookmarks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommunitiesFollowed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunitiesFollowed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunitiesFollowed_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommunitiesFollowed_communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesFollowed_AppUserId",
                table: "CommunitiesFollowed",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesFollowed_CommunityId",
                table: "CommunitiesFollowed",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookmarks_AspNetUsers_AppUserId",
                table: "bookmarks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookmarks_posts_PostId",
                table: "bookmarks",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookmarks_AspNetUsers_AppUserId",
                table: "bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_bookmarks_posts_PostId",
                table: "bookmarks");

            migrationBuilder.DropTable(
                name: "CommunitiesFollowed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookmarks",
                table: "bookmarks");

            migrationBuilder.RenameTable(
                name: "bookmarks",
                newName: "Bookmarks");

            migrationBuilder.RenameIndex(
                name: "IX_bookmarks_PostId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_bookmarks_AppUserId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_AspNetUsers_AppUserId",
                table: "Bookmarks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_posts_PostId",
                table: "Bookmarks",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
