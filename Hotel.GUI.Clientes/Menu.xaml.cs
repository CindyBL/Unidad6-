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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        IManejadorTipoHabitacion manejadorTipoHabitacion;
        IManejadorOtroServicio manejadorOtroServicio;
        public Menu()
        {
            InitializeComponent();
            manejadorTipoHabitacion = new ManejadorTipoHabitacion(new RepositorioGenerico<TipoHabitaciones>());
            manejadorOtroServicio = new ManejadorOtrosServicios(new RepositorioGenerico<OtrosServicios>());
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            lsvHabitaciones.ItemsSource = null;
            lsvHabitaciones.ItemsSource = manejadorTipoHabitacion.Listar;
            lsvServicios.ItemsSource = null;
            lsvServicios.ItemsSource = manejadorOtroServicio.Listar;
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ir = new MainWindow();
            ir.Show();
            this.Close();
        }
    }
}
