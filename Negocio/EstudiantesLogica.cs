using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Datos;


namespace Negocio
{
    public class EstudiantesLogica
    {

        IProgreso progresBar;

        public EstudiantesLogica()
        {
        }

        public EstudiantesLogica(IProgreso _progresBar)
        {
            progresBar = _progresBar;
        }

        public Response Guardar(List<Estudiante> listaEstudiante)
        {
            Estudiante estudiante = new Estudiante();
            foreach (Estudiante item in listaEstudiante)
            {

                try
                {
                    if (estudiante.guardar(item) > 0)
                    {
                        progresBar.Progreso();
                    }
                    else
                    {
                        return new Response() { ImagenIcono = "Error", Mensage = "Error al guardar Los datos" };
                    }
                }
                catch (Exception ex)
                {
                    return new Response() { ImagenIcono = "Error", Mensage = $"Error: {ex} " };
                }


            }
            return new Response() { ImagenIcono = "Information", Mensage = "Datos Guardados con exito" };
        }



        public Response Guardar(Estudiante _estudiante)
        {
            Estudiante Estudiante = new Estudiante();

            if (Estudiante.guardar(_estudiante) > 0)
            {
                return new Response() { ImagenIcono = "Information", Mensage = "Datos Guardados con exito" };
            }
            else
            {
                return new Response() { ImagenIcono = "Error", Mensage = "Error al guardar Los datos" };
            }
        }


        public Estudiante Consultar(int numeroDocumento)
        {
            DatabaseEntities2 Db = new DatabaseEntities2();
            return Db.Estudiante.Find(numeroDocumento);
        }
    }
    public class Response
    {
        public string ImagenIcono { get; set; }
        public string Mensage { get; set; }

    }
}
