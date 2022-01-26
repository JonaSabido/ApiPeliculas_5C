using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPeliculas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    idPelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Director = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Genero = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Puntuacion = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idPelicula", x => x.idPelicula);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pelicula");
        }
    }
}
