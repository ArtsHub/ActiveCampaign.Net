using ActiveCampaign.Net.Models.List;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ActiveCampaign.Net.Models.Contact
{
    public class BasicListResponse : Result
    {
        /// <summary>
        /// The contact ID that was added or updated.
        /// </summary>
        public IEnumerable<BasicList>  list { get; set; }
    }
}