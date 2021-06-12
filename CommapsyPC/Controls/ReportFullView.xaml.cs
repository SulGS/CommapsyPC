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
    /// Lógica de interacción para ReportFullView.xaml
    /// </summary>
    public partial class ReportFullView : UserControl
    {
        private Report report;
        private Opinion opinion;
        private User userReporter;
        private User userReported;
        private Reports reports;

        public ReportFullView(Report r, Opinion o, User uRr, User uRd, Reports rs)
        {
            InitializeComponent();
            report = r;
            opinion = o;
            userReporter = uRr;
            userReported = uRd;
            reports = rs;
            reporter.Content = new UserPenaliseControl(userReporter);
            reported.Content = new UserPenaliseControl(userReported);
            long rate = opinion.Rating;
            comment.Text = (rate / 2) + "/5\n" + opinion.Comment;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Remove.IsEnabled = false;
            Finalize.IsEnabled = false;
            new Thread(() => reports.Manage(report.Mail,true,opinion.ID)).Start();
        }

        private void Finalize_Click(object sender, RoutedEventArgs e)
        {
            Remove.IsEnabled = false;
            Finalize.IsEnabled = false;
            new Thread(() => reports.Manage(report.Mail, false, opinion.ID)).Start();
        }
    }
}
