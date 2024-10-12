using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Table
{
    [Table("Persona")]
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido{get;set;}
        [Required]
        public string Correo{get;set;}
        [Required]
        public int Edad {get;set;}
        [Required]
        public int Telefono {get;set;}
    }
}
