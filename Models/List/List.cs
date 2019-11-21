using ActiveCampaign.Net.Models.Contact;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.List
{
    public class List : BasicList
    {
        [JsonProperty("stringid")]
        public string Stringid { get; set; }

        [JsonProperty("userid")]        
        public string Userid { get; set; }

        [JsonProperty("p_use_tracking")]        
        public string PUseTracking { get; set; }

        [JsonProperty("p_use_analytics_read")]        
        public string PUseAnalyticsRead { get; set; }

        [JsonProperty("p_use_analytics_link")]        
        public string PUseAnalyticsLink { get; set; }

        [JsonProperty("p_use_twitter")]        
        public string PUseTwitter { get; set; }

        [JsonProperty("p_use_facebook")]        
        public string PUseFacebook { get; set; }

        [JsonProperty("p_embed_image")]        
        public string PEmbedImage { get; set; }

        [JsonProperty("p_use_captcha")]        
        public string PUseCaptcha { get; set; }

        [JsonProperty("send_last_broadcast")]        
        public string SendLastBroadcast { get; set; }

        [JsonProperty("analytics_domains")]
        public object AnalyticsDomains { get; set; }

        [JsonProperty("analytics_source")]
        public string AnalyticsSource { get; set; }

        [JsonProperty("analytics_ua")]
        public string AnalyticsUa { get; set; }

        [JsonProperty("twitter_token")]
        public string TwitterToken { get; set; }

        [JsonProperty("twitter_token_secret")]
        public string TwitterTokenSecret { get; set; }

        [JsonProperty("facebook_session")]
        public object FacebookSession { get; set; }

        [JsonProperty("carboncopy")]
        public object Carboncopy { get; set; }

        [JsonProperty("subscription_notify")]
        public object SubscriptionNotify { get; set; }

        [JsonProperty("unsubscription_notify")]
        public object UnsubscriptionNotify { get; set; }

        [JsonProperty("require_name")]        
        public string RequireName { get; set; }

        [JsonProperty("get_unsubscribe_reason")]        
        public string GetUnsubscribeReason { get; set; }

        [JsonProperty("to_name")]
        public string ToName { get; set; }

        [JsonProperty("optinoptout")]        
        public string Optinoptout { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("sender_addr1")]
        public string SenderAddr1 { get; set; }

        [JsonProperty("sender_addr2")]
        public string SenderAddr2 { get; set; }

        [JsonProperty("sender_city")]
        public string SenderCity { get; set; }

        [JsonProperty("sender_state")]
        public string SenderState { get; set; }

        [JsonProperty("sender_zip")]
        public string SenderZip { get; set; }

        [JsonProperty("sender_country")]
        public string SenderCountry { get; set; }

        [JsonProperty("sender_phone")]
        public string SenderPhone { get; set; }

        [JsonProperty("sender_url")]
        public Uri SenderUrl { get; set; }

        [JsonProperty("sender_reminder")]
        public string SenderReminder { get; set; }

        [JsonProperty("fulladdress")]
        public string Fulladdress { get; set; }

        [JsonProperty("optinmessageid")]        
        public string Optinmessageid { get; set; }

        [JsonProperty("optoutconf")]        
        public string Optoutconf { get; set; }

        [JsonProperty("deletestamp")]
        public object Deletestamp { get; set; }

        [JsonProperty("udate")]
        public string Udate { get; set; }

        [JsonProperty("listid")]        
        public string Listid { get; set; }

        [JsonProperty("p_admin")]        
        public string PAdmin { get; set; }

        [JsonProperty("p_list_add")]        
        public string PListAdd { get; set; }

        [JsonProperty("p_list_edit")]        
        public string PListEdit { get; set; }

        [JsonProperty("p_list_delete")]        
        public string PListDelete { get; set; }

        [JsonProperty("p_list_sync")]        
        public string PListSync { get; set; }

        [JsonProperty("p_list_filter")]        
        public string PListFilter { get; set; }

        [JsonProperty("p_message_add")]        
        public string PMessageAdd { get; set; }

        [JsonProperty("p_message_edit")]        
        public string PMessageEdit { get; set; }

        [JsonProperty("p_message_delete")]        
        public string PMessageDelete { get; set; }

        [JsonProperty("p_message_send")]        
        public string PMessageSend { get; set; }

        [JsonProperty("p_subscriber_add")]        
        public string PSubscriberAdd { get; set; }

        [JsonProperty("p_subscriber_edit")]        
        public string PSubscriberEdit { get; set; }

        [JsonProperty("p_subscriber_delete")]        
        public string PSubscriberDelete { get; set; }

        [JsonProperty("p_subscriber_import")]        
        public string PSubscriberImport { get; set; }

        [JsonProperty("p_subscriber_approve")]        
        public string PSubscriberApprove { get; set; }

        [JsonProperty("lcdate")]
        public DateTime? Lcdate { get; set; }

        [JsonProperty("luserid")]        
        public string Luserid { get; set; }

        [JsonProperty("subscribers")]        
        public string Subscribers { get; set; }

        [JsonProperty("subscribers_active")]        
        public string SubscribersActive { get; set; }

        [JsonProperty("cdate_iso")]
        public DateTime? CdateIso { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty("groupsCnt")]
        public string GroupsCnt { get; set; }

        [JsonProperty("bounces")]
        public List<Bounce> Bounces { get; set; }

        [JsonProperty("analytics_domains_list")]
        public List<object> AnalyticsDomainsList { get; set; }

        [JsonProperty("facebook_oauth_logout_url")]
        public string FacebookOauthLogoutUrl { get; set; }

        [JsonProperty("facebook_oauth_login_url")]
        public Uri FacebookOauthLoginUrl { get; set; }

        [JsonProperty("facebook_oauth_me")]
        public object FacebookOauthMe { get; set; }

    }
}