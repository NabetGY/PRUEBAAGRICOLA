using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class LotesAndGrupos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_finca = table.Column<int>(type: "int", nullable: false),
                    arboles = table.Column<int>(type: "int", nullable: false),
                    etapa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lotes", x => x.id);
                    table.ForeignKey(
                        name: "fk_lotes_fincas_id_finca",
                        column: x => x.id_finca,
                        principalTable: "Fincas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_lote = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grupos", x => x.id);
                    table.ForeignKey(
                        name: "fk_grupos_lote_id_lote",
                        column: x => x.id_lote,
                        principalTable: "Lotes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_grupos_id_lote",
                table: "Grupos",
                column: "id_lote");

            migrationBuilder.CreateIndex(
                name: "ix_lotes_id_finca",
                table: "Lotes",
                column: "id_finca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Lotes");
        }
    }
}
