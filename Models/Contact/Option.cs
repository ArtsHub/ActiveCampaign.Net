using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ActiveCampaign.Net.Models.Contact
{
    public class Option
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("isdefault")]
        private string _isDefault { get; set; }
        public bool IsDefault
        {
            get { return _isDefault != "0"; }
            set { _isDefault = value ? "1" : "0"; }
        }


    }
}