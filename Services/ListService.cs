namespace ActiveCampaign.Net.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ActiveCampaign.Net.Models.Contact;
    using Newtonsoft.Json;
    using ActiveCampaign.Net.Models.List;

    /// <summary>
    /// Defines the <see cref="ContactService" />
    /// </summary>
    public class ListService : ActiveCampaignService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="apiKey">The API key <see cref="string"/></param>
        /// <param name="apiUrl">The API URL<see cref="string"/></param>
        /// <param name="apiPassword">The API Password<see cref="string"/></param>
        public ListService(string apiKey = null, string apiUrl = null, string apiPassword = null) : base(apiKey, apiUrl, apiPassword)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// View only one contact's details by searching for their email address.
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <returns><see cref="BasicContactInfo"/></returns>
        public BasicList GetList(string listId)
        {
            var getData = new Dictionary<string, string> { { "id", listId } };
            var jsonResponse = SendRequest("list_view", getData, null);

            return JsonConvert.DeserializeObject<BasicList>(jsonResponse);
        }


        public List<BasicList> ListLists()
        {
            var jsonResponse = SendRequest("list_list", new Dictionary<string, string> { { "ids", "all" } }, null);

            var basicListResponse = JsonConvert.DeserializeObject<BasicListResponse>(jsonResponse);

            return basicListResponse.List;

        }

         #endregion
    }
}