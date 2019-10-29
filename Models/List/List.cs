using ActiveCampaign.Net.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.List
{
    public class List
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }
        [Newtonsoft.Json.JsonProperty("listid")]
        public int ListId { get; set; }

        [Required]
        [Newtonsoft.Json.JsonProperty("stringid")]
        public string StringId { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("cdate")]
        public DateTime LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("p_use_tracking")]
        public bool UseTracking { get; set; }

        [Newtonsoft.Json.JsonProperty("subscribers")]
        public int Subscribers { get; set; }

        [Newtonsoft.Json.JsonProperty("groups")]
        public List<string> Groups { get; set; }

        [Newtonsoft.Json.JsonProperty("ip4")]
        public string IPAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [Newtonsoft.Json.JsonProperty("optname")]
        public int OptName { get; set; }

    }
}