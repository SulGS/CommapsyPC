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
    /// Lógica de interacción para ReportButton.xaml
    /// </summary>
    public partial class ReportButton : UserControl
    {

        private Report report;
        private Opinion opinion;
        private User userReporter;
        private User userReported;
        private Reports reports;

        public ReportButton(Report r, Opinion o, User uRr,User uRd,Reports rs)
        {
            InitializeComponent();
            report = r;
            opinion = o;
            userReporter = uRr;
            userReported = uRd;
            reports = rs;
            id.Content = r.OpinionID;
        }

        private void Click_Click(object sender, RoutedEventArgs e)
        {
            reports.reportInfo.Content = new ReportFullView(report,opinion,userReporter,userReported,reports);
        }
    }
}
