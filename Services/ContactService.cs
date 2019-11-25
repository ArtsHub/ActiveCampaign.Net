﻿namespace ActiveCampaign.Net.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ActiveCampaign.Net.Models.Contact;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="ContactService" />
    /// </summary>
    public class ContactService : ActiveCampaignService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="apiKey">The API key <see cref="string"/></param>
        /// <param name="apiUrl">The API URL<see cref="string"/></param>
        /// <param name="apiPassword">The API Password<see cref="string"/></param>
        public ContactService(string apiKey = null, string apiUrl = null, string apiPassword = null) : base(apiKey, apiUrl, apiPassword)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// View only one contact's details by searching for their email address.
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <returns><see cref="BasicContactInfo"/></returns>
        public Contact GetBasicContactInfo(string email)
        {
            var getData = new Dictionary<string, string> { { "email", email } };
            var jsonResponse = SendRequest("contact_view_email", getData, null);

            return JsonConvert.DeserializeObject<Contact>(jsonResponse);
        }

        /// <summary>
        /// View only one contact's details by searching for their email address.
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <returns><see cref="BasicContact"/></returns>
        public Contact GetContact(int id)
        {
            var getData = new Dictionary<string, string> { { "id", id.ToString() } };
            var jsonResponse = SendRequest("contact_view", getData, null);

            return JsonConvert.DeserializeObject<Contact>(jsonResponse);
        }

        /// <summary>
        /// Add or edit a contact based on their email address. Instead of calling contact_view to check if the contact exists, 
        /// and then calling contact_add or contact_edit, you can make just one call and include only the information you want added or updated.
        /// </summary>
        /// <param name="basicContactInfo"></param>
        /// <param name="contactLists"></param>
        /// <returns><see cref="ContactSyncResponse"/></returns>
        public string SyncContact(Contact contact)
        {
            var postData = new Dictionary<string, string>
            {
                { "email", contact.Email },
                { "first_name", contact.FirstName ?? string.Empty },
                { "last_name", contact.LastName ?? string.Empty },
                { "status", contact.Status.ToString() ?? string.Empty },
                { "status", contact.Status.ToString() ?? string.Empty },
                { "customer_acct_name", contact.CustomerAcctName ?? string.Empty },
                { "tags", string.Join(",", contact.Tags.ToArray() )}
                //{ "phone", basicContactInfo.Phone ?? string.Empty },
                //{ "orgname", basicContactInfo.OrganizationName ?? string.Empty },
                //{ "form", basicContactInfo.FormId.ToString() ?? string.Empty },
            };

            //Fields
            foreach (KeyValuePair<string, Field> f in contact.Fields)
            {
                if (!string.IsNullOrEmpty(f.Key) && f.Value != null && !string.IsNullOrEmpty(f.Value.Tag) && !string.IsNullOrEmpty(f.Value.Val))
                {

                    postData.Add("field[{f.Value.Tag}]", f.Value.Val ?? string.Empty);
                }

            }
            //List & status for each list
            foreach (KeyValuePair<string, ActiveCampaign.Net.Models.List.List> l in contact.Lists)
            {
                if (!string.IsNullOrEmpty(l.Key) && l.Value != null && !string.IsNullOrEmpty(l.Value.Id.ToString()))
                {
                    postData.Add("p[{(f.Value.Id.ToString()}]", (l.Value.Id.ToString() ?? string.Empty));
                    postData.Add("status[{(f.Value.Id.ToString()}]", (contact.Status.ToString() ?? string.Empty));
                }
            }

            //Lists

            //if (basicContactInfo.Tags != null && basicContactInfo.Tags.Any())
            //{
            //    postData.Add("tags", string.Join(",", basicContactInfo.Tags));
            //}

            //foreach (var contactList in contactLists)
            //{
            //    postData.Add(
            //        string.Format("p[{0}]", contactList.Id), contactList.Id.ToString());

            //    postData.Add(
            //        string.Format("status[{0}]", contactList.Id),
            //        contactList.Status.ToString("D"));

            //    postData.Add(
            //        string.Format("noresponders[{0}]", contactList.Id),
            //        Convert.ToInt32(contactList.Noresponders).ToString());

            //    postData.Add(
            //        string.Format("sdate[{0}]", contactList.Id),
            //        contactList.SubscribeDate);

            //    postData.Add(
            //        string.Format("instantresponders[{0}]", contactList.Id),
            //        Convert.ToInt32(contactList.InstantResponders).ToString());

            //    postData.Add(
            //        string.Format("lastmessage[{0}]", contactList.Id),
            //        Convert.ToInt32(contactList.LastMessage).ToString());
            //}

            //if (basicContactInfo.Fields != null && basicContactInfo.Fields.Any())
            //{
            //    foreach (var field in basicContactInfo.Fields)
            //    {
            //        postData.Add(
            //            string.Format("field[{0},0]", field.Id != null ? field.Id.ToString() : field.Name),
            //            field.Value);
            //    }
            //}

            var jsonResponse = SendRequest("contact_sync", null, postData);

            return JsonConvert.DeserializeObject<ContactSyncResponse>(jsonResponse).SubscriberId;
        }

        public List<BasicContactInfo> ListBasicContactInfo(int listId)
        {
            var jsonResponse = SendRequest("contact_list", new Dictionary<string, string> { { "ids", listId.ToString() }, { "full", "0" } }, null);

            var basicListResponse = JsonConvert.DeserializeObject<BasicContactListResponse>(jsonResponse);

            return basicListResponse.List;

        }

        #endregion
    }
}
