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
using Hotel.BIZ;
using Hotel.COMMON.Interfaces;
using Hotel.DAL;
using Hotel.COMMON.Entidades;

namespace Hotel.GUI.Registros
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorContraseñaRegistro manejadorContraseñaRegistro;

        public MainWindow()
        {
            InitializeComponent();
            manejadorContraseñaRegistro = new ManejadorContraseñaRegistro(new RepositorioGenerico<ContraseñaRegistro>());
            cmbUsuario.ItemsSource = null;
            cmbUsuario.ItemsSource = manejadorContraseñaRegistro.Listar;
        }

        private void btnIniciarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbUsuario.Text == "")

                {
                    MessageBox.Show("No ha seleccionado su usuario", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                if (string.IsNullOrEmpty(Contraseña.Password))
                {
                    MessageBox.Show("Aun no a ingresado la contraseña", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (cmbUsuario.SelectedItem != null)

                {
                    ContraseñaRegistro b = cmbUsuario.SelectedItem as ContraseñaRegistro;
                    if (Contraseña.Password == b.Contraseña)
                    {
                        MenuO ir = new MenuO();
                        ir.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contraceña incorrecta", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No a  seleccionado ningun usuario", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }

        private void btnCancelarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            Contraseña.Clear();

        }
    }
}
