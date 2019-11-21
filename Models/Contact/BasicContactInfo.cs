using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.Contact
{
    public class BasicContactInfo
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("subscriberid")]
        public int Subscriberid { get; set; }

        [Required]
        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_list")]
        public string LastList { get; set; }

        [Newtonsoft.Json.JsonProperty("avatar_url")]
        public string AvatarURL { get; set; }

        [Newtonsoft.Json.JsonProperty("cdate")]
        public DateTime CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty("sdate")]
        public string SubscribedOn { get; set; }




    }
}