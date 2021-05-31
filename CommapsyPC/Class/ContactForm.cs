using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CommapsyPC.Class
{
    public class ContactForm
    {
        public int ID { get; set; }
        public string User_Mail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }

        public static ContactForm JsonToContactForm(JObject json)
        {
            ContactForm cf = new ContactForm();

            cf.ID = int.Parse(json.GetValue("id").ToString());
            cf.User_Mail = json.GetValue("user_Mail").ToString();
            cf.Subject = json.GetValue("subject").ToString();
            cf.Body = json.GetValue("body").ToString().Replace(".,.","\n");
            cf.SendDate = DateTime.Parse(json.GetValue("sendDate").ToString());

            return cf;
        }
    }
}
