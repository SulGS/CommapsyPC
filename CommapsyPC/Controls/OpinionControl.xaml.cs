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

namespace CommapsyPC.Controls
{
    /// <summary>
    /// Lógica de interacción para OpinionControl.xaml
    /// </summary>
    public partial class OpinionControl : UserControl
    {
        public OpinionControl(Opinion op)
        {
            InitializeComponent();
            float rate = (float)op.Rating;
            rate /= 2;
            rating.Content = rate + "/5";
            comment.Content = op.Comment;
        }
    }
}
