using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CommapsyPC.Class
{
    public class PlaceRequest
    {
        public int ID { get; set; }
        public string UserMail { get; set; }
        public DateTime SendDate { get; set; }
        public int PlaceID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Admin_Mail { get; set; }
        public bool IsAccepted { get; set; }
        public string ReplyBody { get; set; }
        public DateTime ReplyDate { get; set; }

        public static PlaceRequest JsonToPlaceRequest(JObject json)
        {
            PlaceRequest pr = new PlaceRequest();

            pr.ID = json.GetValue("id").Value<int>();
            pr.UserMail = json.GetValue("userMail").ToString();
            pr.SendDate = DateTime.Parse(json.GetValue("sendDate").ToString());
            pr.PlaceID = json.GetValue("placeID").Value<int>();
            pr.Latitude = json.GetValue("latitude").Value<double>();
            pr.Longitude = json.GetValue("longitude").Value<double>();
            pr.Name = json.GetValue("name").ToString();
            pr.Photo = json.GetValue("photo").ToString();
            pr.Description = json.GetValue("description").ToString();
            pr.Category = json.GetValue("category").ToString();

            return pr;
        }

    }
}
