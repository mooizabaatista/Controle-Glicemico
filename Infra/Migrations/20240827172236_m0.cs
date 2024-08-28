using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GliceControl.Infra.Migrations
{
    /// <inheritdoc />
    public partial class m0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControleGlicemico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorGlicemico = table.Column<int>(type: "INTEGER", nullable: false),
                    Periodo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleGlicemico", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleGlicemico");
        }
    }
}
