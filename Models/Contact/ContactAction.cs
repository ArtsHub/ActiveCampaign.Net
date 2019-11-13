using Newtonsoft.Json;
using System;


namespace ActiveCampaign.Net.Models.Contact
{
    public class ContactAction
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tstamp")]
        public DateTimeOffset Tstamp { get; set; }
               

    }
}