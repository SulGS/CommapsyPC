using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CommapsyPC.Class
{
    public class Report
    {
        public string Mail { get; set; }
        public int OpinionID { get; set; }
        public string ReportComment { get; set; }
        public DateTime SendDate { get; set; }

        public static Report JsonToReport(JObject json)
        {
            Report report = new Report();

            report.Mail = json.GetValue("mail").ToString();
            report.OpinionID = int.Parse(json.GetValue("opinionID").ToString());
            report.ReportComment = json.GetValue("reportComment").ToString();
            report.SendDate = DateTime.Parse(json.GetValue("sendDate").ToString());

            return report;
        }
    }
}
