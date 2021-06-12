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
using Newtonsoft.Json.Linq;
using System.Threading;
using CommapsyPC.Class;
using CommapsyPC.Controls;

namespace CommapsyPC.Windows
{
    /// <summary>
    /// Lógica de interacción para Admins.xaml
    /// </summary>
    public partial class Admins : UserControl
    {
        public Admins()
        {
            InitializeComponent();
            new Thread(new ThreadStart(Search)).Start();
        }

        public void Manage(string Mail) 
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("AdminMail", PlatformWindow.adminMail));
                parameters.Add(new KeyValuePair<string, string>("Mail", Mail));
            });

            string result = Request.Request.RequestData("/Admin/manage", parameters);


            Search();
        }

        public void Search() 
        {
            List<Admin> provAdmins = new List<Admin>();
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                usersList.Children.Clear();
                adminsList.Children.Clear();
                parameters.Add(new KeyValuePair<string, string>("Page", 0 + ""));
            });

            string result = Request.Request.RequestData("/Admin/getAdmins", parameters);

            JArray arrays = Utils.Utils.StringToJsonArray(result);

            int row = -1;

            for (int i = 0; i < arrays.Count; i++)
            {
                Admin admin = Admin.JsonToAdmin((JObject)arrays[i]);
                provAdmins.Add(admin);

                this.Dispatcher.Invoke(() =>
                {
                    ModControl mc = new ModControl(admin,false,this);

                    switch (i % 3)
                    {
                        case 0:
                            row++;
                            Grid.SetColumn(mc,0);
                            break;
                        case 1:
                            Grid.SetColumn(mc, 1);
                            break;
                        case 2:
                            Grid.SetColumn(mc, 2);
                            break;
                    }

                    Grid.SetRow(mc, row);

                    adminsList.Children.Add(mc);

                });
            }

            parameters = new List<KeyValuePair<string, string>>();

            this.Dispatcher.Invoke(() => {
                parameters.Add(new KeyValuePair<string, string>("Page", 0 + ""));
            });

            result = Request.Request.RequestData("/Admin/getUsers", parameters);

            arrays = Utils.Utils.StringToJsonArray(result);



            for (int i = 0; i < arrays.Count; i++)
            {
                bool isAdmin = false;

                User user = User.JsonToUser((JObject)arrays[i]);
                
                for (int j = 0; j < provAdmins.Count; j++)
                {
                    if (user.Mail == provAdmins[j].UserMail) 
                    {
                        isAdmin = true;
                        break;
                    }
                }

                if (!isAdmin)
                {
                    Admin admin = new Admin();
                    admin.UserMail = user.Mail;
                    admin.enable = false;

                    this.Dispatcher.Invoke(() =>
                    {
                        ModControl mc = new ModControl(admin, true,this);
                        usersList.Children.Add(mc);
                    });
                }
            }


        }

    }
}
