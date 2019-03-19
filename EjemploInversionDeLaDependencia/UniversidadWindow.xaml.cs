using EjemploInversionDeLaDependencia.Datos;
using EjemploInversionDeLaDependencia.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace EjemploInversionDeLaDependencia
{
    /// <summary>
    /// Lógica de interacción para UniversidadWindow.xaml
    /// </summary>
    public partial class UniversidadWindow : Window
    {
        public UniversidadWindow()
        {
            InitializeComponent();
        }

        NegocioUniversidad NegocioUniversidad = new NegocioUniversidad();
        Universidad Universidad ;
        DatabaseEntities database = new DatabaseEntities();
        public void Guardar()
        {
            Universidad = new Universidad
            {
                Id = Convert.ToInt32(TextBoxCodigo.Text),
                Nombre = TextBoxNombre.Text,
                Correo = "universidad@universidad.edu.co",
                Telefono = "123456789",
                Direccion = "puertocolombia"
            };
            
            database.Universidad.Add(Universidad);
            CargarDataGrid();
            //NegocioUniversidad.Guardar(Universidad);
        }

        private void CargarDataGrid()
        {
            DataGridUniversidad.DataContext = database.Universidad.ToList();
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CargarDataGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
