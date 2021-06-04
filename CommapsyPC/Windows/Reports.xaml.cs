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
using CommapsyPC.Class;
using CommapsyPC.Controls;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace CommapsyPC.Windows
{
    /// <summary>
    /// Lógica de interacción para Reports.xaml
    /// </summary>
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
            new Thread(new ThreadStart(Search)).Start();
        }

        public void Manage(String Mail, bool State, int OpinionID)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("OpinionID", OpinionID+""));
                parameters.Add(new KeyValuePair<string, string>("UserMail", Mail));
                parameters.Add(new KeyValuePair<string, string>("Delete", State+""));
            });

            string result = Request.Request.RequestData("/Report/manage", parameters);


            this.Dispatcher.Invoke(() => {
                reportInfo.Content = null;
                Search();
            });
        }

        private void Search()
        {

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                reportsList.Children.Clear();
                parameters.Add(new KeyValuePair<string, string>("Page", 0 + ""));
            });

            string result = Request.Request.RequestData("/Report/get", parameters);

            JArray arrays = Utils.Utils.StringToJsonArray(result);

            for (int i = 0; i < arrays.Count; i++)
            {

                Report report = Report.JsonToReport((JObject)arrays[i]);

                parameters = new List<KeyValuePair<string, string>>();

                this.Dispatcher.Invoke(() => {
                    reportsList.Children.Clear();
                    parameters.Add(new KeyValuePair<string, string>("ID", report.OpinionID+""));
                });

                Opinion opinion = Opinion.JsonToOpinion(Utils.Utils.StringToJsonObject(Request.Request.RequestData("/Opinion/get", parameters)));

                parameters = new List<KeyValuePair<string, string>>();

                this.Dispatcher.Invoke(() => {
                    reportsList.Children.Clear();
                    parameters.Add(new KeyValuePair<string, string>("Mail", report.Mail));
                });

                User userReporter = User.JsonToUser(Utils.Utils.StringToJsonObject(Request.Request.RequestData("/User/getUser", parameters)));

                this.Dispatcher.Invoke(() => {
                    reportsList.Children.Clear();
                    parameters.Add(new KeyValuePair<string, string>("Mail", opinion.User_Mail));
                });

                User userReported = User.JsonToUser(Utils.Utils.StringToJsonObject(Request.Request.RequestData("/User/getUser", parameters)));


                this.Dispatcher.Invoke(() => {
                    ReportButton rb = new ReportButton(report,opinion,userReporter,userReported,this);
                    reportsList.Children.Add(rb);
                });
            }



        }
    }
}
