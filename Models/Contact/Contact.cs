using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.Contact
{
    public class Contact : BasicContactInfo
    {
        [JsonProperty("listid")]
        public int Listid { get; set; }

        [JsonProperty("formid")]
        public int Formid { get; set; }

        [JsonProperty("seriesid")]
        public int Seriesid { get; set; }

        [JsonProperty("sdate")]
        public DateTime Sdate { get; set; }

        [JsonProperty("udate")]
        public DateTime Udate { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("responder")]
        public int Responder { get; set; }

        [JsonProperty("sync")]
        public int Sync { get; set; }

        [JsonProperty("unsubreason")]
        public string Unsubreason { get; set; }

        [JsonProperty("unsubcampaignid")]
        public int Unsubcampaignid { get; set; }

        [JsonProperty("unsubmessageid")]
        public int Unsubmessageid { get; set; }

        [JsonProperty("ip4_sub")]
        public string Ip4Sub { get; set; }

        [JsonProperty("sourceid")]
        public int Sourceid { get; set; }

        [JsonProperty("sourceid_autosync")]
        public string SourceidAutosync { get; set; }

        [JsonProperty("ip4_last")]
        public string Ip4Last { get; set; }

        [JsonProperty("ip4_unsub")]
        public string Ip4Unsub { get; set; }

        [JsonProperty("created_timestamp")]
        public DateTime CreatedTimestamp { get; set; }

        [JsonProperty("updated_timestamp")]
        public DateTime? UpdatedTimestamp { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("updated_by")]
        public string UpdatedBy { get; set; }

        [JsonProperty("listname")]
        public string Listname { get; set; }

        [JsonProperty("sdate_iso")]
        public DateTime? SdateIso { get; set; }

        [JsonProperty("lid")]
        public int Lid { get; set; }

        [JsonProperty("ip4")]
        public string Ip4 { get; set; }

        [JsonProperty("a_unsub_date")]
        public DateTime? AUnsubDate { get; set; }

        [JsonProperty("a_unsub_time")]
        public DateTime? AUnsubTime { get; set; }

        [JsonProperty("cdate")]
        public DateTime? Cdate { get; set; }


        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("customer_acct_id")]
        public int CustomerAcctId { get; set; }

        [JsonProperty("customer_acct_name")]
        public string CustomerAcctName { get; set; }

        [JsonProperty("segmentio_id")]
        public string SegmentioId { get; set; }

        [JsonProperty("bounced_hard")]
        public int BouncedHard { get; set; }

        [JsonProperty("bounced_soft")]
        public int BouncedSoft { get; set; }

        [JsonProperty("bounced_date")]
        public DateTime? BouncedDate { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("ua")]
        public string Ua { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("socialdata_lastcheck")]
        public DateTime? SocialdataLastcheck { get; set; }

        [JsonProperty("email_local")]
        public string EmailLocal { get; set; }

        [JsonProperty("email_domain")]
        public string EmailDomain { get; set; }

        [JsonProperty("sentcnt")]
        public int Sentcnt { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("rating_tstamp")]
        public DateTime RatingTstamp { get; set; }

        [JsonProperty("gravatar")]
        public int Gravatar { get; set; }

        [JsonProperty("deleted")]
        private string _deleted { get; set; }

        public bool Deleted
        {
            get { return _deleted != "0"; }
            set { _deleted = value ? "1" : "0"; }
        }

        [JsonProperty("anonymized")]
        public string _anonymized { get; set; }

        public bool Anonymized
        {
            get { return _anonymized != "0"; }
            set { _anonymized = value ? "1" : "0"; }
        }


        [JsonProperty("adate")]
        public DateTime? Adate { get; set; }

        [JsonProperty("edate")]
        public DateTime? Edate { get; set; }

        [JsonProperty("deleted_at")]
        public string DeletedAt { get; set; }

        [JsonProperty("created_utc_timestamp")]
        public DateTime? CreatedUtcTimestamp { get; set; }

        [JsonProperty("updated_utc_timestamp")]
        public DateTime? UpdatedUtcTimestamp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lists")]
        public List<Models.List.BasicList> Lists { get; set; }

        [JsonProperty("listslist")]
        public string Listslist { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }

        [JsonProperty("automation_history")]
        public List<AutomationHistory> AutomationHistory { get; set; }

        [JsonProperty("campaign_history")]
        public List<CampaignHistory> CampaignHistory { get; set; }

        [JsonProperty("bounces")]
        public Bounces Bounces { get; set; }

        [JsonProperty("bouncescnt")]
        public int Bouncescnt { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("orgid")]
        public int Orgid { get; set; }

        [JsonProperty("orgname")]
        public string Orgname { get; set; }

    }
}