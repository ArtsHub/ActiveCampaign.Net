using ActiveCampaign.Net.Custom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.Campaign
{
    public class BasicCampaign
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("cdate")]
        public DateTime Cdate { get; set; }

        [JsonProperty("sdate")]
        private string _Sdate { get; set; }

        public DateTime? SentDate { get { return (string.IsNullOrEmpty(_Sdate) || _Sdate.StartsWith("0000")) ? null :  (DateTime?)Convert.ToDateTime(_Sdate) ;  } }

        [JsonProperty("ldate")]
        private string _Ldate { get; set; }

        public DateTime? LastEditedDate { get { return (string.IsNullOrEmpty(_Ldate) ||_Ldate.StartsWith("0000")) ? null : (DateTime?)Convert.ToDateTime(_Ldate); } }


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("send_amt")]
        public string SendAmt { get; set; }

        [JsonProperty("total_amt")]
        public string TotalAmt { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

    }
}