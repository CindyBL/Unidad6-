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

namespace Hotel.GUI.Clientes
{
    /// <summary>
    /// Lógica de interacción para UsuarioNuevo.xaml
    /// </summary>
    public partial class UsuarioNuevo : Window
    {
        public UsuarioNuevo()
        {
            InitializeComponent();
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
    }
}
