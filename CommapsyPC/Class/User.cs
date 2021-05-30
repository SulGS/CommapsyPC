using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CommapsyPC.Class
{
    public class User
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string _Key { get; set; }
        public bool Is_Enable { get; set; }
        public string Profile_Photo { get; set; }
        public string Gender { get; set; }

        public static User JsonToUser(JObject json)
        {
            User user = new User();

            user.Mail = json.GetValue("mail").ToString();
            user.Name = json.GetValue("name").ToString();
            user.Surname = json.GetValue("surname").ToString();
            user.Password = json.GetValue("password").ToString();
            user._Key = json.GetValue("_Key").ToString();
            user.Is_Enable = json.GetValue("is_Enable").Value<bool>();
            user.Profile_Photo = json.GetValue("profile_Photo").ToString();
            user.Gender = json.GetValue("gender").ToString();

            return user;
        }

    }
}
