using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddLabelAndNoteLabelTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    LabelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_Labels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteLabels",
                columns: table => new
                {
                    NoteLabelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteLabels", x => x.NoteLabelId);
                    table.ForeignKey(
                        name: "FK_NoteLabels_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "LabelId");
                    table.ForeignKey(
                        name: "FK_NoteLabels_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "NotesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_UserId",
                table: "Labels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteLabels_LabelId",
                table: "NoteLabels",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteLabels_NoteId",
                table: "NoteLabels",
                column: "NoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteLabels");

            migrationBuilder.DropTable(
                name: "Labels");
        }
    }
}
