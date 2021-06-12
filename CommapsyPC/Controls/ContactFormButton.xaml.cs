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

namespace CommapsyPC.Controls
{
    /// <summary>
    /// Lógica de interacción para ContactFormButton.xaml
    /// </summary>
    public partial class ContactFormButton : UserControl
    {

        private ContactForm cf;
        private Support sup;
        private User user;

        public ContactFormButton(ContactForm cf,Support s,User user)
        {
            InitializeComponent();
            this.cf = cf;
            subject.Content = cf.Subject;
            sup = s;
            this.user = user;
        }

        private void Click_Click(object sender, RoutedEventArgs e)
        {
            sup.contactInfo.Content = new ContactFormFullView(cf, sup,user);
        }
    }
}
