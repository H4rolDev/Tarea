namespace DataBase.models
{
    public class Person
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public bool estado { get; set; }
    }
    public class PersonBody
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public static implicit operator Person(PersonBody rb) {
            if (rb == null) return null;
            return new Person {
                Id = 0,
                Nombre = rb.Nombre,
                Apellido = rb.Apellido,
                Correo = rb.Correo,
                Edad = rb.Edad,
                Telefono = rb.Telefono,
                estado = true,
            };
        }
    }
}