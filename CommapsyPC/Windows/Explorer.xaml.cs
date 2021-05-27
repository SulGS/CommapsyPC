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
using Newtonsoft.Json.Linq;
using CommapsyPC.Controls;
using CommapsyPC.Class;

namespace CommapsyPC.Windows
{
    /// <summary>
    /// Lógica de interacción para Explorer.xaml
    /// </summary>
    public partial class Explorer : UserControl
    {
        public Explorer()
        {
            InitializeComponent();
        }

        private void Search() 
        {
            string name = "";
            this.Dispatcher.Invoke(() =>
            {
                name = nameField.Text;
            });

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("Name", name));
                parameters.Add(new KeyValuePair<string, string>("Page", 0+""));
            });

            string result = Request.Request.RequestData("/Place/returnPlacesByName", parameters);

            JArray arrays = Utils.Utils.StringToJsonArray(result);

            for (int i = 0; i < arrays.Count; i++)
            {

                Place place = Place.JsonToPlace((JObject)arrays[i]);
                this.Dispatcher.Invoke(() => {
                    PlaceButton pb = new PlaceButton(place,this);

                    placesListPanel.Children.Add(pb);
                });
            }

            this.Dispatcher.Invoke(() =>
            {
                searchButton.IsEnabled = true;
            });


        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            searchButton.IsEnabled = false;
            placesListPanel.Children.Clear();
            new Thread(new ThreadStart(Search)).Start();
        }
    }
}
