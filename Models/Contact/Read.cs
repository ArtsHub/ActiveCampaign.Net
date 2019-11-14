using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ActiveCampaign.Net.Models.Contact
{
    public class Read
    {
        [JsonProperty("tstamp")]
        public DateTimeOffset Tstamp { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("times")]
        public long Times { get; set; }

        [JsonProperty("tstamp_settings")]
        public string TstampSettings { get; set; }
    }
}