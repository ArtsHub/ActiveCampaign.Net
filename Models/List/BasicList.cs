using ActiveCampaign.Net.Models.Contact;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.List
{
    public class BasicList
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cdate")]
        public DateTime CDate { get; set; }

        [JsonProperty("private")]
        private string PrivateAsString { get; set; }

        [JsonIgnore]
        public bool Private
        {
            get { return PrivateAsString != "0"; }
            set { PrivateAsString = value ? "1" : "0"; }
        }

        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("subscriber_count")]
        public int SubscriberCount { get; set; }
    }
}