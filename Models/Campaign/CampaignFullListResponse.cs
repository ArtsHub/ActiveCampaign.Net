using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ActiveCampaign.Net.Models.Campaign
{
    public class CampaignFullListResponse : Result
    {
        /// <summary>
        /// The contact list
        /// </summary>
        public List<CampaignFull> List { get; set; }


        [JsonExtensionData]
        private Dictionary<string, JToken> Data { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            List = Data?.OrderBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Value.ToObject<CampaignFull>())
                        .ToList();
        }

    }
}