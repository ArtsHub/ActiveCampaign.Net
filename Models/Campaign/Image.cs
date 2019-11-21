using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.Campaign
{
    public class Image
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}