using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ActiveCampaign.Net.Models.Contact
{
    public class AutomationHistory
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("listid")]
        public int Listid { get; set; }

        [JsonProperty("listname")]
        public string Listname { get; set; }

        [JsonProperty("campaignname")]
        public string Campaignname { get; set; }

        [JsonProperty("sdate")]
        public DateTime Sdate { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("subscriberid")]
        public id Subscriberid { get; set; }

        [JsonProperty("reads")]
        public List<Read> Reads { get; set; }

        [JsonProperty("links")]
        public List<object> Links { get; set; }

        [JsonProperty("forwards")]
        public List<object> Forwards { get; set; }
    }
}