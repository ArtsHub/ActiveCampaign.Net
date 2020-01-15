namespace ActiveCampaign.Net.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
        /// Get contact by email
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact GetContact(string emailId)
        {
            var getData = new Dictionary<string, string> { { "email", emailId } };
            var jsonResponse = SendRequest("contact_view_email", getData, null);

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
            StringBuilder sb = new StringBuilder();
            string result = string.Empty;
            try
            {
                sb.AppendLine("Creating postdata<br>");
                var postData = new Dictionary<string, string>
                {
                    { "email", contact.Email },
                    { "first_name", contact.FirstName ?? string.Empty },
                    { "last_name", contact.LastName ?? string.Empty }
                };
                sb.AppendLine("Initial postdata created<br>");

                if(contact.Fields != null) sb.AppendLine("Contact field count : " + contact.Fields.Count + "<br>");

                if (!string.IsNullOrEmpty(contact.CustomerAcctName)) postData.Add("customer_acct_name", contact.CustomerAcctName);

                if (contact.Formid > 0) postData.Add("form", contact.Formid.ToString());

                if (!string.IsNullOrEmpty(contact.Phone)) postData.Add("phone", contact.Phone);

                //if (!string.IsNullOrEmpty(contact.Status)) postData.Add("status", contact.Status);

                sb.AppendLine("Initial Before fields<br>");

                //Fields
                if (contact.Fields != null)
                {
                    foreach (KeyValuePair<string, Field> f in contact.Fields)
                    {
                        if (!string.IsNullOrEmpty(f.Key) && f.Value != null && !string.IsNullOrEmpty(f.Value.Tag) && !string.IsNullOrEmpty(f.Value.Val))
                        {
                            sb.AppendLine("field[" + f.Value.Tag + "] - " + f.Value.Val + "<br>");
                            postData.Add("field[" + f.Value.Tag + "]", f.Value.Val ?? string.Empty);
                        }

                    }
                }

                sb.AppendLine("Initial Before lists : " + contact.Listid + "<br>Status : " + contact.Status + "<br>");

                //List & status for each list
                if (contact.Listid > 0 && !string.IsNullOrEmpty(contact.Status))
                { 
                    sb.AppendLine("p[" + contact.Listid.ToString() + "] - " + contact.Listid.ToString() + " <br>");
                    sb.AppendLine("status[" + contact.Listid + "] - " + contact.Status + " <br>");

                    postData.Add("p[" + contact.Listid.ToString() + "]", contact.Listid.ToString());
                    postData.Add("status[" + contact.Listid.ToString() + "]", contact.Status);
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

               // ArtsHub.BLL.Emailing.Emailing.EmailDebugging(" Debugging in AC > ContactService ", sb.ToString());


                var jsonResponse = SendRequest("contact_sync", new Dictionary<string, string> { }, postData);

                result = JsonConvert.DeserializeObject<ContactSyncResponse>(jsonResponse).SubscriberId;
            }
            catch (Exception ex)
            {
                //ArtsHub.BLL.Emailing.Emailing.EmailException_NoPageContext(" in AC > ContactService ", sb.ToString(), ex, true);
                throw new Services.ExceptionService(ex.Message + " in AC > ContactService <br>" + sb.ToString());
            }

            return result;
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
