using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioUniversidad
    {
        DatoUniversidad DatoUniversidad = new DatoUniversidad();
        public bool Guardar(Universidad universidad)
        {
            return DatoUniversidad.Guardar(universidad);
        }

        public List<Universidad> MostrarDatos()
        {
            return DatoUniversidad.MostrarDatos();
        }
    }
}
