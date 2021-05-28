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
    /// Lógica de interacción para PlaceRequestFullView.xaml
    /// </summary>
    public partial class PlaceRequestFullView : UserControl
    {
        private PlaceRequest placeRequest;
        private Place place;
        private User user;
        private Requests req;

        public PlaceRequestFullView(PlaceRequest pr, Place p, User u,Requests r)
        {
            InitializeComponent();
            placeRequest = pr;
            place = p;
            user = u;
            date.Content = pr.SendDate.ToString("dd-MM-yyyy");
            newName.Content = pr.Name;
            newCoordinates.Content = "(" + pr.Latitude + "," + pr.Longitude + ")";
            newCategory.Content = pr.Category;
            newDescription.Text = pr.Description;
            oldName.Content = p.Name;
            oldCoordinates.Content = "(" + p.Latitude + "," + p.Longitude + ")";
            oldCategory.Content = p.Category;
            oldDescription.Text = p.Description;
            req = r;
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete.IsEnabled = false;
            Accept.IsEnabled = false;
            string ID = placeRequest.ID + "";
            string Reply = reply.Text;
            new Thread(() => req.Manage(ID , false + "", Reply)).Start();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Delete.IsEnabled = false;
            Accept.IsEnabled = false;
            string ID = placeRequest.ID + "";
            string Reply = reply.Text;
            new Thread(() => req.Manage(ID, true + "", Reply)).Start();
        }
    }
}
