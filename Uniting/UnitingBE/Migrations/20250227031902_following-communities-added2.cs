using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitingBE.Migrations
{
    /// <inheritdoc />
    public partial class followingcommunitiesadded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesFollowed_AspNetUsers_AppUserId",
                table: "CommunitiesFollowed");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesFollowed_communities_CommunityId",
                table: "CommunitiesFollowed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunitiesFollowed",
                table: "CommunitiesFollowed");

            migrationBuilder.RenameTable(
                name: "CommunitiesFollowed",
                newName: "communitiesFolloweds");

            migrationBuilder.RenameIndex(
                name: "IX_CommunitiesFollowed_CommunityId",
                table: "communitiesFolloweds",
                newName: "IX_communitiesFolloweds_CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunitiesFollowed_AppUserId",
                table: "communitiesFolloweds",
                newName: "IX_communitiesFolloweds_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_communitiesFolloweds",
                table: "communitiesFolloweds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_communitiesFolloweds_AspNetUsers_AppUserId",
                table: "communitiesFolloweds",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_communitiesFolloweds_communities_CommunityId",
                table: "communitiesFolloweds",
                column: "CommunityId",
                principalTable: "communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_communitiesFolloweds_AspNetUsers_AppUserId",
                table: "communitiesFolloweds");

            migrationBuilder.DropForeignKey(
                name: "FK_communitiesFolloweds_communities_CommunityId",
                table: "communitiesFolloweds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_communitiesFolloweds",
                table: "communitiesFolloweds");

            migrationBuilder.RenameTable(
                name: "communitiesFolloweds",
                newName: "CommunitiesFollowed");

            migrationBuilder.RenameIndex(
                name: "IX_communitiesFolloweds_CommunityId",
                table: "CommunitiesFollowed",
                newName: "IX_CommunitiesFollowed_CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_communitiesFolloweds_AppUserId",
                table: "CommunitiesFollowed",
                newName: "IX_CommunitiesFollowed_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunitiesFollowed",
                table: "CommunitiesFollowed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesFollowed_AspNetUsers_AppUserId",
                table: "CommunitiesFollowed",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesFollowed_communities_CommunityId",
                table: "CommunitiesFollowed",
                column: "CommunityId",
                principalTable: "communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
