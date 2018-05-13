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

namespace Hotel.GUI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroHabitacion.xaml
    /// </summary>
    public partial class RegistroHabitacion : Window
    {
        public RegistroHabitacion()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu ir = new Menu();
            ir.Show();
            this.Close();
        }
    }
}
