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

namespace Hotel.GUI.Administracion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorContraseñaAdministrar manejadorContraseñaAdministrar;

        public MainWindow()
        {
            InitializeComponent();
            manejadorContraseñaAdministrar = new ManejadorContraseñaAdmistracion(new RepositorioGenerico<ContraseñaAdministrador>());
            cmbUsuario.ItemsSource = null;
            cmbUsuario.ItemsSource = manejadorContraseñaAdministrar.Listar;
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


                if (string.IsNullOrEmpty(pasword.Password))
                {
                    MessageBox.Show("Aun no a ingresado la contraseña", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (cmbUsuario.SelectedItem != null)

                {
                    ContraseñaAdministrador b = cmbUsuario.SelectedItem as ContraseñaAdministrador;
                    if (pasword.Password == b.Contraseña)
                    {
                        Menu ir = new Menu();
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
            LimpiarCajas();
        }

        private void LimpiarCajas()
        {
            pasword.Clear();
        }
    }
}
