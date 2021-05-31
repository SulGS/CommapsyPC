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

namespace CommapsyPC.Windows
{
    /// <summary>
    /// Lógica de interacción para PlatformWindow.xaml
    /// </summary>
    public partial class PlatformWindow : Window
    {
        public static string adminMail;
        public PlatformWindow()
        {
            InitializeComponent();
        }

        private void buscarLugaresMenu_Click(object sender, RoutedEventArgs e)
        {
            container.Content = new Explorer();
        }

        private void peticionesMenu_Click(object sender, RoutedEventArgs e)
        {
            container.Content = new Requests();
        }

        private void reportesMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void soporteMenu_Click(object sender, RoutedEventArgs e)
        {
            container.Content = new Support();
        }

        private void moderadoresMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void minimizarMenu_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void desconectarMenu_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
