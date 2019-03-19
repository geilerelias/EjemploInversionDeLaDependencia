using Datos;
using Negocio;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Precentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NegocioUniversidad NegocioUniversidad = new NegocioUniversidad();
        Universidad Universidad = new Universidad();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void Guardar()
        {
            Universidad.Id = Convert.ToInt32(TextBoxCodigo.Text);
            Universidad.Nombre = TextBoxNombre.Text;
            Universidad.Correo = "universidad@universidad.edu.co";
            Universidad.Telefono = "123456789";
            Universidad.Direccion = "puertocolombia";
            NegocioUniversidad.Guardar(Universidad);
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }
    }
}
