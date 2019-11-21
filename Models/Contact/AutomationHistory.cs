using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ActiveCampaign.Net.Models.Contact
{
    public class AutomationHistory
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("adddate")]
        public string Adddate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("messages")]
        public List<object> Messages { get; set; }
    }
}