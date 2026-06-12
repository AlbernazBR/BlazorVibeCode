using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoMotos2026.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motocicletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Familia = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cilindrada = table.Column<int>(type: "INTEGER", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 2026)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motocicletas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motocicletas");
        }
    }
}
