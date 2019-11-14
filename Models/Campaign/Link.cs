using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.Campaign
{
    public class Link
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("link")]
        public string LinkLink { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("messageid")]
        public string Messageid { get; set; }

        [JsonProperty("actions")]
        public List<object> Actions { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}