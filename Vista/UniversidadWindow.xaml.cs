
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
using Vista.Datos;
using Vista.Dominio;

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
            DatabaseEntities database = new DatabaseEntities();
            database.Universidad.Add(Universidad);
            //NegocioUniversidad.Guardar(Universidad);
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
