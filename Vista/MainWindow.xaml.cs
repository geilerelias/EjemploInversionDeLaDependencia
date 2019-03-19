using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Collections;
using Vista.Datos;
using Vista.Dominio;

namespace EjemploInversionDeLaDependencia
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IProgreso
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Object> lista = new List<Object>();

        DataSet dataSet;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AbrirOpenfileDialog();
        }

        private void AbrirOpenfileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Workbook| *.xls",
                ValidateNames = true
            };
            if (ofd.ShowDialog() == true)
            {
                FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fs);
                //// reader.IsFirstRowAsColumnNames
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                dataSet = reader.AsDataSet(conf);
                comboBoxHoja.Items.Clear();
                foreach (DataTable dt in dataSet.Tables)
                {
                    comboBoxHoja.Items.Add(dt.TableName);
                }
                reader.Close();

            }
        }

        private void dataGridUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("No puedes editar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void cboSheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dataGrid.ItemsSource = null;
            //dataGrid.DataContext = null;
            progressBar.Value = 0;
            dataGrid.UpdateLayout();
            progressBar.UpdateLayout();
            dataGrid.ItemsSource = dataSet.Tables[comboBoxHoja.SelectedIndex].DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Visibility = System.Windows.Visibility.Visible;
            progressBar.Maximum = lista.Count();


            var logica = new EstudiantesLogica(this);

            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            foreach (var item in dataGrid.ItemsSource as IEnumerable)
            {
                DataRowView dataRowView = item as DataRowView;
                var nombre = dataRowView.Row[0];
                listaEstudiantes.Add(new Estudiante() { Identificacion = Int32.Parse(dataRowView.Row[0].ToString()), Nombre = dataRowView.Row[1].ToString(), Apellido = dataRowView.Row[2].ToString(), Programa = dataRowView.Row[3].ToString(), Email = dataRowView.Row[4].ToString() });
            }
            logica.Guardar(listaEstudiantes);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }

        public void Progreso()
        {
            progressBar.Value += 1;
            progressBar.UpdateLayout();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ReadWindow readWindow = new ReadWindow();
            readWindow.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            UniversidadWindow Window = new UniversidadWindow();
            Window.ShowDialog();
        }
    }


}
