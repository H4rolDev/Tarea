using Main.Errors;
using DataBase.models;
using DataBase;
using DataBase.Table;
using Main.Store.extentions;
using Main.services;

namespace  Main.Store.services {
    public class PersonServiceDbImpl : IPersonService
    {
        private readonly MiDbContext _db;
        public PersonServiceDbImpl(MiDbContext db) {
            _db = db;
        }
        public Person Create(Person entity)
        {
            PersonaTable personaTable = entity.ToTable();
            _db.Personas.Add(personaTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = personaTable.Id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar esta Persona");
            }
        }

        public void Delete(int id)
        {
            PersonaTable? personaTable = _db.Personas.FirstOrDefault(r => r.Id == id && r.estado);
            if (personaTable == null) throw new MessageExeption("No se encontro la persona");
            //_db.roles.Remove(rolTable);
            personaTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Persona");
        }

        public List<Person> GetAll()
        {
            List<Person> roles = _db.Personas
                .Where(r => r.estado)
                .Select<PersonaTable, Person>(
                    rt => rt.ToModel()
                ).ToList();
            return roles;
        }

        public Person? GetById(int id)
        {
            PersonaTable? persona = _db.Personas
                .FirstOrDefault(r => r.Id == id && r.estado);
            if (persona == null) return null;
            return persona.ToModel();
        }

        public void Update(int id, Person body)
        {
            PersonaTable? persona = _db.Personas
                .FirstOrDefault(r => r.Id == id && r.estado);
            if (persona == null) throw new MessageExeption("No se encontro la Persona");
            persona.Nombre = body.Nombre;
            persona.Apellido = body.Apellido;
            persona.Correo = body.Correo;
            persona.Edad = body.Edad;
            persona.Telefono = body.Telefono;
            persona.estado = body.estado;


            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Persona");
        }
    }
}