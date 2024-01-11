using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Topic", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Auteur1", "Article1", new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4693), "Theme1", new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4744) },
                    { 2, "Auteur2", "Article2", new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4747), "Theme2", new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4748) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Auteur1", "Commentaire1.1", new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4752), 1, new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4754) },
                    { 2, "Auteur1", "Commentaire1.2", new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4756), 1, new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4757) },
                    { 3, "Auteur2", "Commentaire2.1", new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4759), 2, new DateTime(2024, 1, 11, 19, 17, 22, 854, DateTimeKind.Local).AddTicks(4761) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
