namespace ActiveCampaign.Net.Services
{
    using ActiveCampaign.Net.Custom;
    using ActiveCampaign.Net.Enums;
    using ActiveCampaign.Net.Models.Campaign;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the class to be used to deal with the active campaign's campaigning
    /// related functionality.
    /// </summary>
    public class CampaignService : ActiveCampaignService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignService"/> class.
        /// </summary>
        /// <param name="apiKey">The API key <see cref="string"/></param>
        /// <param name="apiUrl">The API URL<see cref="string"/></param>
        /// <param name="apiPassword">The API Password<see cref="string"/></param>
        public CampaignService(string apiKey = null, string apiUrl = null, string apiPassword = null) : base(apiKey, apiUrl, apiPassword)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// The function to be used to add or edit the message for a campaign.
        /// </summary>
        /// <param name="model">The model<see cref="MessageAdd"/></param>
        /// <returns>The <see cref="MessageAddResponse"/></returns>
        public MessageAddResponse MessageSync(Message model, bool isEdit)
        {
            try
            {
                var postData = new Dictionary<string, string>()
                {
                    { "format", string.IsNullOrEmpty(model.Format) ? "mime" : model.Format },
                    { "subject", model.Subject },
                    { "fromemail", model.Fromemail },
                    { "fromname", model.Fromname },
                    { "reply2", model.Reply2 },
                    { "priority", string.IsNullOrEmpty(model.Priority)? "3" : model.Priority.ToString() },
                    { "charset",  string.IsNullOrEmpty(model.Charset) ? "utf-8" : model.Charset },
                    { "encoding", string.IsNullOrEmpty(model.Encoding) ? "quoted-printable" : model.Encoding },
                    { "htmlconstructor", string.IsNullOrEmpty(model.HtmlConstructor) ? "editor" : model.HtmlConstructor },
                    { "htmlfetch", string.IsNullOrEmpty(model.HtmlFetch) ? "editor" : model.HtmlFetch },
                    { "htmlfetchwhen", string.IsNullOrEmpty(model.HtmlFetchWhen) ? "" : model.HtmlFetchWhen },
                    { "html", string.IsNullOrEmpty(model.Html)? "HTML is null or empty" : model.Html },
                    { "textconstructor", string.IsNullOrEmpty(model.TextConstructor) ? "editor" : model.TextConstructor },
                    { "text", string.IsNullOrEmpty(model.Text)? "Text is null or empty":model.Text },
                    { $"p[{model.Listslist}]", string.IsNullOrEmpty(model.Listslist)?"0":model.Listslist },
                };

                string apiAction = "message_add";

                if (isEdit)
                {
                    postData.Add("id", model.Id);
                    apiAction = "message_edit";
                }

                var jsonResponse = SendRequest(apiAction, new Dictionary<string, string>(), postData);

                return JsonConvert.DeserializeObject<MessageAddResponse>(jsonResponse);
            }
            catch (Exception ex)
            {
                //ArtsHub.BLL.Emailing.Emailing.EmailException_NoPageContext(" in CampaignService.MessageAdd", "", ex, true);

                throw new ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// The function to be used to create a campaign.
        /// </summary>
        /// <param name="model">An object of type <see cref="CampaignCreate"/></param>
        /// <returns><see cref="CampaignCreateResponse"/></returns>
        public CampaignCreateResponse CampaignCreate(CampaignCreate model)
        {
            try
            {
                var postData = new Dictionary<string, string>()
                {
                    { "api_output", string.IsNullOrEmpty(model.ApiOutput) ? "json" : model.ApiOutput },
                    { "type", model.Type.ToString().ToLower() },
                    { "segmentid", model.SegmentId.ToString() },
                    { "name", model.Name },
                    { "sdate",model.ScheduleDate.HasValue ? model.ScheduleDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "0000-00-00 00:00:00" },
                    { "status", ((int)model.Status).ToString() },
                    { "public", model.Visible ? "1" : "0" },
                    { "tracklinks", model.TrackLinks.ToString().ToLower() },
                    { "tracklinksanalytics", model.IsToTrackLinkAnalytics ? "1" : "0" },
                    { "trackreads", model.IsToTrackReads ? "1" : "0" },
                    { "trackreplies", model.IsToTrackReplies ? "1" : "0" },
                    { "analytics_campaign_name", model.AnalyticsCampaignName },
                    { "tweet", model.IsToUseListTweetSettings ? "1" : "0" },
                    { "facebook", model.IsToUseListFacebookSettings ? "1" : "0" },
                    { "htmlunsub", model.IsToAppendUnsuscribeLinkToHtmlBody ? "1" : "0" },
                    { "textunsub", model.IsToAppendUnsuscribeLinkToTextBody ? "1" : "0" },
                    { "htmlunsubdata", model.HtmlUnsubscribeCustomData },
                    { "textunsubdata", model.TextUnsubscribeCustomData },
                    { $"m[{model.MessageId}]", "100" },
                };

                foreach (int listId in model.ListIds)
                {
                    postData.Add("p[{listId}]", listId.ToString());
                }

                var jsonResponse = SendRequest("campaign_create", new Dictionary<string, string>(), postData);

                return JsonConvert.DeserializeObject<CampaignCreateResponse>(jsonResponse);
            }
            catch (Exception ex)
            {
                throw new ExceptionService(ex.Message);
            }
        }

        public List<BasicCampaign> ListBasicCampigns(Dictionary<string, string> getParameters)
        {
            var jsonResponse = SendRequest("campaign_list", getParameters, null);

            var customJsonConverter = new CustomJsonDateConverter();

            var basicListResponse = JsonConvert.DeserializeObject<BasicCampaignListResponse>(jsonResponse, customJsonConverter);

            return basicListResponse.List;
        }

        public List<CampaignFull> ListFullCampaigns(Dictionary<string, string> getParameters)
        {
            var jsonResponse = SendRequest("campaign_list", getParameters, null);

            var listResponse = JsonConvert.DeserializeObject<CampaignFullListResponse>(jsonResponse);

            return listResponse.List;
        }

        public BasicCampaign GetBasicCampaign(int id)
        {
            var jsonResponse = SendRequest("campaign_list", new Dictionary<string, string> { { "ids", id.ToString() }, { "full", "0" } });

            var basicListResponse = JsonConvert.DeserializeObject<CampaignFull>(jsonResponse);

            return basicListResponse;
        }

        public CampaignFull GetFullCampaign(int id)
        {
            var jsonResponse = SendRequest("campaign_list", new Dictionary<string, string> { { "ids", id.ToString() }, { "full", "1" } });

            var listResponse = JsonConvert.DeserializeObject<CampaignFullListResponse>(jsonResponse);

            CampaignFull firstCampaign = null;

            if (listResponse.List != null && listResponse.List.Count > 0)
            {
                firstCampaign = listResponse.List[0];
            }

            return firstCampaign;
        }

        public int DeleteCampaign(int id)
        {
            var jsonResponse = SendRequest("campaign_delete", new Dictionary<string, string> { { "id", id.ToString() } });

            var result = JsonConvert.DeserializeObject<ActiveCampaign.Net.Models.Result>(jsonResponse);

            return result.ResultCode;
        }

        /// <summary>
        /// Send an existing campaign using optional actions like 'copy', 'preview', 'test'.
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="messageId"></param>
        /// <param name="action">Examples: 'send' = send a campaign to this contact and to append him to the recipients list, 'copy' = send a copy of a campaign to contact (campaign is not updated), 'test' = send a test email to contact (campaign is not updated), 'source' = simulate a campaign test to contact (campaign is not updated), return message source, 'messagesize' = simulate a campaign test to contact (campaign is not updated), return message size, 'spamcheck' = simulate a campaign test to contact (campaign is not updated), return spam rate, 'preview' = same as preview
        /// Example response:
        ///Variable Description
        ///result_code Whether or not the response was successful.Examples: 1 = yes, 0 = no
        ///result_message  A custom message that appears explaining what happened. Example: Message sent
        ///result_output The result output used.Example: serialize
        ///param>
        /// <returns></returns>
        public int CampaignSend(int campaignId, CampaignSendAction action, string messageId, string emailId)
        {

            var jsonResponse = SendRequest("campaign_send", new Dictionary<string, string> { { "campaignid", campaignId.ToString() }, { "messageid", messageId.ToString() }, { "action", action.ToString() }, { "email", emailId } });

            var result = JsonConvert.DeserializeObject<ActiveCampaign.Net.Models.Result>(jsonResponse);

            return result.ResultCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="dateScheduled">New scheduled date (use format YYYY-MM-DD HH:MM:SS). This only applies to scheduled campaigns (status = 1), and "single" (regular/one-time)</param>
        /// <param name="status">New status. Examples: 0 = draft, 1 = scheduled, 2 = sending, 3 = paused, 4 = stopped, 5 = completed</param>
        /// <returns></returns>
        public int UpdateCampaignStatus(int campaignId, string dateScheduled, CampaignStatus status)
        {
            var jsonResponse = SendRequest("campaign_status", new Dictionary<string, string> { { "id", campaignId.ToString() }, { "sdate", dateScheduled }, { "status", ((int)(status)).ToString() } });

            var result = JsonConvert.DeserializeObject<ActiveCampaign.Net.Models.Result>(jsonResponse);

            return result.ResultCode;
        }

        public Message GetMessage(string messageId)
        {
            var jsonResponse = SendRequest("message_view", new Dictionary<string, string> { { "id", messageId } });

            var result = JsonConvert.DeserializeObject<Message>(jsonResponse);

            return result;
        }

        #endregion Methods
    }
}