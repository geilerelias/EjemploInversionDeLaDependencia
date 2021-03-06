//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;

    public partial class Estudiante
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Programa { get; set; }
        public string Email { get; set; }

        public Estudiante()
        {
        }

        public Estudiante(int identificacion, string nombre, string apellido, string programa, string email)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Apellido = apellido;
            Programa = programa;
            Email = email;
        }

        public int guardar(Estudiante estudiante)
        {
            EstudiantesDatabaseEntities Db = new EstudiantesDatabaseEntities();
            Db.Estudiante.Add(estudiante);
            Db.SaveChanges();
            return 1;
        }
    }
}
