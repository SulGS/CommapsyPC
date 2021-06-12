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
using CommapsyPC.Class;
using Newtonsoft.Json.Linq;
using CommapsyPC.Controls;

namespace CommapsyPC.Windows
{
    /// <summary>
    /// Lógica de interacción para Requests.xaml
    /// </summary>
    public partial class Requests : UserControl
    {
        public Requests()
        {
            InitializeComponent();
            new Thread(new ThreadStart(Search)).Start();
        }

        public void Manage(String ID, String State, String Reply) 
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("ID", ID));
                parameters.Add(new KeyValuePair<string, string>("Mail", PlatformWindow.adminMail));
                parameters.Add(new KeyValuePair<string, string>("State", State));
                parameters.Add(new KeyValuePair<string, string>("Reply", Reply));
            });

            string result = Request.Request.RequestData("/PlaceRequest/manage", parameters);


            this.Dispatcher.Invoke(() => {
                requestInfo.Content = null;
                Search();
            });
        }

        private void Search()
        {

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                requestListPanel.Children.Clear();
                parameters.Add(new KeyValuePair<string, string>("Page", 0 + ""));
            });

            string result = Request.Request.RequestData("/PlaceRequest/get", parameters);

            JArray arrays = Utils.Utils.StringToJsonArray(result);

            for (int i = 0; i < arrays.Count; i++)
            {

                PlaceRequest place = PlaceRequest.JsonToPlaceRequest((JObject)arrays[i]);


                this.Dispatcher.Invoke(() => {
                    PlaceRequestButton prb = new PlaceRequestButton(place,this);
                    requestListPanel.Children.Add(prb);
                });
            }



        }
    }
}
