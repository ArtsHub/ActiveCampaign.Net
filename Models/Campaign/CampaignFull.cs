using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.Campaign
{
    public class CampaignFull : BasicCampaign
    {

        [JsonProperty("userid")]
        public int Userid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("segmentid")]
        public int Segmentid { get; set; }

        [JsonProperty("seriesid")]
        public int Seriesid { get; set; }

        [JsonProperty("formid")]
        public int Formid { get; set; }

        [JsonProperty("basetemplateid")]
        public string Basetemplateid { get; set; }

        [JsonProperty("basemessageid")]
        public int Basemessageid { get; set; }

        [JsonProperty("addressid")]
        public int Addressid { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("mdate")]
        public DateTime? Mdate { get; set; }


        [JsonProperty("opens")]
        public int Opens { get; set; }

        [JsonProperty("uniqueopens")]
        public int Uniqueopens { get; set; }

        [JsonProperty("linkclicks")]
        public int Linkclicks { get; set; }

        [JsonProperty("uniquelinkclicks")]
        public int Uniquelinkclicks { get; set; }

        [JsonProperty("subscriberclicks")]
        public int Subscriberclicks { get; set; }

        [JsonProperty("forwards")]
        public int Forwards { get; set; }

        [JsonProperty("uniqueforwards")]
        public int Uniqueforwards { get; set; }

        [JsonProperty("hardbounces")]
        public int Hardbounces { get; set; }

        [JsonProperty("softbounces")]
        public int Softbounces { get; set; }

        [JsonProperty("unsubscribes")]
        public int Unsubscribes { get; set; }

        [JsonProperty("unsubreasons")]
        public int Unsubreasons { get; set; }

        [JsonProperty("updates")]
        public int Updates { get; set; }

        [JsonProperty("socialshares")]
        public int Socialshares { get; set; }

        [JsonProperty("replies")]
        public int Replies { get; set; }

        [JsonProperty("uniquereplies")]
        public int Uniquereplies { get; set; }

        [JsonProperty("tracklinks")]
        public string Tracklinks { get; set; }

        [JsonProperty("tracklinksanalytics")]
        public int Tracklinksanalytics { get; set; }

        [JsonProperty("trackreads")]
        public int Trackreads { get; set; }

        [JsonProperty("trackreadsanalytics")]        
        public int Trackreadsanalytics { get; set; }

        [JsonProperty("analytics_campaign_name")]
        public string AnalyticsCampaignName { get; set; }

        [JsonProperty("tweet")]
        public int Tweet { get; set; }

        [JsonProperty("facebook")]
        public int Facebook { get; set; }

        [JsonProperty("survey")]
        public string Survey { get; set; }

        [JsonProperty("recurring")]
        public string Recurring { get; set; }

        [JsonProperty("split_type")]
        public string SplitType { get; set; }

        [JsonProperty("split_offset")]
        public int SplitOffset { get; set; }

        [JsonProperty("split_offset_type")]
        public string SplitOffsetType { get; set; }

        [JsonProperty("split_winner_messageid")]
        public int SplitWinnerMessageid { get; set; }

        [JsonProperty("split_winner_awaiting")]
        public int SplitWinnerAwaiting { get; set; }

        [JsonProperty("responder_offset")]
        public int ResponderOffset { get; set; }

        [JsonProperty("reminder_field")]
        public string ReminderField { get; set; }

        [JsonProperty("reminder_format")]
        public object ReminderFormat { get; set; }

        [JsonProperty("reminder_type")]
        public string ReminderType { get; set; }

        [JsonProperty("reminder_offset")]
        public int ReminderOffset { get; set; }

        [JsonProperty("reminder_offset_type")]
        public string ReminderOffsetType { get; set; }

        [JsonProperty("reminder_offset_sign")]
        public string ReminderOffsetSign { get; set; }

        [JsonProperty("activerss_interval")]
        public string ActiverssInterval { get; set; }

        [JsonProperty("activerss_url")]
        public object ActiverssUrl { get; set; }

        [JsonProperty("activerss_items")]
        public int ActiverssItems { get; set; }

        [JsonProperty("laststep")]
        public string Laststep { get; set; }

        [JsonProperty("schedule")]
        public int Schedule { get; set; }

        [JsonProperty("scheduleddate")]
        public DateTime? Scheduleddate { get; set; }

        [JsonProperty("replysys")]
        public int Replysys { get; set; }

        [JsonProperty("fake_ldate")]
        public DateTime? FakeLdate { get; set; }


        [JsonProperty("public")]
        public string Public { get; set; }

        [JsonProperty("lists")]
        public List< ActiveCampaign.Net.Models.List.List> Lists { get; set; }

        [JsonProperty("p")]
        public Dictionary<int,int> listIds{ get; set; }
        
        [JsonProperty("m")]
        public Dictionary<int,int> messageIdArray{ get; set; }

        [JsonProperty("listslist")]
        public int Listslist { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        [JsonProperty("messageslist")]

        public int Messageslist { get; set; }

        [JsonProperty("formname")]
        public string Formname { get; set; }

    }
}