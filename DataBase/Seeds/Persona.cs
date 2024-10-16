using DataBase.Table;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Seeds
{
    public static class PersonaSeed
    {
        public static void SeedPersonas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonaTable>().HasData(
                new PersonaTable
                {
                    Id = 1,
                    Nombre = "Juan Carlos",
                    Apellido = "Perez",
                    Correo = "juancarlos.perez@example.com",
                    Edad = 35,
                    Telefono = 998765432,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 2,
                    Nombre = "Maria Luisa",
                    Apellido = "Garcia",
                    Correo = "marialuisa.garcia@example.com",
                    Edad = 28,
                    Telefono = 975342189,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 3,
                    Nombre = "Carlos Alberto",
                    Apellido = "Sánchez",
                    Correo = "carlos.sanchez@example.com",
                    Edad = 42,
                    Telefono = 964567321,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 4,
                    Nombre = "Ana Beatriz",
                    Apellido = "Rojas",
                    Correo = "ana.rojas@example.com",
                    Edad = 30,
                    Telefono = 953245678,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 5,
                    Nombre = "Pedro Enrique",
                    Apellido = "Flores",
                    Correo = "pedro.flores@example.com",
                    Edad = 50,
                    Telefono = 987654321,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 6,
                    Nombre = "Lucia Fernanda",
                    Apellido = "Torres",
                    Correo = "lucia.torres@example.com",
                    Edad = 22,
                    Telefono = 912345678,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 7,
                    Nombre = "Raul Andres",
                    Apellido = "Mendoza",
                    Correo = "raul.mendoza@example.com",
                    Edad = 40,
                    Telefono = 934567890,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 8,
                    Nombre = "Gabriela Patricia",
                    Apellido = "Quispe",
                    Correo = "gabriela.quispe@example.com",
                    Edad = 29,
                    Telefono = 923456789,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 9,
                    Nombre = "Fernando",
                    Apellido = "Chávez",
                    Correo = "fernando.chavez@example.com",
                    Edad = 34,
                    Telefono = 921345678,
                    estado = true,
                },
                new PersonaTable
                {
                    Id = 10,
                    Nombre = "Isabel Cristina",
                    Apellido = "Vargas",
                    Correo = "isabel.vargas@example.com",
                    Edad = 27,
                    Telefono = 918765432,
                    estado = true,
                }
            );
        }
    }
}
