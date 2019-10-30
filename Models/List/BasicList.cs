using ActiveCampaign.Net.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.List
{
    public class BasicList
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }
        [Required]

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("cdate")]
        public DateTime CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty("private")]
        public bool Private { get; set; }

        [Newtonsoft.Json.JsonProperty("userid")]
        public string UserId { get; set; }


        [Newtonsoft.Json.JsonProperty("subscriber_count")]
        public int SubscriberCount { get; set; }
    }
}