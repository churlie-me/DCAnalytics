﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalytics
{
    public class TemplateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Template);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(Template))
            {
                JObject obj = serializer.Deserialize<JToken>(reader) as JObject;
                if (obj != null)
                {
                    var template = new Template();
                    template.ReadJson(obj);
                    return template;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }

        public override bool CanWrite { get { return false; } }

    }
}