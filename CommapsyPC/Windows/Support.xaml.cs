using CommapsyPC.Class;
using CommapsyPC.Controls;
using Newtonsoft.Json.Linq;
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

namespace CommapsyPC.Windows
{
    /// <summary>
    /// Lógica de interacción para Support.xaml
    /// </summary>
    public partial class Support : UserControl
    {
        public Support()
        {
            InitializeComponent();
            new Thread(new ThreadStart(Search)).Start();
        }

        public void Answer(String ID, bool SendMail, String Reply)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("ID", ID));
                parameters.Add(new KeyValuePair<string, string>("Mail", PlatformWindow.adminMail));
                parameters.Add(new KeyValuePair<string, string>("SendMail", SendMail+""));
                parameters.Add(new KeyValuePair<string, string>("Body", Reply));
            });

            string result = Request.Request.RequestData("/ContactForm/answer", parameters);


            this.Dispatcher.Invoke(() => {
                contactInfo.Content = null;
                Search();
            });
        }

        private void Search()
        {

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                contactsList.Children.Clear();
                parameters.Add(new KeyValuePair<string, string>("Page", 0 + ""));
            });

            string result = Request.Request.RequestData("/ContactForm/get", parameters);

            JArray arrays = Utils.Utils.StringToJsonArray(result);

            for (int i = 0; i < arrays.Count; i++)
            {

                ContactForm cf = ContactForm.JsonToContactForm((JObject)arrays[i]);


                this.Dispatcher.Invoke(() => {
                    ContactFormButton cfb = new ContactFormButton(cf,this);
                    contactsList.Children.Add(cfb);
                });
            }



        }
    }
}
