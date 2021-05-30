using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommapsyPC.Class
{
    public class Opinion
    {
        public int ID { get; set; }
        public string User_Mail { get; set; }
        public int PlaceID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public static Opinion JsonToOpinion(JObject json)
        {
            Opinion opinion = new Opinion();

            opinion.ID = int.Parse(json.GetValue("id").ToString());
            opinion.User_Mail = json.GetValue("user_Mail").ToString();
            opinion.PlaceID = int.Parse(json.GetValue("placeID").ToString());
            opinion.Rating = int.Parse(json.GetValue("rating").ToString());
            opinion.Comment = json.GetValue("comment").ToString();

            return opinion;
        }
    }
}
