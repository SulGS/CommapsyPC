using CommapsyPC.Class;
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
using CommapsyPC.Windows;

namespace CommapsyPC.Controls
{
    /// <summary>
    /// Lógica de interacción para PlaceRequestButton.xaml
    /// </summary>
    public partial class PlaceRequestButton : UserControl
    {
        private PlaceRequest pr;
        private Place place;
        private User user;
        private Requests requests;
        
        public PlaceRequestButton(PlaceRequest pr, Requests r)
        {
            InitializeComponent();
            this.pr = pr;
            requests = r;
            new Thread(new ThreadStart(getPlaceAndUser)).Start();
        }

        public void getPlaceAndUser() 
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("ID", pr.PlaceID + ""));
            });

            string result = Request.Request.RequestData("/Place/get", parameters);

            place = Place.JsonToPlace(Utils.Utils.StringToJsonObject(result));

            parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("Mail", pr.UserMail + ""));
            });

            result = Request.Request.RequestData("/User/getUser", parameters);

            user = User.JsonToUser(Utils.Utils.StringToJsonObject(result));

            this.Dispatcher.Invoke(() => {
                placeName.Content = place.Name;
                userName.Content = user.Mail;
            });


        }


        private void Click_Click(object sender, RoutedEventArgs e) 
        {
            requests.requestInfo.Content = new PlaceRequestFullView(pr,place,user,requests);
        }
    }
}
