﻿namespace ActiveCampaign.Net.Services
{
    using System;
    using System.Collections.Generic;
    using ActiveCampaign.Net.Custom;
    using ActiveCampaign.Net.Models.Campaign;
    using Newtonsoft.Json;

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

        #endregion

        #region Methods

        /// <summary>
        /// The function to be used to add the message for a campaign.
        /// </summary>
        /// <param name="model">The model<see cref="MessageAdd"/></param>
        /// <returns>The <see cref="MessageAddResponse"/></returns>
        public MessageAddResponse MessageAdd(MessageAdd model)
        {
            try
            {
                var postData = new Dictionary<string, string>()
                {
                    { "api_output", string.IsNullOrEmpty(model.ApiOutput) ? "json" : model.ApiOutput },
                    { "format", string.IsNullOrEmpty(model.Format) ? "mime" : model.Format },
                    { "subject", model.Subject },
                    { "fromemail", model.FromEmail },
                    { "fromname", model.FromName },
                    { "reply2", model.ReplyTo },
                    { "priority", model.Priority == default(int) ? "3" : model.Priority.ToString() },
                    { "charset",  string.IsNullOrEmpty(model.Charset) ? "utf-8" : model.Charset },
                    { "encoding", string.IsNullOrEmpty(model.Encoding) ? "quoted-printable" : model.Encoding },
                    { "htmlconstructor", string.IsNullOrEmpty(model.HtmlConstructor) ? "editor" : model.HtmlConstructor },
                    { "htmlfetch", string.IsNullOrEmpty(model.HtmlFetch) ? "editor" : model.HtmlFetch },
                    { "htmlfetchwhen", string.IsNullOrEmpty(model.HtmlFetchWhen) ? "" : model.HtmlFetchWhen },
                    { "html", string.IsNullOrEmpty(model.Html)? "HTML is null or empty" : model.Html },
                    { "textconstructor", string.IsNullOrEmpty(model.TextConstructor) ? "editor" : model.TextConstructor },
                    { "text", string.IsNullOrEmpty(model.Text)? "Text is null or empty":model.Text },
                    { $"p[{model.ListId}]", string.IsNullOrEmpty(model.ListId.ToString())?"0":model.ListId.ToString() },
                };


                var jsonResponse = SendRequest("message_add", new Dictionary<string, string>(), postData);

                return JsonConvert.DeserializeObject<MessageAddResponse>(jsonResponse);
            }
            catch (Exception ex)
            {
                ArtsHub.BLL.Emailing.Emailing.EmailException(" in CampaignService.MessageAdd", "", ex);

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

        public List<BasicCampaign> ListBasicCampigns(Dictionary<string,string> getParameters)
        {
            var jsonResponse = SendRequest("campaign_list", getParameters, null);

            var customJsonConverter = new CustomJsonDateConverter();

            var basicListResponse = JsonConvert.DeserializeObject<BasicCampaignListResponse>(jsonResponse, customJsonConverter);

            return basicListResponse.List;

        }
        public List<CampaignFull> ListFullCampaigns(Dictionary<string,string> getParameters)
        {
            var jsonResponse = SendRequest("campaign_list", getParameters, null);

            var customJsonConverter = new CustomJsonDateConverter();

            var listResponse = JsonConvert.DeserializeObject<CampaignFullListResponse>(jsonResponse, customJsonConverter);

            return listResponse.List;

        }

        public BasicCampaign GetBasicCampaign(int id)
        {
            var jsonResponse = SendRequestV3("campaign_list", id, new Dictionary<string, string> { { "ids", "all" }, { "full", "0" } });

            var customJsonConverter = new CustomJsonDateConverter();

            var basicListResponse = JsonConvert.DeserializeObject<CampaignFull>(jsonResponse, customJsonConverter);

            return basicListResponse;
        }


        #endregion
    }
}
