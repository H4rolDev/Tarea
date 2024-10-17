using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Correo", "Edad", "Nombre", "Telefono", "estado" },
                values: new object[,]
                {
                    { 1, "Perez", "juancarlos.perez@example.com", 35, "Juan Carlos", 998765432, true },
                    { 2, "Garcia", "marialuisa.garcia@example.com", 28, "Maria Luisa", 975342189, true },
                    { 3, "Sánchez", "carlos.sanchez@example.com", 42, "Carlos Alberto", 964567321, true },
                    { 4, "Rojas", "ana.rojas@example.com", 30, "Ana Beatriz", 953245678, true },
                    { 5, "Flores", "pedro.flores@example.com", 50, "Pedro Enrique", 987654321, true },
                    { 6, "Torres", "lucia.torres@example.com", 22, "Lucia Fernanda", 912345678, true },
                    { 7, "Mendoza", "raul.mendoza@example.com", 40, "Raul Andres", 934567890, true },
                    { 8, "Quispe", "gabriela.quispe@example.com", 29, "Gabriela Patricia", 923456789, true },
                    { 9, "Chávez", "fernando.chavez@example.com", 34, "Fernando", 921345678, true },
                    { 10, "Vargas", "isabel.vargas@example.com", 27, "Isabel Cristina", 918765432, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
