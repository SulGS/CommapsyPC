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

namespace CommapsyPC.Controls
{
    /// <summary>
    /// Lógica de interacción para placeFullView.xaml
    /// </summary>
    public partial class PlaceFullView : UserControl
    {
        public PlaceFullView(Place p)
        {
            InitializeComponent();
            placeName.Content = p.Name;
            placeDescription.Text = p.Description;
            placeGPS.Content = "(" + p.Latitude + "," + p.Longitude + ")";
            //new Thread(() => ).Start();
            loadImage(p);
            new Thread(() => GetComments(p)).Start();
        }

        public void loadImage(Place p) 
        {
            var fullFilePath = @"http://commapsy.us.to:8082/" + p.Photo;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            Image image = new Image();
            image.Source = bitmap;
            Grid.SetRow(image, 1);
            grid.Children.Add(image);
        }

        private void GetComments(Place p)
        {

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("PlaceID", p.ID + ""));
                parameters.Add(new KeyValuePair<string, string>("Page", 0 + ""));
            });

            string result = Request.Request.RequestData("/Opinion/returnOpinions", parameters);

            JArray arrays = Utils.Utils.StringToJsonArray(result);

            for (int i = 0; i < arrays.Count; i++)
            {
                Opinion opinion = Opinion.JsonToOpinion((JObject)arrays[i]);
                
                this.Dispatcher.Invoke(() => {
                    OpinionControl oc = new OpinionControl(opinion);

                    comments.Children.Add(oc);
                });
            }

            


        }
    }
}
