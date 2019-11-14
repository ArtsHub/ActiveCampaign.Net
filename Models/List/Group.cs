using ActiveCampaign.Net.Models.Contact;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Net.Models.List
{
    public partial class Group
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("descript")]
        public string Descript { get; set; }

        [JsonProperty("unsubscribelink")]        
        public string Unsubscribelink { get; set; }

        [JsonProperty("optinconfirm")]        
        public string Optinconfirm { get; set; }

        [JsonProperty("p_admin")]        
        public string PAdmin { get; set; }

        [JsonProperty("pg_list_add")]        
        public string PgListAdd { get; set; }

        [JsonProperty("pg_list_edit")]        
        public string PgListEdit { get; set; }

        [JsonProperty("pg_list_delete")]        
        public string PgListDelete { get; set; }

        [JsonProperty("pg_list_headers")]        
        public string PgListHeaders { get; set; }

        [JsonProperty("pg_list_emailaccount")]        
        public string PgListEmailaccount { get; set; }

        [JsonProperty("pg_list_bounce")]        
        public string PgListBounce { get; set; }

        [JsonProperty("pg_message_add")]        
        public string PgMessageAdd { get; set; }

        [JsonProperty("pg_message_edit")]        
        public string PgMessageEdit { get; set; }

        [JsonProperty("pg_message_delete")]        
        public string PgMessageDelete { get; set; }

        [JsonProperty("pg_message_send")]        
        public string PgMessageSend { get; set; }

        [JsonProperty("pg_subscriber_add")]        
        public string PgSubscriberAdd { get; set; }

        [JsonProperty("pg_subscriber_edit")]        
        public string PgSubscriberEdit { get; set; }

        [JsonProperty("pg_subscriber_delete")]        
        public string PgSubscriberDelete { get; set; }

        [JsonProperty("pg_subscriber_merge")]        
        public string PgSubscriberMerge { get; set; }

        [JsonProperty("pg_subscriber_import")]        
        public string PgSubscriberImport { get; set; }

        [JsonProperty("pg_subscriber_approve")]        
        public string PgSubscriberApprove { get; set; }

        [JsonProperty("pg_subscriber_export")]        
        public string PgSubscriberExport { get; set; }

        [JsonProperty("pg_subscriber_sync")]        
        public string PgSubscriberSync { get; set; }

        [JsonProperty("pg_subscriber_filters")]        
        public string PgSubscriberFilters { get; set; }

        [JsonProperty("pg_subscriber_actions")]        
        public string PgSubscriberActions { get; set; }

        [JsonProperty("pg_subscriber_fields")]        
        public string PgSubscriberFields { get; set; }

        [JsonProperty("pg_user_add")]        
        public string PgUserAdd { get; set; }

        [JsonProperty("pg_user_edit")]        
        public string PgUserEdit { get; set; }

        [JsonProperty("pg_user_delete")]        
        public string PgUserDelete { get; set; }

        [JsonProperty("pg_group_add")]        
        public string PgGroupAdd { get; set; }

        [JsonProperty("pg_group_edit")]        
        public string PgGroupEdit { get; set; }

        [JsonProperty("pg_group_delete")]        
        public string PgGroupDelete { get; set; }

        [JsonProperty("pg_template_add")]        
        public string PgTemplateAdd { get; set; }

        [JsonProperty("pg_template_edit")]        
        public string PgTemplateEdit { get; set; }

        [JsonProperty("pg_template_delete")]        
        public string PgTemplateDelete { get; set; }

        [JsonProperty("pg_personalization_add")]        
        public string PgPersonalizationAdd { get; set; }

        [JsonProperty("pg_personalization_edit")]        
        public string PgPersonalizationEdit { get; set; }

        [JsonProperty("pg_personalization_delete")]        
        public string PgPersonalizationDelete { get; set; }

        [JsonProperty("pg_automation_manage")]        
        public string PgAutomationManage { get; set; }

        [JsonProperty("pg_form_edit")]        
        public string PgFormEdit { get; set; }

        [JsonProperty("pg_reports_campaign")]        
        public string PgReportsCampaign { get; set; }

        [JsonProperty("pg_reports_list")]        
        public string PgReportsList { get; set; }

        [JsonProperty("pg_reports_user")]        
        public string PgReportsUser { get; set; }

        [JsonProperty("pg_reports_trend")]        
        public string PgReportsTrend { get; set; }

        [JsonProperty("pg_reports_deal")]        
        public string PgReportsDeal { get; set; }

        [JsonProperty("pg_startup_reports")]        
        public string PgStartupReports { get; set; }

        [JsonProperty("pg_startup_gettingstarted")]        
        public string PgStartupGettingstarted { get; set; }

        [JsonProperty("pg_account_add")]        
        public string PgAccountAdd { get; set; }

        [JsonProperty("pg_account_edit")]        
        public string PgAccountEdit { get; set; }

        [JsonProperty("pg_account_delete")]        
        public string PgAccountDelete { get; set; }

        [JsonProperty("pg_account_manage_custom_field")]        
        public string PgAccountManageCustomField { get; set; }

        [JsonProperty("pg_deal")]        
        public string PgDeal { get; set; }

        [JsonProperty("pg_deal_delete")]        
        public string PgDealDelete { get; set; }

        [JsonProperty("pg_deal_reassign")]        
        public string PgDealReassign { get; set; }

        [JsonProperty("pg_deal_fields")]        
        public string PgDealFields { get; set; }

        [JsonProperty("pg_dealgroup_add")]        
        public string PgDealgroupAdd { get; set; }

        [JsonProperty("pg_dealgroup_edit")]        
        public string PgDealgroupEdit { get; set; }

        [JsonProperty("pg_dealgroup_delete")]        
        public string PgDealgroupDelete { get; set; }

        [JsonProperty("pg_saved_responses_manage")]        
        public string PgSavedResponsesManage { get; set; }

        [JsonProperty("sdate")]
        public DateTimeOffset Sdate { get; set; }

        [JsonProperty("req_approval")]        
        public string ReqApproval { get; set; }

        [JsonProperty("req_approval_1st")]        
        public string ReqApproval1St { get; set; }

        [JsonProperty("req_approval_notify")]
        public string ReqApprovalNotify { get; set; }

        [JsonProperty("socialdata")]        
        public string Socialdata { get; set; }

        [JsonProperty("pg_mfa_admin")]        
        public string PgMfaAdmin { get; set; }

        [JsonProperty("pg_deal_export")]        
        public string PgDealExport { get; set; }

        [JsonProperty("pg_deal_manage_roles")]        
        public string PgDealManageRoles { get; set; }

        [JsonProperty("listid")]        
        public string Listid { get; set; }

        [JsonProperty("groupid")]        
        public string Groupid { get; set; }

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
    }
}