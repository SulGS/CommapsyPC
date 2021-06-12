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
    /// Lógica de interacción para ContactFormFullView.xaml
    /// </summary>
    public partial class ContactFormFullView : UserControl
    {
        private ContactForm cf;
        private Support sup;
        private User user;

        public ContactFormFullView(ContactForm cf, Support s,User user)
        {
            InitializeComponent();
            this.cf = cf;
            this.user = user;
            sup = s;
            subject.Content = cf.Subject + " (" + cf.SendDate.ToString("dd-MM-yyyy") + ")";
            body.Text = cf.Body;
            penaliseControl.Content = new UserPenaliseControl(user);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete.IsEnabled = false;
            Accept.IsEnabled = false;
            string ID = cf.ID + "";
            string Reply = reply.Text.Replace("\n", ".,.");
            new Thread(() => sup.Answer(ID, false, Reply)).Start();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Delete.IsEnabled = false;
            Accept.IsEnabled = false;
            string ID = cf.ID + "";
            string Reply = reply.Text.Replace("\n", ".,.");
            new Thread(() => sup.Answer(ID, true, Reply)).Start();
        }
    }
}
