using CommapsyPC.Class;
using CommapsyPC.Windows;
using System.Threading;
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

namespace CommapsyPC.Controls
{
    /// <summary>
    /// Lógica de interacción para UserPenaliseControl.xaml
    /// </summary>
    public partial class UserPenaliseControl : UserControl
    {
        private User user;

        public UserPenaliseControl(User u)
        {
            InitializeComponent();
            user = u;
            userName.Content = user.Name;
        }

        private void SendPenalise() 
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("AdminMail", PlatformWindow.adminMail));
                parameters.Add(new KeyValuePair<string, string>("UserMail", user.Mail));
                parameters.Add(new KeyValuePair<string, string>("Reply", reply.Text.Replace("\n",".,.")));
            });

            string result = Request.Request.RequestData("/User/penalise", parameters);
        }

        private void Penalise_Click(object sender, RoutedEventArgs e)
        {
            Penalise.IsEnabled = false;
            new Thread(new ThreadStart(SendPenalise)).Start();
        }
    }
}
