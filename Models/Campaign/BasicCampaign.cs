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
        public string CreatedDate { get; set; }

        [JsonProperty("sdate")]
        public string SentDate { get; set; }

        [JsonProperty("ldate")]
        public string LastEditedDate { get; set; }

        [JsonProperty("name")]
        public string Title { get; set; }

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