using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaign.Net.Custom
{
    public class CustomJsonDateConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value != null && reader.Value.ToString().StartsWith("0000")) return null;
            else return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
