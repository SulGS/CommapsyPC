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
using CommapsyPC.Windows;
using CommapsyPC.Class;

namespace CommapsyPC
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void Login() 
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("Mail", mailInput.Text));
                PlatformWindow.adminMail = mailInput.Text;
                parameters.Add((new KeyValuePair<string, string>("Password", Utils.Utils.sha256_hash(passwordInput.Password))));
            });

            string result2 = Request.Request.RequestData("/User/login", parameters);

            User user = User.JsonToUser(Utils.Utils.StringToJsonObject(result2));

            Request.Request.Token = user._Key;

            string result = Request.Request.RequestData("/Admin/login", parameters);

            

            this.Dispatcher.Invoke(() => {
                if (result != "")
                {
                    MessageBox.Show("ACCESO PERMITIDO");
                    new PlatformWindow().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ACCESO DENEGADO");
                }

                loginButton.IsEnabled = true;
            });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginButton.IsEnabled = false;
            new Thread(new ThreadStart(Login)).Start();
        }

        
    }
}
