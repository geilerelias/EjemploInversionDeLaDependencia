using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class ControlEstudiantes
    {
        Estudiantes estudiantes= new Estudiantes();
        public void guardar(string Identificacion, string Nombre, string Apellido, string Programa, string Email)
        {
            estudiantes.GuardarEstudiante(new Estudiantes() { Identificacion = Identificacion, Nombres = Nombre, Apellidos = Apellido, Programa = Programa, Email = Email });
        }
    }
}
