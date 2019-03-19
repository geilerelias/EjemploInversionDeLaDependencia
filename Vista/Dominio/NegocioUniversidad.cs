
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista.Datos;

namespace Vista.Dominio
{
    public class NegocioUniversidad
    {
        Universidad DatoUniversidad = new Universidad();
        public bool Guardar(Universidad universidad)
        {
            return DatoUniversidad.Guardar(universidad);
        }

        public List<Universidad> MostrarDatos()
        {
            DatabaseEntities databaseEntities = new DatabaseEntities();
            return databaseEntities.Universidad.ToList();
        }
    }
}
