using ActiveCampaign.Net.Models.Contact;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.List
{
    public class Bounce
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("userid")]
        public long Userid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("host")]
        public object Host { get; set; }

        [JsonProperty("port")]
        public long Port { get; set; }

        [JsonProperty("user")]
        public object User { get; set; }

        [JsonProperty("pass")]
        public object Pass { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("limit_hard")]
        public long LimitHard { get; set; }

        [JsonProperty("limit_soft")]
        public long LimitSoft { get; set; }

        [JsonProperty("emails_per_batch")]
        public long EmailsPerBatch { get; set; }
    }
}