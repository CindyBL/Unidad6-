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
using Hotel.BIZ;
using Hotel.COMMON.Interfaces;
using Hotel.DAL;
using Hotel.COMMON.Entidades;

namespace Hotel.GUI.Clientes
{
    /// <summary>
    /// Lógica de interacción para UsuarioNuevo.xaml
    /// </summary>
    public partial class UsuarioNuevo : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorContraseñaCliente manejadorContraseñaCliente;
        accion accionContraseña;

        public UsuarioNuevo()
        {
            InitializeComponent();
            manejadorContraseñaCliente = new ManejadorContraseñaClientes(new RepositorioGenerico<ContraseñaCliente>());
            LimpiarCajas();
        }

        private void LimpiarCajas()
        {
            txbUsuario.Clear();
            pasword.Clear();
            newpasword.Clear();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ir = new MainWindow();
            ir.Show();
            this.Close();
        }

        private void Image_ImageFailed_1(object sender, Yunan.WPF.ImageAnim.AnimationImageExceptionRoutedEventArgs args)
        {
            
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txbUsuario.Text != "" && pasword.Password != "" && newpasword.Password != "")
            {
                if (pasword.Password == newpasword.Password)
                {
                    if (accionContraseña == accion.Nuevo)
                    {
                        ContraseñaCliente pro = new ContraseñaCliente()
                        {
                            Usuario = txbUsuario.Text,
                            Contraseña = pasword.Password,
                        };
                        if (manejadorContraseñaCliente.Agregar(pro))
                        {
                            MessageBox.Show("Usuario Agregado Correctamente", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCajas();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no se puede agregar", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña no coincide intente de nuevo", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aun le faltan Campos por rellenar", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajas();
        }
    }
}
