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


namespace Hotel.GUI.Administracion
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }

        IManejadorRegistroHuesped manejadorRegistroHuesped;
        IManejadorTipoHabitacion manejadorTipoHabitacion;
        IManejadorDesalojo manejadorDesalojo;
        IManejadorContraseñaAdministrar manejadorContraseñaAdministrar;
        accion accionRegistroHuesped;
        accion accionDesalojo;
        accion accionContraseña;
        int x;

        public Menu()
        {
            InitializeComponent();
            manejadorRegistroHuesped = new ManejadorRegistroHuesped(new RepositorioGenerico<RegistroHuesped>());
            manejadorTipoHabitacion = new ManejadorTipoHabitacion(new RepositorioGenerico<TipoHabitaciones>());
            manejadorDesalojo = new ManejadorDesalojoH(new RepositorioGenerico<DesalojoHabitacion>());
            manejadorContraseñaAdministrar = new ManejadorContraseñaAdmistracion(new RepositorioGenerico<ContraseñaAdministrador>());
            HabilitarCajasRegistroHuesped(false);
            HabilitarBotonesRegistroHuesped(true);
            HabilitarCajasDesalojo(false);
            HabilitarBotonesDesalojo(true);
            HabilitarCajasUsuario(false);
            HabilitarBotonesUsuario(true);
            ActualizarTabla();
        }

        private void HabilitarBotonesUsuario(bool habilitados)
        {
            btnNuevo4.IsEnabled = habilitados;
            btnGuardar4.IsEnabled = !habilitados;
            btnCancelar4.IsEnabled = !habilitados;
        }

        private void HabilitarCajasUsuario(bool habilitadas)
        {
            txbUsuario.Clear();
            txbUsuario.IsEnabled = habilitadas;
            txbContraseña.Clear();
            txbContraseña.IsEnabled = habilitadas;
            txbContraseñaR.Clear();
            txbContraseñaR.IsEnabled = habilitadas;
        }

        private void HabilitarBotonesDesalojo(bool habilitados)
        {
            btnNuevo1.IsEnabled = habilitados;
            btnEditar1.IsEnabled = habilitados;
            btnEliminar1.IsEnabled = habilitados;
            btnGuardar1.IsEnabled = !habilitados;
            btnCancelar1.IsEnabled = !habilitados;
        }

        private void HabilitarCajasDesalojo(bool habilitadas)
        {
            cmbNombreHusped.IsEnabled = habilitadas;
            cmbNombreHusped.ItemsSource = null;
            cmbNombreHusped.ItemsSource = manejadorRegistroHuesped.Listar;
        }

        private void ActualizarTabla()
        {
            dtgTRegistroHuesped.ItemsSource = null;
            dtgTRegistroHuesped.ItemsSource = manejadorRegistroHuesped.Listar;
            dtgDesalojo.ItemsSource = null;
            dtgDesalojo.ItemsSource = manejadorDesalojo.Listar;
            lsvHistorial.ItemsSource = null;
            lsvHistorial.ItemsSource = manejadorRegistroHuesped.Listar;
        }

        private void HabilitarBotonesRegistroHuesped(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void HabilitarCajasRegistroHuesped(bool habilitadas)
        {
            txbNombre.Clear();
            txbNombre.IsEnabled = habilitadas;
            txbApellido.Clear();
            txbApellido.IsEnabled = habilitadas;
            txbDiasHospedaje.Clear();
            txbDiasHospedaje.IsEnabled = habilitadas;
            cmbNombreHabitacion.IsEnabled = habilitadas;
            cmbNombreHabitacion.ItemsSource = null;
            cmbNombreHabitacion.ItemsSource = manejadorTipoHabitacion.Listar;

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasRegistroHuesped(true);
            HabilitarBotonesRegistroHuesped(false);
            accionRegistroHuesped = accion.Nuevo;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            RegistroHuesped pro = dtgTRegistroHuesped.SelectedItem as RegistroHuesped;
            if (pro != null)
            {
                HabilitarCajasRegistroHuesped(true);
                txbNombre.Text = pro.Nombre;
                txbApellido.Text = pro.Apellido;
                cmbNombreHabitacion.Text = pro.Habitacion;
                txbDiasHospedaje.Text = pro.DiasHospedaje;
                dtpFecha.SelectedDate = pro.FechaInicial;
                accionRegistroHuesped = accion.Editar;
                HabilitarBotonesRegistroHuesped(false);
            }
            else
            {
                MessageBox.Show("Seleccione el registro de huesped que desea editar", "RegistroHuesped", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txbNombre.Text!="" && txbApellido.Text!="" && cmbNombreHabitacion.Text!="" && dtpFecha.Text!="")
            {
                if (int.TryParse(txbDiasHospedaje.Text, out x) && !int.TryParse(txbNombre.Text, out x) && !int.TryParse(txbApellido.Text, out x))
                {
                    if (accionRegistroHuesped == accion.Nuevo)
                    {
                        RegistroHuesped pro = new RegistroHuesped()
                        {
                            Nombre = txbNombre.Text,
                            Apellido = txbApellido.Text,
                            Habitacion = cmbNombreHabitacion.Text,
                            DiasHospedaje = txbDiasHospedaje.Text,
                            FechaInicial = dtpFecha.SelectedDate.Value,
                        };
                        if (manejadorRegistroHuesped.Agregar(pro))
                        {
                            MessageBox.Show("El registro del huesped fue agregado correctamente", "Registro Huesped", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesRegistroHuesped(true);
                            HabilitarCajasRegistroHuesped(false);
                        }
                        else
                        {
                            MessageBox.Show("El registro del huesped no se pudo realizar", "Registro Huesped", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        RegistroHuesped pro = dtgTRegistroHuesped.SelectedItem as RegistroHuesped;
                        pro.Nombre = txbNombre.Text;
                        pro.Apellido = txbApellido.Text;
                        pro.Habitacion = cmbNombreHabitacion.Text;
                        pro.DiasHospedaje = txbDiasHospedaje.Text;
                        pro.FechaInicial = dtpFecha.SelectedDate.Value;
                        if (manejadorRegistroHuesped.Modificar(pro))
                        {
                            MessageBox.Show("Registro del huesped modificado correctamente", "Registro Huesped", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesRegistroHuesped(true);
                            HabilitarCajasRegistroHuesped(false);
                        }
                        else
                        {
                            MessageBox.Show("El registro del huesped no se pudo actualizar", "Registro Huesped", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El campo de dias de hospedaje solo admite numeros o el campo de nombre y apellido no admite ese tipo de caracteres", "Registro Huesped", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aun le faltan campos por rellenar", "Registro Huesped", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            RegistroHuesped pro = dtgTRegistroHuesped.SelectedItem as RegistroHuesped;
            if (pro != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar el registro del huesped?", "Registro Huesped", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorRegistroHuesped.Eliminar(pro.Id))
                    {
                        MessageBox.Show("El tregistro del huesped ha sido eliminado correctamente", "Registro Huesped", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El registro del huesped no se pudo eliminar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasRegistroHuesped(false);
            HabilitarBotonesRegistroHuesped(true);
        }

        private void btnNuevo1_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasDesalojo(true);
            HabilitarBotonesDesalojo(false);
            accionDesalojo = accion.Nuevo;
        }

        private void btnEditar1_Click(object sender, RoutedEventArgs e)
        {
            DesalojoHabitacion pro = dtgDesalojo.SelectedItem as DesalojoHabitacion;
            if (pro != null)
            {
                HabilitarCajasDesalojo(true);
                cmbNombreHusped.Text = pro.Nombre;
                dtpFechaFinal.SelectedDate = pro.FechaFinal;
                accionDesalojo= accion.Editar;
                HabilitarBotonesDesalojo(false);
            }
            else
            {
                MessageBox.Show("Seleccione el desalojo que desea editar", "Huesped", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void btnGuardar1_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNombreHusped.Text != ""  && dtpFechaFinal.Text != "")
            {
                
                    if (accionDesalojo == accion.Nuevo)
                    {
                        DesalojoHabitacion pro = new DesalojoHabitacion()
                        {
                            Nombre = cmbNombreHusped.Text,
                            FechaFinal = dtpFechaFinal.SelectedDate.Value,
                        };
                        if (manejadorDesalojo.Agregar(pro))
                        {
                            MessageBox.Show("El desalojo del huesped fue agregado correctamente", "Huesped", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesDesalojo(true);
                            HabilitarCajasDesalojo(false);
                        }
                        else
                        {
                            MessageBox.Show("El desalojo del huesped no se pudo realizar", "Huesped", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        DesalojoHabitacion pro = dtgDesalojo.SelectedItem as DesalojoHabitacion;
                        pro.Nombre = cmbNombreHusped.Text;
                        pro.FechaFinal = dtpFechaFinal.SelectedDate.Value;
                        if (manejadorDesalojo.Modificar(pro))
                        {
                            MessageBox.Show("Desalojo del huesped modificado correctamente", "Huesped", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesDesalojo(true);
                            HabilitarCajasDesalojo(false);
                        }
                        else
                        {
                            MessageBox.Show("El desalojo del huesped no se pudo actualizar", "Huesped", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
               
            }
            else
            {
                MessageBox.Show("Aun le faltan campos por rellenar", "Huesped", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar1_Click(object sender, RoutedEventArgs e)
        {
            DesalojoHabitacion pro = dtgDesalojo.SelectedItem as DesalojoHabitacion;
            if (pro != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar el desalojo del huesped?", "Huesped", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDesalojo.Eliminar(pro.Id))
                    {
                        MessageBox.Show("El desalojo del huesped ha sido eliminado correctamente", "Huesped", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El desalojo del huesped no se pudo eliminar", "Huesped", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }

        private void btnCancelar1_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasDesalojo(false);
            HabilitarBotonesDesalojo(true);
        }

        private void btnNuevo4_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasUsuario(true);
            HabilitarBotonesUsuario(false);
           accionContraseña = accion.Nuevo;
        }

        private void btnGuardar4_Click(object sender, RoutedEventArgs e)
        {
            if (txbUsuario.Text != "" && txbContraseña.Password != "" && txbContraseñaR.Password != "")
            {
                if (txbContraseña.Password == txbContraseñaR.Password)
                {
                    if (accionContraseña == accion.Nuevo)
                    {
                        ContraseñaAdministrador pro = new ContraseñaAdministrador()
                        {
                            Usuario = txbUsuario.Text,
                            Contraseña = txbContraseña.Password,
                        };
                        if (manejadorContraseñaAdministrar.Agregar(pro))
                        {
                            MessageBox.Show("Usuario Agregado Correctamente", "Hotel", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesUsuario(true);
                            HabilitarCajasUsuario(false);
                        }
                        else
                        {
                            MessageBox.Show("El usuario no se puede agregar", "Hotel", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña no coincide intente de nuevo", "Hotel", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aun le faltan Campos por rellenar", "Hotel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar4_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasUsuario(false);
            HabilitarBotonesUsuario(true);
        }
    }
}
