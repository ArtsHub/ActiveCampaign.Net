using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.Campaign
{
    public class Message : Result
    {
        public string HtmlConstructor { get; set; }
        public string HtmlFetch { get; set; }
        public string HtmlFetchWhen { get; set; }
        public string TextConstructor { get; set; }
        public int CampaignId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userid")]
        public string Userid { get; set; }

        [JsonProperty("ed_instanceid")]
        public string EdInstanceid { get; set; }

        [JsonProperty("ed_version")]
        public string EdVersion { get; set; }

        [JsonProperty("cdate")]
        public string CDate { get; set; }


        [JsonProperty("mdate")]
        public string MDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fromname")]
        public string Fromname { get; set; }

        [JsonProperty("fromemail")]
        public string Fromemail { get; set; }

        [JsonProperty("reply2")]
        public string Reply2 { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("charset")]
        public string Charset { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("preheader_text")]
        public string PreheaderText { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("htmlfetch")]
        public string Htmlfetch { get; set; }

        [JsonProperty("textfetch")]
        public string Textfetch { get; set; }

        [JsonProperty("hidden")]
        public string Hidden { get; set; }

        [JsonProperty("preview_mime")]
        public string PreviewMime { get; set; }

        [JsonProperty("preview_data")]
        public string PreviewData { get; set; }

        [JsonProperty("lists")]
        public List<ActiveCampaign.Net.Models.List.List> Lists { get; set; }

        [JsonProperty("files")]
        public List<object> Files { get; set; }

        [JsonProperty("filescnt")]
        public string Filescnt { get; set; }

        [JsonProperty("has_today_tag")]
        public bool HasTodayTag { get; set; }

        [JsonProperty("listslist")]

        public string Listslist { get; set; }

        [JsonProperty("activerss_show")]
        public string ActiverssShow { get; set; }

        [JsonProperty("htmlfetchurl")]
        public string Htmlfetchurl { get; set; }

        [JsonProperty("textfetchurl")]
        public string Textfetchurl { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        [JsonProperty("images")]
        public dynamic Images { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }

        [JsonProperty("sourcesize")]
        public string Sourcesize { get; set; }

        [JsonProperty("spamcheck_score")]
        public string SpamcheckScore { get; set; }

        [JsonProperty("spamcheck_max")]
        public string SpamcheckMax { get; set; }
    }
}