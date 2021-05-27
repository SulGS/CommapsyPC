using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CommapsyPC.Class
{
    public class Place
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public static Place JsonToPlace(JObject json) 
        {
            Place place = new Place();

            place.ID = int.Parse(json.GetValue("id").ToString());
            place.Latitude = double.Parse(json.GetValue("latitude").ToString());
            place.Longitude = double.Parse(json.GetValue("longitude").ToString());
            place.Name = json.GetValue("name").ToString();
            place.Photo = json.GetValue("photo").ToString();
            place.Description = json.GetValue("description").ToString();
            place.Category = json.GetValue("category").ToString();

            return place;
        }
    }
}
