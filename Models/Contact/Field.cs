using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ActiveCampaign.Net.Models.Contact
{
    public class Field
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("descript")]
        public string Descript { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("isrequired")]
        public int Isrequired { get; set; }

        [JsonProperty("perstag")]
        public string Perstag { get; set; }

        [JsonProperty("defval")]
        public string Defval { get; set; }

        [JsonProperty("show_in_list")]
        private string _ShowInList { get; set; }

        [JsonIgnore]
        public bool ShowInList
        {
            get { return _ShowInList != "0"; }
            set { _ShowInList = value ? "1" : "0"; }
        }


        [JsonProperty("rows")]
        public int Rows { get; set; }

        [JsonProperty("cols")]
        public int Cols { get; set; }

        [JsonProperty("visible")]
        private string _visible { get; set; }

        [JsonIgnore]
        public bool IsVisible
        {
            get { return _visible != "0"; }
            set { _visible = value ? "1" : "0"; }
        }


        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("ordernum")]
        public int Ordernum { get; set; }

        [JsonProperty("cdate")]
        public string Cdate { get; set; }

        [JsonProperty("udate")]
        public string Udate { get; set; }

        [JsonProperty("val")]
        public string Val { get; set; }

        [JsonProperty("relid")]
        public int Relid { get; set; }

        [JsonProperty("dataid")]
        public int Dataid { get; set; }

        [JsonProperty("element")]
        public string Element { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }

        [JsonProperty("selected")]
        private string _selected { get; set; }

        [JsonIgnore]
        public bool IsSelected
        {
            get { return _selected != "0"; }
            set { _selected = value ? "1" : "0"; }
        }
        
        [JsonProperty("tag")]
        public string Tag { get; set; }
    }

}