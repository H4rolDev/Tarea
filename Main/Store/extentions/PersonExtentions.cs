using DataBase.Table;
using DataBase.models;

namespace Main.Store.extentions
{
  public static class PersonExtentions {
    public static Person ToModel(this PersonaTable rt) {
      return new Person {
        Id = rt.Id,
        Nombre = rt.Nombre,
        Apellido = rt.Apellido,
        Correo = rt.Correo,
        Edad = rt.Edad,
        Telefono = rt.Telefono,
      };
    }

    public static PersonaTable ToTable(this Person r) {
      return new PersonaTable {
        Id = r.Id,
        Nombre = r.Nombre,
        Apellido = r.Apellido,
        Correo = r.Correo,
        Edad = r.Edad,
        Telefono = r.Telefono,
        estado = true
      };
    }
  }
}