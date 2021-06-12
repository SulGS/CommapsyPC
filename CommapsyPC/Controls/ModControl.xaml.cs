using CommapsyPC.Class;
using CommapsyPC.Windows;
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
using System.Threading;

namespace CommapsyPC.Controls
{
    /// <summary>
    /// Lógica de interacción para ModControl.xaml
    /// </summary>
    public partial class ModControl : UserControl
    {
        private Admins adminWindow;
        private Admin admin;
        private bool isNew;

        public ModControl(Admin a,bool iN,Admins aW)
        {
            InitializeComponent();
            admin = a;
            isNew = iN;
            adminWindow = aW;

            Mail.Content = admin.UserMail;

            if (isNew)
            {
                action.Content = "Añadir";
            }
            else 
            {
                if (admin.enable)
                {
                    action.Content = "Desactivar";
                }
                else 
                {
                    action.Content = "Activar";
                }
            }

        }

        private void action_Click(object sender, RoutedEventArgs e)
        {
            action.IsEnabled = false;
            new Thread(() => adminWindow.Manage(admin.UserMail)).Start();
        }
    }
}
