

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
    /// Lógica de interacción para RegisterPage.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        EstudiantesLogica estudiantesLogica = new EstudiantesLogica();


        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var result = estudiantesLogica.guardar(new Estudiante(TextBoxIdentificacion.Text, TextBoxNombre.Text, TextBoxApellido.Text, ComboBoxPrograma.Text, TextBoxEmail.Text));
            //MessageBox.Show(result.mensage, "Guardando regsitros", MessageBoxButton.OK, result.imagenIcono);
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Estudiante estudiante = new Estudiante() { Identificacion = Int32.Parse(TextBoxIdentificacion.Text), Nombre = TextBoxNombre.Text, Apellido = TextBoxApellido.Text, Programa = ComboBoxPrograma.Text, Email = TextBoxEmail.Text };
            var result = estudiantesLogica.Guardar(estudiante);
            MessageBox.Show(result.Mensage, "Guardando regsitros", MessageBoxButton.OK, (result.ImagenIcono=="Error")?MessageBoxImage.Error:MessageBoxImage.Information);
        }
    }
}
