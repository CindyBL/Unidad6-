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
    /// Lógica de interacción para MenuO.xaml
    /// </summary>
    public partial class MenuO : Window
    {
        public MenuO()
        {
            InitializeComponent();
        }

        private void Reproducir_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Play();
        }

        private void mePlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            mePlayer.MaxHeight = mePlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void mePlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
        }
    }
}
