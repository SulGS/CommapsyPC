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
    

    public partial class PlaceButton : UserControl
    {
        public Place place;
        private Explorer explorer;

        public PlaceButton(Place p,Explorer r)
        {
            InitializeComponent();
            place = p;
            titleLabel.Content = p.Name;
            categoryLabel.Content = p.Category;
            explorer = r;
        }

        private void Click_Click(object sender, RoutedEventArgs e)
        {
            explorer.placeInfo.Content = new PlaceFullView(place);
        }
    }
}
