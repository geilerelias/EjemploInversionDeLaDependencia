using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatoUniversidad
    {
        DatabaseEntities2 Database = new DatabaseEntities2();
        public bool Guardar(Universidad universidad)
        {
            Database.Universidad.Add(universidad);
            Database.SaveChangesAsync();
            Database.SaveChanges();
            return true;
        }

        public List<Universidad> MostrarDatos()
        {
            var query = (from e in Database.Universidad select e);
            return query.ToList();
        }
    }
}
