using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CommapsyPC.Class
{
    public class Admin
    {
        public string UserMail { get; set; }
        public string AdminBy { get; set; }
        public DateTime date { get; set; }
        public bool enable { get; set; }

        public static Admin JsonToAdmin(JObject json)
        {
            Admin admin = new Admin();

            admin.UserMail = json.GetValue("userMail").ToString();
            admin.AdminBy = json.GetValue("adminBy").ToString();
            admin.date = DateTime.Parse(json.GetValue("date").ToString());
            admin.enable = bool.Parse(json.GetValue("enable").ToString());

            return admin;
        }

    }
}
