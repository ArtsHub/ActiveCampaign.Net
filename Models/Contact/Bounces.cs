using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ActiveCampaign.Net.Models.Contact
{
    public class Bounces
    {
        [JsonProperty("mailing")]
        public List<object> Mailing { get; set; }

        [JsonProperty("mailings")]
        public int Mailings { get; set; }

        [JsonProperty("responder")]
        public List<object> Responder { get; set; }

        [JsonProperty("responders")]
        public int Responders { get; set; }
    }
}